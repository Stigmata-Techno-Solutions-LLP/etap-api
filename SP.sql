
CREATE     FUNCTION fn_GetDispStructureName(@site_disp_id int)

 RETURNS VARCHAR(2000)
AS BEGIN
	DECLARE @structureName varchar(2000)

	SELECT @structureName = COALESCE(@structureName + ',','') + Name
	FROM structures 
	where id in (select  structure_id from project_structure where id in  (select drs.proj_struct_id
	from disp_req_structure drs
	where drs.dispreq_id in ( @site_disp_id)))
	RETURN @structureName
END

CREATE  FUNCTION fn_GetReqStructureName(@site_req_id int)

 RETURNS VARCHAR(2000)
AS BEGIN
	DECLARE @structureName varchar(2000)

	SELECT @structureName = COALESCE(@structureName + ',','') + Name
	FROM structures
	where id in (select srs.struct_id
	from site_req_structure srs
	where srs.site_req_id in ( @site_req_id))
	RETURN @structureName
END





CREATE   PROCEDURE sp_ApprovalDeclaration(@decl_id int,
	@role_name varchar(50),
	@role_hierarchy int  null,
	@updated_by int null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)


	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION')
		SET @new_status= (select top 1
			new_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION')

	END 
ELSE 
BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')
		SET @new_status= (select top 1
			new_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')

	END

	IF  EXISTS (select *
	from site_declaration sd
	where   Id = @decl_id and status_internal in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN
		IF @role_name in ('EHS','QA','TWCC')
		BEGIN
			update site_declaration  set status_internal = @new_status, status =@new_status, role_id =@role_id,updated_by =@updated_by where  id =@decl_id
			insert into sitedecl_status_history
				(sitedec_id ,notes ,status ,status_internal ,role_id ,updated_at,updated_by )
			select id, notes, status , status_internal , @role_id , getdate(), @updated_by
			from site_declaration sr
			where id = @decl_id
			IF @role_name in ('TWCC')
		BEGIN
				update project_structure set current_status ='READYTOREUSE' where id = (select proj_struct_id
				from site_declaration
				where id =@decl_id)
			END
		END 
	ELSE 
	BEGIN
			select 'NOT ALLOWED'

		END
	END
	
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
	END

END



CREATE   PROCEDURE sp_ApprovalRequirement(@req_id int,
	@role_name varchar(50),
	@role_hierarchy int  null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)


	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='REQUIREMENT')
		SET @new_status= (select top 1
			new_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='REQUIREMENT')

	END 
ELSE 
BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='REQUIREMENT')
		SET @new_status= (select top 1
			new_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='REQUIREMENT')

	END
	--if parallel approval condition either cmpc/twcc approved, then 2nd one apprval moves to READYTODIPATCH
	if EXISTS (select id
	from site_requirement
	where id = @req_id and status_internal  in ('CMPCAPPROVED','TWCCAPPROVED'))
	BEGIN
		SET @new_status = 'READYTODISPATCH'
		print @new_status
	END
	--select @cond_status,@new_status
	if  EXISTS (select *
	from site_requirement
	where   Id = @req_id and status_internal in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN

		update site_requirement  set status_internal = @new_status, status =@new_status, role_id =@role_id where  id =@req_id
		update site_req_structure set status = @new_status where site_req_id = @req_id

		insert into sitereq_status_history
			(mr_no,sitereq_id ,status ,status_internal ,role_id ,updated_at )
		select mr_no, id, status , status_internal , @role_id , getdate()
		from site_requirement sr
		where id = @req_id

	END
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
	END
END


CREATE      PROCEDURE sp_ApprovalScrap(@scrap_structure_id int,
	@role_name varchar(50),
	@role_hierarchy int  null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)


	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='SCRAP')
		SET @new_status= (select top 1
			new_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='SCRAP')

	END 
ELSE 
BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='SCRAP')
		SET @new_status= (select top 1
			new_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='SCRAP')

	END

	--select @cond_status,@new_status
	if  EXISTS (select *
	from scrap_structure 
	where   Id = @scrap_structure_id and status in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN

		update scrap_structure  set status =@new_status, role_id =@role_id where  id =@scrap_structure_id

		insert into scrap_status_history 
			(scrap_stuctre_id ,status  ,role_id ,updated_at )
		select id, status  , @role_id , getdate()
		from scrap_structure sr
		where id = @scrap_structure_id
		if (@role_name = 'TWCC' )
		BEGIN
		update project_structure set current_status =@new_status where id = (select proj_struct_id
			from scrap_structure 
			where id =@scrap_structure_id)
		END	
	END
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
	END
END



CREATE       PROCEDURE sp_getDeclaration(
	@role_name varchar(50),
	@role_hierarchy int  null)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @view_status varchar (500)

	--select @cond_status
	if (@role_hierarchy is null)
		BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION')
		SET @view_status= (select top 1
			view_details_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION')
	END 
	ELSE 
	BEGIN
		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION' and role_hierarchy  = @role_hierarchy)
		SET @view_status= (select top 1
			view_details_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION' and role_hierarchy  = @role_hierarchy)

	END


	select '1' as 'isAction', pp.name ProjectName, pp.proj_code ProjectCode, sitereq_id as SiteReqId, sd.Id as Id, sd.proj_struct_id as ProjStructId, s2.name as StructureName, ps.struct_code StructureCode, ps.structure_attributes_val as StructureAttributeValue, st.name as StructureTypeName, surplus_fromdate as SurplusDate, status as Status, status_internal as StatusInternal, sd.created_at as CreatedAt, sd.updated_at as UpdatedAt
	into #resultset1
	from site_declaration as sd inner join project_structure ps on sd.proj_struct_id =ps.id inner join structures s2 on  ps.structure_id  = s2.id inner join project pp on pp.id =sd.from_project_id inner join structure_type st on s2.structure_type_id  = st.id
	where status_internal  in (select value
	from STRING_SPLIT(@cond_status,',') )

	select '0' as 'isAction', pp.name ProjectName, pp.proj_code ProjectCode, sitereq_id as SiteReqId, sd.Id as Id, sd.proj_struct_id as ProjStructId, s2.name as StructureName, ps.struct_code StructureCode,ps.structure_attributes_val as StructureAttributeValue, st.name  as StructureTypeName, surplus_fromdate as SurplusDate, status as Status, status_internal as StatusInternal, sd.created_at as CreatedAt, sd.updated_at as UpdatedAt
	into #resultset2
	from site_declaration as sd inner join project_structure ps on sd.proj_struct_id =ps.id inner join structures s2 on  ps.structure_id  = s2.id inner join project pp on pp.id =sd.from_project_id inner join structure_type st on s2.structure_type_id  = st.id
	where status_internal  in (select value
	from STRING_SPLIT(@view_status,',') )

			select *
		from #resultset1
	union all
		select *
		from #resultset2

END



CREATE      PROCEDURE sp_getDispatch( @role_name varchar(50),@role_hierarchy int  null,@project_id int null, @vendor_id int null)
AS
BEGIN
	
	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	declare @view_status varchar (500)
		declare @service_type varchar (500)


	--select @cond_status
	if (@role_hierarchy is null)
	BEGIN 
		
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name  and scenario_type ='DISPATCH')
		SET @view_status= (select top 1 view_details_status from role_hierarchy where role_name =@role_name  and scenario_type ='DISPATCH')
				SET @service_type= (select top 1 service_type from role_hierarchy where role_name =@role_name  and scenario_type ='DISPATCH')

END 
ELSE 
BEGIN 
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name  and scenario_type ='DISPATCH'  and role_hierarchy  = @role_hierarchy)
	SET @view_status= (select top 1 view_details_status from role_hierarchy where role_name =@role_name  and scenario_type ='DISPATCH'  and role_hierarchy  = @role_hierarchy)
	SET @service_type= (select top 1 service_type from role_hierarchy where role_name =@role_name  and scenario_type ='DISPATCH'  and role_hierarchy  = @role_hierarchy)
	
	END

print @cond_status
SELECT '0' as 'isAction', sr.mr_no as MRNo, dr.dispatch_no as DispatchNo, dr.status as Status, 
		dr.status_internal as StatusInternal, dr.created_at as CreatedDateTime,
		dr.id as DispatchId, sr.id as SiteRequestId, 
		st.name as ServiceType, dr.servicetype_id as ServiceTypeId, 
		0 as SubContractorId, '' as SubContractorName,
		dr.to_projectid as ToProjectId,
		(select  name from project where id = dr.to_projectid) as ToProjectName,
		
		dr.to_projectid as FromProjectId,
		0 as DispatchRequestSubContractorId,
			(select  ETapManagementSIT.dbo.fn_GetDispStructureName(dr.id)) as StructureName
		into #resultset1 
		FROM dispatch_requirement dr
		INNER JOIN site_requirement sr ON sr.id = dr.sitereq_id
		INNER JOIN service_type st ON st.id  =dr.servicetype_id 
		where dr.status_internal  in (select value from STRING_SPLIT(@view_status,',') )
		and dr.servicetype_id in (select value from STRING_SPLIT(@service_type,',') )

		--SELECT '1' as 'isAction', sr.mr_no as MRNo, dr.dispatch_no as DispatchNo, dr.status as Status, 
		--dr.status_internal as StatusInternal, dr.created_at as CreatedDateTime, 
		--dr.id as DispatchId, sr.id as SiteRequestId, 
		--st.name as ServiceType, dr.servicetype_id as ServiceTypeId, 
		--drs.subcon_id as SubContractorId, sc.name as SubContractorName,
		--drs.id as DispatchRequestSubContractorId,
		--dr.to_projectid as ToProjectId,
		--dr.to_projectid as FromProjectId,
		--(select  ETapManagementSIT.dbo.fn_GetDispStructureName(dr.id)) as StructureName
		--into #resultset2
		--FROM dispatch_requirement dr
		--INNER JOIN site_requirement sr ON sr.id = dr.sitereq_id
		--INNER JOIN service_type st ON st.id  =dr.servicetype_id 
		--LEFT OUTER JOIN dispatchreq_subcont drs ON   dr.id = drs.dispreq_id
		--INNER JOIN sub_contractor sc ON sc.id  = drs.subcon_id 
		--where dr.status_internal  in (select value from STRING_SPLIT(@view_status,',') )
		--and dr.servicetype_id in (select value from STRING_SPLIT(@service_type,',') )
		
	--	    select * from #resultset1 union all 
	-- select * from #resultset2
	-- if (@project_id is not null)
	-- BEGIN
	--	 print 1
	--	   select * from #resultset1 where ToProjectId = @project_id  union all 
	-- select * from #resultset2 where ToProjectId = @project_id
		 
	-- END
	-- else  if (@vendor_id is not null)
	--BEGIN 
	--	print 2
	--		   select * from #resultset1 where SubContractorId = @vendor_id  union all 
	-- select * from #resultset2 where SubContractorId = @vendor_id
	--END
	--else 
	--BEGIN
	--	print 3
	--	  select * from #resultset1 union all 
	-- select * from #resultset2
	--END
		
	 select * from #resultset1 
	 	
END




CREATE       PROCEDURE SP_GetDispatchDetailsForDelivery(@ProjectId int)
AS
BEGIN
SELECT dr.id as DispatchRequirementId, dr.dispatch_no AS DispatchNumber, 
	   p.name AS ProjectName, p.id AS ProjectId, s.name AS StructureName,
	   ps.Id as ProjectStructId,
	    dr.status_internal as DispReqInternalStatus, dr.status as DispReqStatus ,drs.disp_struct_status as DispStructStatus, 
	   ps.struct_code AS ProjectStructureCode, ps.structure_attributes_val AS StructureAttributesValue, 
	   ps.components_count AS ComponentsCount, drs.id AS DispatchStructureId,
	   drs.is_modification as isModification,
	   (SELECT COUNT(1) FROM disp_structure_comp dsc WHERE disp_structure_id = drs.id and dsc.from_scandate  is not null) AS CountEarned
	   FROM dispatch_requirement dr 
			  INNER JOIN disp_req_structure drs ON drs.dispreq_id = dr.id
			  INNER JOIN project_structure ps  ON ps.id = drs.proj_struct_id
			  INNER JOIN project p ON p.id  = dr.to_projectid
			  INNER JOIN structures s ON s.id = ps.structure_id
	  WHERE drs.from_project_id = @ProjectId  
	  and ps.components_count > (SELECT COUNT(*) FROM disp_structure_comp dsc WHERE disp_structure_id = drs.id and dsc.from_scandate  is not null)
		   and drs.disp_struct_status in ('READYTODELIVER','TWCCMODIFYAPRD')

END	



  
  CREATE   PROCEDURE SP_GetReceiveComponentDetails(@DispatchStrutureId int)
AS
BEGIN
SELECT c.comp_name AS ComponentName, c.comp_id AS ComponentId, dsc.disp_structure_id AS DispatchStructureId, 
			dsc.last_scandate AS LastScanDate, dsc.comp_status AS ComponentStatus, dsc.remarks As Remarks,
			dsc.scanned_by AS ScannedBy,dsc.from_scandate as FromScanDate, dsc.dispatch_date as DispatchDate, dsc.id AS DispatchStructureComponentId, dsc.disp_comp_id AS DispatchComponentId
		FROM disp_structure_comp dsc 
			INNER JOIN component c ON c.id = dsc.disp_comp_id 
		WHERE dsc.disp_structure_id  = @DispatchStrutureId
END




CREATE    PROCEDURE SP_GetReceiveDetails(@ProjectId int)
AS
BEGIN
SELECT dr.id as DispatchRequirementId, dr.dispatch_no AS DispatchNumber, 
	   p.name AS ProjectName, p.id AS ProjectId, s.name AS StructureName,
	   ps.Id as ProjectStructId,
	   dr.status_internal as DispReqInternalStatus, dr.status as DispReqStatus ,drs.disp_struct_status as DispStructStatus, 
	   ps.struct_code AS ProjectStructureCode, ps.structure_attributes_val AS StructureAttributesValue, 
	   ps.components_count AS ComponentsCount, drs.id AS DispatchStructureId,
	   dr.servicetype_id as ServiceTypeId, (select top 1 name from service_type st where id =dr.servicetype_id ) as ServcieTypeName,
	   drs.is_modification as isModification,
	   (SELECT COUNT(1) FROM disp_structure_comp dsc WHERE disp_structure_id = drs.id) AS CountEarned
	   FROM dispatch_requirement dr 
			  INNER JOIN disp_req_structure drs ON drs.dispreq_id = dr.id
			  INNER JOIN project_structure ps  ON ps.id = drs.proj_struct_id
			  INNER JOIN project p ON p.id  = dr.to_projectid
			  INNER JOIN structures s ON s.id = ps.structure_id
	  WHERE dr.to_projectid = @ProjectId
END	





CREATE     PROCEDURE sp_GetRequirement(
	@role_name varchar(50),
	@role_hierarchy int  null)
AS
BEGIN

	declare @role_id int
	DECLARE @structureName varchar(2000)
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	--select @cond_status
	if (@role_hierarchy is null)
	BEGIN
		print 's'
		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type='REQUIREMENT')
	END 
ELSE 
BEGIN
		print 'ss'
		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type='REQUIREMENT')

	END

	--get list, rolename based assigned status
	--isAction (1) means allow to do actions
	select 1 as 'isAction', mr_no as MrNo, sr.Id, from_project_id as ProjectId, remarks as Remarks, status as Status, status_internal as StatusInternal, role_id as RoleId , (select ETapManagementSIT.dbo.fn_GetReqStructureName(sr.id)) as StructureName, p.name as ProjectName, p.proj_code  as ProjectCode, sr.created_at as CreatedDate
	into #resultset1
	from site_requirement sr inner join project p on p.id  = sr.from_project_id
	where status_internal  in (select value
	from STRING_SPLIT(@cond_status,',') )
	order by sr.created_at,sr.updated_at  desc


	--get requirement id list for existing update in status history for this role id based on latest updated date
	SELECT sitereq_id
	INTO #distSiteReqId
	FROM (
  SELECT sitereq_id, updated_at, ROW_NUMBER() OVER (PARTITION BY sitereq_id ORDER BY updated_at desc) RN
		FROM sitereq_status_history
		where role_id = @role_id and sitereq_id  not in (select id
			from #resultset1)) S
	where RN =1

	--isAction (0) means should not to do actions
	select 0 as 'isAction', mr_no as MrNo, sr.Id, from_project_id as ProjectId, remarks as Remarks, status as Status, status_internal as StatusInternal, role_id as RoleId, (select ETapManagementSIT.dbo.fn_GetReqStructureName(sr.id)) as StructureName, p.name as ProjectName, p.proj_code as ProjectCode, sr.created_at as CreatedDate
	into #resultset2
	from site_requirement sr inner join project p on p.id  = sr.from_project_id
	where sr.id  in (select sitereq_id
	from #distSiteReqId)
	order by sr.created_at,sr.updated_at  desc

			(
		select *
		from #resultset1
	union all
		select *
		from #resultset2)
	order by MrNo desc

END




CREATE    PROCEDURE sp_GetScrapDetails(
	@role_name varchar(50),
	@role_hierarchy int  null)
AS
BEGIN

	declare @role_id int
	DECLARE @structureName varchar(2000)
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name  )
	declare @cond_status varchar (500)
	--select @cond_status
	if (@role_hierarchy is null)
	BEGIN
		print 's'
		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name  and scenario_type='SCRAP')
	END 
ELSE 
BEGIN
		print 'ss'
		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type='SCRAP')

	END

	

  
	
	--get list, rolename based assigned status
	--isAction (1) means allow to do actions
	select 1 as 'isAction', ss.Id, from_project_id as FromProjectId, proj_struct_id as ProjStructId, disp_structure_id as DispStructId, status as Status, role_id as RoleId , (select name from structures s2 where id  in (select structure_id from project_structure ps  where id =ss.proj_struct_id  )) as StructureName, p.name as FromProjectName, p.proj_code  as ProjectCode, ss.created_at as CreatedDate
	into #resultset1
	from scrap_structure ss  inner join project p on p.id  = ss.from_project_id
	where status  in (select value
	from STRING_SPLIT(@cond_status,',') )
	order by ss.created_at,ss.updated_at  desc

 
	--get requirement id list for existing update in status history for this role id based on latest updated date
	SELECT scrap_stuctre_id
	INTO #distSiteReqId
	FROM (
  SELECT scrap_stuctre_id, updated_at, ROW_NUMBER() OVER (PARTITION BY scrap_stuctre_id ORDER BY updated_at desc) RN
		FROM scrap_status_history ssh 
		where role_id = @role_id and scrap_stuctre_id  not in (select id
			from #resultset1)) S
	where RN =1

	--isAction (0) means should not to do actions
	select 0 as 'isAction', ss.Id, from_project_id as FromProjectId, proj_struct_id, disp_structure_id, status as Status, role_id as RoleId , (select name from structures s2 where id  in (select structure_id from project_structure ps  where id =ss.proj_struct_id  )) as StructureName, p.name as FromProjectName, p.proj_code  as ProjectCode, ss.created_at as CreatedDate
	into #resultset2
	from scrap_structure ss inner join project p on p.id  = ss.from_project_id
	where ss.id  in (select scrap_stuctre_id
	from #distSiteReqId)
	order by ss.created_at,ss.updated_at  desc

			(
		select *
		from #resultset1
	union all
		select *
		from #resultset2)
	order by Id desc
 
END



CREATE PROCEDURE SP_GetSiteRequirement(@SiteRequirementId int)
 AS
 BEGIN

 SELECT site_req_id AS SiteRequirementId, struct_id AS StructureId, structure_attributes_val AS StrutureAttributes,
		plan_startdate AS PlanStartDate, plan_releasedate AS PlanEndDate, quantity AS Quantity
		FROM site_req_structure WHERE site_req_id = @SiteRequirementId
 END




	CREATE   PROCEDURE SP_GetSubContractorComponentDetails(@DispatchStructureId int)
AS
BEGIN

SELECT dsc.dispatch_date as DispatchDate, DSC.id AS DispStructureComponentId, C.comp_name AS ComponentName, CT.name AS ComponentType, C.comp_id AS ComponentId, C.drawing_no AS DrawingNumber   
				FROM disp_structure_comp DSC INNER JOIN 
				component C ON C.id = DSC.disp_comp_id INNER JOIN 
				component_type CT ON CT.id = C.comp_type_id
				WHERE DSC.disp_structure_id = @DispatchStructureId 
END





CREATE    PROCEDURE SP_GetSubContractorDetails(@VendorId int)
AS
BEGIN
SELECT DRS.id AS DispSubContractorId, DSS.id AS DispSubContractorStructureId, DRS.dispatch_no AS DCNumber, PS.struct_code AS StructureCode, S.name AS StructureName, 
		DRS.quantity AS Quantity, PS.structure_attributes_val AS StructureAttributesValue, 
		PS.components_count AS ComponentCount,
		DSS.disp_structure_id AS DispStructureId,
		PS.id AS ProjectStructureId 
		into #resultset1 
			  FROM dispatchreq_subcont DRS INNER JOIN 
			  disp_subcont_structure DSS ON DSS.dispreqsubcont_id = DRS.id INNER JOIN
			  project_structure PS ON PS.id = DSS.proj_struct_id INNER JOIN 
			  structures S ON S.id = PS.structure_id LEFT OUTER JOIN
			  disp_req_structure DRSS ON DRSS.id = DRS.dispreq_id
			  WHERE DRS.subcon_id = @VendorId AND PS.components_count > (SELECT COUNT(id) FROM disp_structure_comp WHERE disp_structure_id = DSS.disp_structure_id and dispatch_date is not null)
			  and DRS.servicetype_id in (1,2) 
			
			  
			  SELECT DRS.id AS DispSubContractorId, DSS.id AS DispSubContractorStructureId, DRS.dispatch_no AS DCNumber, PS.struct_code AS StructureCode, S.name AS StructureName, 
		DRS.quantity AS Quantity, PS.structure_attributes_val AS StructureAttributesValue, 
		PS.components_count AS ComponentCount,
		DSS.disp_structure_id AS DispStructureId,
		PS.id AS ProjectStructureId 
		into #resultset2
			  FROM dispatchreq_subcont DRS INNER JOIN 
			  disp_subcont_structure DSS ON DSS.dispreqsubcont_id = DRS.id INNER JOIN
			  project_structure PS ON PS.id = DSS.proj_struct_id INNER JOIN 
			  structures S ON S.id = PS.structure_id LEFT OUTER JOIN
			  disp_req_structure DRSS ON DRSS.id = DRS.dispreq_id
			  WHERE DRS.subcon_id = @VendorId AND PS.components_count > (SELECT COUNT(id) FROM disp_structure_comp WHERE disp_structure_id = DSS.disp_structure_id and dispatch_date is not null)
			  and DRS.servicetype_id in (4) 
			  and DSS.disp_structure_id  in (select disp_structure_id from disp_structure_comp dsc where from_scandate is not  null and disp_structure_id = DSS.disp_structure_id)
			  -- and DSS.disp_structure_id not in (select id from disp_req_structure  where status ='TWCCMODIFYAPRD' and id = DSS.disp_structure_id )

			  
			  select * from #resultset1 union 
			  select * from #resultset2
END





CREATE    PROCEDURE [dbo].[SP_GETTWCCDispatch](@Status varchar(100))
AS
BEGIN

SELECT SR.id AS SiteRequirementId, SR.mr_no AS MRNumber, S.name AS StructureName, 
	   SR.from_project_id AS FromProjectId, U.ps_no AS RaisedBy, P.name AS RequestBy,
	   S.id AS StructureId, SR.status AS RequestStatus, SRS.structure_attributes_val AS StructureAttributes,
	   SRS.quantity AS Quantity, srs.id, SR.created_at AS CreatedAt, SR.updated_at AS UpdatedAt
				FROM site_requirement SR INNER JOIN
				site_req_structure SRS ON SR.id = SRS.site_req_id INNER JOIN
				project P ON P.id = SR.from_project_id INNER JOIN
				structures S ON s.id = SRS.struct_id INNER JOIN
				users U ON U.id = SR.created_by
				WHERE SR.status in (select value from  STRING_SPLIT(@Status,','))
				--and srs.id not in (select site_req_structid from dispatch_requirement dr  )

END



CREATE PROCEDURE SP_GetViewStructureChartDetails(@ProjectStructureId int)
AS
BEGIN
	SELECT ps.components_count as TotalCount, 
		(SELECT COUNT(1) FROM disp_structure_comp dsc WHERE dsc.disp_structure_id = drs.id) as AssignedCount, 
		(SELECT COUNT(1) FROM disp_structure_comp dsc2 WHERE dsc2.disp_structure_id = drs.id AND dispatch_date IS NOT NULL) AS DispatchCount,
		(SELECT COUNT(1) FROM disp_structure_comp dsc2 WHERE dsc2.disp_structure_id = drs.id AND last_scandate IS NOT NULL) AS ScannedCount
		FROM project_structure ps 
		INNER JOIN disp_req_structure drs ON drs.proj_struct_id = ps.id WHERE drs.proj_struct_id = @ProjectStructureId
END


CREATE       PROCEDURE sp_RejectionDeclaration(@decl_id int,
	@role_name varchar(50),
	@role_hierarchy int  NULL,
	@updated_by int null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)

	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where  role_hierarchy  = (select top 1
			role_hierarchy
		from role_hierarchy
		where role_name =@role_name and scenario_type ='DECLARATION') -1)

	END 
ELSE 
BEGIN
		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')

	END
	--select @cond_status 
	--select @new_status

	IF  EXISTS (select *
	from site_declaration sd
	where   Id = @decl_id and status_internal in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN
		IF @role_name in ('EHS','QA','TWCC')
		BEGIN
			update site_declaration  set status_internal = @role_name + 'REJECTED', status =@role_name + 'REJECTED', role_id =@role_id,updated_by =@updated_by where  id = @decl_id
			insert into sitedecl_status_history
				(sitedec_id ,notes ,status ,status_internal ,role_id ,updated_at,updated_by )
			select id, notes, status , status_internal , @role_id , getdate(), @updated_by
			from site_declaration sr
			where id = @decl_id
			update project_structure set current_status ='SCRAPPED', structure_status = 'NOTAVAIL' where id = (select proj_struct_id
			from site_declaration
			where id =@decl_id)
			
			insert into scrap_structure  (proj_struct_id,STATUS,created_at ,created_by ) values ((select proj_struct_id  from site_declaration  where id = @decl_id),'NEW',getdate(),@updated_by) 

		END
		ELSE 
		BEGIN
			select 'NOT ALLOWED'
		END
	END	
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
	END

END



CREATE       PROCEDURE sp_RejectScrap(@scrap_structure_id int,
	@role_name varchar(50),
	@role_hierarchy int  null,
	@disp_structure_id int null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)


	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='SCRAP')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where   scenario_type ='SCRAP' and role_hierarchy  = (select top 1
			role_hierarchy
		from role_hierarchy
		where  scenario_type ='SCRAP' and role_name =@role_name ) -1)

	END 
ELSE 
BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='SCRAP')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where role_hierarchy  = @role_hierarchy and scenario_type ='SCRAP')

	END
	--select @cond_status 

	if  EXISTS (select *
	from scrap_structure 
	where   Id = @scrap_structure_id and status in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN
		update scrap_structure  set status =@new_status , role_id = @role_id where  id =@scrap_structure_id
		insert into scrap_status_history 
			(scrap_stuctre_id ,status  ,role_id ,updated_at )
		select id, status  , @role_id , getdate()
		from scrap_structure sr
		where id = @scrap_structure_id
		
	if (@role_name = 'EHS')
	BEGIN
		update disp_req_structure  set disp_struct_status ='SCRAPREJECTED'   where  id =@disp_structure_id
	END
	END
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
			
	END

END



CREATE      PROCEDURE sp_RejectRequirement(@req_id int,
	@role_name varchar(50),
	@role_hierarchy int  null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)


	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='REQUIREMENT')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where  role_hierarchy  = (select top 1
			role_hierarchy
		from role_hierarchy
		where  scenario_type ='REQUIREMENT' and role_name =@role_name and scenario_type ='REQUIREMENT') -1)

	END 
ELSE 
BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='REQUIREMENT')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where role_hierarchy  = @role_hierarchy and scenario_type ='REQUIREMENT')

	END
	--select @cond_status 
	--select @new_status

	if  EXISTS (select *
	from site_requirement
	where   Id = @req_id and status_internal in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN
		update site_requirement  set status ='REJECTED',status_internal = @new_status , role_id = @role_id where  id =@req_id
		insert into sitereq_status_history
			(mr_no,sitereq_id ,status ,status_internal ,role_id ,updated_at )
		select mr_no, id, status, status_internal , @role_id , getdate()
		from site_requirement sr
		where id = @req_id
	END
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
	END

END





CREATE       PROCEDURE sp_RejectScrap(@scrap_structure_id int,
	@role_name varchar(50),
	@role_hierarchy int  null,
	@disp_structure_id int null
)
AS
BEGIN

	declare @role_id int
	SET @role_id = (select top 1
		id
	from roles
	where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)


	if (@role_hierarchy is null)
	BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and scenario_type ='SCRAP')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where   scenario_type ='SCRAP' and role_hierarchy  = (select top 1
			role_hierarchy
		from role_hierarchy
		where  scenario_type ='SCRAP' and role_name =@role_name ) -1)

	END 
ELSE 
BEGIN

		SET @cond_status= (select top 1
			chk_status
		from role_hierarchy
		where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='SCRAP')
		SET @new_status= (select top 1
			chk_status
		from role_hierarchy
		where role_hierarchy  = @role_hierarchy and scenario_type ='SCRAP')

	END
	--select @cond_status 

	if  EXISTS (select *
	from scrap_structure 
	where   Id = @scrap_structure_id and status in (select value
		from STRING_SPLIT(@cond_status,','))) 
	BEGIN
		update scrap_structure  set status =@new_status , role_id = @role_id where  id =@scrap_structure_id
		insert into scrap_status_history 
			(scrap_stuctre_id ,status  ,role_id ,updated_at )
		select id, status  , @role_id , getdate()
		from scrap_structure sr
		where id = @scrap_structure_id
		
	if (@role_name = 'EHS')
	BEGIN
		update disp_req_structure  set disp_struct_status ='SCRAPREJECTED'   where  id =@disp_structure_id
	END
	END
	ELSE 
	BEGIN
		select 'NOT ALLOWED'
			
	END

END




CREATE   PROCEDURE [dbo].[SP_TWCCInnerStructureDetails](@StructureId int)
AS
BEGIN

SELECT PS.id AS ProjectStructureId, PS.structure_id AS StructureId, PS.struct_code AS StructureCode, PS.project_id AS ProjectId, 
			PS.structure_attributes_val AS ProjectStructureAttributes, 
			PS.current_status AS ProjectCurrentStatus, PS.structure_status AS ProjectStructureStatus,
			SD.surplus_fromdate AS SurplusFromDate, P.name AS ProjectName,SD.from_project_id as SurplusFromProjectId,
			0 AS SiteRequirementId, '' AS SiteRequirementStructureAttributes, NULL AS PlanStartDate, NULL AS PlanReleaseDate, PS.exp_release_date AS ExpReleaseDate
				FROM project_structure PS INNER JOIN 
				project P ON P.id = PS.project_id LEFT OUTER JOIN 
				site_declaration SD ON SD.proj_struct_id = PS.id 
				WHERE PS.structure_id = @StructureId
END
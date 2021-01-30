 CREATE OR ALTER FUNCTION fn_GetReqStructureName(@site_req_id int)

 RETURNS VARCHAR(2000)
AS BEGIN 
	 	 	DECLARE @structureName varchar(2000)

  SELECT @structureName = COALESCE(@structureName + ',','') + Name FROM structures
 where id in (select  srs.struct_id from site_req_structure srs  where srs.site_req_id in ( @site_req_id))
	 RETURN @structureName
	 END
	 


CREATE OR ALTER PROCEDURE sp_GetRequirement( @role_name varchar(50),@role_hierarchy int  null)
AS
BEGIN
	
	declare @role_id int 
	DECLARE @structureName varchar(2000)
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	--select @cond_status
	if (@role_hierarchy is null)
	BEGIN 
		print 's'
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name)
END 
ELSE 
BEGIN 
	print 'ss'
		SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and role_hierarchy  = @role_hierarchy)
	
	END

	--get list, rolename based assigned status
	 --isAction (1) means allow to do actions
 select 1 as 'isAction', mr_no as MrNo, sr.Id, project_id as ProjectId, plan_startdate as PlanStartdate, plan_releasedate as PlanReleasedate,actual_startdate as ActualStartdate, actual_releasedate as ActualReleasedate,  require_wbs_id as RequireWbsId, actual_wbs_id as ActualWbsId, remarks as Remarks, status as Status, status_internal as StatusInternal, role_id as RoleId ,	(select  ETapManagement.dbo.fn_GetReqStructureName(sr.id)) as StructureName,p.name as ProjectName,p.proj_code  as ProjectCode, sr.created_at as CreatedDate into #resultset1 from site_requirement sr inner join project p on p.id  = sr.project_id  where status_internal  in (select value from STRING_SPLIT(@cond_status,',') )

	
 --get requirement id list for existing update in status history for this role id based on latest updated date
  SELECT sitereq_id INTO #distSiteReqId
    FROM (
  SELECT sitereq_id, updated_at, ROW_NUMBER() OVER (PARTITION BY sitereq_id ORDER BY updated_at desc) RN
        FROM sitereq_status_history where role_id = @role_id and sitereq_id  not in (select id from #resultset1)) S where RN =1
        
       --isAction (0) means should not to do actions
	  select 0 as 'isAction', mr_no as MrNo, sr.Id, project_id as ProjectId, plan_startdate as PlanStartdate, plan_releasedate as PlanReleasedate,actual_startdate as ActualStartdate, actual_releasedate as ActualReleasedate,  require_wbs_id as RequireWbsId, actual_wbs_id as ActualWbsId, remarks as Remarks, status as Status, status_internal as StatusInternal, role_id as RoleId,  (select  ETapManagement.dbo.fn_GetReqStructureName(sr.id)) as StructureName, p.name as ProjectName,p.proj_code as ProjectCode, sr.created_at as CreatedDate  into #resultset2 from site_requirement sr  inner join project p on p.id  = sr.project_id  where sr.id  in (select sitereq_id from #distSiteReqId)
	 
	 select * from #resultset1 union all 
	 select * from #resultset2
	 	
END



CREATE OR ALTER PROCEDURE sp_ApprovalRequirement(@req_id int, @role_name varchar(50),@role_hierarchy int  null )
AS
BEGIN

	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)

	
	if (@role_hierarchy is null)
	BEGIN 
		
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name)
	SET @new_status= (select top 1 new_status from role_hierarchy where role_name =@role_name)

	END 
ELSE 
BEGIN 
	
		SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and role_hierarchy  = @role_hierarchy)
		SET @new_status= (select top 1 new_status from role_hierarchy where role_name =@role_name  and role_hierarchy  = @role_hierarchy)

	END
	
	if  EXISTS (select * from  site_requirement where   Id = @req_id and status_internal in (select value from STRING_SPLIT(@cond_status,','))) 
	BEGIN 	
	update site_requirement  set status_internal = @new_status, status =@new_status, role_id =@role_id where  id =@req_id
	insert into sitereq_status_history (mr_no,sitereq_id ,status ,status_internal ,role_id ,updated_at ) select mr_no, id,status ,status_internal ,@role_id ,getdate() from site_requirement sr where id = @req_id 
	END
	ELSE 
	BEGIN 
	select 'NOT ALLOWED'
	END
END



CREATE OR ALTER PROCEDURE sp_RejectRequirement(@req_id int, @role_name varchar(50),@role_hierarchy int  null )
AS
BEGIN

	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)

	
	if (@role_hierarchy is null)
	BEGIN 
		
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name)
	SET @new_status= (select top 1 chk_status from role_hierarchy where  role_hierarchy  = (select top 1 role_hierarchy from role_hierarchy where role_name =@role_name) -1)

	END 
ELSE 
BEGIN 
	
		SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and role_hierarchy  = @role_hierarchy)
		SET @new_status= (select top 1 chk_status from role_hierarchy where role_hierarchy  = @role_hierarchy)

	END
	--select @cond_status 
	--select @new_status
	
	if  EXISTS (select * from  site_requirement where   Id = @req_id and status_internal in (select value from STRING_SPLIT(@cond_status,','))) 
	BEGIN 	
	update site_requirement  set status ='REJECTED',status_internal = @new_status , role_id = @role_id where  id =@req_id
	insert into sitereq_status_history (mr_no,sitereq_id ,status ,status_internal ,role_id ,updated_at ) select mr_no, id,status,status_internal ,@role_id ,getdate() from site_requirement sr where id = @req_id 
	END
	ELSE 
	BEGIN 
	select 'NOT ALLOWED'
	END

END









CREATE OR ALTER PROCEDURE sp_getDeclaration( @role_name varchar(50),@role_hierarchy int  null)
AS
BEGIN
	
	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	declare @view_status varchar (500)

	--select @cond_status
	if (@role_hierarchy is null)
	BEGIN 
		
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name  and scenario_type ='DECLARATION')
		SET @view_status= (select top 1 view_details_status from role_hierarchy where role_name =@role_name  and scenario_type ='DECLARATION')
END 
ELSE 
BEGIN 
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name  and scenario_type ='DECLARATION'  and role_hierarchy  = @role_hierarchy)
	SET @view_status= (select top 1 view_details_status from role_hierarchy where role_name =@role_name  and scenario_type ='DECLARATION'  and role_hierarchy  = @role_hierarchy)
	
	END

	
	 select '0' as 'isAction', sitereq_id as SiteReqId, sd.Id as Id, sd.struct_id as StructureId, s2.name as StructureName, st.name as StructureTypeName,  surplus_fromdate as SurplusDate, status as Status, status_internal as StatusInternal into #resultset1 from site_declaration as sd inner join structures s2  on sd.struct_id  = s2.id  inner join structure_type st  on s2.structure_type_id  = st.id  where status_internal  in (select value from STRING_SPLIT(@cond_status,',') )

	 select '1' as 'isAction', sitereq_id as SiteReqId, sd.Id as Id, sd.struct_id as StructureId, s2.name as StructureName, st.name  as StructureTypeName, surplus_fromdate as SurplusDate, status as Status, status_internal as StatusInternal into #resultset2 from site_declaration sd inner join structures s2 on  sd.struct_id  = s2.id  inner join structure_type st on s2.structure_type_id  = st.id   where status_internal  in (select value from STRING_SPLIT(@view_status,',') )

	 select * from #resultset1 union all 
	 select * from #resultset2
	 	
END




CREATE OR ALTER PROCEDURE sp_ApprovalDeclaration(@decl_id int, @role_name varchar(50),@role_hierarchy int  null, @updated_by int null )
AS
BEGIN

	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)

	
	if (@role_hierarchy is null)
	BEGIN 
		
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and scenario_type ='DECLARATION')
	SET @new_status= (select top 1 new_status from role_hierarchy where role_name =@role_name and scenario_type ='DECLARATION')

	END 
ELSE 
BEGIN 
	
		SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')
		SET @new_status= (select top 1 new_status from role_hierarchy where role_name =@role_name  and role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')

	END
	
	IF  EXISTS (select * from  site_declaration sd where   Id = @decl_id and status_internal in (select value from STRING_SPLIT(@cond_status,','))) 
	BEGIN 	
		IF @role_name in ('EHS','QA')
		BEGIN 
	update site_declaration  set status_internal = @new_status, status =@new_status, role_id =@role_id,updated_by =@updated_by where  id =@decl_id
	insert into sitedecl_status_history (sitedec_id ,notes ,status ,status_internal ,role_id ,updated_at,updated_by ) select  id,notes,status ,status_internal ,@role_id ,getdate(), @updated_by from site_declaration sr where id = @decl_id 
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



CREATE OR ALTER PROCEDURE sp_RejectionDeclaration(@decl_id int, @role_name varchar(50),@role_hierarchy int  NULL, @updated_by int null )
AS
BEGIN

	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (500)
	declare @new_status varchar (500)
	
	if (@role_hierarchy is null)
	BEGIN 
		
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and scenario_type ='DECLARATION')
	SET @new_status= (select top 1 chk_status from role_hierarchy where  role_hierarchy  = (select top 1 role_hierarchy from role_hierarchy where role_name =@role_name and scenario_type ='DECLARATION') -1)

	END 
ELSE 
BEGIN 	
		SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')
		SET @new_status= (select top 1 chk_status from role_hierarchy where role_hierarchy  = @role_hierarchy and scenario_type ='DECLARATION')

	END
	--select @cond_status 
	--select @new_status
	
	IF  EXISTS (select * from  site_declaration sd where   Id = @decl_id and status_internal in (select value from STRING_SPLIT(@cond_status,','))) 
	BEGIN 	
		IF @role_name in ('EHS','QA')
		BEGIN 	
			update site_declaration  set status_internal = @role_name + 'REJECTED', status =@role_name + 'REJECTED', role_id =@role_id,updated_by =@updated_by where  id = @decl_id
			insert into sitedecl_status_history (sitedec_id ,notes ,status ,status_internal ,role_id ,updated_at,updated_by ) select  id,notes,status ,status_internal ,@role_id ,getdate(), @updated_by from site_declaration sr where id = @decl_id 
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



CREATE OR ALTER PROCEDURE sp_getDispatch( @role_name varchar(50),@role_hierarchy int  null)
AS
BEGIN
	
	select * from dispatch_requirement dr 
END

        
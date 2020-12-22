
CREATE OR ALTER PROCEDURE sp_GetRequirement( @role_name varchar(50),@role_hierarchy int  null)
AS
BEGIN
	
	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (50)
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

	--select case when status_internal in (@cond_status) then '0' else '1' end 'isAction', * from site_requirement sr where role_id = @roleId and status in (@status)
	--select @cond_status
	
 select '0' as 'isAction', mr_no as MrNo, Id, project_id as ProjectId, plan_startdate as PlanStartdate, plan_releasedate as PlanReleasedate,actual_startdate as ActualStartdate, actual_releasedate as ActualReleasedate,  require_wbs_id as RequireWbsId, actual_wbs_id as ActualWbsId, remarks as Remarks, status as Status, status_internal as StatusInternal, role_id as RoleId    into #resultset1 from site_requirement  where status_internal  in (select value from STRING_SPLIT(@cond_status,',') )

 -- select distinct sitereq_id INTO #distSiteReqId from sitereq_status_history where role_id = @role_id and sitereq_id  not in (select id from #resultset1) order by updated_at  desc
	
 
  SELECT sitereq_id INTO #distSiteReqId
    FROM (
  SELECT sitereq_id, updated_at, ROW_NUMBER() OVER (PARTITION BY sitereq_id ORDER BY updated_at desc) RN
        FROM sitereq_status_history where role_id = @role_id and sitereq_id  not in (select id from #resultset1)) S where RN =1
        
	  select '1' as 'isAction', mr_no as MrNo, Id, project_id as ProjectId, plan_startdate as PlanStartdate, plan_releasedate as PlanReleasedate,actual_startdate as ActualStartdate, actual_releasedate as ActualReleasedate,  require_wbs_id as RequireWbsId, actual_wbs_id as ActualWbsId, remarks as Remarks, status as Status, status_internal as StatusInternal, role_id as RoleId   into #resultset2 from site_requirement sr where id  in (select sitereq_id from #distSiteReqId)
	 
	 select * from #resultset1 union all 
	 select * from #resultset2
	 	
END





CREATE OR ALTER PROCEDURE sp_ApprovalRequirement(@req_id int, @role_name varchar(50),@role_hierarchy int  null )
AS
BEGIN

	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (50)
	declare @new_status varchar (50)

	
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
	declare @cond_status varchar (50)
	declare @new_status varchar (50)

	
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
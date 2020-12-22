

 IF OBJECT_ID('ETapManagement.dbo.component_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component_history ; 

 IF OBJECT_ID('ETapManagement.dbo.component', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component; 
 IF OBJECT_ID('ETapManagement.dbo.project_structure_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project_structure_documents; 
 
 
 IF OBJECT_ID('ETapManagement.dbo.disp_subcont_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_subcont_structure; 
 
  
 IF OBJECT_ID('ETapManagement.dbo.dispatchreq_subcont', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.dispatchreq_subcont; 
 
  
 IF OBJECT_ID('ETapManagement.dbo.disp_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_req_structure; 
  
 IF OBJECT_ID('ETapManagement.dbo.dispatch_requirement', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.dispatch_requirement; 

 
 IF OBJECT_ID('ETapManagement.dbo.sitedecl_status_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.sitedecl_status_history; 
 
 IF OBJECT_ID('ETapManagement.dbo.site_declaration', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.site_declaration; 
 
 
   
 IF OBJECT_ID('ETapManagement.dbo.sitereq_status_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.sitereq_status_history; 
 
 IF OBJECT_ID('ETapManagement.dbo.site_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.site_req_structure; 
 
 
 IF OBJECT_ID('ETapManagement.dbo.site_requirement', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.site_requirement; 


 

 
 
 
 IF OBJECT_ID('ETapManagement.dbo.scrap_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.scrap_structure; 

 
 
 
 IF OBJECT_ID('ETapManagement.dbo.project_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project_structure; 
 
 IF OBJECT_ID('ETapManagement.dbo.work_breakdown', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.work_breakdown; 
 
 
IF OBJECT_ID('ETapManagement.dbo.users', 'U') IS NOT NULL 
DROP TABLE ETapManagement.dbo.users; 
 
  IF OBJECT_ID('ETapManagement.dbo.project_sitelocation', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project_sitelocation ; 
 
  IF OBJECT_ID('ETapManagement.dbo.project', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project; 
 
  
 
 IF OBJECT_ID('ETapManagement.dbo.structures_attributes', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.structures_attributes; 
 
 IF OBJECT_ID('ETapManagement.dbo.structures', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.structures; 

IF OBJECT_ID('ETapManagement.dbo.audit_logs', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.audit_logs; 
 
IF OBJECT_ID('ETapManagement.dbo.roles_applicationforms', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.roles_applicationforms; 

 
 

IF OBJECT_ID('ETapManagement.dbo.application_forms', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.application_forms; 
 
 
 IF OBJECT_ID('ETapManagement.dbo.businessUnit_IC', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.businessUnit_IC ; 
 IF OBJECT_ID('ETapManagement.dbo.business_unit', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.business_unit ;  
 
 IF OBJECT_ID('ETapManagement.dbo.independent_company', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.independent_company; 

 IF OBJECT_ID('ETapManagement.dbo.structure_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.structure_type; 

 
 IF OBJECT_ID('ETapManagement.dbo.component_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component_type; 

 
 
IF OBJECT_ID('ETapManagement.dbo.subContractor_serviceType', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.subContractor_serviceType; 
  
 IF OBJECT_ID('ETapManagement.dbo.service_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.service_type; 
 
IF OBJECT_ID('ETapManagement.dbo.segment', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.segment; 
  
IF OBJECT_ID('ETapManagement.dbo.sub_contractor', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.sub_contractor; 

 
IF OBJECT_ID('ETapManagement.dbo.roles', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.roles; 
 IF OBJECT_ID('ETapManagement.dbo.role_hierarchy', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.roles; 
 

 
 
CREATE TABLE ETapManagement.dbo.roles (
  id int NOT NULL IDENTITY (1,1),
  "name" varchar(30) NOT NULL,
  "description" varchar(300) NULL, 
  "level" int NULL, 
  CONSTRAINT site_roles_name_key UNIQUE (name),
  CONSTRAINT site_roles_pkey PRIMARY KEY (id)
);



CREATE TABLE ETapManagement.dbo.application_forms (
  id int NOT NULL IDENTITY (1,1),
  "name" varchar(30) NOT NULL,
  "description" varchar(300) NULL, 
  "isAdd" bit NULL,
  "isUpdate" bit NULL,
  "isDelete" bit NULL,  
  "isView" bit NULL,    
  CONSTRAINT application_forms_name_key UNIQUE (name),
  CONSTRAINT page_pkey PRIMARY KEY (id),  
);



CREATE TABLE ETapManagement.dbo.roles_applicationforms (
id int NOT NULL IDENTITY(1,1),
form_id int NOT NULL,
role_id int NOT NULL,
 "isAdd" bit NULL,
  "isUpdate" bit NULL,
  "isDelete" bit NULL,  
  "isView" bit NULL,      
CONSTRAINT roles_forms_pkey PRIMARY KEY (id),
CONSTRAINT rolesforms_forms_id_fkey FOREIGN KEY (form_id) REFERENCES application_forms(id),
CONSTRAINT rolesforms_roles_id_fkey FOREIGN KEY (role_id) REFERENCES roles(id),	
)



    CREATE TABLE ETapManagement.dbo.audit_logs(
        id int not null identity(1,1),
        action varchar(100) null,
        "message" varchar(2000) null,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        CONSTRAINT auditlog_pkey PRIMARY KEY (id),
	
    )
   
create table ETapManagement.dbo.independent_company (
id int NOT NULL IDENTITY(1,1) primary key,
name varchar(200) not NULL ,
description varchar(500) NULL,
is_active bit not null default 1,
is_delete bit not null DEFAULT 1,
created_by int null,
created_at datetime default CURRENT_TIMESTAMP,
updated_by int null,
updated_at datetime 

)

create table ETapManagement.dbo.structure_type (
id int NOT NULL IDENTITY(1,1) primary key,
name varchar(200) not NULL ,
is_active bit not null default 1,
is_delete bit not null DEFAULT 1,
description varchar(500) NULL,
created_by int null,
created_at datetime default CURRENT_TIMESTAMP,
updated_by int null,
updated_at datetime 
)
create table ETapManagement.dbo.component_type (
id int NOT NULL IDENTITY(1,1) primary key,
name varchar(200) not NULL unique,
description varchar(500) NULL,
is_delete bit default 0,
is_active bit,
created_by int null,
created_at datetime default CURRENT_TIMESTAMP,
updated_by int null,
updated_at datetime 
)

create table ETapManagement.dbo.segment (
id int NOT NULL IDENTITY(1,1) primary key,
name varchar(200) not NULL unique,
description varchar(500) NULL
)

create table ETapManagement.dbo.service_type (
id int NOT NULL IDENTITY(1,1) primary key,
name varchar(200) not NULL unique,
description varchar(500) NULL
)

    CREATE TABLE ETapManagement.dbo.business_unit(
        id int not null identity(1,1),
        ic_id int not null,    
        name varchar(100) not null ,
        is_delete bit not NULL DEFAULT 0,
        is_active bit,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,     
        CONSTRAINT business_unit_pkey PRIMARY KEY (id),
        CONSTRAINT business_unit_icId_IC__fkey FOREIGN KEY (ic_id) REFERENCES independent_company(id),
    )
         

    CREATE TABLE ETapManagement.dbo.project(
        id int not null identity(1,1),
        "name" varchar(100) null ,
        proj_code varchar(20)  not null ,
        area varchar(10) null,
        ic_id int not null,
        bu_id int not null,
        segment_id int not null,        
        is_delete bit NOT NULL DEFAULT 0,   
        is_active bit NULL,        

        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        CONSTRAINT project_pkey PRIMARY KEY (id),
        CONSTRAINT project_icId_IC__fkey FOREIGN KEY (ic_id) REFERENCES independent_company(id),
        CONSTRAINT project_buId_BU__fkey FOREIGN KEY (bu_id) REFERENCES business_unit(id),
        CONSTRAINT project_segmentId_segment__fkey FOREIGN KEY (segment_id) REFERENCES segment(id),
    )

    CREATE TABLE ETapManagement.dbo.project_sitelocation(
    id int not null identity(1,1),
    "name" varchar(100) null ,
    project_id int not null,
    CONSTRAINT project_sitelocation_pkey PRIMARY KEY (id),
    CONSTRAINT project_sitelocation_projectId_fkey FOREIGN KEY (project_id) REFERENCES project(id),
    )
    
CREATE TABLE ETapManagement.dbo.users (
	id int NOT NULL identity(1,1),	
  project_id int not null,
  ic_id int not null,
  bu_id int not null,
	ps_no varchar(100) not null,
	"password" varchar(500) NOT NULL,
	first_name varchar(100),
	last_name varchar(100),
	phoneno varchar(15),
	email varchar(100) ,
	role_id int not null,
    is_active bit NULL DEFAULT 1,    
    is_delete bit NULL DEFAULT 0,
  	created_at DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	updated_at DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	created_by int NULL,
	updated_by int NULL,
	CONSTRAINT users_pkey PRIMARY KEY (id),
	CONSTRAINT user_roles_id_fkey FOREIGN KEY (role_id) REFERENCES roles(id),
  CONSTRAINT users_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
  CONSTRAINT users_ic_fkey FOREIGN KEY (ic_id) REFERENCES independent_company(id),
  CONSTRAINT users_bu_fkey FOREIGN KEY (bu_id) REFERENCES business_unit(id),
);
    
    CREATE TABLE ETapManagement.dbo.structures(
        id int not null identity(1,1),
        struct_id varchar(10) not null,
        name varchar(50) not null,
        structure_type_id int not null ,
        is_delete bit NOT NULL DEFAULT 0,
        is_active bit NULL ,
        structure_attributes  nvarchar(max) null,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,        
        CONSTRAINT structure_pkey PRIMARY KEY (id),
        CONSTRAINT structures_structuretype_fkey FOREIGN KEY (structure_type_id) REFERENCES structure_type(id),
      )
     
    
           
    CREATE TABLE ETapManagement.dbo.project_structure(
        id int not null identity(1,1),     
        structure_id int not null ,
        project_id int not null,
        drawing_no varchar(20) null,
        components_count int,           
        is_delete bit NULL DEFAULT 0,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        CONSTRAINT projstructure_pkey PRIMARY KEY (id),
        CONSTRAINT projstructure_structures_fkey FOREIGN KEY (structure_id) REFERENCES structures(id),
        CONSTRAINT projstructure_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
    )
    
    
    
       
CREATE TABLE project_structure_documents(
    id int not null identity(1,1),
    project_structure_id int not null,
	file_name varchar(500) null,    
	file_type varchar(10) null,
    "path" varchar(1000) null,
    CONSTRAINT project_structure_documents_pkey PRIMARY KEY (id),
	CONSTRAINT project_structure_id_psID_fkey FOREIGN KEY (project_structure_id) REFERENCES project_structure(id),  
    )

                
    CREATE TABLE ETapManagement.dbo.component(
        id int not null identity(1,1),
        proj_struct_id int not null,
        comp_id varchar(20) not null,
        comp_type_id int not null,
        drawing_no varchar(20) null,
        component_no int null,
        is_group bit null default 0,       
        leng decimal(10,6) null,
        breath decimal(10,6) null,
        height decimal(10,6) null,
        thickness decimal(10,6) null,
        width decimal(10,6) null,
        make_type varchar(30) null,
        is_tag bit null,
        qr_code varchar(200) null,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        is_delete bit NULL DEFAULT 0,
        is_active bit NULL DEFAULT 0,  
        comp_status varchar(20) NULL,
        CONSTRAINT comp_pkey PRIMARY KEY (id),
        CONSTRAINT comp_projstruct_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
        CONSTRAINT comp_comptype_fkey FOREIGN KEY (comp_type_id) REFERENCES component_type(id),
   )
    
     CREATE TABLE ETapManagement.dbo.component_history(
        id int not null identity(1,1),
        proj_struct_id int not null,
        comp_id varchar(20) not null ,
        comp_type_id int not null,
        drawing_no varchar(10) null,
        component_no int null,
        is_group bit null default 0,       
        leng decimal(10,6) null,
        breath decimal(10,6) null,
        height decimal(10,6) null,
        thickness decimal(10,6) null,
        width decimal(10,6) null,
        make_type varchar(30) null,
        is_tag bit null,
        qr_code varchar(200) null,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        is_delete bit NULL DEFAULT 0,
        is_active bit NULL DEFAULT 0,  
        comp_status varchar(20) NULL,
        CONSTRAINT comphistory_pkey PRIMARY KEY (id),
        CONSTRAINT comphistory_projstruct_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
        CONSTRAINT comphistory_comptype_fkey FOREIGN KEY (comp_type_id) REFERENCES component_type(id),
    )
    

    CREATE TABLE ETapManagement.dbo.work_breakdown(
        id int not null identity(1,1),     
        wbs_id varchar(20) not null ,
        project_id int not null,
        name varchar(50) null,
        segment varchar(20) null,
        sub_segment varchar(20) null,
        elements varchar(20) null,
        is_delete bit NULL DEFAULT 0,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        CONSTRAINT wbs_pkey PRIMARY KEY (id),
        CONSTRAINT wbs_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
    )

    CREATE TABLE ETapManagement.dbo.sub_contractor(
        id int not null identity(1,1),     
        vendor_code varchar(20) not null,
        name varchar(50) null, 
        email varchar(50) null,
        phone_no varchar(20) null,
        is_delete bit NULL DEFAULT 0,
        is_status bit NULL DEFAULT 0,        
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        CONSTRAINT subcont_pkey PRIMARY KEY (id),
    )
    
                      
    CREATE TABLE ETapManagement.dbo.subContractor_serviceType(
        id int not null identity(1,1),     
        subcont_id int not null,
        servicetype_id int not null,
        CONSTRAINT subST_pkey PRIMARY KEY (id),
        CONSTRAINT subST_servieType_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),
        CONSTRAINT subST_subconractor_fkey FOREIGN KEY (subcont_id) REFERENCES sub_contractor(id),      
    )
    
    
        CREATE TABLE ETapManagement.dbo.site_requirement(
        id int not null identity(1,1) primary key,     
        mr_no varchar(20) not null unique,
        project_id int not null,
        plan_startdate datetime not null,
        plan_releasedate datetime not null,
        actual_startdate datetime not null,
        actual_releasedate datetime not null,
        require_wbs_id int not null,
        actual_wbs_id int not null,
        remarks varchar(500) null,
        status varchar(50) null,
        status_internal varchar(100) null,
        role_id int not null,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime null,
        is_delete bit not null DEFAULT 0,        
        CONSTRAINT siteReq_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
    )
    
      CREATE TABLE ETapManagement.dbo.site_req_structure(
        id int not null identity(1,1) primary key,  
        site_req_id int not null,
        struct_id int not null,
        drawing_no varchar(20) null,
        quantity int ,       
		CONSTRAINT siteReqStructire_siteReq_fkey FOREIGN KEY (site_req_id) REFERENCES site_requirement(id), 
     	CONSTRAINT siteReqStructire_structure_fkey FOREIGN KEY (struct_id) REFERENCES structures(id),        
    )
    
    
    
        
      CREATE TABLE ETapManagement.dbo.sitereq_status_history(
        id int not null identity(1,1) primary key,     
        mr_no varchar(20) not null ,     
        sitereq_id int not null,
        notes varchar(500) null,
        status varchar(50) null,
        status_internal varchar(100) null, 
        role_id int,
        updated_by int null,
        updated_at datetime null,
        CONSTRAINT sitereq_status_history_sitereq_fkey FOREIGN KEY (sitereq_id) REFERENCES site_requirement(id),
    )
    
    
        CREATE TABLE ETapManagement.dbo.site_declaration(
        id int not null identity(1,1) primary key,   
        sitereq_id int,
        struct_id int,
        surplus_fromdate datetime not null,
        "status" varchar(50)  null,       
        status_internal varchar(100) null,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        notes varchar(500),
        role_id int,        
        updated_by int null,
        updated_at datetime null,
        is_delete bit not null DEFAULT 0,    
        CONSTRAINT siteDec_siteReq_fkey FOREIGN KEY (sitereq_id) REFERENCES site_requirement(id),
        CONSTRAINT siteDec_structure_fkey FOREIGN KEY (struct_id) REFERENCES structures(id),        
    )
    
    
        
        CREATE TABLE ETapManagement.dbo.sitedecl_status_history(
        id int not null identity(1,1) primary key,   
        sitedec_id int, 
        notes varchar(500) null,
        status varchar(50) null,
        status_internal varchar(100) null, 
        role_id int,
        updated_by int null,
        updated_at datetime null,  
        CONSTRAINT siteDeclStatus_siteDec_fkey FOREIGN KEY (sitedec_id) REFERENCES site_declaration(id),
    )
    
    
     CREATE TABLE ETapManagement.dbo.scrap_structure(
        id int not null identity(1,1) primary key,     
        subcon_id int,
        struct_id int,
        scrap_rate decimal(10,2),
        auction_id varchar(20),      
        "status" varchar(50) null,        
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime null,
        is_delete bit not null DEFAULT 0,        
     	CONSTRAINT scrap_strucure_structure_fkey FOREIGN KEY (struct_id) REFERENCES structures(id),        
     	CONSTRAINT scrap_structure_subcon_fkey FOREIGN KEY (subcon_id) REFERENCES sub_contractor(id),        

    )

    
      CREATE TABLE ETapManagement.dbo.dispatch_requirement(
        id int not null identity(1,1) primary key,     
        dispatch_no varchar(20) not null unique,
        sitereq_id int null,
        to_projectid int,
        servicetype_id int,
        quantity int,
        transfer_price decimal(10,2),       
        status varchar(50) null,
        status_internal varchar(100) null,
        role_id int,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime null,
        is_delete bit not null DEFAULT 0,        
        CONSTRAINT dispatch_requirement_proj_fkey FOREIGN KEY (to_projectid) REFERENCES project(id),
        CONSTRAINT dispatch_requirement_siteReq_fkey FOREIGN KEY (sitereq_id) REFERENCES site_requirement(id),
     	CONSTRAINT dispatch_requirement_servicetype_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),        

    )
    
      CREATE TABLE ETapManagement.dbo.disp_req_structure(
        id int not null identity(1,1) primary key,  
        dispreq_id int,
        struct_id int,
		CONSTRAINT DispReqStructire_siteReq_fkey FOREIGN KEY (dispreq_id) REFERENCES site_requirement(id), 
     	CONSTRAINT DispReqStructire_structure_fkey FOREIGN KEY (struct_id) REFERENCES structures(id),        
    )
    
    
     CREATE TABLE ETapManagement.dbo.dispatchreq_subcont(
        id int not null identity(1,1) primary key,     
        dispreq_id int ,
        dispatch_no varchar(20),
        subcon_id int,
        monthly_rent decimal(10,2),
        servicetype_id int,
        contract_years decimal(10,2),
        plan_releasedate datetime null,
        expected_releasedate datetime null,        
        actual_startdate datetime null,
        dispatch_date datetime null,
        workorder_no varchar(20) null,
        quantity int,
        fabrication_cost decimal(10,2),
        status varchar(50) null,
        status_internal varchar(100) null,
        role_id int,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime null,
        is_delete bit not null DEFAULT 0, 
        CONSTRAINT dispatchreq_subcont_subcont_fkey FOREIGN KEY (subcon_id) REFERENCES sub_contractor(id),
     	CONSTRAINT dispatchreq_subcont_dispatch_requirement_fkey FOREIGN KEY (dispreq_id) REFERENCES dispatch_requirement(id),
     	CONSTRAINT dispatchreq_subcont_servicetype_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),        
      )
    
      CREATE TABLE ETapManagement.dbo.disp_subcont_structure(
        id int not null identity(1,1) primary key,  
        dispreqsubcont_id int,
        struct_id int,
		CONSTRAINT dispreqsubcont_structure_siteReq_fkey FOREIGN KEY (dispreqsubcont_id) REFERENCES dispatchreq_subcont(id), 
     	CONSTRAINT disp_subcont_structure_structure_fkey FOREIGN KEY (struct_id) REFERENCES structures(id),        
    )
    
      CREATE TABLE ETapManagement.dbo.role_hierarchy(
        id int not null identity(1,1) PRIMARY KEY,     
        role_name varchar(20),
        scenario_type varchar(50),
        role_hierarchy int,
        new_status varchar(50),
        chk_status varchar(50),
        view_details_status varchar(500),
        )
    

    select * from INFORMATION_SCHEMA.TABLES t 







CREATE OR ALTER PROCEDURE sp_GetRequirement( @role_name varchar(50),@role_hierarchy int  null)
AS
BEGIN
	
	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (50)
	
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
	print @cond_status
	
 select '0'as 'isAction', * into #resultset1 from site_requirement  where status_internal  in (@cond_status)

 -- select distinct sitereq_id INTO #distSiteReqId from sitereq_status_history where role_id = @role_id and sitereq_id  not in (select id from #resultset1) order by updated_at  desc
	
 
  SELECT sitereq_id INTO #distSiteReqId
    FROM (
  SELECT sitereq_id, updated_at, ROW_NUMBER() OVER (PARTITION BY sitereq_id ORDER BY updated_at desc) RN
        FROM sitereq_status_history where role_id = @role_id and sitereq_id  not in (select id from #resultset1)) S where RN =1
        
	  select '1'as 'isAction', *  into #resultset2 from site_requirement sr where id  in (select sitereq_id from #distSiteReqId)
	 
	 select * from #resultset1 union all 
	 select * from #resultset2
END

exec sp_GetRequirement 'SITE',null




CREATE OR ALTER PROCEDURE sp_ApprovalRequirement(@req_id int, @role_name varchar(50),@role_hierarchy int  null )
AS
BEGIN

	declare @role_id int 
	SET @role_id = (select top 1 id from roles where name =@role_name)
	declare @cond_status varchar (50)
	declare @new_status varchar (50)

	
	if (@role_hierarchy is null)
	BEGIN 
		select 's'
	SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name)
	SET @new_status= (select top 1 new_status from role_hierarchy where role_name =@role_name)

	END 
ELSE 
BEGIN 
	select 'ss'
		SET @cond_status= (select top 1 chk_status from role_hierarchy where role_name =@role_name and role_hierarchy  = @role_hierarchy)
		SET @new_status= (select top 1 new_status from role_hierarchy where role_name =@role_name  and role_hierarchy  = @role_hierarchy)

	END
	select @cond_status 
	select @new_status
	
	if  EXISTS (select * from  site_requirement where   Id = @req_id and status_internal in (@cond_status)) 
	BEGIN 	
	update site_requirement  set status_internal = @new_status where  id =@req_id
	insert into sitereq_status_history (mr_no,sitereq_id ,status ,status_internal ,role_id ,updated_at ) select mr_no, id,status ,status_internal ,@role_id ,getdate() from site_requirement sr where id = @req_id 
	END
	ELSE 
	BEGIN 
	select 'NOT ALLOWED'
	END

END



exec sp_ApprovalRequirement 6, 'BU', null




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
	select @cond_status 
	select @new_status
	
	if  EXISTS (select * from  site_requirement where   Id = @req_id and status_internal in (@cond_status)) 
	BEGIN 	
	update site_requirement  set status ='REJECT',status_internal = @new_status where  id =@req_id
	insert into sitereq_status_history (mr_no,sitereq_id ,status ,status_internal ,role_id ,updated_at ) select mr_no, id,status,status_internal ,@role_id ,getdate() from site_requirement sr where id = @req_id 
	END
	ELSE 
	BEGIN 
	select 'NOT ALLOWED'
	END

END
        
exec sp_RejectRequirement 6, 'BU', null
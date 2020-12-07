

 IF OBJECT_ID('ETapManagement.dbo.component_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component_history ; 

 IF OBJECT_ID('ETapManagement.dbo.component', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component; 

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
 
 
 
IF OBJECT_ID('ETapManagement.dbo.business_unit', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.business_unit ; 
 
 
 IF OBJECT_ID('ETapManagement.dbo.independent_company', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.independent_company; 

 
 IF OBJECT_ID('ETapManagement.dbo.service_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.service_type; 
 
 
 
 IF OBJECT_ID('ETapManagement.dbo.structure_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.structure_type; 

 
 IF OBJECT_ID('ETapManagement.dbo.component_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component_type; 

 
 
IF OBJECT_ID('ETapManagement.dbo.subContractor_serviceType', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.subContractor_serviceType; 
  

IF OBJECT_ID('ETapManagement.dbo.segment', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.segment; 
  
IF OBJECT_ID('ETapManagement.dbo.sub_contractor', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.sub_contractor; 
 
 
 



IF OBJECT_ID('ETapManagement.dbo.roles', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.roles; 
 
  
 
CREATE TABLE ETapManagement.dbo.roles (
  id int NOT NULL IDENTITY (1,1),
  "name" varchar(30) NOT NULL,
  "description" varchar(300) NULL, 
  "level" int NULL, 
  updated_at DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  updated_by int null,

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
name varchar(200) not NULL unique,
description varchar(500) NULL,
is_delete bit NULL DEFAULT 0,

)

create table ETapManagement.dbo.structure_type (
id int NOT NULL IDENTITY(1,1) primary key,
name varchar(200) not NULL unique,
is_active bit not null default 1,
is_delete bit not null DEFAULT 1,
description varchar(500) NULL
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
        name varchar(100) not null unique,
        ic_id int  null,
        is_delete bit NULL DEFAULT 0,
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
        proj_code varchar(20)  not null unique,
        area varchar(10) null,
        ic_id int null,
        bu_id int null,
        segment_id int null,        
        is_delete bit NULL DEFAULT 0,        
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
    project_id int null,
    CONSTRAINT project_sitelocation_pkey PRIMARY KEY (id),
    CONSTRAINT project_sitelocation_projectId_fkey FOREIGN KEY (project_id) REFERENCES project(id),
    )
    
CREATE TABLE ETapManagement.dbo.users (
	id int NOT NULL identity(1,1),	
  project_id int null,
  ic_id int null,
  bu_id int null,
	ps_no varchar(100),
	"password" varchar(500) NOT NULL,
	first_name varchar(100),
	last_name varchar(100),
	phoneno varchar(15),
	email varchar(100) ,
	role_id int null,
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
        struct_id varchar(10) not null unique,
        structure_type_id int null ,
        is_delete bit NOT NULL DEFAULT 0,
        structure_status varchar(20) null,
        is_active bit NOT NULL DEFAULT 0,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        CONSTRAINT structure_pkey PRIMARY KEY (id),
        CONSTRAINT structures_structuretype_fkey FOREIGN KEY (structure_type_id) REFERENCES structure_type(id),
      )
        CREATE TABLE ETapManagement.dbo.structures_attributes(
        id int not null identity(1,1),
        structure_id int null ,
        attribute_desc varchar(50) null,
        input_type varchar(50) null,    
        uom varchar(50) null,
        value varchar(500) null,        
        CONSTRAINT structures_attribute_pkey PRIMARY KEY (id),
        CONSTRAINT structures_attribute_structure_fkey FOREIGN KEY (structure_id) REFERENCES structures(id),     
      )
    
           
    CREATE TABLE ETapManagement.dbo.project_structure(
        id int not null identity(1,1),     
        structure_id int null ,
        project_id int null,
        drawing_no varchar(10) null,
        components_count int null,
        total_weight decimal(10,6),
        capacity smallint,
        overall_length smallint,
        slung_type varchar(20) null,
        basic_length decimal(10,6),
        basic_width decimal(10,6),
        basic_height decimal(10,6),
        is_delete bit NULL DEFAULT 0,
        created_by int null,
        created_at datetime default CURRENT_TIMESTAMP,
        updated_by int null,
        updated_at datetime ,
        CONSTRAINT projstructure_pkey PRIMARY KEY (id),
        CONSTRAINT projstructure_structures_fkey FOREIGN KEY (structure_id) REFERENCES structures(id),
        CONSTRAINT projstructure_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
    )
    
    
        
    CREATE TABLE ETapManagement.dbo.component(
        id int not null identity(1,1),
        proj_struct_id int,
        comp_id varchar(20) not null unique,
        comp_type_id int null,
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
        proj_struct_id int,
        comp_id varchar(20) not null unique,
        comp_type_id int null,
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
        project_id int null,
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
        vendor_code varchar(20) not null unique,
        name varchar(50) null, 
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
        subcont_id int null,
        servicetype_id int null,
        CONSTRAINT subST_pkey PRIMARY KEY (id),
        CONSTRAINT subST_servieType_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),
        CONSTRAINT subST_subconractor_fkey FOREIGN KEY (subcont_id) REFERENCES sub_contractor(id),
      
    )
    select * from INFORMATION_SCHEMA.TABLES t 
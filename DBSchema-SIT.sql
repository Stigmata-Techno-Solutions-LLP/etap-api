

--DROP DATABASE ETapManagementSIT

--CREATE DATABASE ETapManagementSIT

IF OBJECT_ID('ETapManagementSIT.dbo.site_comp_physicalverf', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.site_comp_physicalverf ;

IF OBJECT_ID('ETapManagementSIT.dbo.site_structure_physicalverf', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.site_structure_physicalverf ;

IF OBJECT_ID('ETapManagementSIT.dbo.site_physical_verf', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.site_physical_verf ;

IF OBJECT_ID('ETapManagementSIT.dbo.component_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.component_history ;


IF OBJECT_ID('ETapManagementSIT.dbo.project_structure_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.project_structure_documents;


IF OBJECT_ID('ETapManagementSIT.dbo.disp_subcont_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disp_subcont_documents;

IF OBJECT_ID('ETapManagementSIT.dbo.disp_subcont_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disp_subcont_structure;


IF OBJECT_ID('ETapManagementSIT.dbo.dispatchreq_subcont', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.dispatchreq_subcont;



IF OBJECT_ID('ETapManagementSIT.dbo.disp_structure_comp', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disp_structure_comp;


IF OBJECT_ID('ETapManagementSIT.dbo.disp_structure_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disp_structure_documents;


IF OBJECT_ID('ETapManagementSIT.dbo.disp_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disp_req_structure;


IF OBJECT_ID('ETapManagementSIT.dbo.disreq_status_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disreq_status_history;
IF OBJECT_ID('ETapManagementSIT.dbo.disp_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.disp_req_structure;
IF OBJECT_ID('ETapManagementSIT.dbo.dispatch_requirement', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.dispatch_requirement;

IF OBJECT_ID('ETapManagementSIT.dbo.sitedecl_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.sitedecl_documents;


IF OBJECT_ID('ETapManagementSIT.dbo.sitedecl_status_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.sitedecl_status_history;

IF OBJECT_ID('ETapManagementSIT.dbo.site_declaration', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.site_declaration;



IF OBJECT_ID('ETapManagementSIT.dbo.sitereq_status_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.sitereq_status_history;

IF OBJECT_ID('ETapManagementSIT.dbo.site_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.site_req_structure;


IF OBJECT_ID('ETapManagementSIT.dbo.site_requirement', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.site_requirement;







IF OBJECT_ID('ETapManagementSIT.dbo.scrap_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.scrap_structure;




IF OBJECT_ID('ETapManagementSIT.dbo.work_breakdown', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.work_breakdown;



IF OBJECT_ID('ETapManagementSIT.dbo.users', 'U') IS NOT NULL 
DROP TABLE ETapManagementSIT.dbo.users;



IF OBJECT_ID('ETapManagementSIT.dbo.audit_logs', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.audit_logs;

IF OBJECT_ID('ETapManagementSIT.dbo.roles_applicationforms', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.roles_applicationforms;




IF OBJECT_ID('ETapManagementSIT.dbo.application_forms', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.application_forms;

IF OBJECT_ID('ETapManagementSIT.dbo.project_sitelocation', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.project_sitelocation ;



IF OBJECT_ID('ETapManagementSIT.dbo.component', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.component;


IF OBJECT_ID('ETapManagementSIT.dbo.project_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.project_structure;


IF OBJECT_ID('ETapManagementSIT.dbo.project', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.project;


IF OBJECT_ID('ETapManagementSIT.dbo.structures', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.structures;

IF OBJECT_ID('ETapManagementSIT.dbo.businessUnit_IC', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.businessUnit_IC ;
IF OBJECT_ID('ETapManagementSIT.dbo.business_unit', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.business_unit ;

IF OBJECT_ID('ETapManagementSIT.dbo.independent_company', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.independent_company;

IF OBJECT_ID('ETapManagementSIT.dbo.structure_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.structure_type;


IF OBJECT_ID('ETapManagementSIT.dbo.component_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.component_type;



IF OBJECT_ID('ETapManagementSIT.dbo.subContractor_serviceType', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.subContractor_serviceType;

IF OBJECT_ID('ETapManagementSIT.dbo.service_type', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.service_type;

IF OBJECT_ID('ETapManagementSIT.dbo.segment', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.segment;

IF OBJECT_ID('ETapManagementSIT.dbo.sub_contractor', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.sub_contractor;


IF OBJECT_ID('ETapManagementSIT.dbo.roles', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.roles;
IF OBJECT_ID('ETapManagementSIT.dbo.role_hierarchy', 'U') IS NOT NULL 
  DROP TABLE ETapManagementSIT.dbo.role_hierarchy;









CREATE TABLE ETapManagementSIT.dbo.roles
(
  id int NOT NULL IDENTITY (1,1),
  "name" varchar(30) NOT NULL,
  "description" varchar(300) NULL,
  "level" int NULL,
  CONSTRAINT SIT_site_roles_name_key UNIQUE (name),
  CONSTRAINT SIT_site_roles_pkey PRIMARY KEY (id)
);



CREATE TABLE ETapManagementSIT.dbo.application_forms
(
  id int NOT NULL IDENTITY (1,1),
  "name" varchar(30) NOT NULL,
  "description" varchar(300) NULL,
  "isAdd" bit NULL,
  "isUpdate" bit NULL,
  "isDelete" bit NULL,
  "isView" bit NULL,
  CONSTRAINT SIT_application_forms_name_key UNIQUE (name),
  CONSTRAINT SIT_page_pkey PRIMARY KEY (id),
);



CREATE TABLE ETapManagementSIT.dbo.roles_applicationforms
(
  id int NOT NULL IDENTITY(1,1),
  form_id int NOT NULL,
  role_id int NOT NULL,
  "isAdd" bit NULL,
  "isUpdate" bit NULL,
  "isDelete" bit NULL,
  "isView" bit NULL,
  CONSTRAINT SIT_roles_forms_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_rolesforms_forms_id_fkey FOREIGN KEY (form_id) REFERENCES application_forms(id),
  CONSTRAINT SIT_rolesforms_roles_id_fkey FOREIGN KEY (role_id) REFERENCES roles(id),
)



CREATE TABLE ETapManagementSIT.dbo.audit_logs
(
  id int not null identity(1,1),
  action varchar(100) null,
  "message" varchar(2000) null,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  CONSTRAINT SIT_auditlog_pkey PRIMARY KEY (id),

)

create table ETapManagementSIT.dbo.independent_company
(
  id int NOT NULL IDENTITY(1,1) primary key,
  name varchar(200) not NULL ,
  description varchar(500) NULL,
  is_active bit not null default 1,
  is_delete bit not null DEFAULT 0,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime

)

create table ETapManagementSIT.dbo.structure_type
(
  id int NOT NULL IDENTITY(1,1) primary key,
  name varchar(200) not NULL ,
  is_active bit not null default 1,
  is_delete bit not null DEFAULT 0,
  description varchar(500) NULL,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime
)
create table ETapManagementSIT.dbo.component_type
(
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

create table ETapManagementSIT.dbo.segment
(
  id int NOT NULL IDENTITY(1,1) primary key,
  name varchar(200) not NULL unique,
  description varchar(500) NULL
)

create table ETapManagementSIT.dbo.service_type
(
  id int NOT NULL IDENTITY(1,1) primary key,
  name varchar(200) not NULL unique,
  description varchar(500) NULL
)

CREATE TABLE ETapManagementSIT.dbo.business_unit
(
  id int not null identity(1,1),
  ic_id int not null,
  name varchar(100) not null ,
  is_delete bit not NULL DEFAULT 0,
  is_active bit,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime ,
  CONSTRAINT SIT_business_unit_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_business_unit_icId_IC__fkey FOREIGN KEY (ic_id) REFERENCES independent_company(id),
)


CREATE TABLE ETapManagementSIT.dbo.project
(
  id int not null identity(1,1),
  "name" varchar(100) null ,
  proj_code varchar(20) not null ,
  area varchar(10) null,
  ic_id int not null,
  bu_id int not null,
  job_code varchar(20) null,
  edrc_code varchar(20) null,
  is_delete bit NOT NULL DEFAULT 0,
  is_active bit NULL,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime ,
  CONSTRAINT SIT_project_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_project_icId_IC__fkey FOREIGN KEY (ic_id) REFERENCES independent_company(id),
  CONSTRAINT SIT_project_buId_BU__fkey FOREIGN KEY (bu_id) REFERENCES business_unit(id),
)

CREATE TABLE ETapManagementSIT.dbo.project_sitelocation
(
  id int not null identity(1,1),
  "name" varchar(100) null ,
  project_id int not null,
  CONSTRAINT SIT_project_sitelocation_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_project_sitelocation_projectId_fkey FOREIGN KEY (project_id) REFERENCES project(id),
)

CREATE TABLE ETapManagementSIT.dbo.users
(
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
  CONSTRAINT SIT_users_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_user_roles_id_fkey FOREIGN KEY (role_id) REFERENCES roles(id),
  CONSTRAINT SIT_users_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
  CONSTRAINT SIT_users_ic_fkey FOREIGN KEY (ic_id) REFERENCES independent_company(id),
  CONSTRAINT SIT_users_bu_fkey FOREIGN KEY (bu_id) REFERENCES business_unit(id),
);

CREATE TABLE ETapManagementSIT.dbo.structures
(
  id int not null identity(1,1),
  name varchar(50) not null,
  structure_type_id int not null ,
  is_delete bit NOT NULL DEFAULT 0,
  is_active bit NULL ,
  structure_attributes nvarchar(max) null,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime ,
  CONSTRAINT SIT_structure_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_structures_structuretype_fkey FOREIGN KEY (structure_type_id) REFERENCES structure_type(id),
)



CREATE TABLE ETapManagementSIT.dbo.project_structure
(
  id int not null identity(1,1),
  structure_id int not null ,
  struct_code varchar(20) not null,
  project_id int not null,
  drawing_no varchar(20) null,
  components_count int,
  estimated_weight decimal(10,2),
  structure_status varchar(20) null,
  current_status varchar(20) null,
  structure_attributes nvarchar(max) null,
  is_delete bit NULL DEFAULT 0,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime ,
  CONSTRAINT SIT_projstructure_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_projstructure_structures_fkey FOREIGN KEY (structure_id) REFERENCES structures(id),
  CONSTRAINT SIT_projstructure_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
)




CREATE TABLE ETapManagementSIT.dbo.project_structure_documents
(
  id int not null identity(1,1),
  project_structure_id int not null,
  file_name varchar(500) null,
  file_type varchar(10) null,
  "path" varchar(1000) null,
  CONSTRAINT SIT_project_structure_documents_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_project_structure_id_psID_fkey FOREIGN KEY (project_structure_id) REFERENCES project_structure(id),
)


CREATE TABLE ETapManagementSIT.dbo.component
(
  id int not null identity(1,1),
  proj_struct_id int not null,
  comp_id varchar(20) not null,
  comp_type_id int not null,
  drawing_no varchar(20) null,
  component_no int null,
  comp_name varchar(20) NULL,
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
  CONSTRAINT SIT_comp_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_comp_projstruct_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
  CONSTRAINT SIT_comp_comptype_fkey FOREIGN KEY (comp_type_id) REFERENCES component_type(id),
)

CREATE TABLE ETapManagementSIT.dbo.component_history
(
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
  CONSTRAINT SIT_comphistory_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_comphistory_projstruct_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
  CONSTRAINT SIT_comphistory_comptype_fkey FOREIGN KEY (comp_type_id) REFERENCES component_type(id),
)


CREATE TABLE ETapManagementSIT.dbo.work_breakdown
(
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
  CONSTRAINT SIT_wbs_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_wbs_proj_fkey FOREIGN KEY (project_id) REFERENCES project(id),
)

CREATE TABLE ETapManagementSIT.dbo.sub_contractor
(
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
  CONSTRAINT SIT_subcont_pkey PRIMARY KEY (id),
)


CREATE TABLE ETapManagementSIT.dbo.subContractor_serviceType
(
  id int not null identity(1,1),
  subcont_id int not null,
  servicetype_id int not null,
  CONSTRAINT SIT_subST_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_subST_servieType_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),
  CONSTRAINT SIT_subST_subconractor_fkey FOREIGN KEY (subcont_id) REFERENCES sub_contractor(id),
)


CREATE TABLE ETapManagementSIT.dbo.site_requirement
(
  id int not null identity(1,1) primary key,
  mr_no varchar(20) not null unique,
  from_project_id int not null,
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
  CONSTRAINT SIT_siteReq_proj_fkey FOREIGN KEY (from_project_id) REFERENCES project(id),
)

CREATE TABLE ETapManagementSIT.dbo.site_req_structure
(
  id int not null identity(1,1) primary key,
  site_req_id int not null,
  proj_struct_id int not null,
  structure_attributes nvarchar(max) null,
  drawing_no varchar(20) null,
  quantity int ,
  CONSTRAINT SIT_siteReqStructire_siteReq_fkey FOREIGN KEY (site_req_id) REFERENCES site_requirement(id),
  CONSTRAINT SIT_siteReqStructire_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
)




CREATE TABLE ETapManagementSIT.dbo.sitereq_status_history
(
  id int not null identity(1,1) primary key,
  mr_no varchar(20) not null ,
  sitereq_id int not null,
  notes varchar(500) null,
  status varchar(50) null,
  status_internal varchar(100) null,
  role_id int,
  updated_by int null,
  updated_at datetime null,
  CONSTRAINT SIT_sitereq_status_history_sitereq_fkey FOREIGN KEY (sitereq_id) REFERENCES site_requirement(id),
)


CREATE TABLE ETapManagementSIT.dbo.site_declaration
(
  id int not null identity(1,1) primary key,
  proj_struct_id int,
  from_project_id int,
  surplus_fromdate datetime not null,
  "status" varchar(50) null,
  status_internal varchar(100) null,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  notes varchar(500),
  role_id int,
  updated_by int null,
  updated_at datetime null,
  is_delete bit not null DEFAULT 0,
  CONSTRAINT SIT_siteDecl_proj_fkey FOREIGN KEY (from_project_id) REFERENCES project(id),
  CONSTRAINT SIT_siteDec_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
)



CREATE TABLE ETapManagementSIT.dbo.sitedecl_status_history
(
  id int not null identity(1,1) primary key,
  sitedec_id int,
  notes varchar(500) null,
  status varchar(50) null,
  status_internal varchar(100) null,
  role_id int,
  updated_by int null,
  updated_at datetime null,
  CONSTRAINT SIT_siteDeclStatus_siteDec_fkey FOREIGN KEY (sitedec_id) REFERENCES site_declaration(id),
)




CREATE TABLE ETapManagementSIT.dbo.sitedecl_documents
(
  id int not null identity(1,1),
  sitedec_id int not null,
  file_name varchar(500) null,
  file_type varchar(10) null,
  "path" varchar(1000) null,
  CONSTRAINT SIT_sitedecl_documents_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_sitedecl_documents_sitedecl_fkey FOREIGN KEY (sitedec_id) REFERENCES site_declaration(id),
)


CREATE TABLE ETapManagementSIT.dbo.scrap_structure
(
  id int not null identity(1,1) primary key,
  subcon_id int,
  proj_struct_id int not null,
  scrap_rate decimal(10,2),
  auction_id varchar(20),
  "status" varchar(50) null,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime null,
  is_delete bit not null DEFAULT 0,
  CONSTRAINT SIT_scrap_strucure_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
  CONSTRAINT SIT_scrap_structure_subcon_fkey FOREIGN KEY (subcon_id) REFERENCES sub_contractor(id),

)


CREATE TABLE ETapManagementSIT.dbo.dispatch_requirement
(
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
  CONSTRAINT SIT_dispatch_requirement_proj_fkey FOREIGN KEY (to_projectid) REFERENCES project(id),
  CONSTRAINT SIT_dispatch_requirement_siteReq_fkey FOREIGN KEY (sitereq_id) REFERENCES site_requirement(id),
  CONSTRAINT SIT_dispatch_requirement_servicetype_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),

)



CREATE TABLE ETapManagementSIT.dbo.disreq_status_history
(
  id int not null identity(1,1) primary key,
  dispatch_no varchar(20) not null unique,
  dispreq_id int null,
  status varchar(50) null,
  status_internal varchar(100) null,
  notes varchar(500) null,
  role_id int,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  CONSTRAINT SIT_dispatch_requirement_statushistory_dispreq_fkey FOREIGN KEY (dispreq_id) REFERENCES dispatch_requirement(id),

)

CREATE TABLE ETapManagementSIT.dbo.disp_req_structure
(
  id int not null identity(1,1) primary key,
  dispreq_id int,
  proj_struct_id int not null,
  CONSTRAINT SIT_DispReqStructire_siteReq_fkey FOREIGN KEY (dispreq_id) REFERENCES dispatch_requirement(id),
  CONSTRAINT SIT_DispReqStructire_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
)


CREATE TABLE ETapManagementSIT.dbo.disp_structure_comp
(
  id int not null identity(1,1),
  disp_structure_id int not null,
  disp_comp_id int not null,
  last_scandate datetime null,
  comp_status varchar(20) null,
  remarks varchar(100) null,
  scanned_by int null,
  CONSTRAINT SIT_disp_structure_comp_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_disp_req_structure_comp_id_StructureID_fkey FOREIGN KEY (disp_structure_id) REFERENCES disp_req_structure(id),
  CONSTRAINT SIT_disp_req_structure_comp_id_CompID_fkey FOREIGN KEY (disp_comp_id) REFERENCES component(id),
)

CREATE TABLE ETapManagementSIT.dbo.disp_structure_documents
(
  id int not null identity(1,1),
  disp_structure_id int not null,
  file_name varchar(500) null,
  file_type varchar(10) null,
  "path" varchar(1000) null,
  CONSTRAINT SIT_disp_structure_documents_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_disp_req_structure_docs_id_docsID_fkey FOREIGN KEY (disp_structure_id) REFERENCES disp_req_structure(id),
)


CREATE TABLE ETapManagementSIT.dbo.dispatchreq_subcont
(
  id int not null identity(1,1) primary key,
  dispreq_id int ,
  dispatch_no varchar(20),
  subcon_id int,
  servicetype_id int,
  workorder_no varchar(20) null,
  quantity int,
  status varchar(50) null,
  status_internal varchar(100) null,
  role_id int,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime null,
  is_delete bit not null DEFAULT 0,
  CONSTRAINT SIT_dispatchreq_subcont_subcont_fkey FOREIGN KEY (subcon_id) REFERENCES sub_contractor(id),
  CONSTRAINT SIT_dispatchreq_subcont_dispatch_requirement_fkey FOREIGN KEY (dispreq_id) REFERENCES dispatch_requirement(id),
  CONSTRAINT SIT_dispatchreq_subcont_servicetype_fkey FOREIGN KEY (servicetype_id) REFERENCES service_type(id),
)

CREATE TABLE ETapManagementSIT.dbo.disp_subcont_structure
(
  id int not null identity(1,1) primary key,
  dispreqsubcont_id int,
  proj_struct_id int not null,
  is_Delivered bit null default 0,
  fabrication_cost decimal (10,2) null,
  monthly_rent decimal(10,2) null,
  contract_years decimal(10,2) null,
  plan_releasedate datetime null,
  expected_releasedate datetime null,
  actual_startdate datetime null,
  dispatch_date datetime null,

  CONSTRAINT SIT_dispreqsubcont_structure_siteReq_fkey FOREIGN KEY (dispreqsubcont_id) REFERENCES dispatchreq_subcont(id),
  CONSTRAINT SIT_disp_subcont_structure_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
)

CREATE TABLE ETapManagementSIT.dbo.disp_subcont_documents
(
  id int not null identity(1,1),
  disp_subcont_id int not null,
  file_name varchar(500) null,
  file_type varchar(10) null,
  "path" varchar(1000) null,
  CONSTRAINT SIT_disp_subcont_documents_pkey PRIMARY KEY (id),
  CONSTRAINT SIT_disp_subcont_id_docsID_fkey FOREIGN KEY (disp_subcont_id) REFERENCES dispatchreq_subcont(id),
)

CREATE TABLE ETapManagementSIT.dbo.role_hierarchy
(
  id int not null identity(1,1) PRIMARY KEY,
  role_name varchar(20),
  scenario_type varchar(50),
  role_hierarchy int,
  new_status varchar(50),
  chk_status varchar(50),
  view_details_status varchar(500),
  service_type varchar(100)
)

CREATE TABLE ETapManagementSIT.dbo.site_physical_verf
(
  id int not null identity(1,1) primary key,
  duedate_from datetime,
  duedate_to datetime,
  inspection_id varchar(20),
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
)


CREATE TABLE ETapManagementSIT.dbo.site_structure_physicalverf
(
  id int not null identity(1,1) primary key,
  site_verf_id int,
  proj_struct_id int not null,
  duedate_from datetime,
  duedate_to datetime,
  status varchar(50) null,
  status_internal varchar(50) null,
  role_id int null,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime null,
  CONSTRAINT SIT_site_structure_physicalverf_site_physical_verf_fkey FOREIGN KEY (site_verf_id) REFERENCES site_physical_verf(id),
  CONSTRAINT SIT_site_structure_physicalverf_strucutre_fkey FOREIGN KEY (proj_struct_id) REFERENCES project_structure(id),
)

CREATE TABLE ETapManagementSIT.dbo.site_comp_physicalverf
(
  id int not null identity(1,1) primary key,
  sitestructure_verfid int,
  comp_id int,
  qrcode int,
  remarks varchar(2000),
  status varchar(50) null,
  created_by int null,
  created_at datetime default CURRENT_TIMESTAMP,
  updated_by int null,
  updated_at datetime null,
  CONSTRAINT SIT_site_comp_physicalverf_site_structure_physicalverf_fkey FOREIGN KEY (sitestructure_verfid) REFERENCES site_structure_physicalverf(id),
)

select *
from INFORMATION_SCHEMA.TABLES t 





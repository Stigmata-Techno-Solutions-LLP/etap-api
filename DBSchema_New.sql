


 IF OBJECT_ID('ETapManagement.dbo.disp_fabrication_cost', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_fabrication_cost ;

 IF OBJECT_ID('ETapManagement.dbo.site_comp_physicalverf', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.site_comp_physicalverf ;

IF OBJECT_ID('ETapManagement.dbo.site_structure_physicalverf', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.site_structure_physicalverf ;

IF OBJECT_ID('ETapManagement.dbo.site_physical_verf', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.site_physical_verf ;

IF OBJECT_ID('ETapManagement.dbo.component_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component_history ;


IF OBJECT_ID('ETapManagement.dbo.project_structure_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project_structure_documents;


IF OBJECT_ID('ETapManagement.dbo.disp_subcont_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_subcont_documents;

IF OBJECT_ID('ETapManagement.dbo.disp_subcont_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_subcont_structure;


IF OBJECT_ID('ETapManagement.dbo.dispatchreq_subcont', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.dispatchreq_subcont;



IF OBJECT_ID('ETapManagement.dbo.disp_mod_stage_component', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_mod_stage_component;

IF OBJECT_ID('ETapManagement.dbo.disp_structure_comp', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_structure_comp;


IF OBJECT_ID('ETapManagement.dbo.disp_structure_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_structure_documents;


IF OBJECT_ID('ETapManagement.dbo.disp_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_req_structure;


IF OBJECT_ID('ETapManagement.dbo.disreq_status_history', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disreq_status_history;

IF OBJECT_ID('ETapManagement.dbo.disp_req_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.disp_req_structure;



IF OBJECT_ID('ETapManagement.dbo.dispatch_requirement', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.dispatch_requirement;

IF OBJECT_ID('ETapManagement.dbo.sitedecl_documents', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.sitedecl_documents;


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


IF OBJECT_ID('ETapManagement.dbo.work_breakdown', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.work_breakdown;


IF OBJECT_ID('ETapManagement.dbo.users', 'U') IS NOT NULL 
DROP TABLE ETapManagement.dbo.users;


IF OBJECT_ID('ETapManagement.dbo.audit_logs', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.audit_logs;

IF OBJECT_ID('ETapManagement.dbo.roles_applicationforms', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.roles_applicationforms;


IF OBJECT_ID('ETapManagement.dbo.application_forms', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.application_forms;

IF OBJECT_ID('ETapManagement.dbo.project_sitelocation', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project_sitelocation ;



IF OBJECT_ID('ETapManagement.dbo.component', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.component;


IF OBJECT_ID('ETapManagement.dbo.project_structure', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project_structure;


IF OBJECT_ID('ETapManagement.dbo.project', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.project;


IF OBJECT_ID('ETapManagement.dbo.structures', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.structures;

IF OBJECT_ID('ETapManagement.dbo.strategic_business', 'U') IS NOT NULL 
  DROP TABLE ETapManagement.dbo.strategic_business ;

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
  DROP TABLE ETapManagement.dbo.role_hierarchy;

 

-- -- DROP TABLE

-- -- DROP TABLE ETapManagementSIT2.dbo.application_forms 

CREATE TABLE ETapManagementSIT2.dbo.application_forms (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	description varchar(300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	isAdd bit NULL,
	isUpdate bit NULL,
	isDelete bit NULL,
	isView bit NULL,
	CONSTRAINT application_forms_name_key UNIQUE (name),
	CONSTRAINT page_pkey PRIMARY KEY (id)
) 
CREATE UNIQUE INDEX application_forms_name_key ON ETapManagementSIT2.dbo.application_forms (name) ;


-- ETapManagementSIT2.dbo.audit_logs definition

-- -- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.audit_logs 

CREATE TABLE ETapManagementSIT2.dbo.audit_logs (
	id int IDENTITY(1,1) NOT NULL,
	[action] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	message varchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	CONSTRAINT auditlog_pkey PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.component_type definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.component_type 

CREATE TABLE ETapManagementSIT2.dbo.component_type (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	description varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_delete bit DEFAULT 0 NULL,
	is_active bit NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__componen__3213E83F568EF532 PRIMARY KEY (id),
	CONSTRAINT UQ__componen__72E12F1B396403F9 UNIQUE (name)
) 
CREATE UNIQUE INDEX UQ__componen__72E12F1B396403F9 ON ETapManagementSIT2.dbo.component_type (name) ;


-- ETapManagementSIT2.dbo.independent_company definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.independent_company 

CREATE TABLE ETapManagementSIT2.dbo.independent_company (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	description varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_active bit DEFAULT 1 NOT NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__independ__3213E83FC05B418C PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.role_hierarchy definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.role_hierarchy 

CREATE TABLE ETapManagementSIT2.dbo.role_hierarchy (
	id int IDENTITY(1,1) NOT NULL,
	role_name varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	scenario_type varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_hierarchy int NULL,
	new_status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	chk_status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	view_details_status varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	service_type varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__role_hie__3213E83FB7A46A91 PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.roles definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.roles 

CREATE TABLE ETapManagementSIT2.dbo.roles (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	description varchar(300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[level] int NULL,
	CONSTRAINT site_roles_name_key UNIQUE (name),
	CONSTRAINT site_roles_pkey PRIMARY KEY (id)
) 
CREATE UNIQUE INDEX site_roles_name_key ON ETapManagementSIT2.dbo.roles (name) ;


-- ETapManagementSIT2.dbo.segment definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.segment 

CREATE TABLE ETapManagementSIT2.dbo.segment (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	description varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__segment__3213E83FBD863FCE PRIMARY KEY (id),
	CONSTRAINT UQ__segment__72E12F1BB60B301A UNIQUE (name)
) 
CREATE UNIQUE INDEX UQ__segment__72E12F1BB60B301A ON ETapManagementSIT2.dbo.segment (name) ;


-- ETapManagementSIT2.dbo.service_type definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.service_type 

CREATE TABLE ETapManagementSIT2.dbo.service_type (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	description varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__service___3213E83FDC739188 PRIMARY KEY (id),
	CONSTRAINT UQ__service___72E12F1BC5E41A68 UNIQUE (name)
) 
CREATE UNIQUE INDEX UQ__service___72E12F1BC5E41A68 ON ETapManagementSIT2.dbo.service_type (name) ;


-- ETapManagementSIT2.dbo.site_physical_verf definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_physical_verf 

CREATE TABLE ETapManagementSIT2.dbo.site_physical_verf (
	id int IDENTITY(1,1) NOT NULL,
	duedate_from datetime NULL,
	duedate_to datetime NULL,
	inspection_id varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	CONSTRAINT PK__site_phy__3213E83F9853B11A PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.strategic_business definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.strategic_business 

CREATE TABLE ETapManagementSIT2.dbo.strategic_business (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	is_active bit NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT strategic_business_pkey PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.structure_type definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.structure_type 

CREATE TABLE ETapManagementSIT2.dbo.structure_type (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	is_active bit DEFAULT 1 NOT NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	description varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__structur__3213E83F1851D90C PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.sub_contractor definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.sub_contractor 

CREATE TABLE ETapManagementSIT2.dbo.sub_contractor (
	id int IDENTITY(1,1) NOT NULL,
	vendor_code varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	name varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	email varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	phone_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_delete bit DEFAULT 0 NULL,
	is_status bit DEFAULT 0 NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT subcont_pkey PRIMARY KEY (id)
) ;


-- ETapManagementSIT2.dbo.business_unit definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.business_unit 

CREATE TABLE ETapManagementSIT2.dbo.business_unit (
	id int IDENTITY(1,1) NOT NULL,
	ic_id int NOT NULL,
	name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	is_active bit NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	sbg_id int NULL,
	CONSTRAINT business_unit_pkey PRIMARY KEY (id),
	CONSTRAINT business_unit_icId_IC__fkey FOREIGN KEY (ic_id) REFERENCES ETapManagementSIT2.dbo.independent_company(id),
	CONSTRAINT business_unit_sbgId_SBG__fkey FOREIGN KEY (sbg_id) REFERENCES ETapManagementSIT2.dbo.strategic_business(id)
) ;


-- ETapManagementSIT2.dbo.project definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.project 

CREATE TABLE ETapManagementSIT2.dbo.project (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	proj_code varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	area varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ic_id int NOT NULL,
	bu_id int NOT NULL,
	job_code varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	edrc_code varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	is_active bit NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT project_pkey PRIMARY KEY (id),
	CONSTRAINT project_buId_BU__fkey FOREIGN KEY (bu_id) REFERENCES ETapManagementSIT2.dbo.business_unit(id),
	CONSTRAINT project_icId_IC__fkey FOREIGN KEY (ic_id) REFERENCES ETapManagementSIT2.dbo.independent_company(id)
) ;


-- ETapManagementSIT2.dbo.project_sitelocation definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.project_sitelocation 

CREATE TABLE ETapManagementSIT2.dbo.project_sitelocation (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	project_id int NOT NULL,
	CONSTRAINT project_sitelocation_pkey PRIMARY KEY (id),
	CONSTRAINT project_sitelocation_projectId_fkey FOREIGN KEY (project_id) REFERENCES ETapManagementSIT2.dbo.project(id)
) ;


-- ETapManagementSIT2.dbo.roles_applicationforms definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.roles_applicationforms 

CREATE TABLE ETapManagementSIT2.dbo.roles_applicationforms (
	id int IDENTITY(1,1) NOT NULL,
	form_id int NOT NULL,
	role_id int NOT NULL,
	isAdd bit NULL,
	isUpdate bit NULL,
	isDelete bit NULL,
	isView bit NULL,
	CONSTRAINT roles_forms_pkey PRIMARY KEY (id),
	CONSTRAINT rolesforms_forms_id_fkey FOREIGN KEY (form_id) REFERENCES ETapManagementSIT2.dbo.application_forms(id),
	CONSTRAINT rolesforms_roles_id_fkey FOREIGN KEY (role_id) REFERENCES ETapManagementSIT2.dbo.roles(id)
) ;


-- ETapManagementSIT2.dbo.site_requirement definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_requirement 

CREATE TABLE ETapManagementSIT2.dbo.site_requirement (
	id int IDENTITY(1,1) NOT NULL,
	mr_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	from_project_id int NOT NULL,
	remarks varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NOT NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	CONSTRAINT PK__site_req__3213E83FC195E882 PRIMARY KEY (id),
	CONSTRAINT UQ__site_req__AE8CB972C5005D06 UNIQUE (mr_no),
	CONSTRAINT siteReq_proj_fkey FOREIGN KEY (from_project_id) REFERENCES ETapManagementSIT2.dbo.project(id)
) 
CREATE UNIQUE INDEX UQ__site_req__AE8CB972C5005D06 ON ETapManagementSIT2.dbo.site_requirement (mr_no) ;


-- ETapManagementSIT2.dbo.sitereq_status_history definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.sitereq_status_history 

CREATE TABLE ETapManagementSIT2.dbo.sitereq_status_history (
	id int IDENTITY(1,1) NOT NULL,
	mr_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	sitereq_id int NOT NULL,
	notes varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__sitereq___3213E83F6E97E4A7 PRIMARY KEY (id),
	CONSTRAINT sitereq_status_history_sitereq_fkey FOREIGN KEY (sitereq_id) REFERENCES ETapManagementSIT2.dbo.site_requirement(id)
) ;


-- ETapManagementSIT2.dbo.structures definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.structures 

CREATE TABLE ETapManagementSIT2.dbo.structures (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	structure_type_id int NOT NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	is_active bit NULL,
	structure_attributes_def nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT structure_pkey PRIMARY KEY (id),
	CONSTRAINT structures_structuretype_fkey FOREIGN KEY (structure_type_id) REFERENCES ETapManagementSIT2.dbo.structure_type(id)
) ;


-- ETapManagementSIT2.dbo.subContractor_serviceType definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.subContractor_serviceType 

CREATE TABLE ETapManagementSIT2.dbo.subContractor_serviceType (
	id int IDENTITY(1,1) NOT NULL,
	subcont_id int NOT NULL,
	servicetype_id int NOT NULL,
	CONSTRAINT subST_pkey PRIMARY KEY (id),
	CONSTRAINT subST_servieType_fkey FOREIGN KEY (servicetype_id) REFERENCES ETapManagementSIT2.dbo.service_type(id),
	CONSTRAINT subST_subconractor_fkey FOREIGN KEY (subcont_id) REFERENCES ETapManagementSIT2.dbo.sub_contractor(id)
) ;


-- ETapManagementSIT2.dbo.users definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.users 

CREATE TABLE ETapManagementSIT2.dbo.users (
	id int IDENTITY(1,1) NOT NULL,
	project_id int NOT NULL,
	ic_id int NOT NULL,
	bu_id int NOT NULL,
	ps_no varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	password varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	first_name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	last_name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	phoneno varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	email varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NOT NULL,
	is_active bit DEFAULT 1 NULL,
	is_delete bit DEFAULT 0 NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_at datetime DEFAULT getdate() NULL,
	created_by int NULL,
	updated_by int NULL,
	vendor_id int NULL,
	CONSTRAINT users_pkey PRIMARY KEY (id),
	CONSTRAINT user_roles_id_fkey FOREIGN KEY (role_id) REFERENCES ETapManagementSIT2.dbo.roles(id),
	CONSTRAINT users_bu_fkey FOREIGN KEY (bu_id) REFERENCES ETapManagementSIT2.dbo.business_unit(id),
	CONSTRAINT users_ic_fkey FOREIGN KEY (ic_id) REFERENCES ETapManagementSIT2.dbo.independent_company(id),
	CONSTRAINT users_proj_fkey FOREIGN KEY (project_id) REFERENCES ETapManagementSIT2.dbo.project(id)
) ;


-- ETapManagementSIT2.dbo.work_breakdown definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.work_breakdown 

CREATE TABLE ETapManagementSIT2.dbo.work_breakdown (
	id int IDENTITY(1,1) NOT NULL,
	wbs_id varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	project_id int NOT NULL,
	name varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	elements varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_delete bit DEFAULT 0 NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	segment varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	sub_segment varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT wbs_pkey PRIMARY KEY (id),
	CONSTRAINT wbs_proj_fkey FOREIGN KEY (project_id) REFERENCES ETapManagementSIT2.dbo.project(id)
) ;


-- ETapManagementSIT2.dbo.project_structure definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.project_structure 

CREATE TABLE ETapManagementSIT2.dbo.project_structure (
	id int IDENTITY(1,1) NOT NULL,
	structure_id int NOT NULL,
	struct_code varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	project_id int NOT NULL,
	components_count int NULL,
	structure_attributes_val nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	estimated_weight decimal(10,2) NULL,
	structure_status varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	current_status varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_delete bit DEFAULT 0 NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	exp_release_date datetime NULL,
	drawing_no varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	actual_wbs int NULL,
	fabrication_year datetime NULL,
	remarks varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	actual_weight decimal(18,2) NULL,
	reusuability bit NULL,
	fabriacation_cost decimal(10,0) NULL,
	CONSTRAINT projstructure_pkey PRIMARY KEY (id),
	CONSTRAINT projstructure_proj_fkey FOREIGN KEY (project_id) REFERENCES ETapManagementSIT2.dbo.project(id),
	CONSTRAINT projstructure_structures_fkey FOREIGN KEY (structure_id) REFERENCES ETapManagementSIT2.dbo.structures(id)
) ;


-- ETapManagementSIT2.dbo.project_structure_documents definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.project_structure_documents 

CREATE TABLE ETapManagementSIT2.dbo.project_structure_documents (
	id int IDENTITY(1,1) NOT NULL,
	project_structure_id int NOT NULL,
	file_name varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	file_type varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT project_structure_documents_pkey PRIMARY KEY (id),
	CONSTRAINT project_structure_id_psID_fkey FOREIGN KEY (project_structure_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id)
) ;


-- ETapManagementSIT2.dbo.scrap_structure definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.scrap_structure 

CREATE TABLE ETapManagementSIT2.dbo.scrap_structure (
	id int IDENTITY(1,1) NOT NULL,
	subcon_id int NULL,
	proj_struct_id int NULL,
	scrap_rate decimal(10,2) NULL,
	auction_id varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	role_id int NULL,
	from_project_id int NULL,
	disp_structure_id int NULL,
	CONSTRAINT PK__scrap_st__3213E83F72AA0607 PRIMARY KEY (id),
	CONSTRAINT scrap_structure_subcon_fkey FOREIGN KEY (subcon_id) REFERENCES ETapManagementSIT2.dbo.sub_contractor(id),
	CONSTRAINT scrap_strucure_projstructure_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id)
) ;


-- ETapManagementSIT2.dbo.site_declaration definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_declaration 

CREATE TABLE ETapManagementSIT2.dbo.site_declaration (
	id int IDENTITY(1,1) NOT NULL,
	sitereq_id int NULL,
	proj_struct_id int NULL,
	from_project_id int NULL,
	surplus_fromdate datetime NOT NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	notes varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	CONSTRAINT PK__site_dec__3213E83F774BB95E PRIMARY KEY (id),
	CONSTRAINT siteDec_projstructure_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id),
	CONSTRAINT siteDec_siteReq_fkey FOREIGN KEY (sitereq_id) REFERENCES ETapManagementSIT2.dbo.site_requirement(id)
) ;


-- ETapManagementSIT2.dbo.site_req_structure definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_req_structure 

CREATE TABLE ETapManagementSIT2.dbo.site_req_structure (
	id int IDENTITY(1,1) NOT NULL,
	site_req_id int NOT NULL,
	struct_id int NOT NULL,
	structure_attributes_val nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	plan_startdate datetime NOT NULL,
	plan_releasedate datetime NOT NULL,
	actual_startdate datetime NOT NULL,
	actual_releasedate datetime NOT NULL,
	require_wbs_id int NOT NULL,
	actual_wbs_id int NOT NULL,
	quantity int NULL,
	status varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__site_req__3213E83F9CFDDCC9 PRIMARY KEY (id),
	CONSTRAINT siteReqStructire_siteReq_fkey FOREIGN KEY (site_req_id) REFERENCES ETapManagementSIT2.dbo.site_requirement(id),
	CONSTRAINT siteReqStructire_structure_fkey FOREIGN KEY (struct_id) REFERENCES ETapManagementSIT2.dbo.structures(id)
) ;


-- ETapManagementSIT2.dbo.site_structure_physicalverf definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_structure_physicalverf 

CREATE TABLE ETapManagementSIT2.dbo.site_structure_physicalverf (
	id int IDENTITY(1,1) NOT NULL,
	site_verf_id int NULL,
	project_id int NULL,
	proj_struct_id int NULL,
	duedate_from datetime NULL,
	duedate_to datetime NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__site_str__3213E83FCA6FA223 PRIMARY KEY (id),
	CONSTRAINT site_structure_physicalverf_proj_fkey FOREIGN KEY (project_id) REFERENCES ETapManagementSIT2.dbo.project(id),
	CONSTRAINT site_structure_physicalverf_site_physical_verf_fkey FOREIGN KEY (site_verf_id) REFERENCES ETapManagementSIT2.dbo.site_physical_verf(id),
	CONSTRAINT site_structure_physicalverf_strucutre_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id)
) ;


-- ETapManagementSIT2.dbo.sitedecl_documents definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.sitedecl_documents 

CREATE TABLE ETapManagementSIT2.dbo.sitedecl_documents (
	id int IDENTITY(1,1) NOT NULL,
	sitedec_id int NOT NULL,
	file_name varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	file_type varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT sitedecl_documents_pkey PRIMARY KEY (id),
	CONSTRAINT sitedecl_documents_sitedecl_fkey FOREIGN KEY (sitedec_id) REFERENCES ETapManagementSIT2.dbo.site_declaration(id)
) ;


-- ETapManagementSIT2.dbo.sitedecl_status_history definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.sitedecl_status_history 

CREATE TABLE ETapManagementSIT2.dbo.sitedecl_status_history (
	id int IDENTITY(1,1) NOT NULL,
	sitedec_id int NULL,
	notes varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__sitedecl__3213E83F38EB8188 PRIMARY KEY (id),
	CONSTRAINT siteDeclStatus_siteDec_fkey FOREIGN KEY (sitedec_id) REFERENCES ETapManagementSIT2.dbo.site_declaration(id)
) ;


-- ETapManagementSIT2.dbo.component definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.component 

CREATE TABLE ETapManagementSIT2.dbo.component (
	id int IDENTITY(1,1) NOT NULL,
	proj_struct_id int NOT NULL,
	comp_id varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	comp_type_id int NOT NULL,
	component_no int NULL,
	comp_name varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_group bit DEFAULT 0 NULL,
	leng decimal(10,6) NULL,
	breath decimal(10,6) NULL,
	height decimal(10,6) NULL,
	thickness decimal(10,6) NULL,
	weight decimal(10,6) NULL,
	make_type varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_tag bit NULL,
	qr_code varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	is_delete bit DEFAULT 0 NULL,
	is_active bit DEFAULT 0 NULL,
	comp_status varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	drawing_no varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	fabriacation_cost decimal(10,0) NULL,
	CONSTRAINT comp_pkey PRIMARY KEY (id),
	CONSTRAINT comp_comptype_fkey FOREIGN KEY (comp_type_id) REFERENCES ETapManagementSIT2.dbo.component_type(id),
	CONSTRAINT comp_projstruct_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id)
) ;


-- ETapManagementSIT2.dbo.component_history definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.component_history 

CREATE TABLE ETapManagementSIT2.dbo.component_history (
	id int IDENTITY(1,1) NOT NULL,
	proj_struct_id int NOT NULL,
	comp_id varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	comp_type_id int NOT NULL,
	component_no int NULL,
	is_group bit DEFAULT 0 NULL,
	leng decimal(10,6) NULL,
	breath decimal(10,6) NULL,
	height decimal(10,6) NULL,
	thickness decimal(10,6) NULL,
	weight decimal(10,6) NULL,
	make_type varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	is_tag bit NULL,
	qr_code varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	is_delete bit DEFAULT 0 NULL,
	is_active bit DEFAULT 0 NULL,
	comp_status varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	drawing_no varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT comphistory_pkey PRIMARY KEY (id),
	CONSTRAINT comphistory_comptype_fkey FOREIGN KEY (comp_type_id) REFERENCES ETapManagementSIT2.dbo.component_type(id),
	CONSTRAINT comphistory_projstruct_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id)
) ;


-- ETapManagementSIT2.dbo.dispatch_requirement definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.dispatch_requirement 

CREATE TABLE ETapManagementSIT2.dbo.dispatch_requirement (
	id int IDENTITY(1,1) NOT NULL,
	dispatch_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	sitereq_id int NULL,
	to_projectid int NULL,
	servicetype_id int NULL,
	quantity int NULL,
	transfer_price decimal(10,2) NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	site_req_structid int NULL,
	CONSTRAINT PK__dispatch__3213E83F08EA011E PRIMARY KEY (id),
	CONSTRAINT UQ__dispatch__F7205CCDFAFBA6D9 UNIQUE (dispatch_no),
	CONSTRAINT dispatch_requirement_proj_fkey FOREIGN KEY (to_projectid) REFERENCES ETapManagementSIT2.dbo.project(id),
	CONSTRAINT dispatch_requirement_servicetype_fkey FOREIGN KEY (servicetype_id) REFERENCES ETapManagementSIT2.dbo.service_type(id),
	CONSTRAINT dispatch_requirement_siteReq_fkey FOREIGN KEY (sitereq_id) REFERENCES ETapManagementSIT2.dbo.site_requirement(id),
	CONSTRAINT dispatch_requirement_siteReqstructure_fkey FOREIGN KEY (site_req_structid) REFERENCES ETapManagementSIT2.dbo.site_req_structure(id)
) 
CREATE UNIQUE INDEX UQ__dispatch__F7205CCDFAFBA6D9 ON ETapManagementSIT2.dbo.dispatch_requirement (dispatch_no) ;


-- ETapManagementSIT2.dbo.dispatchreq_subcont definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.dispatchreq_subcont 

CREATE TABLE ETapManagementSIT2.dbo.dispatchreq_subcont (
	id int IDENTITY(1,1) NOT NULL,
	dispreq_id int NULL,
	dispatch_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	subcon_id int NULL,
	servicetype_id int NULL,
	workorder_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	quantity int NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	is_delete bit DEFAULT 0 NOT NULL,
	CONSTRAINT PK__dispatch__3213E83FB68E0A4F PRIMARY KEY (id),
	CONSTRAINT dispatchreq_subcont_dispatch_requirement_fkey FOREIGN KEY (dispreq_id) REFERENCES ETapManagementSIT2.dbo.dispatch_requirement(id),
	CONSTRAINT dispatchreq_subcont_servicetype_fkey FOREIGN KEY (servicetype_id) REFERENCES ETapManagementSIT2.dbo.service_type(id),
	CONSTRAINT dispatchreq_subcont_subcont_fkey FOREIGN KEY (subcon_id) REFERENCES ETapManagementSIT2.dbo.sub_contractor(id)
) ;


-- ETapManagementSIT2.dbo.disreq_status_history definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disreq_status_history 

CREATE TABLE ETapManagementSIT2.dbo.disreq_status_history (
	id int IDENTITY(1,1) NOT NULL,
	dispatch_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	dispreq_id int NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	notes varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	CONSTRAINT PK__disreq_s__3213E83FCFEF97C1 PRIMARY KEY (id),
	CONSTRAINT dispatch_requirement_statushistory_dispreq_fkey FOREIGN KEY (dispreq_id) REFERENCES ETapManagementSIT2.dbo.dispatch_requirement(id)
) ;


-- ETapManagementSIT2.dbo.scrap_status_history definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.scrap_status_history 

CREATE TABLE ETapManagementSIT2.dbo.scrap_status_history (
	id int IDENTITY(1,1) NOT NULL,
	scrap_stuctre_id int NULL,
	notes varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__scrap_st__3213E83F3ACAA346 PRIMARY KEY (id),
	CONSTRAINT scrap_status_history_scrapstructure_fkey FOREIGN KEY (scrap_stuctre_id) REFERENCES ETapManagementSIT2.dbo.scrap_structure(id)
) ;


-- ETapManagementSIT2.dbo.site_comp_physicalverf definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_comp_physicalverf 

CREATE TABLE ETapManagementSIT2.dbo.site_comp_physicalverf (
	id int IDENTITY(1,1) NOT NULL,
	sitestructure_verfid int NULL,
	comp_id int NULL,
	qrcode int NULL,
	remarks varchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__site_com__3213E83F529BF61A PRIMARY KEY (id),
	CONSTRAINT site_comp_physicalverf_site_structure_physicalverf_fkey FOREIGN KEY (sitestructure_verfid) REFERENCES ETapManagementSIT2.dbo.site_structure_physicalverf(id)
) ;


-- ETapManagementSIT2.dbo.site_strct_physicalverf_doc definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.site_strct_physicalverf_doc 

CREATE TABLE ETapManagementSIT2.dbo.site_strct_physicalverf_doc (
	id int IDENTITY(1,1) NOT NULL,
	site_structure_physicalverf_id int NOT NULL,
	file_name varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	file_type varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT site_strct_physicalverf_doc_pkey PRIMARY KEY (id),
	CONSTRAINT site_structure_physicalverf_id_sspID_fkey FOREIGN KEY (site_structure_physicalverf_id) REFERENCES ETapManagementSIT2.dbo.site_structure_physicalverf(id)
) ;


-- ETapManagementSIT2.dbo.disp_req_structure definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_req_structure 

CREATE TABLE ETapManagementSIT2.dbo.disp_req_structure (
	id int IDENTITY(1,1) NOT NULL,
	dispreq_id int NULL,
	proj_struct_id int NULL,
	is_modification bit NULL,
	disp_structure_id int NULL,
	disp_struct_status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	from_project_id int NULL,
	surplus_date datetime NULL,
	fabriacation_cost decimal(10,0) NULL,
	CONSTRAINT PK__disp_req__3213E83F381D5DC3 PRIMARY KEY (id),
	CONSTRAINT DispReqStructire_siteReq_fkey FOREIGN KEY (dispreq_id) REFERENCES ETapManagementSIT2.dbo.dispatch_requirement(id),
	CONSTRAINT DispReqStructire_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id)
) ;


-- ETapManagementSIT2.dbo.disp_structure_comp definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_structure_comp 

CREATE TABLE ETapManagementSIT2.dbo.disp_structure_comp (
	id int IDENTITY(1,1) NOT NULL,
	disp_structure_id int NOT NULL,
	disp_comp_id int NOT NULL,
	last_scandate datetime NULL,
	comp_status varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	remarks varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	scanned_by int NULL,
	dispatch_date datetime NULL,
	from_scandate datetime NULL,
	from_scan_by int NULL,
	fabriacation_cost decimal(10,0) NULL,
	CONSTRAINT disp_structure_comp_pkey PRIMARY KEY (id),
	CONSTRAINT disp_req_structure_comp_id_CompID_fkey FOREIGN KEY (disp_comp_id) REFERENCES ETapManagementSIT2.dbo.component(id),
	CONSTRAINT disp_req_structure_comp_id_StructureID_fkey FOREIGN KEY (disp_structure_id) REFERENCES ETapManagementSIT2.dbo.disp_req_structure(id)
) ;


-- ETapManagementSIT2.dbo.disp_structure_documents definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_structure_documents 

CREATE TABLE ETapManagementSIT2.dbo.disp_structure_documents (
	id int IDENTITY(1,1) NOT NULL,
	disp_structure_id int NOT NULL,
	file_name varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	file_type varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT disp_structure_documents_pkey PRIMARY KEY (id),
	CONSTRAINT disp_req_structure_docs_id_docsID_fkey FOREIGN KEY (disp_structure_id) REFERENCES ETapManagementSIT2.dbo.disp_req_structure(id)
) ;


-- ETapManagementSIT2.dbo.disp_subcont_documents definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_subcont_documents 

CREATE TABLE ETapManagementSIT2.dbo.disp_subcont_documents (
	id int IDENTITY(1,1) NOT NULL,
	disp_subcont_id int NOT NULL,
	file_name varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	file_type varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT disp_subcont_documents_pkey PRIMARY KEY (id),
	CONSTRAINT disp_subcont_id_docsID_fkey FOREIGN KEY (disp_subcont_id) REFERENCES ETapManagementSIT2.dbo.dispatchreq_subcont(id)
) ;


-- ETapManagementSIT2.dbo.disp_subcont_structure definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_subcont_structure 

CREATE TABLE ETapManagementSIT2.dbo.disp_subcont_structure (
	id int IDENTITY(1,1) NOT NULL,
	dispreqsubcont_id int NULL,
	proj_struct_id int NULL,
	is_Delivered bit DEFAULT 0 NULL,
	fabrication_cost decimal(10,2) NULL,
	monthly_rent decimal(10,2) NULL,
	contract_years decimal(10,2) NULL,
	plan_releasedate datetime NULL,
	expected_releasedate datetime NULL,
	actual_startdate datetime NULL,
	dispatch_date datetime NULL,
	disp_structure_id int NULL,
	CONSTRAINT PK__disp_sub__3213E83F47B4A99C PRIMARY KEY (id),
	CONSTRAINT disp_subcont_structure_structure_fkey FOREIGN KEY (proj_struct_id) REFERENCES ETapManagementSIT2.dbo.project_structure(id),
	CONSTRAINT dispreqsubcont_structure_siteReq_fkey FOREIGN KEY (dispreqsubcont_id) REFERENCES ETapManagementSIT2.dbo.dispatchreq_subcont(id)
) ;


-- ETapManagementSIT2.dbo.disp_fabrication_cost definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_fabrication_cost 

CREATE TABLE ETapManagementSIT2.dbo.disp_fabrication_cost (
	id int IDENTITY(1,1) NOT NULL,
	dispatch_no varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	disp_req_id int NOT NULL,
	disp_structure_id int NULL,
	assinged_project_id int NULL,
	status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status_internal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	role_id int NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	updated_by int NULL,
	updated_at datetime NULL,
	CONSTRAINT PK__disp_fab__3213E83F17579B13 PRIMARY KEY (id),
	CONSTRAINT UQ__disp_fab__F7205CCDFC4F1D62 UNIQUE (dispatch_no),
	CONSTRAINT fabrication_cost_disp_structure_id_fkey FOREIGN KEY (disp_structure_id) REFERENCES ETapManagementSIT2.dbo.disp_req_structure(id),
	CONSTRAINT fabrication_cost_proj_fkey FOREIGN KEY (assinged_project_id) REFERENCES ETapManagementSIT2.dbo.project(id)
) 
CREATE UNIQUE INDEX UQ__disp_fab__F7205CCDFC4F1D62 ON ETapManagementSIT2.dbo.disp_fabrication_cost (dispatch_no) ;


-- ETapManagementSIT2.dbo.disp_mod_stage_component definition

-- -- DROP TABLE

-- DROP TABLE ETapManagementSIT2.dbo.disp_mod_stage_component 

CREATE TABLE ETapManagementSIT2.dbo.disp_mod_stage_component (
	id int IDENTITY(1,1) NOT NULL,
	dispstruct_comp_id int NULL,
	leng decimal(10,6) NULL,
	breath decimal(10,6) NULL,
	height decimal(10,6) NULL,
	thickness decimal(10,6) NULL,
	weight decimal(10,6) NULL,
	make_type varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	addplate varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	qr_code varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	created_by int NULL,
	created_at datetime DEFAULT getdate() NULL,
	CONSTRAINT compmodif_pkey PRIMARY KEY (id),
	CONSTRAINT compmodif_dispcomp_fkey FOREIGN KEY (dispstruct_comp_id) REFERENCES ETapManagementSIT2.dbo.disp_structure_comp(id)
) ;

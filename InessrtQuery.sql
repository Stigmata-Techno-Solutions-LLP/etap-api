



delete from disp_mod_stage_component 

delete from disp_structure_comp

delete from disp_req_structure 
delete from disreq_status_history 


delete from disp_subcont_documents 
delete from disp_subcont_structure 
delete from dispatchreq_subcont 

delete from dispatch_requirement

delete from dispatchreq_subcont 


insert into roles values('Admin','Admin',1);
insert into roles values ('IC','IC',2)
insert into roles values ('SBG','SBG',3)
insert into roles values ('BU','BU',4)
insert into roles values ('CMPC','CMPC',5)
insert into roles values ('TWCC','TWCC',6)
insert into roles values ('PROJECTS','PROJECTS',7)
insert into roles values ('PROCUREMENT','PROCUREMENT',8)
insert into roles values ('QA','QA',9)

insert into roles values ('FAA','FAA',10)

insert into roles values ('EHS','EHS',11)
insert into roles values ('VENDOR','VENDOR',12)
insert into roles values('SITE','SITE',13);


insert into independent_company  values('HCIC','',1,0,1,getdate(),null,null)

insert into strategic_business  values('STG1',0,1,1,getdate(),null,null)

insert into business_unit  values(1,'Metros',1,0,1,getdate(),null,null,1)
insert into business_unit  values(1,'Nuclear',1,0,1,getdate(),null,null,1)
insert into business_unit  values(1,'Port',1,0,1,getdate(),null,null,1)

insert into segment values ('SEG001','')


insert into project   values ('BMRC RT 02','PROJ001',200,1,1,'JOB001','ERDC0001',0,1,1,getdate(),null,null)
insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('admin','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,1,getdate(),null,null,null,1,1,1)

insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_bu','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,4,getdate(),null,null,null,1,1,1)

insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_twcc','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,6,getdate(),null,null,null,1,1,1)

insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_cmpc','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,5,getdate(),null,null,null,1,1,1)

insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_site','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,13,getdate(),null,null,null,1,1,1)

insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_vendor','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,12,getdate(),null,null,null,1,1,1)
insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_qa','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,9,getdate(),null,null,null,1,1,1)
insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_ehs','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,11,getdate(),null,null,null,1,1,1)
insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_faa','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,10,getdate(),null,null,null,1,1,1)
insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('stig_proc','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,8,getdate(),null,null,null,1,1,1)


INSERT INTO [service_type]([name] ,[description]) VALUES('Fabrication' ,'Fabrication')
INSERT INTO [service_type]([name] ,[description]) VALUES('Outsourcing' ,'Outsourcing')
INSERT INTO [service_type]([name] ,[description]) VALUES('Scrap' ,'Scrap')
insert into service_type values('Reuse','Reuse')




insert into component_type values('COMP1','',0,1,1,getdate(),null,null)
insert into structure_type values('LG & Bridge Builders',1,0,'',1,getdate(),null,null)


INSERT INTO role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status,service_type) VALUES 
('SITE','REQUIREMENT',1,'NEW','REJECT','REJECT,NEW,BU APPROVED,CMPC APPROVED,TWCC APPROVED,READY TO DISPATCH',NULL)
,('BU','REQUIREMENT',2,'BU APPROVED','NEW','NEW,BU APPROVED,CMPC APPROVED,TWCC APPROVED,READY TO DISPATCH',NULL)
,('CMPC','REQUIREMENT',3,'CMPC APPROVED','BU APPROVED,TWCC APPROVED','BU APPROVED,CMPC APPROVED,TWCC APPROVED,READY TO DISPATCH',NULL)
,('TWCC','REQUIREMENT',3,'TWCC APPROVED','BU APPROVED,CMPC APPROVED','BU APPROVED,CMPC APPROVED,TWCC APPROVED,READY TO DISPATCH',NULL)
,('TWCC','REQUIREMENT',4,'DISPATCHED','READY TO DISPATCH,PARTIALLY DISPATCHED','READY TO DISPATCH,PARTIALLY DISPATCHED',NULL)
,('SITE','DECLARATION',1,'NEW','','REJECT,NEW,BU APPROVED,CMPC APPROVED,TWCC APPROVED,READY TO REUSE,EHS REJECTED,QA REJECTED',NULL)
,('EHS','DECLARATION',2,'EHS APPROVED','NEW','EHS APPROVED,READY TO REUSE,EHS REJECTED,QA REJECTED,QA APPROVED',NULL)
,('QA','DECLARATION',3,'QA APPROVED','EHS APPROVED','READY TO REUSE,QA REJECTED,TWCC REJECTED',NULL)
,('PROCUREMENT','DECLARATION',3,NULL,'EHSREJECTED,QAREJECTED,TWCCREJECTED','',NULL)
,('TWCC','DECLARATION',4,'READY TO REUSE','QA APPROVED','READY TO REUSE,QA APPROVED',NULL)
;
INSERT INTO role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status,service_type) VALUES 
('CMPC','DECLARATION',5,'READY TO REUSE','','READY TO REUSE',NULL)
,('BU','DECLARATION',6,'READY TO REUSE','','READY TO REUSE',NULL)
,('PROCUREMENT','DECLARATION',7,'SCRAPPED','QA REJECTED,EHS REJECTED','',NULL)
,('PROCUREMENT','DISPATCH',1,'PROC APPROVED','CMPC APPROVED','TOSITE APPROVED,FAA APPROVED,FROMSITE APPROVED,DISPATCHED,CMPC APPROVED','1,2')
,('CMPC','DISPATCH',1,'CMPCAPPROVED','NEW',NULL,'4')
,('FAA','DISPATCH',2,'FAA APPROVED','CMPC APPROVED','TOSITE APPROVED,FAA APPROVED,FROMSITE APPROVED,DISPATCHED','4')
,('SITE','DISPATCH',3,'FROMSITE APPROVED','FAA APPROVED','FAA APPROVED','4')
,('SITE','DISPATCH',4,'TOSITE APPROVED','PROC APPROVED,FROMSITE APPROVED','REJECT,NEW,PROC APPROVED,TOSITE APPROVED,VENDOR APPROVED,FAA APPROVED,FROMSITE APPROVED','1,2,4')
,('VENDOR','DISPATCH',5,'DISPATCHED','TOSITE APPROVED','PROC APPROVED,TOSITE APPROVED,VENDOR APPROVED,FAA APPROVED,FROMSITE APPROVED','1,2')
,('SITE','DISPATCH',5,'DISPATCHED','TOSITE APPROVED','TOSITE APPROVED','4')
;

 --insert into dispatch_requirement values('DC000001',9,1,1,null,null,'NEW','NEW',1,1,getdate(),null,null,0)
 --insert into dispatch_requirement values('DC000003',9,1,2,null,null,'NEW','NEW',1,1,getdate(),null,null,0)

 

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

insert into business_unit  values(1,'Metros',1,0,1,getdate(),null,null)
insert into business_unit  values(1,'Nuclear',1,0,1,getdate(),null,null)
insert into business_unit  values(1,'Port',1,0,1,getdate(),null,null)

insert into segment values ('SEG001','')

insert into project   values ('BMRC RT 02','PROJ001',200,1,1,1,0,1,1,getdate(),null,null)
insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at,project_id,ic_id ,bu_id ) values('admin','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,1,getdate(),null,null,null,1,1,1)



INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Fabrication' ,'Fabrication')
INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Outsourcing' ,'Outsourcing')
INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Scrap' ,'Scrap')




insert into component_type values('COMP1','',0,1,1,getdate(),null,null)
insert into structure_type values('LG & Bridge Builders',1,0,'',1,getdate(),null,null)




        
      insert into role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status)
        values('SITE','REQUIREMENT',1,'NEW','REJECT','REJECT,NEW,BUAPPROVED,CMPCAPPROVED,TWCCAPPROVED,READYTODISPATCH')
                
      insert into role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status)
        values('BU','REQUIREMENT',2,'BUAPPROVED','NEW','NEW,BUAPPROVED,CMPCAPPROVED,TWCCAPPROVED,READYTODISPATCH')
        
      insert into role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status)
        values('CMPC','REQUIREMENT',3,'CMPCAPPROVED','BUAPPROVED,TWCCAPPROVED','BUAPPROVED,CMPCAPPROVED,TWCCAPPROVED,READYTODISPATCH')
        
      insert into role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status)
        values('TWCC','REQUIREMENT',3,'TWCCAPPROVED','BUAPPROVED,CMPCAPPROVED','BUAPPROVED,CMPCAPPROVED,TWCCAPPROVED,READYTODISPATCH')
        
      insert into role_hierarchy (role_name,scenario_type,role_hierarchy,new_status,chk_status,view_details_status)
        values('TWCC','REQUIREMENT',4,'DISPATCHED','READYTODISPATCH','READYTODISPATCH')
        

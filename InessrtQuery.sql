insert into roles values('Admin','Admin',1);
insert into roles values('Project Manager','Project Manager',2);
insert into roles values('Manager','Manager',3);
insert into roles values('Site Engineer','Site Engineer',4);


insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at ) values('admin','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,1,getdate(),null,null,null)



INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Fabrication' ,'Fabrication')
INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Outsourcing' ,'Outsourcing')
INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Scrap' ,'Scrap')


insert into independent_company  values('HCIC','',1,0,1,getdate(),null,null)

insert into business_unit  values(1,'Metros',1,0,1,getdate(),null,null)
insert into business_unit  values(1,'Nuclear',1,0,1,getdate(),null,null)
insert into business_unit  values(1,'Port',1,0,1,getdate(),null,null)

insert into segment values ('SEG001','')

insert into project   values ('BMRC RT 02','PROJ001',200,1,1,1,0,1,1,getdate(),null,null)
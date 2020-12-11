insert into roles values('Admin','Admin',1,getdate(),null);
insert into roles values('Project Manager','Project Manager',2,getdate(),null);
insert into roles values('Manager','Manager',3,getdate(),null);
insert into roles values('Site Engineer','Site Engineer',4,getdate(),null);


insert into users(ps_no,password,email,is_active,role_id,created_at,updated_by,created_by ,updated_at ) values('admin','dL37tZVNK3V60v2HjhCXFA==','admin@gmail.com',1,1,getdate(),null,null,null)

INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Fabrication' ,'Fabrication')
INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Outsourcing' ,'Outsourcing')
INSERT INTO [dbo].[service_type]([name] ,[description]) VALUES('Scrap' ,'Scrap')
GO

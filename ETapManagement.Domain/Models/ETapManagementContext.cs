using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETapManagement.Domain
{
    public partial class ETapManagementContext : DbContext
    {
    

        public ETapManagementContext(DbContextOptions<ETapManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationForms> ApplicationForms { get; set; }
        public virtual DbSet<AuditLogs> AuditLogs { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnit { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<ComponentType> ComponentType { get; set; }
        public virtual DbSet<IndependentCompany> IndependentCompany { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectStructure> ProjectStructure { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesApplicationforms> RolesApplicationforms { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<StructureType> StructureType { get; set; }
        public virtual DbSet<Structures> Structures { get; set; }
        public virtual DbSet<SubContractor> SubContractor { get; set; }
        public virtual DbSet<SubContractorServiceType> SubContractorServiceType { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkBreakdown> WorkBreakdown { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationForms>(entity =>
            {
                entity.ToTable("application_forms");

                entity.HasIndex(e => e.Name)
                    .HasName("application_forms_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdd).HasColumnName("isAdd");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.IsUpdate).HasColumnName("isUpdate");

                entity.Property(e => e.IsView).HasColumnName("isView");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuditLogs>(entity =>
            {
                entity.ToTable("audit_logs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AuditLogs)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("auditlog_createdby_users__fkey");
            });

            modelBuilder.Entity<BusinessUnit>(entity =>
            {
                entity.ToTable("business_unit");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__business__72E12F1B1F99ABF2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IcId).HasColumnName("ic_id");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Segment)
                    .HasColumnName("segment")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BusinessUnitCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("business_unit_createdby_users_fkey");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.BusinessUnit)
                    .HasForeignKey(d => d.IcId)
                    .HasConstraintName("business_unit_icId_IC__fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.BusinessUnitUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("business_unit_updated_users_fkey");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("component");

                entity.HasIndex(e => e.CompId)
                    .HasName("UQ__componen__531653DC700EDDE4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Breath)
                    .HasColumnName("breath")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CompId)
                    .IsRequired()
                    .HasColumnName("comp_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompTypeId).HasColumnName("comp_type_id");

                entity.Property(e => e.ComponentNo).HasColumnName("component_no");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DrawingNo)
                    .HasColumnName("drawing_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsGroup)
                    .HasColumnName("is_group")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTag).HasColumnName("is_tag");

                entity.Property(e => e.Leng)
                    .HasColumnName("leng")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.MakeType)
                    .HasColumnName("make_type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjStructId).HasColumnName("proj_struct_id");

                entity.Property(e => e.QrCode)
                    .HasColumnName("qr_code")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Thickness)
                    .HasColumnName("thickness")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.CompTypeId)
                    .HasConstraintName("comp_comptype_fkey");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ComponentCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("comp_createdby_users_fkey");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.ProjStructId)
                    .HasConstraintName("comp_projstruct_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ComponentUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("comp_updated_users_fkey");
            });

            modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.ToTable("component_type");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__componen__72E12F1B8517FA4E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IndependentCompany>(entity =>
            {
                entity.ToTable("independent_company");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__independ__72E12F1BCC36EF12")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasIndex(e => e.ProjCode)
                    .HasName("UQ__project__C0ECFF4F0277E102")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BuId).HasColumnName("bu_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IcId).HasColumnName("ic_id");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjCode)
                    .IsRequired()
                    .HasColumnName("proj_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Segment)
                    .HasColumnName("segment")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Bu)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.BuId)
                    .HasConstraintName("project_buId_BU__fkey");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("project_createdby_users_fkey");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IcId)
                    .HasConstraintName("project_icId_IC__fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProjectUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("project_updated_users_fkey");
            });

            modelBuilder.Entity<ProjectStructure>(entity =>
            {
                entity.ToTable("project_structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasicHeight)
                    .HasColumnName("basic_height")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.BasicLength)
                    .HasColumnName("basic_length")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.BasicWidth)
                    .HasColumnName("basic_width")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.ComponentsCount).HasColumnName("components_count");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DrawingNo)
                    .HasColumnName("drawing_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OverallLength).HasColumnName("overall_length");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.SlungType)
                    .HasColumnName("slung_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StructureId).HasColumnName("structure_id");

                entity.Property(e => e.TotalWeight)
                    .HasColumnName("total_weight")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectStructureCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("projstructure_createdby_users_fkey");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectStructure)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("projstructure_proj_fkey");

                entity.HasOne(d => d.Structure)
                    .WithMany(p => p.ProjectStructure)
                    .HasForeignKey(d => d.StructureId)
                    .HasConstraintName("projstructure_structures_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProjectStructureUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("projstructure_updated_users_fkey");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Name)
                    .HasName("site_roles_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<RolesApplicationforms>(entity =>
            {
                entity.ToTable("roles_applicationforms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.IsAdd).HasColumnName("isAdd");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.IsUpdate).HasColumnName("isUpdate");

                entity.Property(e => e.IsView).HasColumnName("isView");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.RolesApplicationforms)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rolesforms_forms_id_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesApplicationforms)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rolesforms_roles_id_fkey");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("service_type");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__service___72E12F1B463B385E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StructureType>(entity =>
            {
                entity.ToTable("structure_type");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__structur__72E12F1B36A8781E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Structures>(entity =>
            {
                entity.ToTable("structures");

                entity.HasIndex(e => e.StructId)
                    .HasName("UQ__structur__70F1946B588CF273")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttributeCount).HasColumnName("attribute_count");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StructId)
                    .IsRequired()
                    .HasColumnName("struct_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StructureTypeId).HasColumnName("structure_type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StructuresCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("structures_createdby_users_fkey");

                entity.HasOne(d => d.StructureType)
                    .WithMany(p => p.Structures)
                    .HasForeignKey(d => d.StructureTypeId)
                    .HasConstraintName("structures_structuretype_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.StructuresUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("structures_updated_users_fkey");
            });

            modelBuilder.Entity<SubContractor>(entity =>
            {
                entity.ToTable("sub_contractor");

                entity.HasIndex(e => e.VendorCode)
                    .HasName("UQ__sub_cont__A5795F1DA743D429")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasColumnName("vendor_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SubContractorCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("subcont_createdby_users_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.SubContractorUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("subcont_updated_users_fkey");
            });

            modelBuilder.Entity<SubContractorServiceType>(entity =>
            {
                entity.ToTable("subContractor_serviceType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.ServicetypeId).HasColumnName("servicetype_id");

                entity.Property(e => e.SubcontId).HasColumnName("subcont_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Servicetype)
                    .WithMany(p => p.SubContractorServiceType)
                    .HasForeignKey(d => d.ServicetypeId)
                    .HasConstraintName("subST_servieType_fkey");

                entity.HasOne(d => d.Subcont)
                    .WithMany(p => p.SubContractorServiceType)
                    .HasForeignKey(d => d.SubcontId)
                    .HasConstraintName("subST_subconractor_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .HasColumnName("phoneno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PsNo)
                    .HasColumnName("ps_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("user_roles_id_fkey");
            });

            modelBuilder.Entity<WorkBreakdown>(entity =>
            {
                entity.ToTable("work_breakdown");

                entity.HasIndex(e => e.WbsId)
                    .HasName("UQ__work_bre__4E4F5C8600EE1A8F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Elements)
                    .HasColumnName("elements")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Segment)
                    .HasColumnName("segment")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubSegment)
                    .HasColumnName("sub_segment")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.WbsId)
                    .IsRequired()
                    .HasColumnName("wbs_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.WorkBreakdownCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("wbs_createdby_users_fkey");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.WorkBreakdown)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("wbs_proj_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.WorkBreakdownUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("wbs_updated_users_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

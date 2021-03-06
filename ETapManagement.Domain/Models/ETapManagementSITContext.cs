﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Domain.Models
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
        public virtual DbSet<ComponentHistory> ComponentHistory { get; set; }
        public virtual DbSet<ComponentType> ComponentType { get; set; }
        public virtual DbSet<DispFabricationCost> DispFabricationCost { get; set; }
        public virtual DbSet<DispModStageComponent> DispModStageComponent { get; set; }
        public virtual DbSet<DispReqStructure> DispReqStructure { get; set; }
        public virtual DbSet<DispStructureComp> DispStructureComp { get; set; }
        public virtual DbSet<DispStructureDocuments> DispStructureDocuments { get; set; }
        public virtual DbSet<DispSubcontDocuments> DispSubcontDocuments { get; set; }
        public virtual DbSet<DispSubcontStructure> DispSubcontStructure { get; set; }
        public virtual DbSet<DispatchRequirement> DispatchRequirement { get; set; }
        public virtual DbSet<DispatchreqSubcont> DispatchreqSubcont { get; set; }
        public virtual DbSet<DisreqStatusHistory> DisreqStatusHistory { get; set; }
        public virtual DbSet<IndependentCompany> IndependentCompany { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectSitelocation> ProjectSitelocation { get; set; }
        public virtual DbSet<ProjectStructure> ProjectStructure { get; set; }
        public virtual DbSet<ProjectStructureDocuments> ProjectStructureDocuments { get; set; }
        public virtual DbSet<RoleHierarchy> RoleHierarchy { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesApplicationforms> RolesApplicationforms { get; set; }
        public virtual DbSet<ScrapStatusHistory> ScrapStatusHistory { get; set; }
        public virtual DbSet<ScrapStructure> ScrapStructure { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<SiteCompPhysicalverf> SiteCompPhysicalverf { get; set; }
        public virtual DbSet<SiteDeclaration> SiteDeclaration { get; set; }
        public virtual DbSet<SitePhysicalVerf> SitePhysicalVerf { get; set; }
        public virtual DbSet<SiteReqStructure> SiteReqStructure { get; set; }
        public virtual DbSet<SiteRequirement> SiteRequirement { get; set; }
        public virtual DbSet<SiteStrctPhysicalverfDoc> SiteStrctPhysicalverfDoc { get; set; }
        public virtual DbSet<SiteStructurePhysicalverf> SiteStructurePhysicalverf { get; set; }
        public virtual DbSet<SitedeclDocuments> SitedeclDocuments { get; set; }
        public virtual DbSet<SitedeclStatusHistory> SitedeclStatusHistory { get; set; }
        public virtual DbSet<SitereqStatusHistory> SitereqStatusHistory { get; set; }
        public virtual DbSet<StrategicBusiness> StrategicBusiness { get; set; }
        public virtual DbSet<StructureType> StructureType { get; set; }
        public virtual DbSet<Structures> Structures { get; set; }
        public virtual DbSet<SubContractor> SubContractor { get; set; }
        public virtual DbSet<SubContractorServiceType> SubContractorServiceType { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkBreakdown> WorkBreakdown { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=database-1.cllg2g64ndar.ap-southeast-1.rds.amazonaws.com;Database=ETapManagementSIT;User Id=admin;Password=Admin169;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

    modelBuilder.Query<SiteRequirementDetail> ();
            modelBuilder.Query<SiteDispatchDetail>();
            modelBuilder.Query<StructureListCode>();
            modelBuilder.Query<SurplusDetails> ();
            modelBuilder.Query<AssignStructureDtlsOnly> ();
            modelBuilder.Query<AvailableStructureForReuse> ();
            modelBuilder.Query<TWCCDispatch>();
            modelBuilder.Query<TWCCDispatchInnerStructure>();
            modelBuilder.Query<SiteRequirementDetailsForDispatch>();
            modelBuilder.Query<DispRequestDto> ();
            modelBuilder.Query<DispStructureCMPC> ();
            modelBuilder.Query<ComponentDetailsDto> ();            
            modelBuilder.Query<SubContractorDetail>();
            modelBuilder.Query<SubContractorComponentDetail>();
            modelBuilder.Query<ReceiveDetail>();
            modelBuilder.Query<ReceiveComponentDetail>();
            modelBuilder.Query<PhysicalVerificationDetail> ();
            modelBuilder.Query<InspectionPhysicalVerificationDetail> ();
            modelBuilder.Query<ComponentDetailsInput> ();
             
            modelBuilder.Query<ScrapStructureWorkFlowDetail> ();
            modelBuilder.Query<ViewStructureChart>();
            modelBuilder.Query<Code>();
             modelBuilder.Query<AsBuildStructure>();
             modelBuilder.Query<CostComponentDetailsDto>();
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
            });

            modelBuilder.Entity<BusinessUnit>(entity =>
            {
                entity.ToTable("business_unit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IcId).HasColumnName("ic_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SbgId).HasColumnName("sbg_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.BusinessUnit)
                    .HasForeignKey(d => d.IcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("business_unit_icId_IC__fkey");

                entity.HasOne(d => d.Sbg)
                    .WithMany(p => p.BusinessUnit)
                    .HasForeignKey(d => d.SbgId)
                    .HasConstraintName("business_unit_sbgId_SBG__fkey");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("component");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Breath)
                    .HasColumnName("breath")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CompId)
                    .IsRequired()
                    .HasColumnName("comp_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompName)
                    .HasColumnName("comp_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompStatus)
                    .HasColumnName("comp_status")
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
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FabriacationCost)
                    .HasColumnName("fabriacation_cost")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.CompTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comp_comptype_fkey");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.ProjStructId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comp_projstruct_fkey");
            });

            modelBuilder.Entity<ComponentHistory>(entity =>
            {
                entity.ToTable("component_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Breath)
                    .HasColumnName("breath")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CompId)
                    .IsRequired()
                    .HasColumnName("comp_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompStatus)
                    .HasColumnName("comp_status")
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
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.CompType)
                    .WithMany(p => p.ComponentHistory)
                    .HasForeignKey(d => d.CompTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comphistory_comptype_fkey");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.ComponentHistory)
                    .HasForeignKey(d => d.ProjStructId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comphistory_projstruct_fkey");
            });

            modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.ToTable("component_type");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__componen__72E12F1B396403F9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<DispFabricationCost>(entity =>
            {
                entity.ToTable("disp_fabrication_cost");

                entity.HasIndex(e => e.DispatchNo)
                    .HasName("UQ__disp_fab__F7205CCDFC4F1D62")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssingedProjectId).HasColumnName("assinged_project_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DispReqId).HasColumnName("disp_req_id");

                entity.Property(e => e.DispStructureId).HasColumnName("disp_structure_id");

                entity.Property(e => e.DispatchNo)
                    .IsRequired()
                    .HasColumnName("dispatch_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.AssingedProject)
                    .WithMany(p => p.DispFabricationCost)
                    .HasForeignKey(d => d.AssingedProjectId)
                    .HasConstraintName("fabrication_cost_proj_fkey");

                entity.HasOne(d => d.DispStructure)
                    .WithMany(p => p.DispFabricationCost)
                    .HasForeignKey(d => d.DispStructureId)
                    .HasConstraintName("fabrication_cost_disp_structure_id_fkey");
            });

            modelBuilder.Entity<DispModStageComponent>(entity =>
            {
                entity.ToTable("disp_mod_stage_component");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addplate)
                    .HasColumnName("addplate")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Breath)
                    .HasColumnName("breath")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DispstructCompId).HasColumnName("dispstruct_comp_id");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Leng)
                    .HasColumnName("leng")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.MakeType)
                    .HasColumnName("make_type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.QrCode)
                    .HasColumnName("qr_code")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Thickness)
                    .HasColumnName("thickness")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.DispstructComp)
                    .WithMany(p => p.DispModStageComponent)
                    .HasForeignKey(d => d.DispstructCompId)
                    .HasConstraintName("compmodif_dispcomp_fkey");
            });

            modelBuilder.Entity<DispReqStructure>(entity =>
            {
                entity.ToTable("disp_req_structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DispStructStatus)
                    .HasColumnName("disp_struct_status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DispStructureId).HasColumnName("disp_structure_id");

                entity.Property(e => e.DispreqId).HasColumnName("dispreq_id");

                entity.Property(e => e.FabriacationCost)
                    .HasColumnName("fabriacation_cost")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.FromProjectId).HasColumnName("from_project_id");

                entity.Property(e => e.IsModification).HasColumnName("is_modification");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjStructId).HasColumnName("proj_struct_id");

                entity.Property(e => e.SurplusDate)
                    .HasColumnName("surplus_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Dispreq)
                    .WithMany(p => p.DispReqStructure)
                    .HasForeignKey(d => d.DispreqId)
                    .HasConstraintName("DispReqStructire_siteReq_fkey");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.DispReqStructure)
                    .HasForeignKey(d => d.ProjStructId)
                    .HasConstraintName("DispReqStructire_structure_fkey");
            });

            modelBuilder.Entity<DispStructureComp>(entity =>
            {
                entity.ToTable("disp_structure_comp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompStatus)
                    .HasColumnName("comp_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DispCompId).HasColumnName("disp_comp_id");

                entity.Property(e => e.DispStructureId).HasColumnName("disp_structure_id");

                entity.Property(e => e.DispatchDate)
                    .HasColumnName("dispatch_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FabriacationCost)
                    .HasColumnName("fabriacation_cost")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.FromScanBy).HasColumnName("from_scan_by");

                entity.Property(e => e.FromScandate)
                    .HasColumnName("from_scandate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastScandate)
                    .HasColumnName("last_scandate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ScannedBy).HasColumnName("scanned_by");

                entity.HasOne(d => d.DispComp)
                    .WithMany(p => p.DispStructureComp)
                    .HasForeignKey(d => d.DispCompId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disp_req_structure_comp_id_CompID_fkey");

                entity.HasOne(d => d.DispStructure)
                    .WithMany(p => p.DispStructureComp)
                    .HasForeignKey(d => d.DispStructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disp_req_structure_comp_id_StructureID_fkey");
            });

            modelBuilder.Entity<DispStructureDocuments>(entity =>
            {
                entity.ToTable("disp_structure_documents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DispStructureId).HasColumnName("disp_structure_id");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasColumnName("file_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.DispStructure)
                    .WithMany(p => p.DispStructureDocuments)
                    .HasForeignKey(d => d.DispStructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disp_req_structure_docs_id_docsID_fkey");
            });

            modelBuilder.Entity<DispSubcontDocuments>(entity =>
            {
                entity.ToTable("disp_subcont_documents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DispSubcontId).HasColumnName("disp_subcont_id");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasColumnName("file_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.DispSubcont)
                    .WithMany(p => p.DispSubcontDocuments)
                    .HasForeignKey(d => d.DispSubcontId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disp_subcont_id_docsID_fkey");
            });

            modelBuilder.Entity<DispSubcontStructure>(entity =>
            {
                entity.ToTable("disp_subcont_structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualStartdate)
                    .HasColumnName("actual_startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContractYears)
                    .HasColumnName("contract_years")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DispStructureId).HasColumnName("disp_structure_id");

                entity.Property(e => e.DispatchDate)
                    .HasColumnName("dispatch_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DispreqsubcontId).HasColumnName("dispreqsubcont_id");

                entity.Property(e => e.ExpectedReleasedate)
                    .HasColumnName("expected_releasedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FabricationCost)
                    .HasColumnName("fabrication_cost")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsDelivered)
                    .HasColumnName("is_Delivered")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MonthlyRent)
                    .HasColumnName("monthly_rent")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PlanReleasedate)
                    .HasColumnName("plan_releasedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjStructId).HasColumnName("proj_struct_id");

                entity.HasOne(d => d.Dispreqsubcont)
                    .WithMany(p => p.DispSubcontStructure)
                    .HasForeignKey(d => d.DispreqsubcontId)
                    .HasConstraintName("dispreqsubcont_structure_siteReq_fkey");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.DispSubcontStructure)
                    .HasForeignKey(d => d.ProjStructId)
                    .HasConstraintName("disp_subcont_structure_structure_fkey");
            });

            modelBuilder.Entity<DispatchRequirement>(entity =>
            {
                entity.ToTable("dispatch_requirement");

                entity.HasIndex(e => e.DispatchNo)
                    .HasName("UQ__dispatch__F7205CCDFAFBA6D9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DispatchNo)
                    .IsRequired()
                    .HasColumnName("dispatch_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ServicetypeId).HasColumnName("servicetype_id");

                entity.Property(e => e.SiteReqStructid).HasColumnName("site_req_structid");

                entity.Property(e => e.SitereqId).HasColumnName("sitereq_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToProjectid).HasColumnName("to_projectid");

                entity.Property(e => e.TransferPrice)
                    .HasColumnName("transfer_price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Servicetype)
                    .WithMany(p => p.DispatchRequirement)
                    .HasForeignKey(d => d.ServicetypeId)
                    .HasConstraintName("dispatch_requirement_servicetype_fkey");

                entity.HasOne(d => d.SiteReqStruct)
                    .WithMany(p => p.DispatchRequirement)
                    .HasForeignKey(d => d.SiteReqStructid)
                    .HasConstraintName("dispatch_requirement_siteReqstructure_fkey");

                entity.HasOne(d => d.Sitereq)
                    .WithMany(p => p.DispatchRequirement)
                    .HasForeignKey(d => d.SitereqId)
                    .HasConstraintName("dispatch_requirement_siteReq_fkey");

                entity.HasOne(d => d.ToProject)
                    .WithMany(p => p.DispatchRequirement)
                    .HasForeignKey(d => d.ToProjectid)
                    .HasConstraintName("dispatch_requirement_proj_fkey");
            });

            modelBuilder.Entity<DispatchreqSubcont>(entity =>
            {
                entity.ToTable("dispatchreq_subcont");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DispatchNo)
                    .HasColumnName("dispatch_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DispreqId).HasColumnName("dispreq_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ServicetypeId).HasColumnName("servicetype_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubconId).HasColumnName("subcon_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.WorkorderNo)
                    .HasColumnName("workorder_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dispreq)
                    .WithMany(p => p.DispatchreqSubcont)
                    .HasForeignKey(d => d.DispreqId)
                    .HasConstraintName("dispatchreq_subcont_dispatch_requirement_fkey");

                entity.HasOne(d => d.Servicetype)
                    .WithMany(p => p.DispatchreqSubcont)
                    .HasForeignKey(d => d.ServicetypeId)
                    .HasConstraintName("dispatchreq_subcont_servicetype_fkey");

                entity.HasOne(d => d.Subcon)
                    .WithMany(p => p.DispatchreqSubcont)
                    .HasForeignKey(d => d.SubconId)
                    .HasConstraintName("dispatchreq_subcont_subcont_fkey");
            });

            modelBuilder.Entity<DisreqStatusHistory>(entity =>
            {
                entity.ToTable("disreq_status_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DispatchNo)
                    .IsRequired()
                    .HasColumnName("dispatch_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DispreqId).HasColumnName("dispreq_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dispreq)
                    .WithMany(p => p.DisreqStatusHistory)
                    .HasForeignKey(d => d.DispreqId)
                    .HasConstraintName("dispatch_requirement_statushistory_dispreq_fkey");
            });

            modelBuilder.Entity<IndependentCompany>(entity =>
            {
                entity.ToTable("independent_company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

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

                entity.Property(e => e.EdrcCode)
                    .HasColumnName("edrc_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IcId).HasColumnName("ic_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.JobCode)
                    .HasColumnName("job_code")
                    .HasMaxLength(20)
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

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Bu)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.BuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_buId_BU__fkey");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_icId_IC__fkey");
            });

            modelBuilder.Entity<ProjectSitelocation>(entity =>
            {
                entity.ToTable("project_sitelocation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectSitelocation)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_sitelocation_projectId_fkey");
            });

            modelBuilder.Entity<ProjectStructure>(entity =>
            {
                entity.ToTable("project_structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualWbs).HasColumnName("actual_wbs");

                entity.Property(e => e.ActualWeight)
                    .HasColumnName("actual_weight")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ComponentsCount).HasColumnName("components_count");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CurrentStatus)
                    .HasColumnName("current_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DrawingNo)
                    .HasColumnName("drawing_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedWeight)
                    .HasColumnName("estimated_weight")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ExpReleaseDate)
                    .HasColumnName("exp_release_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FabriacationCost)
                    .HasColumnName("fabriacation_cost")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.FabricationYear)
                    .HasColumnName("fabrication_year")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Reusuability).HasColumnName("reusuability");

                entity.Property(e => e.StructCode)
                    .IsRequired()
                    .HasColumnName("struct_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StructureAttributesVal)
                    .HasColumnName("structure_attributes_val")
                    .HasMaxLength(1);

                entity.Property(e => e.StructureId).HasColumnName("structure_id");

                entity.Property(e => e.StructureStatus)
                    .HasColumnName("structure_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectStructure)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projstructure_proj_fkey");

                entity.HasOne(d => d.Structure)
                    .WithMany(p => p.ProjectStructure)
                    .HasForeignKey(d => d.StructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projstructure_structures_fkey");
            });

            modelBuilder.Entity<ProjectStructureDocuments>(entity =>
            {
                entity.ToTable("project_structure_documents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasColumnName("file_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStructureId).HasColumnName("project_structure_id");

                entity.HasOne(d => d.ProjectStructure)
                    .WithMany(p => p.ProjectStructureDocuments)
                    .HasForeignKey(d => d.ProjectStructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_structure_id_psID_fkey");
            });

            modelBuilder.Entity<RoleHierarchy>(entity =>
            {
                entity.ToTable("role_hierarchy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChkStatus)
                    .HasColumnName("chk_status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewStatus)
                    .HasColumnName("new_status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleHierarchy1).HasColumnName("role_hierarchy");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ScenarioType)
                    .HasColumnName("scenario_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceType)
                    .HasColumnName("service_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ViewDetailsStatus)
                    .HasColumnName("view_details_status")
                    .HasMaxLength(500)
                    .IsUnicode(false);
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

            modelBuilder.Entity<ScrapStatusHistory>(entity =>
            {
                entity.ToTable("scrap_status_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ScrapStuctreId).HasColumnName("scrap_stuctre_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.ScrapStuctre)
                    .WithMany(p => p.ScrapStatusHistory)
                    .HasForeignKey(d => d.ScrapStuctreId)
                    .HasConstraintName("scrap_status_history_scrapstructure_fkey");
            });

            modelBuilder.Entity<ScrapStructure>(entity =>
            {
                entity.ToTable("scrap_structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuctionId)
                    .HasColumnName("auction_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DispStructureId).HasColumnName("disp_structure_id");

                entity.Property(e => e.FromProjectId).HasColumnName("from_project_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ProjStructId).HasColumnName("proj_struct_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ScrapRate)
                    .HasColumnName("scrap_rate")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubconId).HasColumnName("subcon_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.ScrapStructure)
                    .HasForeignKey(d => d.ProjStructId)
                    .HasConstraintName("scrap_strucure_projstructure_fkey");

                entity.HasOne(d => d.Subcon)
                    .WithMany(p => p.ScrapStructure)
                    .HasForeignKey(d => d.SubconId)
                    .HasConstraintName("scrap_structure_subcon_fkey");
            });

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.ToTable("segment");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__segment__72E12F1BB60B301A")
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

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("service_type");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__service___72E12F1BC5E41A68")
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

            modelBuilder.Entity<SiteCompPhysicalverf>(entity =>
            {
                entity.ToTable("site_comp_physicalverf");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Qrcode)
                    .HasColumnName("qrcode")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SitestructureVerfid).HasColumnName("sitestructure_verfid");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.SitestructureVerf)
                    .WithMany(p => p.SiteCompPhysicalverf)
                    .HasForeignKey(d => d.SitestructureVerfid)
                    .HasConstraintName("site_comp_physicalverf_site_structure_physicalverf_fkey");
            });

            modelBuilder.Entity<SiteDeclaration>(entity =>
            {
                entity.ToTable("site_declaration");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.FromProjectId).HasColumnName("from_project_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProjStructId).HasColumnName("proj_struct_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SitereqId).HasColumnName("sitereq_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SurplusFromdate)
                    .HasColumnName("surplus_fromdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.SiteDeclaration)
                    .HasForeignKey(d => d.ProjStructId)
                    .HasConstraintName("siteDec_projstructure_fkey");

                entity.HasOne(d => d.Sitereq)
                    .WithMany(p => p.SiteDeclaration)
                    .HasForeignKey(d => d.SitereqId)
                    .HasConstraintName("siteDec_siteReq_fkey");
            });

            modelBuilder.Entity<SitePhysicalVerf>(entity =>
            {
                entity.ToTable("site_physical_verf");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DuedateFrom)
                    .HasColumnName("duedate_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DuedateTo)
                    .HasColumnName("duedate_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.InspectionId)
                    .HasColumnName("inspection_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SiteReqStructure>(entity =>
            {
                entity.ToTable("site_req_structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualReleasedate)
                    .HasColumnName("actual_releasedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActualStartdate)
                    .HasColumnName("actual_startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActualWbsId).HasColumnName("actual_wbs_id");

                entity.Property(e => e.PlanReleasedate)
                    .HasColumnName("plan_releasedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlanStartdate)
                    .HasColumnName("plan_startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RequireWbsId).HasColumnName("require_wbs_id");

                entity.Property(e => e.SiteReqId).HasColumnName("site_req_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StructId).HasColumnName("struct_id");

                entity.Property(e => e.StructureAttributesVal)
                    .HasColumnName("structure_attributes_val")
                    .HasMaxLength(1);

                entity.HasOne(d => d.SiteReq)
                    .WithMany(p => p.SiteReqStructure)
                    .HasForeignKey(d => d.SiteReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("siteReqStructire_siteReq_fkey");

                entity.HasOne(d => d.Struct)
                    .WithMany(p => p.SiteReqStructure)
                    .HasForeignKey(d => d.StructId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("siteReqStructire_structure_fkey");
            });

            modelBuilder.Entity<SiteRequirement>(entity =>
            {
                entity.ToTable("site_requirement");

                entity.HasIndex(e => e.MrNo)
                    .HasName("UQ__site_req__AE8CB972C5005D06")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.FromProjectId).HasColumnName("from_project_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MrNo)
                    .IsRequired()
                    .HasColumnName("mr_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.FromProject)
                    .WithMany(p => p.SiteRequirement)
                    .HasForeignKey(d => d.FromProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("siteReq_proj_fkey");
            });

            modelBuilder.Entity<SiteStrctPhysicalverfDoc>(entity =>
            {
                entity.ToTable("site_strct_physicalverf_doc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasColumnName("file_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SiteStructurePhysicalverfId).HasColumnName("site_structure_physicalverf_id");

                entity.HasOne(d => d.SiteStructurePhysicalverf)
                    .WithMany(p => p.SiteStrctPhysicalverfDoc)
                    .HasForeignKey(d => d.SiteStructurePhysicalverfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("site_structure_physicalverf_id_sspID_fkey");
            });

            modelBuilder.Entity<SiteStructurePhysicalverf>(entity =>
            {
                entity.ToTable("site_structure_physicalverf");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DuedateFrom)
                    .HasColumnName("duedate_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DuedateTo)
                    .HasColumnName("duedate_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjStructId).HasColumnName("proj_struct_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SiteVerfId).HasColumnName("site_verf_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.ProjStruct)
                    .WithMany(p => p.SiteStructurePhysicalverf)
                    .HasForeignKey(d => d.ProjStructId)
                    .HasConstraintName("site_structure_physicalverf_strucutre_fkey");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.SiteStructurePhysicalverf)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("site_structure_physicalverf_proj_fkey");

                entity.HasOne(d => d.SiteVerf)
                    .WithMany(p => p.SiteStructurePhysicalverf)
                    .HasForeignKey(d => d.SiteVerfId)
                    .HasConstraintName("site_structure_physicalverf_site_physical_verf_fkey");
            });

            modelBuilder.Entity<SitedeclDocuments>(entity =>
            {
                entity.ToTable("sitedecl_documents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasColumnName("file_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SitedecId).HasColumnName("sitedec_id");

                entity.HasOne(d => d.Sitedec)
                    .WithMany(p => p.SitedeclDocuments)
                    .HasForeignKey(d => d.SitedecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sitedecl_documents_sitedecl_fkey");
            });

            modelBuilder.Entity<SitedeclStatusHistory>(entity =>
            {
                entity.ToTable("sitedecl_status_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SitedecId).HasColumnName("sitedec_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Sitedec)
                    .WithMany(p => p.SitedeclStatusHistory)
                    .HasForeignKey(d => d.SitedecId)
                    .HasConstraintName("siteDeclStatus_siteDec_fkey");
            });

            modelBuilder.Entity<SitereqStatusHistory>(entity =>
            {
                entity.ToTable("sitereq_status_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MrNo)
                    .IsRequired()
                    .HasColumnName("mr_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SitereqId).HasColumnName("sitereq_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInternal)
                    .HasColumnName("status_internal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Sitereq)
                    .WithMany(p => p.SitereqStatusHistory)
                    .HasForeignKey(d => d.SitereqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sitereq_status_history_sitereq_fkey");
            });

            modelBuilder.Entity<StrategicBusiness>(entity =>
            {
                entity.ToTable("strategic_business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<StructureType>(entity =>
            {
                entity.ToTable("structure_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<Structures>(entity =>
            {
                entity.ToTable("structures");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StructureAttributesDef)
                    .HasColumnName("structure_attributes_def")
                    .HasMaxLength(1);

                entity.Property(e => e.StructureTypeId).HasColumnName("structure_type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.StructureType)
                    .WithMany(p => p.Structures)
                    .HasForeignKey(d => d.StructureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("structures_structuretype_fkey");
            });

            modelBuilder.Entity<SubContractor>(entity =>
            {
                entity.ToTable("sub_contractor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus)
                    .HasColumnName("is_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(20)
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
            });

            modelBuilder.Entity<SubContractorServiceType>(entity =>
            {
                entity.ToTable("subContractor_serviceType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ServicetypeId).HasColumnName("servicetype_id");

                entity.Property(e => e.SubcontId).HasColumnName("subcont_id");

                entity.HasOne(d => d.Servicetype)
                    .WithMany(p => p.SubContractorServiceType)
                    .HasForeignKey(d => d.ServicetypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subST_servieType_fkey");

                entity.HasOne(d => d.Subcont)
                    .WithMany(p => p.SubContractorServiceType)
                    .HasForeignKey(d => d.SubcontId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subST_subconractor_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuId).HasColumnName("bu_id");

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

                entity.Property(e => e.IcId).HasColumnName("ic_id");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

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

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.PsNo)
                    .IsRequired()
                    .HasColumnName("ps_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.Bu)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_bu_fkey");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ic_fkey");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_proj_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_roles_id_fkey");
            });

            modelBuilder.Entity<WorkBreakdown>(entity =>
            {
                entity.ToTable("work_breakdown");

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
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubSegment)
                    .HasColumnName("sub_segment")
                    .HasMaxLength(100)
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

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.WorkBreakdown)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("wbs_proj_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

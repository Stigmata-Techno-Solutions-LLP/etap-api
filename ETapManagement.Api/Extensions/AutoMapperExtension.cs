using System;
using System.Collections.Generic;
using AutoMapper;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.Extensions.DependencyInjection;
namespace ETapManagement.Api.Extensions {
	public static class AutoMapperExtension {
		public static void AddAutoMapperSetup (this IServiceCollection services) {
			if (services == null) throw new ArgumentNullException (nameof (services));

			services.AddAutoMapper (typeof (MappingProfile));
		}
	}

	public class MappingProfile : Profile {
		public MappingProfile () {

			CreateMap<UserDetails, Users> ()
				.ForMember (dest =>
					dest.FirstName,
					opt => opt.MapFrom (src => src.firstName))
				.ForMember (dest =>
					dest.LastName,
					opt => opt.MapFrom (src => src.lastName))
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.userId))
				.ForMember (dest =>
					dest.Email,
					opt => opt.MapFrom (src => src.email))
				.ForMember (dest =>
					dest.Phoneno,
					opt => opt.MapFrom (src => src.mobileNo))
				.ForMember (dest =>
					dest.PsNo,
					opt => opt.MapFrom (src => src.userName))
				.ForMember (dest =>
					dest.Password,
					opt => opt.MapFrom (src => src.password))
				.ForMember (dest =>
					dest.RoleId,
					opt => opt.MapFrom (src => src.roleId))
				.ForMember (dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ForMember (dest =>
					dest.BuId,
					opt => opt.MapFrom (src => src.BUId))
				.ForMember (dest =>
					dest.IcId,
					opt => opt.MapFrom (src => src.ICId))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.isActive))
				.ForMember (dest =>
					dest.CreatedBy,
					opt => opt.MapFrom (src => src.createdBy))
				.ForMember (dest =>
					dest.UpdatedBy,
					opt => opt.MapFrom (src => src.updatedBy))
				.ReverseMap ();

			CreateMap<PageAccess, RolesApplicationforms> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.FormId,
					opt => opt.MapFrom (src => src.PageDetailId))
				.ForMember (dest =>
					dest.RoleId,
					opt => opt.MapFrom (src => src.RoleId))
				.ForMember (dest =>
					dest.IsAdd,
					opt => opt.MapFrom (src => src.IsAdd))
				.ForMember (dest =>
					dest.IsUpdate,
					opt => opt.MapFrom (src => src.IsUpdate))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.IsView,
					opt => opt.MapFrom (src => src.IsView))
				.ReverseMap ();

			CreateMap<PageDetails, ApplicationForms> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ForMember (dest =>
					dest.IsAdd,
					opt => opt.MapFrom (src => src.IsAdd))
				.ForMember (dest =>
					dest.IsUpdate,
					opt => opt.MapFrom (src => src.IsUpdate))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.IsView,
					opt => opt.MapFrom (src => src.IsView))
				.ReverseMap ();

			CreateMap<Role, Roles> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ForMember (dest =>
					dest.Level,
					opt => opt.MapFrom (src => src.Level))
				.ReverseMap ();

			CreateMap<AddProject, Project> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.ProjCode,
					opt => opt.MapFrom (src => src.ProjCode))
				.ForMember (dest =>
					dest.Area,
					opt => opt.MapFrom (src => src.Area))
				.ForMember (dest =>
					dest.IcId,
					opt => opt.MapFrom (src => src.ICId))
				.ForMember (dest =>
					dest.BuId,
					opt => opt.MapFrom (src => src.BUId))
				.ForMember (dest =>
					dest.SegmentId,
					opt => opt.MapFrom (src => src.SegmentId))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.ProjectSitelocation,
					opt => opt.MapFrom (src => src.ProjectSiteLocationDetails))
				.ReverseMap ();

			CreateMap<Project, ProjectDetail> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.ProjCode,
					opt => opt.MapFrom (src => src.ProjCode))
				.ForMember (dest =>
					dest.Area,
					opt => opt.MapFrom (src => src.Area))
				.ForMember (dest =>
					dest.ICId,
					opt => opt.MapFrom (src => src.IcId))
				.ForMember (dest =>
					dest.ICName,
					opt => opt.MapFrom (src => src.Ic.Name))
				.ForMember (dest =>
					dest.BUId,
					opt => opt.MapFrom (src => src.BuId))
				.ForMember (dest =>
					dest.BUName,
					opt => opt.MapFrom (src => src.Bu.Name))
				.ForMember (dest =>
					dest.SegmentId,
					opt => opt.MapFrom (src => src.SegmentId))
				.ForMember (dest =>
					dest.SegmentName,
					opt => opt.MapFrom (src => src.Segment.Name))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.CreatedBy,
					opt => opt.MapFrom (src => src.CreatedBy))
				.ForMember (dest =>
					dest.CreatedAt,
					opt => opt.MapFrom (src => src.CreatedAt.HasValue ? src.CreatedAt.Value.ToString ("dd/MM/yyyy") : string.Empty))
				.ForMember (dest =>
					dest.UpdatedBy,
					opt => opt.MapFrom (src => src.UpdatedBy))
				.ForMember (dest =>
					dest.UpdatedtAt,
					opt => opt.MapFrom (src => src.UpdatedAt.HasValue ? src.UpdatedAt.Value.ToString ("dd/MM/yyyy") : string.Empty))
				.ForMember (dest =>
					dest.ProjectSiteLocationDetails,
					opt => opt.MapFrom (src => src.ProjectSitelocation))
				.ReverseMap ();

			CreateMap<SegmentDetail, Segment> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ReverseMap ();

			CreateMap<ComponentTypeDetails, ComponentType> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ReverseMap ();

			CreateMap<AddWorkBreakDown, WorkBreakdown> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.WbsId,
					opt => opt.MapFrom (src => src.WorkBreakDownCode))
				.ForMember (dest =>
					dest.Segment,
					opt => opt.MapFrom (src => src.Segment))
				.ForMember (dest =>
					dest.SubSegment,
					opt => opt.MapFrom (src => src.SubSegment))
				.ForMember (dest =>
					dest.Elements,
					opt => opt.MapFrom (src => src.Element))
				.ForMember (dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ReverseMap ();

			CreateMap<WorkBreakdown, WorkBreakDownDetails> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.WorkBreakDownCode,
					opt => opt.MapFrom (src => src.WbsId))
				.ForMember (dest =>
					dest.Segment,
					opt => opt.MapFrom (src => src.Segment))
				.ForMember (dest =>
					dest.SubSegment,
					opt => opt.MapFrom (src => src.SubSegment))
				.ForMember (dest =>
					dest.Element,
					opt => opt.MapFrom (src => src.Elements))
				.ForMember (dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ForMember (dest =>
					dest.ProjectCode,
					opt => opt.MapFrom (src => src.Project.ProjCode))
				.ForMember (dest =>
					dest.CreatedDate,
					opt => opt.MapFrom (src => src.CreatedAt != null ? src.CreatedAt.Value.ToString ("yyyy-MM-dd") : ""))
				.ForMember (dest =>
					dest.UpdatedDate,
					opt => opt.MapFrom (src => src.UpdatedAt != null ? src.UpdatedAt.Value.ToString ("yyyy-MM-dd") : ""))
				.ReverseMap ();

			CreateMap<WorkBreakdown, WorkBreakDownCode> ()
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.WbsId))

				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id));

			CreateMap<VendorDetail, SubContractor> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.VendorCode,
					opt => opt.MapFrom (src => src.VendorCode))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.IsStatus,
					opt => opt.MapFrom (src => src.IsStatus))
				.ForMember (dest =>
					dest.CreatedBy,
					opt => opt.MapFrom (src => src.CreatedBy))
				.ForMember (dest =>
					dest.CreatedAt,
					opt => opt.MapFrom (src => src.CreatedAt))
				.ForMember (dest =>
					dest.UpdatedBy,
					opt => opt.MapFrom (src => src.UpdatedBy))
				.ForMember (dest =>
					dest.UpdatedAt,
					opt => opt.MapFrom (src => src.UpdatedAt))
				.ForMember (dest =>
					dest.Email,
					opt => opt.MapFrom (src => src.Email))
				.ForMember (dest =>
					dest.PhoneNo,
					opt => opt.MapFrom (src => src.PhoneNunmber))
				.ForMember (dest =>
					dest.SubContractorServiceType,
					opt => opt.MapFrom (src => src.VendorServiceTypeDetails))
				.ReverseMap ();

			CreateMap<AddVendor, SubContractor> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.VendorCode,
					opt => opt.MapFrom (src => src.VendorCode))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.IsStatus,
					opt => opt.MapFrom (src => src.IsStatus))
				.ForMember (dest =>
					dest.Email,
					opt => opt.MapFrom (src => src.Email))
				.ForMember (dest =>
					dest.PhoneNo,
					opt => opt.MapFrom (src => src.PhoneNunmber))
				.ForMember (dest =>
					dest.SubContractorServiceType,
					opt => opt.MapFrom (src => src.VendorServiceTypeDetails))
				.ReverseMap ();

			CreateMap<ProjectSiteLocationDetail, ProjectSitelocation> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ReverseMap ();

			CreateMap<VendorServiceTypeDetail, SubContractorServiceType> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.SubcontId,
					opt => opt.MapFrom (src => src.VendorId))
				.ForMember (dest =>
					dest.ServicetypeId,
					opt => opt.MapFrom (src => src.ServiceTypeId))
				.ReverseMap ();

			CreateMap<StructureTypeDetail, StructureType> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.IsActive))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ReverseMap ();

			CreateMap<AddStructureType, StructureType> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.IsActive))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ReverseMap ();

			CreateMap<IndependentCompanyDetail, IndependentCompany> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ReverseMap ();

			CreateMap<AddIndependentCompany, IndependentCompany> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.Description,
					opt => opt.MapFrom (src => src.Description))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ReverseMap ();

			CreateMap<BusinessUnitDetail, BusinessUnit> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.CreatedBy,
					opt => opt.MapFrom (src => src.CreatedBy))
				.ForMember (dest =>
					dest.CreatedAt,
					opt => opt.MapFrom (src => src.CreatedAt))
				.ForMember (dest =>
					dest.UpdatedBy,
					opt => opt.MapFrom (src => src.UpdatedBy))
				.ForMember (dest =>
					dest.UpdatedAt,
					opt => opt.MapFrom (src => src.UpdatedAt))
				.ForMember (dest =>
					dest.IcId,
					opt => opt.MapFrom (src => src.IcId))
				.ReverseMap ();

			CreateMap<StructureDetails, Structures> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				/*.ForMember(dest =>
					 dest.Name,
					opt => opt.MapFrom(src => src.Name))*/
				.ForMember (dest =>
					dest.StructureTypeId,
					opt => opt.MapFrom (src => src.StructureTypeId))
				.ForMember (dest =>
					dest.StructureAttributes,
					opt => opt.MapFrom (src => src.StructureAttributes))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.IsActive))
				.ReverseMap ();

			CreateMap<Upload_Docs, ProjectStructureDocuments> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.FileName,
					opt => opt.MapFrom (src => src.fileName))
				.ForMember (dest =>
					dest.FileType,
					opt => opt.MapFrom (src => src.fileType))

				.ForMember (dest =>
					dest.Path,
					opt => opt.MapFrom (src => src.filepath))
				.ReverseMap ();
			CreateMap<ProjectStructure, AssignStructureDtlsOnly> ()

				.ForMember (dest =>
					dest.DrawingNo,
					opt => opt.MapFrom (src => src.DrawingNo))

				.ForMember (dest =>
					dest.StrcutureName,
					opt => opt.MapFrom (src => src.Structure.Name))
				.ForMember (dest =>
					dest.ProjectName,
					opt => opt.MapFrom (src => src.Project.Name))	
				.ForMember (dest =>
					dest.StructureCode,
					opt => opt.MapFrom (src => src.Structure.StructId))	
				.ForMember(dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ForMember(dest =>
					dest.StructureAttributes,
					opt => opt.MapFrom (src => src.Structure.StructureAttributes))
				.ForMember (dest =>
					dest.structureDocs,
					opt => opt.MapFrom (src => src.ProjectStructureDocuments))
				.ForMember (dest =>
					dest.StructureId,
					opt => opt.MapFrom (src => src.StructureId))
				.ForMember (dest =>
					dest.Components,
					opt => opt.MapFrom (src => src.Component))
				.ReverseMap ();

		

			CreateMap<UpdateBusinessUnit, BusinessUnit> ()
				.ForMember (dest =>
					dest.Name,
					opt => opt.MapFrom (src => src.Name))
				.ForMember (dest =>
					dest.IcId,
					opt => opt.MapFrom (src => src.IcId))
				.ReverseMap ();

			CreateMap<ProjectStructureDetails, ProjectStructure> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.StructureId,
					opt => opt.MapFrom (src => src.StructureId))
				.ForMember (dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.DrawingNo,
					opt => opt.MapFrom (src => src.DrawingNo))
				.ForMember (dest =>
					dest.ComponentsCount,
					opt => opt.MapFrom (src => src.ComponentsCount))
				.ReverseMap ();

			CreateMap<ComponentDetails, Component> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))

				.ForMember (dest =>
					dest.CompId,
					opt => opt.MapFrom (src => src.CompId))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.DrawingNo,	
					opt => opt.MapFrom (src => src.DrawingNo))
				// .ForMember (dest =>
				// 	dest.CompType.Name,
				// 	opt => opt.MapFrom (src => src.CompTypeName))
				.ForMember (dest =>
					dest.ComponentNo,
					opt => opt.MapFrom (src => src.ComponentNo))
				.ForMember (dest =>
					dest.IsGroup,
					opt => opt.MapFrom (src => src.IsGroup))
				.ForMember (dest =>
					dest.Leng,
					opt => opt.MapFrom (src => src.Leng))
				.ForMember (dest =>
					dest.Breath,
					opt => opt.MapFrom (src => src.Breath))
				.ForMember (dest =>
					dest.Height,
					opt => opt.MapFrom (src => src.Height))
				.ForMember (dest =>
					dest.Breath,
					opt => opt.MapFrom (src => src.Breath))
				.ForMember (dest =>
					dest.CompStatus,
					opt => opt.MapFrom (src => src.CompStatus))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.IsActive))
				.ForMember (dest =>
					dest.Thickness,
					opt => opt.MapFrom (src => src.Thickness))
				.ForMember (dest =>
					dest.QrCode,
					opt => opt.MapFrom (src => src.QrCode))
				.ForMember (dest =>
					dest.Width,
					opt => opt.MapFrom (src => src.Width))
				.ForMember (dest =>
					dest.MakeType,
					opt => opt.MapFrom (src => src.MakeType))
				.ForMember (dest =>
					dest.IsTag,
					opt => opt.MapFrom (src => src.IsTag))
				.ReverseMap ();

			CreateMap<ComponentHistory, Component> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))

				.ForMember (dest =>
					dest.CompId,
					opt => opt.MapFrom (src => src.CompId))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.DrawingNo,
					opt => opt.MapFrom (src => src.DrawingNo))
				.ForMember (dest =>
					dest.CompTypeId,
					opt => opt.MapFrom (src => src.CompTypeId))
				.ForMember (dest =>
					dest.ComponentNo,
					opt => opt.MapFrom (src => src.ComponentNo))
				.ForMember (dest =>
					dest.IsGroup,
					opt => opt.MapFrom (src => src.IsGroup))
				.ForMember (dest =>
					dest.Leng,
					opt => opt.MapFrom (src => src.Leng))
				.ForMember (dest =>
					dest.Breath,
					opt => opt.MapFrom (src => src.Breath))
				.ForMember (dest =>
					dest.Height,
					opt => opt.MapFrom (src => src.Height))
				.ForMember (dest =>
					dest.Breath,
					opt => opt.MapFrom (src => src.Breath))
				.ForMember (dest =>
					dest.CompStatus,
					opt => opt.MapFrom (src => src.CompStatus))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.IsActive))
				.ForMember (dest =>
					dest.Thickness,
					opt => opt.MapFrom (src => src.Thickness))
				.ForMember (dest =>
					dest.QrCode,
					opt => opt.MapFrom (src => src.QrCode))
				.ForMember (dest =>
					dest.Width,
					opt => opt.MapFrom (src => src.Width))
				.ForMember (dest =>
					dest.MakeType,
					opt => opt.MapFrom (src => src.MakeType))
				.ForMember (dest =>
					dest.IsTag,
					opt => opt.MapFrom (src => src.IsTag))
				.ReverseMap ();

			CreateMap<ComponentDetails, ComponentHistory> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))

				.ForMember (dest =>
					dest.CompId,
					opt => opt.MapFrom (src => src.CompId))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.DrawingNo,
					opt => opt.MapFrom (src => src.DrawingNo))
				// .ForMember (dest =>
				// 	dest.CompType.Name,
				// 	opt => opt.MapFrom (src => src.CompTypeName))
				.ForMember (dest =>
					dest.ComponentNo,
					opt => opt.MapFrom (src => src.ComponentNo))
				.ForMember (dest =>
					dest.IsGroup,
					opt => opt.MapFrom (src => src.IsGroup))
				.ForMember (dest =>
					dest.Leng,
					opt => opt.MapFrom (src => src.Leng))
				.ForMember (dest =>
					dest.Breath,
					opt => opt.MapFrom (src => src.Breath))
				.ForMember (dest =>
					dest.Height,
					opt => opt.MapFrom (src => src.Height))
				.ForMember (dest =>
					dest.Breath,
					opt => opt.MapFrom (src => src.Breath))
				.ForMember (dest =>
					dest.CompStatus,
					opt => opt.MapFrom (src => src.CompStatus))
				.ForMember (dest =>
					dest.IsActive,
					opt => opt.MapFrom (src => src.IsActive))
				.ForMember (dest =>
					dest.Thickness,
					opt => opt.MapFrom (src => src.Thickness))
				.ForMember (dest =>
					dest.QrCode,
					opt => opt.MapFrom (src => src.QrCode))
				.ForMember (dest =>
					dest.Width,
					opt => opt.MapFrom (src => src.Width))
				.ForMember (dest =>
					dest.MakeType,
					opt => opt.MapFrom (src => src.MakeType))
				.ForMember (dest =>
					dest.IsTag,
					opt => opt.MapFrom (src => src.IsTag))
				.ReverseMap ();

			CreateMap<AddSiteRequirement, SiteRequirement> ()
				.ForMember (dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ForMember (dest =>
					dest.PlanStartdate,
					opt => opt.MapFrom (src => src.PlanStartdate))
				.ForMember (dest =>
					dest.ActualReleasedate,
					opt => opt.MapFrom (src => src.ActualReleasedate))
				.ForMember (dest =>
					dest.RequireWbsId,
					opt => opt.MapFrom (src => src.RequireWbsId))
				.ForMember (dest =>
					dest.ActualWbsId,
					opt => opt.MapFrom (src => src.ActualWbsId))
				.ForMember (dest =>
					dest.ActualWbsId,
					opt => opt.MapFrom (src => src.ActualWbsId))
				.ForMember (dest =>
					dest.Remarks,
					opt => opt.MapFrom (src => src.Remarks))
				.ForMember (dest =>
					dest.Status,
					opt => opt.MapFrom (src => src.Status))
				.ForMember (dest =>
					dest.StatusInternal,
					opt => opt.MapFrom (src => src.StatusInternal))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ReverseMap ();

			CreateMap<SiteRequirementDetailWithStruct, SiteRequirement> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.MrNo,
					opt => opt.MapFrom (src => src.MrNo))
				.ForMember (dest =>
					dest.ProjectId,
					opt => opt.MapFrom (src => src.ProjectId))
				.ForMember (dest =>
					dest.PlanStartdate,
					opt => opt.MapFrom (src => src.PlanStartdate))
				.ForMember (dest =>
					dest.ActualReleasedate,
					opt => opt.MapFrom (src => src.ActualReleasedate))
				.ForMember (dest =>
					dest.RequireWbsId,
					opt => opt.MapFrom (src => src.RequireWbsId))
				.ForMember (dest =>
					dest.ActualWbsId,
					opt => opt.MapFrom (src => src.ActualWbsId))
				.ForMember (dest =>
					dest.ActualWbsId,
					opt => opt.MapFrom (src => src.ActualWbsId))
				.ForMember (dest =>
					dest.Remarks,
					opt => opt.MapFrom (src => src.Remarks))
				.ForMember (dest =>
					dest.Status,
					opt => opt.MapFrom (src => src.Status))
				.ForMember (dest =>
					dest.StatusInternal,
					opt => opt.MapFrom (src => src.StatusInternal))
				.ForMember (dest =>
					dest.IsDelete,
					opt => opt.MapFrom (src => src.IsDelete))
				.ForMember (dest =>
					dest.SiteReqStructure,
					opt => opt.MapFrom (src => src.SiteRequirementStructures))
				.ReverseMap ();

			CreateMap<SiteRequirementStructure, SiteReqStructure> ()
				.ForMember (dest =>
					dest.Id,
					opt => opt.MapFrom (src => src.Id))
				.ForMember (dest =>
					dest.DrawingNo,
					opt => opt.MapFrom (src => src.DrawingNo))
				.ForMember (dest =>
					dest.StructId,
					opt => opt.MapFrom (src => src.StructId))
				.ForMember (dest =>
					dest.Struct.Name,
					opt => opt.MapFrom (src => src.StructName))					
				.ReverseMap ();

			CreateMap<AddSurplus, SiteDeclaration> ()
				.ForMember (dest =>
					dest.SitereqId,
					opt => opt.MapFrom (src => src.SiteReqId))
				.ForMember (dest =>
					dest.StructId,
					opt => opt.MapFrom (src => src.StructureId))
				.ForMember (dest =>
					dest.SurplusFromdate,
					opt => opt.MapFrom (src => src.SurplusDate))
				.ReverseMap ();

		}
	}

}
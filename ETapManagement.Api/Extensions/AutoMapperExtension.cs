using System;
using System.Collections.Generic;
using AutoMapper;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.Extensions.DependencyInjection;
namespace ETapManagement.Api.Extensions
{
	public static class AutoMapperExtension
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper(typeof(MappingProfile));
		}
	}

	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			CreateMap<UserDetails, Users>()
				.ForMember(dest =>
				   dest.FirstName,
					opt => opt.MapFrom(src => src.firstName))
				.ForMember(dest =>
				   dest.LastName,
					opt => opt.MapFrom(src => src.lastName))
				.ForMember(dest =>
				   dest.Id,
					opt => opt.MapFrom(src => src.userId))
				.ForMember(dest =>
				   dest.Email,
					opt => opt.MapFrom(src => src.email))
				.ForMember(dest =>
				   dest.Phoneno,
					opt => opt.MapFrom(src => src.mobileNo))
				.ForMember(dest =>
				   dest.PsNo,
					opt => opt.MapFrom(src => src.userName))
				.ForMember(dest =>
				   dest.Password,
					opt => opt.MapFrom(src => src.password))
				.ForMember(dest =>
				   dest.RoleId,
					opt => opt.MapFrom(src => src.roleId))
				.ForMember(dest =>
				   dest.ProjectId,
					opt => opt.MapFrom(src => src.ProjectId))
				.ForMember(dest =>
				   dest.BuId,
					opt => opt.MapFrom(src => src.BUId))
				.ForMember(dest =>
				   dest.IcId,
					opt => opt.MapFrom(src => src.ICId))						
				.ForMember(dest =>
				   dest.IsActive,
					opt => opt.MapFrom(src => src.isActive))
				.ForMember(dest =>
				   dest.CreatedBy,
					opt => opt.MapFrom(src => src.createdBy))
				.ForMember(dest =>
				   dest.UpdatedBy,
					opt => opt.MapFrom(src => src.updatedBy))
				.ReverseMap();

			CreateMap<PageAccess, RolesApplicationforms>()
				.ForMember(dest =>
				   dest.Id,
					opt => opt.MapFrom(src => src.Id))
				.ForMember(dest =>
				   dest.FormId,
					opt => opt.MapFrom(src => src.PageDetailId))
				.ForMember(dest =>
				   dest.RoleId,
					opt => opt.MapFrom(src => src.RoleId))
				.ForMember(dest =>
				   dest.IsAdd,
					opt => opt.MapFrom(src => src.IsAdd))
				.ForMember(dest =>
				   dest.IsUpdate,
					opt => opt.MapFrom(src => src.IsUpdate))
				.ForMember(dest =>
				   dest.IsDelete,
					opt => opt.MapFrom(src => src.IsDelete))
				.ForMember(dest =>
				   dest.IsView,
					opt => opt.MapFrom(src => src.IsView))
				.ReverseMap();

			CreateMap<PageDetails, ApplicationForms>()
				.ForMember(dest =>
				   dest.Id,
					opt => opt.MapFrom(src => src.Id))
				.ForMember(dest =>
				   dest.Name,
					opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				   dest.Description,
					opt => opt.MapFrom(src => src.Description))
				.ForMember(dest =>
				   dest.IsAdd,
					opt => opt.MapFrom(src => src.IsAdd))
				.ForMember(dest =>
				   dest.IsUpdate,
					opt => opt.MapFrom(src => src.IsUpdate))
				.ForMember(dest =>
				   dest.IsDelete,
					opt => opt.MapFrom(src => src.IsDelete))
				.ForMember(dest =>
				   dest.IsView,
					opt => opt.MapFrom(src => src.IsView))
				.ReverseMap();

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

            CreateMap<ProjectDetail, Project> ()
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
                    opt => opt.MapFrom (src => src.UpdatedtAt))
                .ForMember(dest =>
                    dest.ProjectSitelocation,
                    opt => opt.MapFrom(src => src.ProjectSiteLocationDetails))
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
        
    
			
			CreateMap<ComponentTypeDetails, ComponentType>()
			.ForMember(dest =>
			   dest.Id,
				opt => opt.MapFrom(src => src.Id))
			.ForMember(dest =>
			   dest.Name,
				opt => opt.MapFrom(src => src.Name))
			.ForMember(dest =>
			   dest.Description,
				opt => opt.MapFrom(src => src.Description))
			.ReverseMap();

		CreateMap<AddWorkBreakDown, WorkBreakdown>()
			.ForMember(dest =>
			   dest.Id,
				opt => opt.MapFrom(src => src.Id))
			.ForMember(dest =>
			   dest.WbsId,
				opt => opt.MapFrom(src => src.WorkBreakDownCode))
			.ForMember(dest =>
			   dest.Segment,
				opt => opt.MapFrom(src => src.Segment))
			.ForMember(dest =>
			   dest.SubSegment,
				opt => opt.MapFrom(src => src.SubSegment))
			.ForMember(dest =>
			   dest.Elements,
				opt => opt.MapFrom(src => src.Element))
						.ForMember(dest =>
			   dest.ProjectId,
				opt => opt.MapFrom(src => src.ProjectId))	
			.ReverseMap();
		

		CreateMap< WorkBreakdown,WorkBreakDownDetails>()
			.ForMember(dest =>
			   dest.Id,
				opt => opt.MapFrom(src => src.Id))
			.ForMember(dest =>
			   dest.WorkBreakDownCode,
				opt => opt.MapFrom(src => src.WbsId))
			.ForMember(dest =>
			   dest.Segment,
				opt => opt.MapFrom(src => src.Segment))
			.ForMember(dest =>
			   dest.SubSegment,
				opt => opt.MapFrom(src => src.SubSegment))
			.ForMember(dest =>
			   dest.Element,
				opt => opt.MapFrom(src => src.Elements))
			.ForMember(dest =>
			   dest.ProjectId,
				opt => opt.MapFrom(src => src.ProjectId))	
			.ForMember(dest =>
			   dest.ProjectCode,
				opt => opt.MapFrom(src => src.Project.ProjCode))
					.ForMember(dest =>
			dest.CreatedDate,
			opt => opt.MapFrom(src =>   src.CreatedAt != null ? src.CreatedAt.Value.ToString("yyyy-MM-dd"):""))
		.ForMember(dest =>
			dest.UpdatedDate ,
			opt => opt.MapFrom(src =>  src.UpdatedAt != null ? src.UpdatedAt.Value.ToString("yyyy-MM-dd"):""))										
			.ReverseMap();



			CreateMap<WorkBreakdown,WorkBreakDownCode>()                   
			.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.WbsId))

			.ForMember(dest =>
				dest.Id,
				opt => opt.MapFrom(src => src.Id));

			CreateMap<VendorDetail, SubContractor>()
				.ForMember(dest =>
				   dest.Id,
					opt => opt.MapFrom(src => src.Id))
				.ForMember(dest =>
				   dest.Name,
					opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				   dest.VendorCode,
					opt => opt.MapFrom(src => src.VendorCode))
				.ForMember(dest =>
				   dest.IsDelete,
					opt => opt.MapFrom(src => src.IsDelete))
				.ForMember(dest =>
				   dest.IsStatus,
					opt => opt.MapFrom(src => src.IsStatus))
				.ForMember(dest =>
				   dest.CreatedBy,
					opt => opt.MapFrom(src => src.CreatedBy))
				.ForMember(dest =>
				   dest.CreatedAt,
					opt => opt.MapFrom(src => src.CreatedAt))
				.ForMember(dest =>
				   dest.UpdatedBy,
					opt => opt.MapFrom(src => src.UpdatedBy))
				.ForMember(dest =>
					dest.UpdatedAt,
					opt => opt.MapFrom(src => src.UpdatedAt))
				.ForMember(dest =>
					dest.Email,
					opt => opt.MapFrom(src => src.Email))
				.ForMember(dest =>
					dest.PhoneNo,
					opt => opt.MapFrom(src => src.PhoneNunmber))
				.ForMember(dest =>
					dest.SubContractorServiceType,
					opt => opt.MapFrom(src => src.VendorServiceTypeDetails))
				.ReverseMap(); 

			CreateMap<ProjectSiteLocationDetail, ProjectSitelocation>()
				.ForMember(dest =>
				dest.Id,
				opt => opt.MapFrom(src => src.Id))
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Name))
				.ReverseMap();

			CreateMap<VendorServiceTypeDetail, SubContractorServiceType>()
				.ForMember(dest =>
				dest.Id,
				opt => opt.MapFrom(src => src.Id))
				.ForMember(dest =>
				dest.SubcontId,
				opt => opt.MapFrom(src => src.VendorId))
				.ForMember(dest =>
				dest.ServicetypeId,
				opt => opt.MapFrom(src => src.ServiceTypeId))
				.ReverseMap();
		}
	} 

}
using System;
using System.Collections.Generic;
using AutoMapper;
using ETapManagement.Domain;
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

			CreateMap<Role, Roles>()
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
				   dest.Level,
					opt => opt.MapFrom(src => src.Level))
				.ReverseMap();

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
			/*.ForMember(dest =>
			   dest.IsDelete,
				opt => opt.MapFrom(src => src.IsDelete))  //TODO table does not have this column yet
			.ForMember(dest =>
			   dest.IsActive,
				opt => opt.MapFrom(src => src.IsActive))*/
			.ReverseMap();
		}
	}

}
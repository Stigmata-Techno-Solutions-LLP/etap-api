using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using ETapManagement.Api.Extensions;
using ETapManagement.Api.Helper;
using ETapManagement.Repository;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OwaspHeaders.Core.Extensions;
using ETapManagement.Common;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

		}
		public void ConfigureServices(IServiceCollection services)
		{

			// configure strongly typed settings objects
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<ETapManagement.ViewModel.Dto.AppSettings>(appSettingsSection);

			// configure jwt authentication
			var appSettings = appSettingsSection.Get<ETapManagement.ViewModel.Dto.AppSettings>();
			//Extension method for less clutter in startup
			services.AddApplicationDbContext(appSettings);
			services.AddControllers().AddNewtonsoftJson(options =>
			  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
			//DI Services and Repos
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddScoped<IPageAccessService, PageAccessService>();
			services.AddScoped<IPageAccessRepository, PageAccessRepository>();
			services.AddScoped<IComponentTypeRepository, ComponentTypeRepository>();
			services.AddScoped<IComponentTypeService, ComponentTypeService>();
			services.AddScoped<ICommonRepository, CommonRepository>();
			services.AddScoped<IProjectService, ProjectService>();
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ISegmentService, SegmentService>();
			services.AddScoped<ISegmentRepository, SegmentRepository>();
			services.AddScoped<IWBSRepository, WBSRepository>();
			services.AddScoped<IWBSService, WBSService>();
			services.AddScoped<IVendorService, VendorService>();
			services.AddScoped<IVendorRepository, VendorRepository>();
			services.AddScoped<IStructureTypeService, StructureTypeService>();
			services.AddScoped<IStructureTypeRepository, StructureTypeRepository>();
			services.AddScoped<IICService, ICService>();
			services.AddScoped<IICRepository, ICRepository>();
			services.AddScoped<IBUService, BUService>();
			services.AddScoped<IBURepository, BURepository>();
			services.AddScoped<IStructureService, StructureService>();
			services.AddScoped<IStructureRepository, StructureRepository>();

			services.AddScoped<IAssignStructureComponentRepository, AssignStructureComponentRepository>();
			services.AddScoped<IAssignStructureComponentService, AssignStructureComponentService>();
			services.AddScoped<IComponentService, ComponentService>();
			services.AddScoped<IComponentRepository, ComponentRepository>();

			services.AddScoped<ISiteRequirementRepository, SiteRequirementRepository>();
			services.AddScoped<ISiteRequirementService, SiteRequirementService>();
			services.AddScoped<ISurplusRepository, SurplusRepository>();
			services.AddScoped<ISurplusService, SurplusService>();

			services.AddScoped<ISiteDispatchRepository, SiteDispatchRepository>();
			services.AddScoped<ISiteDispatchService, SiteDispatchService>();
			services.AddScoped<IDispatchService, DispatchService>();

			services.AddScoped<IScrapStructureRepository, ScrapStructureRepository>();
			services.AddScoped<IScrapStructureService, ScrapStructureService>();

			services.AddScoped<IDispatchReqSubConRepository, DispatchReqSubConRepository>();

			services.AddScoped<IPhysicalVerificationService, PhysicalVerificationService>();
			services.AddScoped<IPhysicalVerificationRepository, PhysicalVerificationRepository>();

			services.AddScoped<IFabricationManagementService, FabricationManagementService>();
			services.AddScoped<IFabricationManagementRepository, FabricationManagementRepository>();

			services.AddScoped<IReceiveRepository, ReceiveRepository>();
			services.AddScoped<IReceiveService, ReceiveService>();

			services.AddScoped<IStrategicBusinessRepository, StrategicBusinessRepository>();
			services.AddScoped<IStrategicBusinessService, StrategicBusinessService>();


			services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

			var key = Encoding.ASCII.GetBytes(appSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})

				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false,
						ClockSkew = TimeSpan.Zero
					};
				});
			services.Configure<ETapManagement.ViewModel.Dto.AppSettings>(Configuration.GetSection("AppSettings"));
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			// WebApi Configuration
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.IgnoreNullValues = true;
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // for enum as strings
			});

			// AutoMapper settings
			services.AddAutoMapperSetup();

			// HttpContext for log enrichment 
			services.AddHttpContextAccessor();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			// Swagger settings
			services.AddApiDoc();
			// GZip compression
			services.AddCompression();

			services.AddControllersWithViews();
			services.AddDirectoryBrowser();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCustomSerilogRequestLogging();

			app.UseRouting();
			app.UseStaticFiles();
			if (!Directory.Exists("./Images")) Directory.CreateDirectory("./Images");
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
						Path.Combine(env.ContentRootPath, "Images")),
				RequestPath = "/Images"
			});

			app.UseDirectoryBrowser(new DirectoryBrowserOptions
			{
				FileProvider = new PhysicalFileProvider(
						Path.Combine(env.ContentRootPath, "Images")),
				RequestPath = "/Images"
			});
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
						Path.Combine(env.ContentRootPath, "Documents")),
				RequestPath = "/Documents"
			});

			app.UseDirectoryBrowser(new DirectoryBrowserOptions
			{
				FileProvider = new PhysicalFileProvider(
						Path.Combine(env.ContentRootPath, "Documents")),
				RequestPath = "/Documents"
			});

			app.UseCors("AllowAll");

			app.UseApiDoc();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
            WebHelpers.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

			//added request logging

			app.UseHttpsRedirection();
			app.UseMiddleware<JwtMiddleware>();
			app.UseMiddleware<ApiLoggingMiddleware>();

			app.UseResponseCompression();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseSecureHeadersMiddleware(SecureHeadersMiddlewareExtensions.BuildDefaultConfiguration());
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			// app.UseCors(options => options.AllowAnyOrigin());  

		}
	}
}
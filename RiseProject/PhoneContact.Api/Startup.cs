using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PhoneContact.Core.Helpers;
using PhoneContact.Data.Abstract;
using PhoneContact.Data.EfDbContext;
using PhoneContact.Data.Uow;
using PhoneContact.Engine.Abstract;
using PhoneContact.Engine.Services;
using System.Text;

namespace PhoneContact.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers().AddNewtonsoftJson(options =>
            //{
            //    // Use the default property (Pascal) casing
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});
            services.AddControllers();

           
            //services.AddTransient<IValidator<UserDto>, UserValidator>();
            services.AddMemoryCache();
            services.AddDbContext<PhoneContactContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAppSettings, AppSettings>();
            services.AddTransient<IUSerServices, UserManager>();
            services.AddTransient<IContactService, ContactManager>();
            services.AddTransient<ICacheManagementService, CacheManager>();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(x => x
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()); 
            app.UseAuthentication();
          
        }
    }
}

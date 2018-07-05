using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Application.Mapper;
using Infrastructure.Repository.UnitOfWork;
using Application.Interface;
using Application.Implementation;
using Domain.Interface;
using Domain.Implementation;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("App")));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DtoMapperProfile>();
                cfg.AddProfile<EntityMapperProfile>();
            });

            ConfigureDependencies(services);
        }

        private static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            #region AppService

            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IStockAppService, StockAppService>();

            #endregion

            #region Service

            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IStockDomainService, StockDomainService>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

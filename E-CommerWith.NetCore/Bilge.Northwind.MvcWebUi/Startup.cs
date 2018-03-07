using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge.Northwind.Business.Abstract;
using Bilge.Northwind.Business.Concrete;
using Bilge.Northwind.DataAccess.Abstract;
using Bilge.Northwind.DataAccess.Concrete.EntityFramework;
using Bilge.Northwind.MvcWebUi.Entities;
using Bilge.Northwind.MvcWebUi.Middlewares;
using Bilge.Northwind.MvcWebUi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bilge.Northwind.MvcWebUi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategorytDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer("Server=.;Database=NORTHWND;User Id=sa; Password=123"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession();
            app.UseMvc(configureRoutes);


        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {

            routeBuilder.MapRoute("Default", "{controller=Product}/{Action=Index}/{id?}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Contexts;
using CoreApp.Entities;
using CoreApp.Interfaces;
using CoreApp.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddDbContext<CoreAppContext>();
            services.AddIdentity<AppUser, IdentityRole>(opt=> {

                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;

            
            }).AddEntityFrameworkStores<CoreAppContext>();

            services.ConfigureApplicationCookie(opt => 
            {

                opt.LoginPath = new PathString("/Home/GirisYap");//klogin yolu bu
                opt.Cookie.Name = "AspNetCoreApp";//cookinn tarayýcada görünme adý
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;//cookie site modu strict olunca hiç bir alt domian kullanamaz
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);//cookienin kalma süresi


            }) ;

            services.AddHttpContextAccessor();

            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IUrunRepository, UrunRepository>();
            services.AddScoped<IUrunKategoriRepository, UrunKategoriRepository>();
            services.AddScoped<ISepetRepository, SepetRepository>();
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");

          

           // IdentityInitializer.OlusuturAdmin(userManager, roleManager);

          

            app.UseRouting();
            app.UseSession();


            app.UseAuthentication();//ilglil kullanýcý gitiþ yapmýþ mý kontrol eder
            app.UseAuthorization();//giriþ yapan kullanýcýnýn yetkisini kontrol eder

            //nodee module ile dosya dýþarý çýkarma
            //app.UseStaticFiles(new StaticFileOptions
            //{//bu middle ware bootstrap vs dosyalarý import etmek için 
            //    FileProvider =new PhysicalFileProvider(Path.Combine
            //    (Directory.GetCurrentDirectory(),"node_modules")),

            //    //Nasý bir istek geldiðinde açýlacak onu belirtiyoruz
            //    RequestPath="/content"



            //});

            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "Areas", pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}");

                //adimine gitmesi için yazdýðýmýz endpoint

                endpoints.MapControllerRoute(
                    name: "default",

                    pattern: "{Controller=Home}/{Action=Index}/{id?}"


                    );



            });
        }
    }
    
}

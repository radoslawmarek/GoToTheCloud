using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authentication;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authorization;
using PIcodeFirst.GoToTheCloud.FrontEnd.Configuration;
using PICodeFirst.GoToTheCloud.App.Configurations;
using PICodeFirst.GoToTheCloud.App.TravelModel;
using PICodeFirst.GoToTheCloud.App.UserModel;
using PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi;
using PICodeFirst.GoToTheCloud.Infrastructure.Db;
using System;

namespace PIcodeFirst.GoToTheCloud.FrontEnd
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

            })
            .AddAzureAdAuthentication(options => Configuration.Bind("AzureAd", options))
            .AddCookie();

            services.Configure<AzureAdGroupsOptions>(Configuration.GetSection("AdGroups"));
            services.AddSingleton<ConnectionStrings>(Configuration.GetConnectionStrings());
            services.AddSingleton<UserApiCredentials>(Configuration.GetUserApiCredentials());

            services.AddTransient<ITravelRepository, SqlTravelRepository>();
            services.AddTransient<IUserService, AzureAdGraphService>();

            services.AddMvc();
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ClaimsPrincipalExtensions.SetAzureAdGroupOptions(serviceProvider.GetService<IOptions<AzureAdGroupsOptions>>().Value);

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

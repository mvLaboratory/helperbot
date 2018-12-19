using Core;
using Core.Jobs;
using DAL.Data;
using Hangfire;
using HelperBot;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebHelper
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
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      var connectionString = @"Server=localhost\SQLEXPRESS;Database=HelperBotDb;Integrated Security=True;";
      services.AddHangfire(x => x.UseSqlServerStorage(connectionString));

      services.AddDbContext<BotSqlStorage>(options => options.UseSqlServer(connectionString));

      services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));
      services.AddSingleton<IJobFactory, JobFactory>();
      services.AddSingleton<ITelegramChat, TelegramChat>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseHangfireServer();
      app.UseHangfireDashboard();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });

      var jobFactory = (IJobFactory) app.ApplicationServices.GetService(typeof(IJobFactory));
      jobFactory.SetUpDefaultJobs();
    }
  }
}

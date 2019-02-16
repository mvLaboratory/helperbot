using DAL;
using Hangfire;
using Core.Jobs;
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

      //TODO:: read from config
      var dbConnectionString = @"Server=localhost\SQLEXPRESS;Database=HelperBotDb;Integrated Security=True;";
      services.AddHangfire(x => x.UseSqlServerStorage(dbConnectionString));
      services.AddDbContextPool<HelperBotContext>(options => options.UseSqlServer(dbConnectionString));
      //options => options.UseSqlServer(dbConnectionString)

      services.AddSingleton<IJobFactory, JobFactory>();
      services.AddScoped<SendCurrencyExchangeRateNotificationJob, SendCurrencyExchangeRateNotificationJob>();
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

      SetupJobs((IJobFactory)app.ApplicationServices.GetService(typeof(IJobFactory)));
    }

    public void SetupJobs(IJobFactory jobFactory)
    {
      jobFactory.GetDefailtJobs().ForEach(job =>
        RecurringJob.AddOrUpdate(() => job.Item1.Execute(), job.Item2)
      );
    }
  }
}
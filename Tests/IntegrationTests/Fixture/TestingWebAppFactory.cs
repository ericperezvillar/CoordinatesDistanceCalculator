using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi;

namespace IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Startup> where TEntryPoint : Startup
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            /*
             
                WE DON'T NEED TO DO THIS InMemory SET AS IT IS ALREADY PART OF OUR WEB.API 

             */


            builder.ConfigureServices(services =>
            {
                //var descriptor = services.SingleOrDefault(
                //    d => d.ServiceType ==
                //        typeof(DbContextOptions<CalculatorContext>));

                //if (descriptor != null)
                //    services.Remove(descriptor);

                //services.AddDbContext<CalculatorContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryCalculatorContextTest");
                //});

                //var sp = services.BuildServiceProvider();
                //using (var scope = sp.CreateScope()) ;
                //using (var appContext = scope.ServiceProvider.GetRequiredService<CalculatorContext>())
                //{
                //    try
                //    {
                //        appContext.Database.EnsureCreated();
                //    }
                //    catch (Exception ex)
                //    {
                //        //Log errors or do anything you think it's needed
                //        throw;
                //    }
                //}
            });
        }
    }
}

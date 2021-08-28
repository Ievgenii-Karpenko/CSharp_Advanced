using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            int x = 0;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.Use(async (context, next) =>
            //{
            //    x++;
            //    await next.Invoke();
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //    endpoints.MapGet("/req", async context =>
            //    {
            //        await context.Response.WriteAsync($"Requests sent: {x}");
            //    });
            //});

            //x = 2;
            //app.Use(async (context, next) =>
            //{
            //    x = x * 2;      // 2 * 2 = 4
            //    await next.Invoke();    // вызов app.Run
            //    x = x * 2;      // 8 * 2 = 16
            //    await context.Response.WriteAsync($"Result: {x}");
            //});

            //app.Run(async (context) =>
            //{
            //    x = x * 2;  //  4 * 2 = 8
            //    await Task.FromResult(0);
            //});

            //// not recommended
            //{
            //    //app.Use(async (context, next) =>
            //    //{
            //    //    await context.Response.WriteAsync("<p>Hello world!</p>"); // do not use before next.Invoke()
            //    //    await next.Invoke();
            //    //});

            //    //app.Run(async (context) =>
            //    //{
            //    //    // await Task.Delay(10000); можно поставить задержку
            //    //    await context.Response.WriteAsync("<p>Good bye, World...</p>");
            //    //});
            //}

            ////Mapping of pages
            //{
            //    app.Map("/index", Index);
            //    app.Map("/about", About);

            //    //can be inside other map
            //    app.Map("/home", home =>
            //    {
            //        home.Map("/index", Index);
            //        home.Map("/about", About);
            //    });

            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("-- Main Page --");
            //    });
            //}

            //// Map with condition
            //{
            //    app.MapWhen(context =>
            //    {

            //        return context.Request.Query.ContainsKey("id") &&
            //                context.Request.Query["id"] == "5";
            //    }, HandleId);

            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Good bye, World...");
            //    });
            //}

            //Custom middleware
            {
                //app.UseMiddleware<TokenMiddleware>();

                //app.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            }

            //Custom middleware sith own name 
            {
                app.UseToken("456");

                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                //Add using of pattern
            }

        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }

        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }
    }
}

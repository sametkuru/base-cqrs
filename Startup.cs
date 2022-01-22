using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.CQRS.Handlers;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentContext>(opt =>
            {
                opt.UseNpgsql(
                    "Host=localhost;Database=StudentsManagementDb;Username=postgres;Password=gotr*123;Port=5433;");
            });

            services.AddMediatR(typeof(Startup));
            
            // services.AddScoped<GetStudentByIdQueryHandler>();
            // services.AddScoped<GetAllStudentsQueryHandler>();
            // services.AddScoped<CreateStudentCommandHandler>();
            // services.AddScoped<RemoveStudentCommandHandler>();
            // services.AddScoped<UpdateStudentCommandHandler>();

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}
using AwesomeGymLive.Application;
using AwesomeGymLive.Application.Commands.AddStudent;
using AwesomeGymLive.Application.Queries.GetStudents;
using AwesomeGymLive.Application.Repositories;
using AwesomeGymLive.Domain;
using AwesomeGymLive.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace AwesomeGymLive.API
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

            services.AddMediatR(typeof(Startup));

            services.AddDbContext<StudentContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("StudentConnection"))
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AwesomeGymLive.API", Version = "v1" });
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRequestHandler<AddStudentCommand, bool>, AddStudentCommandHandler>();
            services.AddScoped<IRequestHandler<GetStudentQueryById, GetStudentsViewModel>, GetStudentQueryHandler>();
            services.AddScoped<IRequestHandler<GetStudentByName, List<GetStudentsViewModel>>, GetStudentQueryHandler>();
            services.AddScoped<IRequestHandler<GetStudentQueryAll, List<GetStudentsViewModel>>, GetStudentQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AwesomeGymLive.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

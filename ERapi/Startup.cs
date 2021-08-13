using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Application;
using Application.Aplication.Infrastructure;
using Application.Aplication.Product.Domain.Read.Repositories;
using Application.Aplication.Function.Domain.Read.Repositories;
using Application.Aplication.Product.Domain.Write.Repositories;
using Application.Aplication.Function.Domain.Write.Repositories;
using Application.Aplication.Worker.Domain.Write.Repositories;
using Application.Aplication.Product.Domain.Write.CommandHandlers;
using Application.Aplication.Function.Domain.Write.CommandHandllers;
using Application.Aplication.Worker.Domain.Write.CommandHandlers;
using Application.Aplication.Product.Domain.Maps.Read;

namespace ERapi
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
            //just having one coppy of instance
            //Sql connection
            services.AddSingleton<ISqlConnectionFactory,SqlConnectionFactory>();
            
            //Repositories ( Read )
            services.AddScoped<IBaseReadProductRepository,ProductReadRepository>();
            services.AddScoped<IBaseReadFunctionRepository, FunctionReadRepository>();

            //Reopsitories ( Write )
            services.AddScoped<IBaseWriteProductRepository,ProductWriteRepository>();
            services.AddScoped<IBaseWriteFunctionRepository,FunctionWriteRepository>();
            services.AddScoped<IBaseWriteWorkerRepository, WorkerWriteRepository>();

            //CommandHandlers
            services.AddScoped<IProductCommandHandler,ProductCommandHandler>();
            services.AddScoped<IFunctionCommandHandler,FunctionCommandHandler>();
            services.AddScoped<IWorkerCommandHandler,WorkerCommandHandler>();


            services.AddControllers();

            services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERapi", Version = "v1" });
            });

            //NHibernate Configuration
            var sqlConnectionFactory = new SqlConnectionFactory();
            var connStr = sqlConnectionFactory.GetConnectionString();
           //  var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           /* var _sessionFactory = Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                                      .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                                      .BuildSessionFactory();*/
            var _sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductModelMap>())
                            .BuildSessionFactory();
            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERapi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

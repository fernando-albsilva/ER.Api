using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using Application.Aplication.Infrastructure;
using Application.Aplication.Product.Domain.Read.Repositories;
using Application.Aplication.Function.Domain.Read.Repositories;
using Application.Aplication.Product.Domain.Write.Repositories;
using Application.Aplication.Function.Domain.Write.Repositories;
using Application.Aplication.Worker.Domain.Write.Repositories;

using Application.Aplication.Function.Domain.Write.CommandHandllers;
using Application.Aplication.Worker.Domain.Write.CommandHandlers;
using Application.Aplication.Product.Domain.Maps.Read;
using Application.Aplication.Function.Domain.Maps.Read;
using Application.Aplication.Worker.Domain.Maps.Read;
using Application.Aplication.Worker.Domain.Read.Repositories;
using System.Text;
using ERapi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Application.Aplication.Auth.User.Read.Repositories;
using Application.Aplication.Home.Domain.Maps.Read;
using Application.Aplication.Home.Domain.Read.Repositories;
using Application.Aplication.Invoice.Domain.Write.CommandHandlers;
using Application.Aplication.Product.Domain.Write.CommandHandlers;
using Application.Aplication.Invoice.Domain.Write.Repositories;
using Application.Aplication.Invoice.Domain.Read.Repositories;

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
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

            //Repositories ( Read )
            services.AddScoped<IBaseReadProductRepository, ProductReadRepository>();
            services.AddScoped<IBaseReadFunctionRepository, FunctionReadRepository>();
            services.AddScoped<IBaseReadWorkerRepository, WorkerReadRepository>();
            services.AddScoped<IBaseReadUserRepository, UserReadRepository>();
            services.AddScoped< IBaseReadHomeRepository, HomeReadRepository > ();
            services.AddScoped< IBaseReadInvoiceRepository, InvoiceReadRepository > ();



            //Reopsitories ( Write )
            services.AddScoped<IBaseWriteProductRepository, ProductWriteRepository>();
            services.AddScoped<IBaseWriteFunctionRepository, FunctionWriteRepository>();
            services.AddScoped<IBaseWriteWorkerRepository, WorkerWriteRepository>();
            services.AddScoped<IBaseWriteInvoiceRepository, InvoiceWriteRepository>();



            //CommandHandlers
            services.AddScoped<IFunctionCommandHandler, FunctionCommandHandler>();
            services.AddScoped<IWorkerCommandHandler, WorkerCommandHandler>();
            services.AddScoped<IProductCommandHandler, ProductCommandHandler>();
            services.AddScoped<IInvoiceCommandHandler, InvoiceCommandhandler>();

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

            var _sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                            .Mappings(m => m.FluentMappings
                                .AddFromAssemblyOf<ProductModelMap>()
                                .AddFromAssemblyOf<FunctionModelMap>()
                                .AddFromAssemblyOf<WorkerModelMap>()
                                .AddFromAssemblyOf<WaiterModelMap>())
                            .BuildSessionFactory();
            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });

            //token
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
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

            //app.UseCors();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }


    }
}

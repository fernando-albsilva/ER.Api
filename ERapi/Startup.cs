using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Application.DataBaseConnection;
using Application.Product.Domain.Read.Repositories;
using Application.Function.Domain.Read.Repositories;
using Application.Worker.Domain.Read.Repositories;
using Application.Home.Domain.Read.Repositories;
using Application.Invoice.Domain.Read.Repositories;
using Application.Product.Domain.Write.Repositories;
using Application.Function.Domain.Write.Repositories;
using Application.Worker.Domain.Write.Repositories;
using Application.Invoice.Domain.Write.Repositories;
using Application.Function.Domain.Write.CommandHandllers;
using Application.Worker.Domain.Write.CommandHandlers;
using Application.Product.Domain.Write.CommandHandlers;
using Application.Invoice.Domain.Write.CommandHandlers;
using Application.Product.Domain.Maps.Read;
using Application.Product.Domain.Maps.Write;
using Application.Function.Domain.Maps.Read;
using Application.Worker.Domain.Maps.Read;
using Application.Home.Domain.Maps.Read;
using Application.Invoice.Domain.Maps.Write;
using Application.Auth.Domain.Read.Repositories;
using Application.Auth.User.Read.Repositories;
using Application.Auth.User.Domain.Write.Repositories;
using Application.Auth.User.Domain.Write.CommandHandlers;
using System;
using Application.ActiveInvoice.Domain.Write.CommandHandlers;
using Application.ActiveInvoice.Domain.Write.Repositories;
using Application.ActiveInvoice.Domain.Read.Repositories;
using Application.ActiveInvoice.Domain.Maps.Write;
using Application.Auth.User.Domain.Maps.Read;
using Application.Worker.Domain.Read.Model;
using Application.Auth.User.Domain.Maps.read;
using Application.CheckManagement.Domain.Read.Repositories;

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
            services.AddScoped<IBaseReadHomeRepository, HomeReadRepository> ();
            services.AddScoped<IBaseReadInvoiceRepository, InvoiceReadRepository> ();
            services.AddScoped<IBaseReadActiveInvoiceRepository, ActiveInvoiceReadRepository> ();
            services.AddScoped<IBaseReadCheckManagementRepository, CheckManagementReadRepository> ();


            //Reopsitories ( Write )
            services.AddScoped<IBaseWriteProductRepository, ProductWriteRepository>();
            services.AddScoped<IBaseWriteFunctionRepository, FunctionWriteRepository>();
            services.AddScoped<IBaseWriteWorkerRepository, WorkerWriteRepository>();
            services.AddScoped<IBaseWriteUserRepository, UserWriteRepository>();
            services.AddScoped<IBaseWriteInvoiceRepository, InvoiceWriteRepository>();
            services.AddScoped<IBaseWriteActiveInvoiceRepository, ActiveInvoiceWriteRepository>();



            //CommandHandlers
            services.AddScoped<IFunctionCommandHandler, FunctionCommandHandler>();
            services.AddScoped<IWorkerCommandHandler, WorkerCommandHandler>();
            services.AddScoped<IUserCommandHandler, UserCommandHandler>();
            services.AddScoped<IProductCommandHandler, ProductCommandHandler>();
            services.AddScoped<IInvoiceCommandHandler, InvoiceCommandhandler>();
            services.AddScoped<IActiveInvoiceCommandHandler, ActiveInvoiceCommandHandler>();

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
                                .AddFromAssemblyOf<ProductStateMap>()
                                .AddFromAssemblyOf<FunctionModelMap>()
                                .AddFromAssemblyOf<WorkerModelMap>()
                                .AddFromAssemblyOf<WorkerActiveInvoiceModel>()
                                .AddFromAssemblyOf<WaiterModelMap>()
                                .AddFromAssemblyOf<UserModelMap>()
                                .AddFromAssemblyOf<InvoiceStateMap>()
                                .AddFromAssemblyOf<InvoiceItemStateMap>()
                                .AddFromAssemblyOf<ActiveInvoiceStateMap>()
                                .AddFromAssemblyOf<ActiveInvoiceItemStateMap>()
                                .AddFromAssemblyOf<UserInvoiceModelMap>()
                             )
                            .BuildSessionFactory();
            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Tokens:Issuer"],
                       ValidAudience = Configuration["Tokens:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                       ClockSkew = TimeSpan.Zero,
                   };
               });

           /* //token
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
             });*/


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

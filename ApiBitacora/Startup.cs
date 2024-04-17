using AccessControl.Interfaces;
using AccessControl.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AccessControl.Services;

using DAOApi.Models;

using static System.Net.WebRequestMethods;
using ServicesApi.InterfaceApi;
using ServicesApi.ImplementacionApi;
using DAOApi;
using Logic.OpercaionesDB;

namespace ApiBitacora
{
    public class Startup
    {

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddCors(o => o.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("authorization")));
            // Access-Control-Expose-Headers: authorization sirve para exponer authorization en el lado del cliente

            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ICredentialManager, CredentialManager>();
            services.AddScoped<IJwtHandler, JwtHandler>();

            // se agrega el service despues de implemetar una interface con implementacion de services
            services.AddScoped<IAuthServices, ImAuthService>();
            services.AddScoped<InterfaceGenerica, ImpGenerica>();
            services.AddScoped<IConUsuario, ImpConUser>();
            services.AddScoped<IFaseProspectos, ImpFaseProspectos>();
            services.AddScoped<IConsultaProspecto, ImpConProspecto>();
            services.AddScoped<IConBitacora, ImpConBitacora>();

            services.AddScoped<ProcesaHistoricoBitacora>();
            services.AddScoped<ConsultaUsuario>();
            services.AddScoped<FaseProspectos>();
            services.AddScoped<ConsultaProspecto>();
            services.AddScoped<ConsultaBitacora>();



            services.AddHttpContextAccessor();
            services.AddControllers();

            var jwtSection = _configuration.GetSection("jwt");
            var jwtOptions = new JwtOptions();

            jwtSection.Bind(jwtOptions);
            services.AddAuthentication()
               .AddJwtBearer(cfg =>
               {
                   cfg.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                       ValidIssuer = jwtOptions.Issuer,
                       ValidateAudience = jwtOptions.ValidateAudience,
                       ValidateLifetime = jwtOptions.ValidateLifetime
                   };
               });
            services.Configure<JwtOptions>(jwtSection);
            services.Configure<AccessOptions>(_configuration.GetSection("access"));

            // DAOApi
            // services.Configure<ModelConexion>(_configuration.GetSection("ConnectionStrings"));
            services.AddTransient<ConexionSql>();
            services.AddTransient<SqlServerParameterList>();
            services.Configure<ModelConexion>(_configuration.GetSection("ConnectionStrings"));

            //
            //TODO: Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            
            // ---------------------------------------------------------------------------------------------------------------------







            //-----------------------------------------------------------------------------------------------------------------------
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                // app.UseExceptionHandler("/Home/Error");
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            if (env.IsProduction())
            {
                // app.UseExceptionHandler("/Home/Error");
                app.UseSwagger();
                app.UseSwaggerUI();

            }


            //-----------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------



            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<TokenMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}

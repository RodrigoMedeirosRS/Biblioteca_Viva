using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;

using API.Interface;
using BibliotecaViva.BLL;
using BibliotecaViva.DAL;
using BibliotecaViva.DataContext;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;
namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            AdicionarControladores(services);
            RealizarInjecaoDeDependenciasBLL(services);
            RealizarInjecaoDeDependenciasDAL(services);
            DefinirConfiguracaoSwagger(services);           
        }

        private static void AdicionarControladores(IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void RealizarInjecaoDeDependenciasBLL(IServiceCollection services)
        {
            services.AddScoped<IPessoaBLL, PessoaBLL>();
            services.AddScoped<IRegistroBLL, RegistroBLL>();
        }

        private static void RealizarInjecaoDeDependenciasDAL(IServiceCollection services)
        { 
            services.AddScoped<ITipoDAL, TipoDAL>();
            services.AddScoped<IIdiomaDAL, IdiomaDAL>();
            services.AddScoped<IPessoaDAL, PessoaDAL>();
            services.AddScoped<IApelidoDAL, ApelidoDAL>();
            services.AddScoped<IRequisicao, Requisicao>();
            services.AddScoped<IRegistroDAL, RegistroDAL>();
            services.AddScoped<IDescricaoDAL, DescricaoDAL>(); 
            services.AddScoped<IReferenciaDAL, ReferenciaDAL>();
            services.AddScoped<INomeSocialDAL, NomeSocialDAL>(); 
            services.AddScoped<ITipoRelacaoDAL, TipoRelecaoDAL>();
            services.AddScoped<IPessoaRegistroDAL, PessoaRegistroDAL>();
            services.AddScoped<ILocalizacaoGeograficaDAL, LocalizacaoGeograficaDAL>();         
            
            services.AddSingleton<ISQLiteDataContext, SQLiteDataContext>();
        }

        private static void DefinirConfiguracaoSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblioteca Viva", Version = "v1" });
                options.CustomOperationIds(d => (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { 
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

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

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;

using BibliotecaViva.BLL;
using BibliotecaViva.DAL;
using BibliotecaViva.DTO;
using BibliotecaViva.Interface;
using BibliotecaViva.DataContext;
using BibliotecaViva.Controllers;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva
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
            services.AddScoped<IEventoBLL, EventoBLL>();
            services.AddScoped<IPerssoaBLL, PessoaBLL>();
            services.AddScoped<IGlossarioBLL, GlossarioBLL>();
            services.AddScoped<IDocumentoBLL, DocumentoBLL>();
            services.AddScoped<ILocalizacaoBLL, LocalizacaoBLL>();
            services.AddScoped<ILinhaDoTempoBLL, LinhaDoTempoBLL>();
        }

        private static void RealizarInjecaoDeDependenciasDAL(IServiceCollection services)
        {
            services.AddScoped<ITextoDAL, TextoDAL>();
            services.AddScoped<IVideoDAL, VideoDAL>();
            services.AddScoped<IAudioDAL, AudioDAL>();
            services.AddScoped<IImagemDAL, ImagemDAL>();
            services.AddScoped<IEventoDAL, EventoDAL>();
            services.AddScoped<IPessoaDAL, PessoaDAL>();
            services.AddScoped<IGeneroDAL, GeneroDAL>();
            services.AddScoped<IIdiomaDAL, IdiomaDAL>();
            services.AddScoped<IRequisicao, Requisicao>();
            services.AddScoped<IApelidoDAL, ApelidoDAL>();
            services.AddScoped<IConceitoDAL, ConceitoDAL>();
            services.AddScoped<IGlossarioDAL, GlossarioDAL>();
            services.AddScoped<IDocumentoDAL, DocumentoDAL>();
            services.AddScoped<ITipoEventoDAL, TipoEventoDAL>();
            services.AddScoped<INomeSocialDAL, NomeSocialDAL>();
            services.AddScoped<ILocalizacaoDAL, LocalizacaoDAL>();
            services.AddScoped<ISignificadoDAL, SignificadoDAL>();
            services.AddScoped<ITipoRelacaoDAL, TipoRelacaoDAL>();
            services.AddScoped<ILinhaDoTempoDAL, LinhaDoTempoDAL>();
            services.AddScoped<ITipoParticipacaoDAL, TipoParticipacaoDAL>();
            
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

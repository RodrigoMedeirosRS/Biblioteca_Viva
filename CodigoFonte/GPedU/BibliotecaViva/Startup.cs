using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;

using BibliotecaViva.BLL;
using BibliotecaViva.DTO;
using BibliotecaViva.Controllers;
using BibliotecaViva.BLL.Interfaces;


namespace BibliotecaViva
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AdicionarControladores(services);
            RealizarInjecaoDeDependencias(services);
            DefinirConfiguracaoSwagger(services);           
        }

        private static void AdicionarControladores(IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void RealizarInjecaoDeDependencias(IServiceCollection services)
        {
            services.AddScoped<IPerssoaBLL, PessoaBLL>();
            //services.AddScoped<IFFMPEG, FFMPEG>();
            //services.AddScoped<ITerminalBashBLL, TerminalBashBLL>();
            //services.AddScoped<IRequisicao, Requisicao>();
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

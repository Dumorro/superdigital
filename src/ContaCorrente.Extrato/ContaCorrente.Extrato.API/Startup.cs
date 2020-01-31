using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao;
using ContaCorrente.Extrato.Aplicacao.Servicos;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Servicos;
using ContaCorrente.Extrato.Infra.CacheAdaptador;
using ContaCorrente.Extrato.Infra.ExtratoRepositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContaCorrente.Extrato.API
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
            ConfiguracaoDoMVC.Configurar(services);
            ConfiguracaoDeInjecaoDeDependencia.Configurar(services, Configuration);
            ConfiguracaoDoSwagger.Configurar(services);
            ConfiguracaoDoRedis.Configurar(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               ConfiguracaoDoSwagger.UseSwaggerUI(app);
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

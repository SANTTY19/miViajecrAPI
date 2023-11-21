using api_miviajecr.Models;
using api_miviajecr.Services.ServicioAmenidades;
using api_miviajecr.Services.ServicioDenuncias;
using api_miviajecr.Services.ServicioFavoritos;
using api_miviajecr.Services.ServicioHistoricoLugaresVisitado;
using api_miviajecr.Services.ServicioInmueble;
using api_miviajecr.Services.ServicioInmuebles;
using api_miviajecr.Services.ServicioPoliticas;
using api_miviajecr.Services.ServicioRestricciones;
using api_miviajecr.Services.Servicios;
using api_miviajecr.Services.ServiciosReservaciones;
using api_miviajecr.Services.ServicioUsuario;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace api_miviajecr
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
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "miViajecrApi", Version = "v1" });
                c.ResolveConflictingActions(apiDesc => apiDesc.First());
            });
            services.AddDbContext<tiusr27pl_ApimisviajescrContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });
            services.AddScoped<IAmenidadRepositorio, AmenidadRepositorio>();
            services.AddScoped<IDetalle, Detalle>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();
            services.AddScoped<ICalificacionUsuarioRepositorio, CalificacionUsuarioRepositorio>();
            services.AddScoped<IInmuebleRepositorio, InmuebleRepositorio>();
            services.AddScoped<ITipoInmuebleRepositorio, TipoInmuebleRepositorio>();
            services.AddScoped<ICaracteristicasInmuebleRepositorio, CaracteristicasInmuebleRepositorio>();
            services.AddScoped<IDisponibilidadInmuebleRepositorio, DisponibilidadInmuebleRepositorio>();
            services.AddScoped<IImagenesInmuebleRepositorio, ImagenesInmuebleRepositorio>();
            services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
            services.AddScoped<IPoliticaRepositorio, PoliticaRepositorio>();
            services.AddScoped<IRestriccionesRepositorio, RestriccionesRepositorio>();
            services.AddScoped<IAmenidadesPorInmuebleRepositorio, AmenidadesPorInmuebleRepositorio>();
            services.AddScoped<IPoliticasPorInmuebleRepositorio, PoliticasPorInmuebleRepositorio>();
            services.AddScoped<IRestriccionesPorInmuebleRepositorio, RestriccionesPorInmuebleRepositorio>();
            services.AddScoped<IServiciosPorInmuebleRepositorio, ServiciosPorInmuebleRepositorio>();
            services.AddScoped<IUbicacionInmuebleRepositorio, UbicacionInmuebleRepositorio>();
            services.AddScoped<IReservacioneRepositorio, ReservacioneRepositorio>();
            services.AddScoped<ICalificacionReservacioneRepositorio, CalificacionReservacioneRepositorio>();
            services.AddScoped<IReservacionCheckInRepositorio, ReservacionCheckInRepositorio>();
            services.AddScoped<IReservacionCheckOutRepositorio, ReservacionCheckOutRepositorio>();
            services.AddScoped<IStatusReservacionRepositorio, StatusReservacionRepositorio>();
            services.AddScoped<IDenunciaRepositorio, DenunciaRepositorio>();  
            services.AddScoped<IStatusDenunciaRepositorio, StatusDenunciaRepositorio>();
            services.AddScoped<IHistoricoLugaresVisitadoRepositorio, HistoricoLugaresVisitadoRepositorio>();
            services.AddScoped<IFavoritoRepositorio, FavoritoRepositorio>();
            


            services.AddCors(o =>
            {
                o.AddPolicy(
                    name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "miViajecrApi v1");
                c.DocumentTitle = "miViajecrApi";
            });

           app.UseHttpsRedirection();
            
            app.UseDeveloperExceptionPage();
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

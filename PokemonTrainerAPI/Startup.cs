using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PokemonTrainerAPI.Map;
using PokemonTrainerAPI.Map.Interfaces;
using PokemonTrainerAPI.Repository;
using PokemonTrainerAPI.Repository.Interfaces;
using PokemonTrainerAPI.Services;
using PokemonTrainerAPI.Services.Interfaces;

namespace PokemonTrainerAPI
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

            services.AddControllers();
            services.AddDbContext<PkTrainerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokemonTrainerAPI", Version = "v1" });
            });
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPokemonService, PokemonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokemonTrainerAPI v1");
                //c.RoutePrefix = string.Empty;
            });
        }
    }
}

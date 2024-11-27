using CursoIdiomasApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomasApi.Configuration
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContexConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApiDbContext>(opitions =>
            {
                opitions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;
        }
    }
}

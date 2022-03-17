using Microsoft.EntityFrameworkCore;
using Server.Data.Migrations;

namespace Server.Infrastruture

{
    public  static class AppBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var service = app.ApplicationServices.CreateScope();
           var dbContext = service.ServiceProvider.GetService<AppDbContext>();

           dbContext.Database.Migrate();
            
        }
    }
}
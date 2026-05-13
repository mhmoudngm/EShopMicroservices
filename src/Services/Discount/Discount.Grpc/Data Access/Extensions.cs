using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data_Access
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbcontext.Database.MigrateAsync();
            return app;
        }
    }
}

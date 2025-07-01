using JobTracking.Application.Contracts.Base;
using JobTracking.Application.Implementation;

namespace JobTracking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register application services and infrastructure
            builder.AddContext();       // Add EF DbContext
            builder.AddIdentity();      // Configure identity and authentication
            builder.AddCors();          // Register CORS policies
            builder.AddServices();      // Add custom services (DI)

            // Add controller support
            builder.Services.AddControllers();

            var app = builder.Build();

            // Middleware pipeline
            app.UseCors("AllowAngularClient");  // Allow frontend access

            app.UseHttpsRedirection();          // Enforce HTTPS

            app.UseAuthorization();             // Apply authorization rules

            app.MapControllers();               // Map API controller routes

            app.Run();                          // Start the application
        }
    }
}
using JobTracking.Application.Contracts.Base;
using JobTracking.Application.Implementation;

namespace JobTracking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddContext();
            builder.AddIdentity();
            builder.AddCors();
            builder.AddServices();

            builder.Services.AddControllers();

            var app = builder.Build();
            
            app.UseCors("AllowAngularClient");

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
using JobTracking.Application.Contracts.Base;
using JobTracking.Application.Implementation;
using JobTracking.DataAccess;
using JobTracking.DataAccess.Persistance;

namespace JobTracking.API
{
    public static class ServiceConfiguratorExtensions
    {
        // Register DbContext for dependency injection
        public static void AddContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<AppDbContext>();
        }

        // Register Identity services (commented)
        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            // builder.Services.AddIdentityCore<IdentityUser>()
            //     .AddRoles<IdentityRole>()
            //     .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("JobTracking")
            //     .AddEntityFrameworkStores<AppDbContext>()
            //     .AddDefaultTokenProviders();

            // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            // {
            //     options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuer = true,
            //         ValidateAudience = true,
            //         ValidateLifetime = true,
            //         ValidateIssuerSigningKey = true,
            //         ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //         ValidAudience = builder.Configuration["Jwt:Audience"],
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //     };
            // });
        }

        // Register application-specific services
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DependencyProvider>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IJobAdService, JobAdService>();
            builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
        }

        // Register CORS policy for frontend access
        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient", policy =>
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
            });
        }
    }
}
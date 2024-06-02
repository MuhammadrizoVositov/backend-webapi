using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Tokens;
using WebSite.Infrostructure.Common;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories;
using WebSite.Persistance.Repositories.Interface;


namespace WebSite.Api.Configurations;

public static partial class HostConfiguration
{
    private static IList<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly()
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }
    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services.AddDbContext<AppIdentityDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddDataProtection();
        builder.Services.AddScoped<IAuthService, AuthService>()
            .AddScoped<ITokenGenerateService, TokenGenerateService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IReactionService, RaectionService>()
            .AddScoped<ICommentService, CommentService>()
            .AddScoped<ICommentRepository, CommentRepository>()
            .AddScoped<IReactionRepository, ReactionRepository>()
            .AddScoped<IFileService, FileService>()
            .AddScoped<IImageRepository, ImageRepsotory>()
            .AddScoped<IImageService, ImageService>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IBookService, BookService>()
            .AddScoped<IProfileService, ProfileService>()
            .AddScoped<IPofileRepository, ProfileRepository>();
        
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "My API - V1",
                    Version = "v1"
                }
             );
        });

        return builder;
    }
    private static WebApplicationBuilder AddAuthontication(this WebApplicationBuilder builder)
    {

        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
        builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;

        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidAudience = jwtSettings.ValidAudience,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidateLifetime = jwtSettings.ValidateLifetime,
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["token"];
                return Task.CompletedTask;
            }
        };

    });
        return builder;
    }
    private static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}

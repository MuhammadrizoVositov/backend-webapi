namespace WebSite.Api.Configurations;

public static partial class HostConfiguration
{
    public async static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddInfrastructure().AddAuthontication().AddDevTools();

          
        return await new ValueTask<WebApplicationBuilder>(builder);
    }
    public async static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseIdentityInfrastructure().UseDevTools().UseExposers();

        return app;
    }

}

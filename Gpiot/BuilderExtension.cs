using Gpiot.DB;
using Gpiot.Helpers;
using Gpiot.Interfaces;
using Microsoft.EntityFrameworkCore;

public static partial class BuilderExtension {
    public static void RegisterCustomDependencies(this WebApplicationBuilder builder) {
        builder.Services.AddSingleton<IGpioHandler, GpioHandler>();
        var connectionString = EnvVariableHelper.GetConnectionString(builder);
        builder.Services.AddDbContext<RpiDbContext>(options => options.UseNpgsql(connectionString));
    }    
}
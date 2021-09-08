using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;

namespace SignalRServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
            .WithOrigins("null")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapHub<ChatHub>("/chathub");
            });

        }
    }
}

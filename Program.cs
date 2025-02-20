
using Microsoft.Extensions.DependencyInjection;
using RTBApi.Hubs;

namespace RTBApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR().AddAzureSignalR("Endpoint=https://imrbpro.service.signalr.net;AccessKey=+jS31AskUn1bb97zAU7n9EhN9ETYhcNzU3QqQoY25TQ=;Version=1.0;");
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.MapControllers();
            app.MapHub<TeamUpdateHub>("/TeamBoard");
            app.Run();
        }
    }
}

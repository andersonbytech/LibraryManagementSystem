using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Queries;
using Library.Infrastructure.Data;

namespace Library.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicione a política de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Write
            builder.Services.AddDbContext<WriteContext>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("WriteConnection"),
                b => b.MigrationsAssembly("Library.API")));

            // Cria a estrutura de leitura via EF (Só será usada pra isso)
            builder.Services.AddDbContext<ReadContext>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("ReadConnection"),
                b => b.MigrationsAssembly("Library.API")));

            // Read
            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("ReadConnection")));
                                    

            builder.Services.AddScoped<GetAllBooksQueryHandler>();
            builder.Services.AddScoped<GetBookIdQueryHandler>();
            builder.Services.AddScoped<AddBookCommandHandler>();
            builder.Services.AddScoped<DeleteBookCommandHandler>();


            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowBlazorClient");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

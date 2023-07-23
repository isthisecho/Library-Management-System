
using Library.API.DataLayer.Implementations;
using Library.API.Services;
using Library.API.Services.UserService;
using LibraryManagementSystem.DataLayer.Abstractions;
using LibraryManagementSystem.DataLayer.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(bearer =>
            {
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey=true                                           ,
                    IssuerSigningKey        = new SymmetricSecurityKey
                                                  (Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
                    ValidateIssuer          =false                                           ,
                    ValidateAudience        =false                                           ,
                };
            });

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
;

            builder.Services.AddDbContext<LibraryDbContext>(context => context.UseNpgsql(builder.Configuration.GetConnectionString("WebApiConnection")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(LibraryDbRepository<> ));
            builder.Services.AddScoped<IBookService,BookService>();
            builder.Services.AddScoped<ITransactionService,TransactionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddSingleton<IConfiguration>(x => builder.Configuration);



            WebApplication app = builder.Build();


            using IServiceScope scope = app.Services.CreateScope();
            await using LibraryDbContext dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            await dbContext.Database.MigrateAsync();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
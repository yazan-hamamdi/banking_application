
using Banking_application_Business.IServices;
using Banking_application_Business.Profile;
using Banking_application_Business.Services;
using banking_application_Data;
using banking_application_Data.Entities;
using banking_application_Data.IEntities;
using banking_application_Data.IRepositories;
using banking_application_Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banking_application_API
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

            // Register repositories
            builder.Services.AddScoped<IAccount, Account>();
            builder.Services.AddScoped<ICustomer, Customer>();
            builder.Services.AddScoped<ITransactionHistory, TransactionHistory>();

            builder.Services.AddScoped<IAccountRepo, AccountRepo>();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<ITransactionHistoryRepo, TransactionHistoryRepo>();

            // Register services
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(AccountProfile));
            builder.Services.AddAutoMapper(typeof(CustomerProfile));
            builder.Services.AddAutoMapper(typeof(TransProfile));

            var app = builder.Build();
            // Configure the HTTP request pipeline.
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
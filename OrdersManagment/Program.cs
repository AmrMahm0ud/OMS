using Microsoft.EntityFrameworkCore;
using OrdersManagment.DataAccess;
using IConfigurationProvider = OrdersManagment.DataAccess.Providers.IConfigurationProvider;
using ConfigurationProvider = OrdersManagment.DataAccess.Providers.ConfigurationProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region DB Connection

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionString")));

#endregion
#region Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
#endregion
#region Service Bindings
builder.Services.AddScoped<IConfigurationProvider, ConfigurationProvider>();
#endregion
builder.Services.AddCors(p => p.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

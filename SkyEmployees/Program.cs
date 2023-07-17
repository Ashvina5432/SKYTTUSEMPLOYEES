using SkyEmployees.BL;
using SkyEmployees.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<EmployeeBL>();
builder.Services.AddTransient<EmployeeRepository>();
builder.Services.AddTransient<EmployeeAddressBL>();
builder.Services.AddTransient<EmployeeAddressRepository>();
builder.Services.AddTransient<EmployeeRelationBL>();
builder.Services.AddTransient<EmployeeRelationRepository>();
builder.Services.AddTransient<FamilyDetailsBL>();
builder.Services.AddTransient<FamilyDetailsRepository>();
builder.Services.AddTransient<AddressTypeBL>();
builder.Services.AddTransient<AddressTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();

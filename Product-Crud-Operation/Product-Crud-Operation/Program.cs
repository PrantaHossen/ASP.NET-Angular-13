using Microsoft.EntityFrameworkCore;
using Product_Crud_Operation.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with the correct connection string
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConEmp")));

builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();

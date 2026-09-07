using Ecom.API.Mapping;
using Ecom.API.Middleware;
using Ecom.infrastructure;
using Microsoft.AspNetCore.Http.Features;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.infrastructureConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(
    cfg => { },
    typeof(CategoryMapping).Assembly,
    typeof(ProductMapping).Assembly
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionsMiddleware>();

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseCors("CORSPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

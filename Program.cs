using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LionDevAPI.Models;

//string MyCors = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyCors, builder =>
//                        //builder.AllowAnyOrigin()
//                        builder.WithOrigins("*")
//                        .AllowAnyMethod()
//                        .AllowAnyHeader()
//                        .Build());
//});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetConnectionString("LionDevConn");

builder.Services.AddDbContext<LionDevContext>(options =>
{
    object value = options.UseSqlServer(builder.Configuration.GetConnectionString("LionDevConn"));

}); ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();

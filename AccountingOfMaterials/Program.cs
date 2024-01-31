using Microsoft.EntityFrameworkCore;
using AccountingOfMaterials.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = "Server=(localdb)\\mssqllocaldb;Database=MachiningBD;Trusted_Connection=False;";
builder.Services.AddDbContext<MaterialsContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
using Microsoft.EntityFrameworkCore;
using ServicePet.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();
app.ConfigureMiddleware();

app.Run();

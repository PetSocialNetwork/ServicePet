using Microsoft.EntityFrameworkCore;
using ServicePet.DataEntityFramework.Repositories;
using ServicePet.DataEntityFramework;
using ServicePet.Domain.Interfaces;
using ServicePet.Domain.Services;
using ServicePet.WebApi.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers
(options =>
{
    options.Filters.Add<CentralizedExceptionHandlingFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PetService", Version = "v1" });
    //options.UseAllOfToExtendReferenceSchemas();
    //string pathToXmlDocs = Path.Combine(AppContext.BaseDirectory, AppDomain.CurrentDomain.FriendlyName + ".xml");
    //options.IncludeXmlComments(pathToXmlDocs, true);
});

builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped(typeof(IRepositoryEF<>), typeof(EFRepository<>));
builder.Services.AddScoped<IPetProfileRepository, PetProfileRepository>();
builder.Services.AddScoped<PetProfileService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

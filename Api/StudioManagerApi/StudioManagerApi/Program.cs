using StudioManagerApi;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using StudioManagerApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(sgo =>
{
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "StudioManagerApi",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "bozic.petra35@gmail.com",
            Name = "Petra Bozic"
        },
        Description = "Ovo je dokumentacija za StudioManagerApi",
        License = new Microsoft.OpenApi.Models.OpenApiLicense()
        {
            Name = "Edukacijska licenca"
        }
    };
    sgo.SwaggerDoc("v1", o);

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    sgo.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

});

// svi se od svuda na sve mogu?e na?ine mogu spojitina naš API

builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );

});


// dodavanje baze podataka

builder.Services.AddDbContext<StudioManagerApiContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString(name: "StudioManagerApiContext"))
);



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();

// mogu?nost generiranja poziva rute u CMD i Powershell

app.UseSwaggerUI(opcije =>
{
    opcije.ConfigObject.
    AdditionalItems.Add("requestSnippetsEnabled", true);
});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.Run();


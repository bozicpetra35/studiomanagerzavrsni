using Microsoft.EntityFrameworkCore;
using StudioManager.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// prilagodba za dokumentaciju
builder.Services.AddSwaggerGen(sgo =>
{ // sgo je instanca klase SwaggerGenOptions
  
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Studio Manager",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "bozic.petra35@gmail.com",
            Name = "Petra Božić"
        },
        Description = "Ovo je dokumentacija za Studio Manager",
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

//dodajem bazu podataka

builder.Services.AddDbContext<StudioManagerContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString(name: "StudioManagerContext"))
);




// Svi se od svuda na sve moguće načine mogu spojitina naš API

builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );

});


// dodavanje baze podataka
builder.Services.AddDbContext<StudioManagerContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString(name: "StudioManagerContext"))
);



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
// mogućnost generiranja poziva rute u CMD i Powershell
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


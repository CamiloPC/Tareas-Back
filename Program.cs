using NLog;
using TaskApi.Extensions;
using TaskApi.Logger;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

//Create nescesary folders for the app client and admin, where static files are served 
string clientFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "client");
if (!Directory.Exists(clientFolder))
{
    Directory.CreateDirectory(clientFolder);
}

string adminFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin");
if (!Directory.Exists(adminFolder))
{
    Directory.CreateDirectory(adminFolder);
}


//Create assets folders
string imgFolder = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Images");
string vidFolder = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Videos");
string docFolder = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Documents");

if (!Directory.Exists(imgFolder))
{
    Directory.CreateDirectory(imgFolder);
}

if (!Directory.Exists(vidFolder))
{
    Directory.CreateDirectory(vidFolder);
}
if (!Directory.Exists(docFolder))
{
    Directory.CreateDirectory(docFolder);
}


var builder = WebApplication.CreateBuilder(args);

//Add logger
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Tareas API", Version = "v1"});
});

//Add My Services
builder.Services.AddAppServices(builder.Configuration, builder.Environment);

var app = builder.Build();

//Use static files
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Assets")),
    RequestPath = new PathString("/Assets")
});

//Logger service
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
             "Cache-Control", $"public, max-age={cacheMaxAgeOneWeek}");
    }
});

app.UseAuthorization();

//swagger
app.UseSwagger();
app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json","Tareas Api v1");});

//agregar endpoints
app.UseEndpoints(
    endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapFallbackToController("Index", "Fallback");
    });

app.MigrateDatabase();

app.Run();

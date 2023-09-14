using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using KafeinStudyCase.Core.Base.IoC;
using KafeinStudyCase.Core.Base.Middlewares;
using KafeinStudyCase.API.CustomProviders;
using KafeinStudyCase.API.Swagger;
using KafeinStudyCase.Application.Registrations;
using KafeinStudyCase.Infrastructure;
using KafeinStudyCase.Persistence;
using System.Text.Json.Serialization;
using KafeinStudyCase.Core.ExceptionHandling;
using KafeinStudyCase.Core.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = builder.Configuration;

configuration
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{env}.json", true, true)
    .Build();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Internal DI Registrations

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(configuration);

#endregion

#region Base DI Registrations

builder.Services.AddApiLayer();

#endregion


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);//TODO: ServiceResponse düzeltildikten sonra KALDIRILACAK


builder.Services.AddHeaderContext();

builder.Services.AddServices();
builder.Services.AddHttpClient();

//builder.Services.AddDataLayer();
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
        options.SuppressModelStateInvalidFilter = true);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ErrorResponses = new ApiVersioningErrorResponseProvider();
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});


builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();
app.AddExceptionHandlingMiddleware(true);


app.AddHeaderContextMiddleware();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

//app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

using Unimar.ProjetoAcademico.ApplicationService;
using Unimar.ProjetoAcademico.Domain;
using Unimar.ProjetoAcademico.Infra.CrossCutting.FluentValidation;
using Unimar.ProjetoAcademico.Infra.CrossCutting.IoC;
using Unimar.ProjetoAcademico.Infra.CrossCutting.MediatoR;
using Unimar.ProjetoAcademico.Infra.CrossCutting.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitApplicationService();
builder.Services.InitDomain();

var assemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddIoC(builder.Configuration);
builder.Services.AddMediator(assemblies);
builder.Services.AddFluentValitationAutoValidation(assemblies);

builder.Services.AddOpenApi();
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("DefaultCorsPolicy", policy =>
//    {
//        policy.WithOrigins(
//                "http://localhost:4200",
//                "https://dev.unimar.com",
//                "https://qa.unimar.com",
//                "https://qld.unimar.com",
//                "https://prd.unimar.com"
//            )
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials();
//    });
//});

var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

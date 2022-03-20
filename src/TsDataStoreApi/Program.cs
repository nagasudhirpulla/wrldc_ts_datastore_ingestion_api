using Microsoft.OpenApi.Models;
using TsDataStoreApi.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ITsDataStore, TsDataStore>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // add Basic Authentication
    var basicSecurityScheme = new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
    };
    c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {basicSecurityScheme, Array.Empty<string>()}
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

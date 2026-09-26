using Portfolio.Api.Data;
using Portfolio.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ITechnologyService, TechnologyService>();
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();

// OpenAPI document generation
builder.Services.AddOpenApi();

// Swagger generation and UI
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Danilvar.LinkSave.Api.Endpoints;
using Danilvar.LinkSave.Api.Infrastructure;
using Danilvar.LinkSave.Api.Infrastructure.Repositories;
using Danilvar.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSql")));

builder.Services.AddScoped<UnitOfWork<ApplicationDbContext>>();
builder.Services.AddScoped<ILinkGroupRepository, LinkGroupGroupRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapLinkEndpoints();

app.Run();

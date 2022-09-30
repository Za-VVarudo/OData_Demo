using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData_Demo.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovieCollectionContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MovieCollection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    })
    .AddOData(option =>
        option.AddRouteComponents("odata", GetEdmModel())
              .Select().Filter().Count().OrderBy().SetMaxTop(null).Expand());


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
app.Run();


// create Entity Data Model for OData data structure
static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

    builder.EntitySet<ActedIn>("ActedIn").EntityType
        .HasKey(a => new { a.ActorId, a.MovieId });

    var movie = builder.EntitySet<Movie>("Movie");


    builder.EntitySet<Actor>("Actor");


    builder.EntitySet<Genre>("Genre");

    return builder.GetEdmModel();
}

using Nest;
using WebSite.Api.Configurations;
using Elasticsearch.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("global_search");
var client = new ElasticClient(settings);

await builder.ConfigureAsync();

var app = builder.Build();

if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseCors(option =>
{
    option.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});

await app.ConfigureAsync();

app.Run();

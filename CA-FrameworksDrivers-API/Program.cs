
using CA_ApplicationLayer;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters_Data;
using CA_InterfaceAdapters_Mappers;
using CA_InterfaceAdapters_Mappers.Dtos.Request;
using CA_InterfaceAdapters_Models;
using CA_InterfaceAdapters_Presenters;
using CA_InterfaceAdapters_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//dependencias 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<Irepository<Beer>, Repository>();
builder.Services.AddScoped<IPresenter<Beer, BeerviewModel>, BeerPresenter>();
builder.Services.AddScoped<GetBeerUseCase<Beer,BeerviewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDTO>>();
builder.Services.AddScoped<Imapper<BeerRequestDTO,Beer>,BeerMapper>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/beer", async ([FromServices] GetBeerUseCase<BeerModel, BeerviewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
.WithName("beers");

app.MapPost("/beer", async (BeerRequestDTO beerRequest,
    AddBeerUseCase<BeerRequestDTO> beerUseCase)
    =>
    {
        await beerUseCase.ExecuteAsync(beerRequest);
        return Results.Created();
    })
    .WithName("addBeer");
 

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

using BussinesComponents;
using Microsoft.Extensions.DependencyInjection;
using RepositoryComponent;

var container = new ServiceCollection()
                .AddSingleton<IRepository, BeerRepository>()
                .AddTransient<BeerManager>()
                .BuildServiceProvider();




var beerManager= container.GetService<BeerManager>();
var beerManager2 = new BeerManager(new BeerRepository());
public class DefaultRepository :IRepository
{

    public void Add(string name)
    { }

    public string Get()
        => "algo";

}
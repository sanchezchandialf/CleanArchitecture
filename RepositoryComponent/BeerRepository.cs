using BussinesComponents;

namespace RepositoryComponent
{
    public class BeerRepository : IRepository

    {
        private List<String> _beers;

        public BeerRepository()
        
            =>_beers = new List<String>();

        public void  Add(String name)
            => _beers.Add(name);

        public string Get()
            => _beers.Aggregate("", (ac, beer) => ac + beer + ",");
    }
}

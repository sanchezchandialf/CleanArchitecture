using CA_ApplicationLayer;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters_Data;
using CA_InterfaceAdapters_Models;
using Microsoft.EntityFrameworkCore;

namespace CA_InterfaceAdapters_Repository
{
    public class Repository :Irepository<Beer> 
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Beer beer)
        {
            var beerModel = new BeerModel
            {
                Name = beer.Name,
                Style = beer.Style,
                Alcohol = beer.Alcohol,
            };
            await _appDbContext.Beers.AddAsync(beerModel);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beer>> GetAllAsync()
        {
            return await _appDbContext.Beers
                .Select(b=>new Beer
                {
                    Id=b.Id,
                    Name = b.Name,
                    Style = b.Style,
                    Alcohol = b.Alcohol,
                })
                .ToListAsync();
        }

        public async Task<Beer> GetByIdAsync(int id)
        {
            var beerModel = await _appDbContext.Beers.FindAsync(id);
            return new Beer
            {
                Id = beerModel.Id,
                Name = beerModel.Name,
                Style = beerModel.Style,
                Alcohol = beerModel.Alcohol,
            };
        }

       
    }
}

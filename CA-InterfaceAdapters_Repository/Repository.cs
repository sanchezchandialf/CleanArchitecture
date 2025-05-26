using CA_ApplicationLayer;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters_Data;
using Microsoft.EntityFrameworkCore;

namespace CA_InterfaceAdapters_Repository
{
    public class Repository :Irepository 
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Beer beer)
        {
            await _appDbContext.AddAsync(beer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beer>> GetAllAsync()
        {
            return await _appDbContext.Beers.ToListAsync();
        }

        public async Task<Beer> GetByIdAsync(int id)
        {
            return await _appDbContext.Beers.FindAsync(id);
        }

        Task<Beer> Irepository.AddAsync(Beer beer)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_EnterpriseLayer;


namespace CA_ApplicationLayer
{
    public interface Irepository
    {
        Task<Beer> GetByIdAsync(int id);
        Task<IEnumerable<Beer>> GetAllAsync();
        Task<Beer> AddAsync(Beer beer);
    }
}

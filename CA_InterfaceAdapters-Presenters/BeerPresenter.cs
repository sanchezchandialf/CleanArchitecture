using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_ApplicationLayer;
using CA_EnterpriseLayer;

namespace CA_InterfaceAdapters_Presenters
{
    public class BeerPresenter : IPresenter<Beer, BeerviewModel>
    {
        public IEnumerable<BeerviewModel> Present(IEnumerable<Beer> beers)
        {
            return beers.Select(b => new BeerviewModel
            {
                Id = b.Id,
                Name = b.Name,
                Alcohol = b.Alcohol,
            });
        }
    }
}

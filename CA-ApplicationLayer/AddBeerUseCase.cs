using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_EnterpriseLayer;

namespace CA_ApplicationLayer
{
    public class AddBeerUseCase<TDTO>
    {
        private readonly Irepository<Beer> _beerRepository;
        private readonly Imapper<TDTO, Beer> _mapper;

        public AddBeerUseCase(Irepository<Beer> beerRepository,
            Imapper<TDTO, Beer> mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO beerDTO)
        {
            var beer = _mapper.ToEntity(beerDTO);
            if (string.IsNullOrEmpty(beer.Name))
                throw new Exception("El nombre de la cerveza es obligatorio");
            await _beerRepository.AddAsync(beer);
        }
    }
}

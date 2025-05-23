using CA_EnterpriseLayer;

namespace CA_ApplicationLayer
{
    public class GetBeerUseCase
    {
        private readonly  Irepository _beerRepository;

        public GetBeerUseCase(Irepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<IEnumerable<Beer>> ExecuteAsync()
        {
            return await _beerRepository.GetAllAsync();
        }
    }
}

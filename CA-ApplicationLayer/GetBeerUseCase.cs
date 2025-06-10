using CA_EnterpriseLayer;

namespace CA_ApplicationLayer
{
    public class GetBeerUseCase<TEntity,TOutput>
    {
        private readonly  Irepository<TEntity> _beerRepository;
        private readonly IPresenter<TEntity,TOutput> _presenter;
        public GetBeerUseCase(Irepository<TEntity> beerRepository, IPresenter<TEntity,TOutput>presenter)
        {
            _beerRepository = beerRepository;
            _presenter = presenter;
        }

        public async Task<IEnumerable<TOutput>> ExecuteAsync()
        {
           var beers=  await _beerRepository.GetAllAsync();
            return _presenter.Present(beers);
        }
    }
}

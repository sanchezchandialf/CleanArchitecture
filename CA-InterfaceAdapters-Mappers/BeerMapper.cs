using CA_ApplicationLayer;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters_Mappers.Dtos.Request;

namespace CA_InterfaceAdapters_Mappers
{
    public class BeerMapper:Imapper<BeerRequestDTO,Beer>
    {
        public Beer ToEntity(BeerRequestDTO dto)
            => new Beer()
            {
                Id=dto.Id,
                Name=dto.Name,
                Style=dto.Style,
                Alcohol=dto.Alcohol
            };
    }
}

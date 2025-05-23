namespace CA_EnterpriseLayer

//Capa entitites
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public decimal Alcohol { get; set; }


        public bool IsStronBeer() => Alcohol > 7.5m;
        
    }
}

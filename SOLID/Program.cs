
var beerdata= new BeerData();
beerdata.AddBeer("Corona");
beerdata.AddBeer("Quilmes");
var reportgenerator=new ReportGeneratorBeer(beerdata);
var report = new Report();
var data = reportgenerator.Generate();
report.Save(data, "beer.txt");
public class BeerData
{
    private List<string> _beer;

    public BeerData()
    {
        _beer = new List<string>();
    }
    public void AddBeer(string beer)
        => _beer.Add(beer);
     public void removeBeer(string beer)
        => _beer.Remove(beer);
    public List<string> Get()
        => _beer;

}


public class ReportGeneratorBeer
{ 

    private BeerData _beerData;

    public ReportGeneratorBeer(BeerData beerData)
    {
        _beerData = beerData;
    }

    public List<string> Generate()
    {
        var data = new List<string>();
        int i = 1;
        foreach (var beer in _beerData.Get())
        {
            data.Add(i + "Cerveza:" + beer);
        }
        return data;
    }


}
public class Report
{
    public void Save(List<string> data, string filePath)
    { 
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var item in data)
            {
                writer.WriteLine(item);
            }
        }

    }
}

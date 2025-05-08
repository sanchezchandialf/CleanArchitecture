
var beerdata= new BeerData();
beerdata.AddBeer("Corona");
beerdata.AddBeer("Quilmes");
var reportgenerator=new ReportGeneratorBeer(beerdata);
var reportgeneratorhtmlbeer = new ReportGeneratorBeerhtml(beerdata);

var report = new Report();
var data = reportgenerator.Generate();
//report.Save(reportgenerator, "beer.txt");
report.Save(reportgeneratorhtmlbeer,"cervezas.html");

//PRINCIPIO SOLID :ABIERTO CERRADO
public interface IReportGenerate
{
    public string Generate();
}



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

//Principio LISKOV
/*Si una clase S hereda de una clase T, entonces deberíamos poder usar objetos de tipo S en lugar de objetos de tipo T sin que el comportamiento del programa cambie incorrectamente.
 O más simple: "las subclases deben poder usarse como si fueran la clase base sin romper nada." */
public class LimitedBeerData2
{
    private BeerData _beerData=new BeerData();
    private int _limit;
    private int _count = 0;
    public  LimitedBeerData2(int limit)
    {
        _limit = limit;
    }

    public void Add(string beer)
    {
        if (_count >= _limit)
        {
            throw new InvalidOperationException("lista de cervezas alcanzadas");
        }
        _beerData.AddBeer(beer);
        _count++;

    }
}

public class ReportGeneratorBeerhtml:IReportGenerate
{
    private BeerData _beerdata;

    public ReportGeneratorBeerhtml(BeerData beerdata)
    {
        _beerdata = beerdata;
    }
    public string Generate()
    {
        string data = "<div>";
        foreach (var beer in _beerdata.Get())
        {
            data += "<b>" + beer + "</b>";
        }
        data += "</div>";
        return data;
    }
}
public class ReportGeneratorBeer: IReportGenerate
{ 

    private BeerData _beerData;

    public ReportGeneratorBeer(BeerData beerData)
    {
        _beerData = beerData;
    }

    public string Generate()
    {
        string data="";
        foreach (var beer in _beerData.Get())
        {
            data += "Cerveza" + beer + Environment.NewLine;
        }
        return data;
    }


}
// Esta clase consume cualquier clase que implemente IReportGenerate, y guarda el contenido generado en un archivo.
public class Report
{
    public void Save(IReportGenerate reportGenerator, string filePath)
    { 
        using (var writer = new StreamWriter(filePath))
        {
            string data=reportGenerator.Generate();
            writer.WriteLine(data);
        }

    }
}

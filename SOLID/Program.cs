
var beerdata= new BeerData();
beerdata.Add("Corona");
beerdata.Add("Quilmes");
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

public interface IReportShow
{
    public void Show();
}


// Interfaz genérica para un repositorio de cualquier tipo T
public interface IRepository<T>
{
    public void Add(T item);
    public List<T> Get();
}

// Implementación concreta de IRepository para strings, simulando una base de datos de cervezas
public class BeerData : IRepository<string>
{
    protected List<string> _beer;

    public BeerData()
    {
        _beer = new List<string>();
    }

    // Agrega una cerveza a la lista
    public void Add(string beer)
        => _beer.Add(beer);

    // Retorna la lista completa de cervezas
    public List<string> Get()
        => _beer;
}


//Principio LISKOV
/*Si una clase S hereda de una clase T, entonces deberíamos poder usar objetos de tipo S en lugar de objetos de tipo T sin que el comportamiento del programa cambie incorrectamente.
 O más simple: "las subclases deben poder usarse como si fueran la clase base sin romper nada." */

// Clase que usa el principio de inversión de dependencias (DIP)
public class LimitedBeerData2
{
    // Se depende de una abstracción (IRepository<string>), no de una implementación concreta (como BeerData)
    private IRepository<string> _beerData;

    // Límite máximo de cervezas permitidas
    private int _limit;

    // Contador actual de cervezas agregadas
    private int _count = 0;

    // ✅ Este constructor aplica la Inversión de Dependencias
    // Recibe una instancia de IRepository<string>, no importa si es BeerData o cualquier otra clase que implemente esa interfaz
    public LimitedBeerData2(int limit, IRepository<string> beerdata)
    {
        _limit = limit;
        _beerData = beerdata;
    }

    // Método que agrega cerveza mientras no se supere el límite
    public void Add(string beer)
    {
        if (_count >= _limit)
        {
            // Se lanza excepción si se intenta superar el límite
            throw new InvalidOperationException("lista de cervezas alcanzadas");
        }

        // Se delega la lógica de almacenamiento a la dependencia inyectada
        _beerData.Add(beer);
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


public class ReportGeneratorBeer: IReportGenerate , IReportShow
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

    //Principio de segregacion de interfaz , si uso una interfaz y no utilizo su metodo en todas las clases donde se aplica el contrato, debo hacer otra , para que no existan metodos que no hagan nada 
    public void Show()
    {
        foreach(var beer in _beerData.Get())
        {
            Console.WriteLine("Cerveza" + beer);
        }
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

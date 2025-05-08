using System.Reflection.Metadata.Ecma335;
using FuncionalParadigma;
var beer = new Beer()
{
    Name = "Cerveza"
};
var funcional = new Funcional();

//funcion no pura 
Beer ToUpper(Beer beer)
{
    beer.Name = beer.Name.ToUpper();
    return beer;
}

Action<String> show = Console.WriteLine;
Action<int, int, int> suma = (a, b, c) => show((a + b + c).ToString());
suma(1, 2, 3);
show("buenas tardes");
Func<int, int, int> suma2 = (a, b) => a * b;
Func<int, int, string> suma3 = (a, b) =>
{
    var res = (a + b).ToString();
    return res;
};
//show(suma3(1, 2));
var t = ToUpperPure;
//Funcion Pura
Beer ToUpperPure(Beer beer)
{
    var beer2 = new Beer
    {
        Name = beer.Name.ToUpper()
    };
    return beer2;
}

Predicate<int> espar = number => number % 2 == 0;
List<int> number = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var number2 = filter(number, espar);
var anita = filter(number, number => number is 1 or 4);
foreach (var item in number2)
{
    Console.WriteLine(item);
}
foreach (var item in anita)
{
    Console.WriteLine(item);
}
//predicate si o si retorna bool
List<int> filter(List<int> list, Predicate<int> predicate)
{
    var result = new List<int>();
    foreach (var item in list)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }
    return result;
}

show(ToUpperPure(beer).Name);
show(beer.Name);
show(ToUpperPure(beer).Name);





 int sumas(int a, int b)
{
   return a + b;

}
    

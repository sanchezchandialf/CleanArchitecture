using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalParadigma
{
    class Funcional
    {
        //funcion no pura 
        DateTime Tomorrow()
        {
            return DateTime.Now.AddDays(1);
        }

        //funcion pura
        DateTime Tomorrow(DateTime date)
        {
            return date.AddDays(1);
        }

    }

    class Beer
    {
        public string Name { get; set; }

     
    }
}
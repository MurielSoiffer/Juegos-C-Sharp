using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Tablero t = new Tablero();
            t.ejecutarJuego();
            
        }
    }
}

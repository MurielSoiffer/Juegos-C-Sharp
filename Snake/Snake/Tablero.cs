using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    internal class Tablero
    {
        private Point esquinaArriba;
        private Point esquinaAbajo;
        public Point EsqArriba { get { return esquinaArriba; } }
        public Point EsqAbajo { get { return esquinaAbajo; } }
        public Tablero(Point esqArriba, Point esqAbajo) 
        { 
            esquinaArriba = esqArriba;
            esquinaAbajo = esqAbajo;
        }
        public void dibujar()
        {
            for (int i = esquinaArriba.X; i <= esquinaAbajo.X; i++)
            {
                Console.SetCursorPosition(i, esquinaArriba.Y);
                Console.WriteLine("═");
                Console.SetCursorPosition(i, esquinaAbajo.Y);
                Console.WriteLine("═");
            }
            for (int i = esquinaArriba.Y; i <= esquinaAbajo.Y; i++)
            {
                Console.SetCursorPosition(esquinaArriba.X, i);
                Console.WriteLine("║");
                Console.SetCursorPosition(esquinaAbajo.X, i);
                Console.WriteLine("║");
            }
            Console.SetCursorPosition(esquinaAbajo.X, esquinaAbajo.Y);
            Console.WriteLine("╝");
            Console.SetCursorPosition(esquinaAbajo.X, esquinaArriba.Y);
            Console.WriteLine("╗");
            Console.SetCursorPosition(esquinaArriba.X, esquinaAbajo.Y);
            Console.WriteLine("╚");
            Console.SetCursorPosition(esquinaArriba.X, esquinaArriba.Y);
            Console.WriteLine("╔");
        }
    }
}

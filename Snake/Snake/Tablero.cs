using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting;

namespace Snake
{
    internal class Tablero
    {
        private Point esquinaArriba;
        private Point esquinaAbajo;
        private int area;
        public Point EsqArriba { get { return esquinaArriba; } }
        public Point EsqAbajo { get { return esquinaAbajo; } }
        public int Area { get { return area; } }
        public Tablero(Point esqArriba, Point esqAbajo) 
        { 
            esquinaArriba = esqArriba;
            esquinaAbajo = esqAbajo;
            area = ((esquinaAbajo.X - esquinaArriba.X - 1) * (esquinaAbajo.Y - esquinaArriba.Y - 1));
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

        public void dibujarInfo(Snake serpiente)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(esquinaArriba.X , esquinaArriba.Y - 1);
            Console.WriteLine("Puntaje: " + serpiente.Puntaje + "  ");
            Console.SetCursorPosition(esquinaArriba.X + 34, esquinaArriba.Y - 1);
            Console.WriteLine("Puntaje Max: " + serpiente.PuntajeMaximo + "  ");
        }
    }
}

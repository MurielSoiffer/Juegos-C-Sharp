using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Manzana
    {
        Tablero t;
        private Point posicion;
        public Point Posicion { get {return posicion; } }
        private Random r;
        public Manzana(Tablero tablero) 
        {
            r = new Random();
            t = tablero;

        }
        public bool posicionar(Snake serpiente)
        {
            int largoSerpiente = serpiente.Cuerpo.Count + 1;

            if(t.Area -largoSerpiente <= 0) 
                return false;

            int x = r.Next(t.EsqArriba.X + 1, t.EsqAbajo.X);
            int y = r.Next(t.EsqArriba.Y + 1, t.EsqAbajo.Y);
            posicion = new Point(x, y);

            foreach (Point c in serpiente.Cuerpo)
            {
                if((x == c.X && y == c.Y) || (x == serpiente.Cabeza.X && y == serpiente.Cabeza.Y))
                {
                    if (posicionar(serpiente))
                        return true;
                }
            }
            return true;
        }
        public void dibujar()
        {            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posicion.X, posicion.Y);
            Console.WriteLine("0");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flappyBird
{
    public class Ave
    {
        Tablero t = new Tablero();
        private int x; 
        private int y;
        private int puntos;
        public int Puntos { get { return puntos; } }
        public Ave()
        {
            x = 15;
            y = (t.H / 2) - 1;
            puntos = 0;
        }
        public void restart()
        {
            y = (t.H / 2) - 1;
            puntos = 0;
        }
        public void saltar()
        {
            borrar(" ");
            Console.SetCursorPosition(x + 1, y - 1);
            Console.WriteLine(" ");
            
            if (y - 3 > 1)
                y = y - 3;
            else 
                y = 3;

        }
        public void caida()
        {
            if (y != t.H - 1)
            {
                borrar(" ");
                Console.SetCursorPosition(x + 1, y - 1);
                Console.WriteLine(" ");
                y++;
            }
        }
        public bool colision(List<Tubo> tubos)
        {
            foreach (Tubo tubo in tubos) { 
                if (x + 1 >= tubo.X - 2 && x <= tubo.X + 2)
                {
                    if (y >= tubo.Y + 4 || y <= tubo.Y - 1)
                    {
                        return false;
                    }
                }
                if ((x == tubo.X + 2) && (y <= tubo.Y + 4 && y >= tubo.Y - 1))
                {
                    puntos+= 5;
                }
            }
            return true;
        }
        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            borrar("0");
            Console.SetCursorPosition(x + 1, y - 1);
            Console.WriteLine(">");
            Console.ForegroundColor = ConsoleColor.White;

        }
        private void borrar(string l)
        {
            Console.SetCursorPosition(x - 1, y);
            Console.WriteLine(l);
            Console.SetCursorPosition(x, y);
            Console.WriteLine(l);
            Console.SetCursorPosition(x, y - 1);
            Console.WriteLine(l);
            Console.SetCursorPosition(x - 1, y - 1);
            Console.WriteLine(l);
        }
    }
    
}

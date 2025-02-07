using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Manzana
    {
        private int w = Console.WindowWidth;
        private int h = Console.WindowHeight;
        private int x;
        private int y;
        private Random r;
        public Manzana() 
        {
            r = new Random();
            x = r.Next(0,w);
            y = r.Next(0, h);
        }
        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("0");
        }
    }
}

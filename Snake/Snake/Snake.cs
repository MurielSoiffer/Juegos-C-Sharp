using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        private int w = Console.WindowWidth;
        private int h = Console.WindowHeight;
        private Point cabeza;
        private Point cabezaAnt = new Point();
        private char dir;
        private int delay = 0;
        private List<Point> cuerpo = new List<Point>();
        public Snake()
        {
            cabeza = new Point(w / 2 - 4, h / 2);
            cabezaAnt = cabeza;
            dir = 'n';
            iniciarCuerpo();
        }

        private void iniciarCuerpo()
        {
            int partes = 5;
            int x = cabeza.X - 1;
            for (int i = 0; i < partes; i++) 
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(x, cabeza.Y);
                Console.WriteLine("o");
                cuerpo.Add(new Point(x,cabeza.Y));
                x--;
            }
        }
        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(cabeza.X, cabeza.Y);
            Console.WriteLine("0");
        }

        public void moverse()
        {
            delay++;
            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.D && dir != 'l') dir = 'r';
                if (tecla == ConsoleKey.A && dir != 'r') dir = 'l';
                if (tecla == ConsoleKey.W && dir != 'd') dir = 'u';
                if (tecla == ConsoleKey.S && dir != 'u') dir = 'd';
            }
            direccion();
            
        }
        private void moverCuerpo(Point posCabeza)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(posCabeza.X, posCabeza.Y);
            Console.WriteLine("o");
            cuerpo.Insert(0,posCabeza);

            Console.SetCursorPosition(cuerpo[cuerpo.Count-1].X, cuerpo[cuerpo.Count - 1].Y);
            Console.WriteLine(" ");
            cuerpo.RemoveAt(cuerpo.Count-1);
        }
        private void direccion()
        {
            if (delay > 2000)
            {
                borrar();
                cabezaAnt = cabeza;
                if (dir == 'r') cabeza.X++;
                else if(dir == 'l') cabeza.X--;
                else if(dir == 'u') cabeza.Y--;
                else if(dir == 'd') cabeza.Y++;
                delay = 0;
                moverCuerpo(cabezaAnt);
            }
        }
        private void borrar()
        {
            Console.SetCursorPosition(cabeza.X, cabeza.Y);
            Console.WriteLine(" ");
        }
    }
}

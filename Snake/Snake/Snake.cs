using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        private int w = Console.WindowWidth;
        private int h = Console.WindowHeight;
        private int x;
        private int y;
        private bool empezarMoverse;
        private char dir;
        private int delay = 0;
        public Snake()
        {
            x = w / 2 - 4;
            y = h / 2;
            empezarMoverse = false;
            dir = 'n';
        }
        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("0");
        }
        public void moverse()
        {
            delay++;
            if (!empezarMoverse && Console.KeyAvailable) 
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.D || tecla == ConsoleKey.A || tecla == ConsoleKey.W || tecla == ConsoleKey.S) empezarMoverse = true;
            }
            else if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.D) dir = 'r';
                if (tecla == ConsoleKey.A) dir = 'l';
                if (tecla == ConsoleKey.W) dir = 'u';
                if (tecla == ConsoleKey.S) dir = 'd';
            }
            direccion();
        }
        private void direccion()
        {
            if (delay > 3000)
            {
                borrar();
                if (dir == 'r') x++;
                else if(dir == 'l') x--;
                else if(dir == 'u') y--;
                else if(dir == 'd') y++;
                delay = 0;
            }
        }
        private void borrar()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }
    }
}

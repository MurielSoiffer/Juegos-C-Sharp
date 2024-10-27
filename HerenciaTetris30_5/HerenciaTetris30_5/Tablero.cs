using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaTetris30_5
{
    internal class Tablero
    {
        public void dibujar()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.SetCursorPosition(50, i);
                Console.WriteLine("|");
                Console.SetCursorPosition(70, i);
                Console.WriteLine("|");
            }
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(45 + i, 25);
                Console.WriteLine("-");
            }
            
            Linea t = new Linea();
            t.color(t.colorP);
            Console.SetCursorPosition(57 , 27);
            Console.WriteLine("TETRIS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, 27);
            Console.WriteLine("SCORE:");
        }
        public void perdiste()
        {
            int a = Console.WindowHeight;
            int b = Console.WindowWidth;
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition((b / 2) - 5, a / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Perdiste");
            }
        }
    }
}

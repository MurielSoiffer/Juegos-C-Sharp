using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jueguito
{
    public class Tablero
    {
        private int w;
        private int h;
        private int pt;
        private int vida;
        public Tablero() 
        {
            w = Console.WindowWidth;
            h = Console.WindowHeight;

            pt = 0;
            vida = 3;
        }
        public void dibujar(int puntos, int v)
        {
            this.pt = puntos;
            Console.SetCursorPosition(2, 1);
            Console.WriteLine($"Score: {pt}");
            Console.SetCursorPosition(2, 2);
            Console.Write($"Vida:");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < v; i++)
                Console.Write("<3 ");
            if (vida != v)
            {
                Console.Write("          ");
                vida = v;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void perdiste()
        {
                for (int i = 0; i < 30; i++)
                {
                    for (int e = 0; e < 6; e++)
                    {
                        Console.SetCursorPosition((w / 2) - 15 + i, (h / 2) - 3 + e);
                        Console.WriteLine(" ");
                    }
                }
                for (int i = (w / 2) - 14; i < (w / 2) + 15; i++)
                {
                    Console.SetCursorPosition(i, (h / 2) - 3);
                    Console.WriteLine("-");
                    Console.SetCursorPosition(i, (h / 2) + 3);
                    Console.WriteLine("-");
                }
                for (int i = (h / 2) - 2; i < (h / 2) + 3; i++)
                {
                    Console.SetCursorPosition((w / 2) - 15, i);
                    Console.WriteLine("|");
                    Console.SetCursorPosition((w / 2) + 15, i);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition((w / 2) - 3, (h / 2) - 2);
                Console.WriteLine("Perdiste");
                Console.SetCursorPosition((w / 2) - 4, (h / 2));
                Console.WriteLine($"Puntos: {pt}");
                Console.SetCursorPosition((w / 2) - 5, (h / 2) + 2);

                Console.WriteLine($"Reiniciar (R)");
        }
    }
}

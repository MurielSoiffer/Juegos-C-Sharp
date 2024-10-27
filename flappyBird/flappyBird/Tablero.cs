using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flappyBird
{
    public class Tablero
    {
        private int w;
        private int h;
        private int puntos;
        public int Puntos { get { return puntos; } set { puntos = value; } }
        public int W { get { return w; } }
        public int H { get { return h; } }
        public Tablero()
        {
            w = Console.WindowWidth;
            h = Console.WindowHeight - 2;
        }
        public void dibujar()
        {
            for (int i = 0; i < h - 2; i++)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.WriteLine("|");
                Console.SetCursorPosition(w - 1, i + 2);
                Console.WriteLine("|");
            }
            for (int i = 0; i < w - 2; i++)
            {
                Console.SetCursorPosition(i + 1, 1);
                Console.WriteLine("–");
                Console.SetCursorPosition(i + 1, h);
                Console.WriteLine("–");
            } 
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Puntos: {puntos}");
            Console.SetCursorPosition((w/2) - 7, 0);
            Console.WriteLine($"FLAPPY BIRD");
            Console.SetCursorPosition(w - 30, 0);
            Console.WriteLine($"Hecho por Muriel Soiffer");
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
            Console.SetCursorPosition((w / 2) - 4, (h / 2) );
            Console.WriteLine($"Puntos: {puntos}");
            Console.SetCursorPosition((w / 2) - 5, (h / 2) + 2);

            Console.WriteLine($"Reiniciar (R)");
        }
    }
}

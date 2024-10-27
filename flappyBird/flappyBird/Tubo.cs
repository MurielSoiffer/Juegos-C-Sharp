using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flappyBird
{
    public class Tubo
    {
        private int x, y;
        private int alto;
        private int ancho;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        Random r;
        public Tubo(int x)
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));
            r = new Random(seed);

            alto = Console.WindowHeight - 2;
            ancho = Console.WindowWidth;
            this.x = x;
            y = r.Next(5, alto - 4);
        }
        public void restart(int x)
        {
            this.x = x;
        }
        public void mover()
        {
            borrar(" ");
            x--;
            dibujar();
            if (x - 2 <= 0)
            {
                x = ancho - 2;
                y = r.Next(5, alto - 4);
            }
        }
        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if(x - 2 >= 1 && x + 2 <= ancho - 1){
                for (int i = 2; i < y - 3; i++) 
                { 
                    Console.SetCursorPosition(x - 2, i);
                    Console.WriteLine("1");
                    Console.SetCursorPosition(x + 2, i);
                    Console.WriteLine("1");
                }
                for (int i = alto - 1; i > y + 3; i--)
                {
                    Console.SetCursorPosition(x - 2, i);
                    Console.WriteLine("1");
                    Console.SetCursorPosition(x + 2, i);
                    Console.WriteLine("1");
                }
                for (int i = x - 2; i < x + 3; i++)
                {
                    Console.SetCursorPosition(i, y - 3);
                    Console.WriteLine("-");
                    Console.SetCursorPosition(i, y + 4);
                    Console.WriteLine("-");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void borrar(string l)
        {
            if (x - 2 >= 1 && x + 2 <= ancho - 1)
            {
                for (int i = 2; i < y - 3; i++)
                {
                    Console.SetCursorPosition(x - 2, i);
                    Console.WriteLine(l);
                    Console.SetCursorPosition(x + 2, i);
                    Console.WriteLine(l);
                }
                for (int i = alto - 1; i > y + 3; i--)
                {
                    Console.SetCursorPosition(x - 2, i);
                    Console.WriteLine(l);
                    Console.SetCursorPosition(x + 2, i);
                    Console.WriteLine(l);
                }
                for (int i = x - 2; i < x + 3; i++)
                {
                    Console.SetCursorPosition(i, y - 3);
                    Console.WriteLine(l);
                    Console.SetCursorPosition(i, y + 4);
                    Console.WriteLine(l);
                }
            }
        }
    }
}

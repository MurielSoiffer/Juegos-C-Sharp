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
        private Point cabeza;
        private Point cabezaAnt = new Point();
        private char dir;
        private int delay = 0;
        private List<Point> cuerpo = new List<Point>();
        private Point esquinaArriba;
        private Point esquinaAbajo;
        private Manzana m;
        private bool comer;

        public List<Point> Cuerpo { get { return cuerpo; } }
        public Point Cabeza { get { return cabeza; } }
        public Snake(Tablero tablero, Manzana manzana)
        {
            comer = false;
            cabezaAnt = cabeza;
            dir = 'n';
            esquinaArriba = tablero.EsqArriba;
            esquinaAbajo = tablero.EsqAbajo;
            cabeza = new Point(esquinaAbajo.X / 2, esquinaAbajo.Y / 2 + esquinaArriba.Y / 2);
            m = manzana;
            iniciarCuerpo();
        }

        private void iniciarCuerpo()
        {
            int partes = 3;
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
            colisionPared();
            colisionManzana();


        }
        private void moverCuerpo(Point posCabeza)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(posCabeza.X, posCabeza.Y);
            Console.WriteLine("o");
            cuerpo.Insert(0,posCabeza);

            if (comer == false)
            {
                Console.SetCursorPosition(cuerpo[cuerpo.Count - 1].X, cuerpo[cuerpo.Count - 1].Y);
                Console.WriteLine(" ");
                cuerpo.RemoveAt(cuerpo.Count - 1);
            }
            else comer = false;
        }
        private void direccion()
        {
            if (delay > 1000)
            {
                borrar();
                cabezaAnt = cabeza;
                if (dir == 'r') cabeza.X++;
                else if(dir == 'l') cabeza.X--;
                else if(dir == 'u') cabeza.Y--;
                else if(dir == 'd') cabeza.Y++;
                delay = 0;
                if (dir != 'n')
                    moverCuerpo(cabezaAnt);
            }
        }
        private void borrar()
        {
            Console.SetCursorPosition(cabeza.X, cabeza.Y);
            Console.WriteLine(" ");
        }
        private void colisionPared()
        {
            if (cabeza.X <= esquinaArriba.X) 
                cabeza = new Point(esquinaAbajo.X - 1,cabeza.Y);
            if (cabeza.X >= esquinaAbajo.X)
                cabeza = new Point(esquinaArriba.X + 1, cabeza.Y);
            if (cabeza.Y <= esquinaArriba.Y)
                cabeza = new Point(cabeza.X, esquinaAbajo.Y - 1);
            if (cabeza.Y >= esquinaAbajo.Y)
                cabeza = new Point(cabeza.X, esquinaArriba.Y + 1);
        }
        private void colisionManzana()
        {
            if (cabeza == m.Posicion)
            {
                m.posicionar(this);
                comer = true;
            }
        }
    }
}

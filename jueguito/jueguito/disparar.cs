using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jueguito
{
    public class Balas
    {
        public Balas(int x, int y, int z) 
        { 
            this.y = y;
            this.x = x;
            this.z = z;
        }
        private int x;
        private int y;
        private int z;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Z { get { return z; } set { z = value; } }

    }
    public class Disparos
    {
        public List<Balas> list;
        public List<Enemigo> listaE;
        public int x;
        public int y;
        private int w;
        private int h;
        public Disparos()
        {
            list = new List<Balas>();
            w = Console.WindowWidth;
            h = Console.WindowHeight;
        }
        public void tiro(int cordenada)
        {
            list.Add(new Balas(x, y, cordenada));
            
        }
        private void cambios(Balas item)
        {
            if (item.Z == 0) item.X++;
            else if (item.Z == 1) item.Y--;
            else if (item.Z == 2) item.X--;
            else if (item.Z == 3) item.Y++;
        }
        private void borrarBala()
        {
            foreach (Enemigo e in listaE)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    
                    if (
                        list[i].Z == 0 && list[i].X == (int)Math.Floor(e.X) + 2 && list[i].Y == (int)Math.Floor(e.Y) + 1 ||
                        list[i].Z == 1 && list[i].X == (int)Math.Floor(e.X) + 1 && list[i].Y == (int)Math.Floor(e.Y) ||
                        list[i].Z == 2 && list[i].X == (int)Math.Floor(e.X) && list[i].Y == (int)Math.Floor(e.Y) + 1 ||
                        list[i].Z == 3 && list[i].X == (int)Math.Floor(e.X) + 1 && list[i].Y == (int)Math.Floor(e.Y) + 2
                        )
                    {
                        Console.SetCursorPosition(list[i].X, list[i].Y);
                        Console.WriteLine(" ");
                        list.RemoveAt(i);
                    
                    }
                }
            }
        }
        public void dibujar(List<Enemigo> listaE)
        {
            this.listaE = listaE;
            foreach (Balas item in list)
            {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.WriteLine(" ");
                    cambios(item);
                    Console.SetCursorPosition(item.X , item.Y);
                    Console.WriteLine("o");
            }
            for (int i = 0; i < list.Count; i++) 
            {
                if (list[i].X + 5 > w || list[i].X <= 0 || list[i].Y <= 1 || list[i].Y + 3 > h){
                      Console.SetCursorPosition(list[i].X, list[i].Y);
                      Console.WriteLine(" ");
                      list.RemoveAt(i);
                }
            }
            borrarBala();
            Thread.Sleep(20);
        }
    }
}

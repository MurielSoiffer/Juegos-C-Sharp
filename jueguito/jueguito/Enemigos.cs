using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jueguito
{
    public class Enemigos
    {
        public List<Enemigo> enemigos;
        private double contador;
        private int puntos;
        public int Puntos { get { return puntos; } }
        public Enemigos()
        {
            enemigos = new List<Enemigo>();
            contador = 0;
            puntos = 0;
        }
        public void crearEnemigo()
        {
            contador++;
            if (contador > 100)
            {
                enemigos.Add(new Enemigo());
                contador = 0;
            }
            for(int i = enemigos.Count - 1; i >= 0; i--) 
            { 
                if(enemigos[i].Ene <= 0)
                {
                    enemigos.Remove(enemigos[i]);
                    puntos += 100;
                }
            }
        }
        public void dibujar(int xj, int yj, List<Balas> list)
        {
            foreach (var item in enemigos)
            {
                item.colisiones(list);
                item.seguir(xj, yj);
            }
        }
    }
    public class Enemigo
    {
        private int w = Console.WindowWidth;
        private int h = Console.WindowHeight;
        private double xAnte; 
        private double yAnte;
        private double x;
        private double y;
        private int xj;
        private int yj;
        private int enemigo;
        private int contador;
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public int Ene { get { return enemigo; } }
        private Random r;
        public Enemigo()
        {
            r = new Random();
            x = r.Next(0,w - 5); 
            y = r.Next(0, h - 3);
            enemigo = 3;
            contador = 0;
        }
        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((int)Math.Floor(x) + 1, (int)Math.Floor(y) + 1);
            Console.WriteLine(enemigo);
        }
        public void borrar()
        {
            Console.SetCursorPosition((int)Math.Floor(x) + 1, (int)Math.Floor(y) + 1);
            Console.WriteLine(" ");
        }
        //-----------logica-----------------
        private void siguiendo()
        {
            if(contador == 60) 
            {
                xAnte = x; yAnte = y;
                contador = 0;
            }
            if(enemigo > 0) 
            {
            borrar();
            if (x <= xj) x += 0.1;
            if (x >= xj) x -= 0.1;
            if (y <= yj) y += 0.1;
            if (y >= yj) y -= 0.1;
            dibujar();
            }
            else if(enemigo <= 0)
                borrar();
            contador++;
        }
        public void seguir(int xj, int yj) 
        {
            this.xj = xj;
            this.yj = yj;
            siguiendo();
        }
        public void colisiones(List<Balas> lista)
        {
            foreach (var bala in lista) 
            {
                if (bala.X == (int)Math.Floor(x) + 1 && bala.Y == (int)Math.Floor(y) + 1 )
                    enemigo--;
            }
            //Revisar esto despues
            if (xj == (int)Math.Floor(x) + 1 && yj == (int)Math.Floor(y) + 1)
            {
                x = xAnte ; y = yAnte;
            }
        }
    }
}

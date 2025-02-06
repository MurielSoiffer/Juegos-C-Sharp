using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas
{
    public class PantallaInicio
    {
        private bool empezar;
        private int tiempo;
        private List<string> dificultades;
        private int w;
        private int h;
        private int[] posiciones;
        private int posTotal;
        private Random r;
        private List<ConsoleColor> colores;
        private ConsoleColor colorTexto;
        private int dificultadElegida;
        private ConsoleColor ColorDifElegida;
        private ConsoleColor ColorStart;
        private int filaElegida;
        public int DifElegida { get { return dificultadElegida; } }
        public PantallaInicio() 
        {
            ColorDifElegida = ConsoleColor.Red;
            ColorStart = ConsoleColor.Black;
            filaElegida = 0;
            dificultadElegida = 0;
            colorTexto = ConsoleColor.White;
            r = new Random();
            tiempo = 0;
            posiciones = new int[20];
            posTotal = 0;
            colores = new List<ConsoleColor>() { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.Cyan, ConsoleColor.Yellow};
            dificultades = new List<string>() { "facil","medio","dificil"};
            for (int i = 0; i < dificultades.Count; i++) 
            {
                posiciones[i] = posTotal;
                posTotal += dificultades[i].Length + 5;
            }
            w = Console.WindowWidth;
            h = Console.WindowHeight;
        }
        public void dibujar()
        {
            ColorDifElegida = (filaElegida == 0) ? ConsoleColor.Red : ConsoleColor.DarkGray;
            ColorStart = (filaElegida == 1) ? ConsoleColor.Red : ConsoleColor.Black;
            tiempo++;
            if(tiempo >= 1500)
            {
                colorTexto = colores[r.Next(0, colores.Count)];
                tiempo = 0;
            }
                
            Console.ForegroundColor = colorTexto ;
            Console.SetCursorPosition(w/2 - 8, h/2 - 5);
            Console.WriteLine("BUSCA MINAS");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < dificultades.Count; i++)
            {
                Console.SetCursorPosition(w / 2 - posTotal / 2 + posiciones[i] , h / 2 - 1);
                Console.BackgroundColor = (i == dificultadElegida) ? ColorDifElegida : ConsoleColor.Black;
                Console.WriteLine($" {dificultades[i]} ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            boton("Empezar", w / 2 - 8, h / 2 + 3, ColorStart);
            

        }
        private void boton(string texto, int posX, int posY, ConsoleColor color)
        {
            int largoT = texto.Length;
            int vari = (largoT % 2 == 0) ? 4 : 3;
            Console.SetCursorPosition(posX + 1, posY);
            for (int i = 0; i <= largoT + vari ; i++) 
                Console.Write("-");
            Console.SetCursorPosition(posX , posY + 1);
                Console.Write($"|");
            Console.BackgroundColor = color;
            Console.Write($"  {texto}  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"|");
            Console.SetCursorPosition(posX + 1, posY + 2);
            for (int i = 0; i <= largoT + vari; i++)
                Console.Write("-");
        }
        public int dificultad()
        {
            return 3;
        }
        public void moverse()
        {
            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.W)
                    filaElegida = (filaElegida < 1) ? filaElegida + 1 : 0;
                if (tecla == ConsoleKey.S)
                    filaElegida = (filaElegida > 0) ? filaElegida - 1 : 1;
                if (filaElegida == 0)
                {
                    if (tecla == ConsoleKey.D)
                        dificultadElegida = (dificultadElegida < dificultades.Count - 1) ? dificultadElegida + 1 : 0;
                    if (tecla == ConsoleKey.A)
                        dificultadElegida = (dificultadElegida > 0) ? dificultadElegida - 1 : dificultades.Count - 1;
                }
                if (filaElegida == 1)
                {
                    if (tecla == ConsoleKey.Enter)
                        empezar = true;
                }
            }
        }
        public bool empezarJuego()
        {
            if(empezar)
                Console.Clear();
            return empezar;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BuscaMinas
{
    
    public class Tablero
    {
        List<Juego> juegos;
        Juego j;
        PantallaInicio pa;
        int w, h;
        public Tablero() 
        {
            pa = new PantallaInicio();
            j = new Juego(0, 0, 0, 0, 0);
            w = Console.WindowWidth;
            h = Console.WindowHeight;
        }
        public void ejecutarJuego()
        {
            while (true) 
            {
                pa = new PantallaInicio();
                while (true)
                {
                    pa.dibujar();
                    pa.moverse();
                    if (pa.empezarJuego())
                    {
                        dificultad(pa.DifElegida);
                        break;
                    }
                }
                while (true)
                {
                    j.revisarSiGanaste();
                    j.moverse();
                    j.dibujar();
                    dibujar();
                    if (j.Volver)
                        break;
                }
                Console.Clear();
            }

            
        }
        private void dificultad(int dif)
        {
            if(dif == 0)
                j = new Juego(5, 7, 4, w / 2 - 10, h / 2 - 9);
            else if (dif == 1)
                j = new Juego(8, 10, 7, w / 2 - 12, h / 2 - 9);
            else if (dif == 2)
                j = new Juego(10, 13, 18, w / 2 - 14, h / 2 - 9);
        }
        private void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            cuadrado(j.Columnas, j.Filas);
            Console.SetCursorPosition(w / 2 - 12, h / 2 - 11);
            Console.Write($"Banderas:{j.Minas - j.CantPosMarcadas}  ");

            Console.SetCursorPosition(w / 2 - 18, h / 2 + 4);
            Console.Write($"Enter: Romper  -  E: Marcar");
            Console.SetCursorPosition(w / 2 - 20, h / 2 + 5);
            Console.Write($"V: Volver al menu  -  R: restart");
        }
        private void cuadrado(int width, int height)
        {
            for (int i = 0; i < width * 2; i++) 
            {
                Console.SetCursorPosition(w / 2 - (10 + pa.DifElegida * 2) + i , h / 2 - 10);
                Console.Write('-');
            }
            for (int i = 0; i < width * 2; i++)
            {
                Console.SetCursorPosition(w / 2 - (10 + pa.DifElegida * 2) + i, h / 2 - 10 + height + 1);
                Console.Write('-');
            }
            for(int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(w / 2 - (10 + pa.DifElegida * 2) - 1, h / 2 - 10 + i);
                Console.Write('|');
            }
            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(w / 2 - (10 + pa.DifElegida * 2) + width * 2, h / 2 - 10 + i);
                Console.Write('|');
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace flappyBird
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool restart = false;
            Console.CursorVisible = false;
            Ave flappy = new Ave();
            Tubo tubo1 = new Tubo(110);
            Tubo tubo2 = new Tubo(30);
            Tubo tubo3 = new Tubo(55);
            Tubo tubo4 = new Tubo(80);
            List<Tubo> tubos = new List<Tubo>() { tubo1, tubo2, tubo3, tubo4 };
            Tablero t = new Tablero();
            while (true)
            {
                if (restart == false)
                {
                    while (flappy.colision(tubos))
                    {
                        t.Puntos = flappy.Puntos;
                        if (Console.KeyAvailable)
                        {
                            var tecla = Console.ReadKey(true).Key;
                            if (tecla == ConsoleKey.Spacebar)
                                flappy.saltar();
                        }
                        foreach (Tubo tubo in tubos)
                        {
                            tubo.mover();
                            tubo.dibujar();
                        }
                        flappy.caida();
                        flappy.dibujar();
                        t.dibujar();
                        Thread.Sleep(100);
                    }
                    restart = true;
                }
                    t.perdiste();
                var teclaR = Console.ReadKey(true).Key;
                if (teclaR == ConsoleKey.R)
                {
                    Console.Clear();
                    flappy.restart();
                    tubo1.restart(110);
                    tubo2.restart(30);
                    tubo3.restart(55);
                    tubo4.restart(80);
                    restart = false;
                }
                    
            
            }
        }
    }
}

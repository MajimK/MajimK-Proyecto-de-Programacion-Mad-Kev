using System;
using Pieces;
using Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace Condiciones
{
    public class ClasicC<T> : IWin<T>
    {
        public bool WinnerCoditions(int j, IPlayers<T>[] jugadores)
        {
            if (jugadores[j].Number == 0)
            {
                Painter<IPieces>.Actualizacion(j);
                for (int i = 0; i < jugadores.Length; i++)
                {
                    if (j == i)
                    {
                        Painter<IPieces>.Finish(j + 1);
                        return true;
                    }
                }
            }
            return false;
        }
        public int Tranco(IPlayers<T>[] jugadores)
        {
            int ganador = 0;
            int min = int.MaxValue;

            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].Puntuacion < min)
                {
                    min = jugadores[i].Puntuacion;
                    ganador = i + 1;
                }
            }
            Painter<IPieces>.Finish(ganador);
            return ganador;
        }

    }
    public class Inverter<T> : IWin<T>
    {
        public bool WinnerCoditions(int j, IPlayers<T>[] jugadores)
        {
            if (jugadores[j].Number == 0)
            {
                Painter<IPieces>.Actualizacion(j);
                Tranco(jugadores);
                return true;
            }
            return false;
        }
        public int Tranco(IPlayers<T>[] jugadores)
        {
            int ganador = 0;
            int max = int.MinValue;
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (max < jugadores[i].Puntuacion)
                {
                    max = jugadores[i].Puntuacion;
                    ganador = i + 1;
                }
            }
            Painter<IPieces>.Finish(ganador);
            return ganador;
        }
    }
    public class Pasado<T> : IWin<T>
    {
        public bool WinnerCoditions(int j, IPlayers<T>[] jugadores)
        {
            if (jugadores[j].Number==0)
            {
                Painter<IPieces>.Actualizacion(j);
                Painter<IPieces>.Finish(j + 1);
                return true;

            }
            

             if (Painter<IPieces>.SePaso())
                {
                Painter<IPieces>.Actualizacion(j);
                int y = TrancoI(jugadores);
                if (y-1 == j) 
                {
                    Tranco(jugadores);
                }
                else 
                {
                    Painter<IPieces>.Finish(y);
                }
                return true;
                }
            
            return false;

        }
        private int TrancoI(IPlayers<T>[] jugadores)
        {
            int ganador = 0;
            int min = int.MaxValue;

            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].Puntuacion < min)
                {
                    min = jugadores[i].Puntuacion;
                    ganador = i + 1;
                }
            }
            return ganador;
        }
        public int Tranco(IPlayers<T>[] jugadores)
        {
            int ganador = 0;
            int min = int.MaxValue;
            int m= 0;
            for (int i = 0;i < jugadores.Length;i++) 
            {
                if (jugadores[i].Puntuacion < min)
                {
                    min = jugadores[i].Puntuacion;
                    m = min;
                }
            }
            min = int.MaxValue;

            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].Puntuacion < min&&jugadores[i].Puntuacion>m)
                {
                    min = jugadores[i].Puntuacion;
                    ganador = i + 1;
                }
            }
            Painter<IPieces>.Finish(ganador);
            return ganador;
        }


    }
}
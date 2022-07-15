using System;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KindGame
{ 

public class ClasicF<T> : IPlay<T>
{
    public void Play(IPlayers<T>[] jugadores, IWin<T> cond, Mesa<T> mesa, List<T> pieces)
    {
        int ganador = 0;
        bool hubojugada = true;
        while (hubojugada)
        {
            int juego = mesa.Count;
            for (int i = 0; i < jugadores.Length; i++)
            {
                int m = mesa.Count;
                jugadores[i].Strategy(mesa);
                if (m == mesa.Count)
                {
                    mesa.Addp();
                    jugadores[i].Pase();

                    }
                    if (cond.WinnerCoditions(i, jugadores))
                {
                    ganador = i + 1;
                    break;
                }
                Painter<IPieces>.Actualizacion(i);
            }
            if (mesa.Count == juego || ganador != 0)
            {
                break;
            }
        }
        if (ganador == 0)
        {
            int ganad = cond.Tranco(jugadores);
        }
    }

}
public class KeepPlaying<T> : IPlay<T>
{
    public void Play(IPlayers<T>[] jugadores, IWin<T> cond, Mesa<T> mesa, List<T> pieces)
    {

        int ganador = 0;
        bool hubojugada = true;
        while (hubojugada)
        {
            int juego = mesa.Count;
            for (int i = 0; i < jugadores.Length; i++)
            {
                int m = 0;
                //si jugo pues que siga jugando
                do
                {
                    m = mesa.Count;
                    jugadores[i].Strategy(mesa);
                    if (m == mesa.Count&&jugadores[i].Number!=0)
                    {
                        mesa.Addp();
                        jugadores[i].Pase();

                        }
                        if (cond.WinnerCoditions(i, jugadores))
                    {
                        ganador = i + 1;
                        break;
                    }
                        Painter<IPieces>.Actualizacion(i);
                    } while (m != mesa.Count);
                if (ganador!=0)
                {
                    break;
                }
            }
            if (mesa.Count == juego || ganador != 0)
            {
                break;
            }
        }
        if (ganador == 0)
        {
            int ganad = cond.Tranco(jugadores);

        }
    }
}
public class Thief<T> : IPlay<T>
{
        public void Play(IPlayers<T>[] jugadores, IWin<T> cond, Mesa<T> mesa, List<T> pieces)
        {
            Random r = new Random();
            int ganador = 0;
            bool hubojugada = true;
            while (hubojugada)
            {
                int juego = mesa.Count;
                for (int i = 0; i < jugadores.Length; i++)
                {
                    int m = mesa.Count;
                    //Si se paso que robe una ficha
                    while (m == mesa.Count)
                    {
                        jugadores[i].Strategy(mesa);
                        if (pieces.Count == 0)
                        {
                            break;
                        }
                        if (m == mesa.Count)
                        {
                            int n = r.Next(0, pieces.Count);
                            jugadores[i].Add(pieces[n]);
                            pieces.Remove(pieces[n]);
                        }
                    }
                    if (ganador != 0)
                    {
                        break;
                    }
                    if (m == mesa.Count)
                    {
                        mesa.Addp();
                        jugadores[i].Pase();
                    }
                    if (cond.WinnerCoditions(i, jugadores))
                    {
                        ganador = i + 1;
                        break;
                    }
                    
                        Painter<IPieces>.Actualizacion(i);
                    
                    


                }
                if (mesa.Count == juego || ganador != 0)
                {
                    break;
                }
            }
            if (ganador == 0)
            {
                int ganad = cond.Tranco(jugadores);

            }
        }
        }
}


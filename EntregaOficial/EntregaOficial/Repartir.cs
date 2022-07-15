using System;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repartir
{ 
public class ClasicR<T> : IRepartir<T>
{
    public void Repartir(IPlayers<T>[] jugadores, List<T> pieces, int modalidad)
    {
        //por si me pasan mas jugadores de la cuenta
        int cant = pieces.Count;

        int f = (int)((float)cant / (float)jugadores.Length);
        if (f < modalidad + 1 && f != 0)
        {
            for (int i = 0; i < f; i++)
            {
                for (int j = 0; j < jugadores.Length; j++)
                {
                    Random r = new Random();
                    int p = r.Next(0, pieces.Count);
                    jugadores[j].Add(pieces[p]);
                    pieces.Remove(pieces[p]);
                }
            }
        }
        else
        {
            //Repartir Normal
            for (int i = 0; i <= modalidad; i++)
            {
                for (int j = 0; j < jugadores.Length; j++)
                {
                    Random r = new Random();
                    int p = r.Next(0, pieces.Count);
                    jugadores[j].Add(pieces[p]);
                    pieces.Remove(pieces[p]);
                }
            }
        }
    }

}
    public class All<T> : IRepartir<T>
    {
        public void Repartir(IPlayers<T>[] jugadores, List<T> pieces, int modalidad)
        {
            Random r = new Random();
            foreach (var item in jugadores)
            {
                int e= r.Next(0, pieces.Count);
                item.Add(pieces[e]);
                pieces.Remove(pieces[e]);
            }
            while (pieces.Count != 0)
            {
                int u = r.Next(0, pieces.Count);
                int j = r.Next(0, jugadores.Length);
                jugadores[j].Add(pieces[u]);
                pieces.Remove(pieces[u]);


            }

        }
    }

}
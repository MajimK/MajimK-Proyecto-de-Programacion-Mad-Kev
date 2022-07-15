using System;
using Interfaces;
using System.Collections.Generic;
using System.Linq;
public static class Painter<T> where T : IPieces
{
     static List<T> hola = new List<T>();
     static List<string> act = new List<string>();
    public static void Stat(IPieces ficha)
    {
        hola.Add((T)ficha);
    }
    public static void Finish(int i)
    {
        act.Add($"Player {i} has won");
    }
    public static (List<T>, List<string>) Devolver()
    {
        return (hola, act);
    }
    public static void Actualizacion(int i)
    {
        T ficha = hola.Last();
        if (ficha.UpValue == null)
        {
            act.Add($"Player {i + 1} has passed");
        }
        else
        {
            act.Add($"Player {i + 1} has played");
        }
        
    }
    public static bool SePaso() 
    {
        if (hola.Last().UpValue is null) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
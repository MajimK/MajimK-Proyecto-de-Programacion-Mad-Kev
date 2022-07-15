using System;
using Mesa;
using System.Collections.Generic;
using System.Linq;
//Aqui van todas las interfaces

namespace Interfaces
{
    public interface IPlayers<T>
    {
         int Puntuacion { get; }
         int Number { get; }
         void Strategy(Mesa<T> mesa);
         void Add(T piece);
         void Pase();
    }
    public interface IWin<T>
    {
         bool WinnerCoditions(int i, IPlayers<T>[] jugadores);
         int Tranco(IPlayers<T>[] jugadores);
    }
    public interface IPlay<T>
    {
         void Play(IPlayers<T>[] players, IWin<T> cond, Mesa<T> mesa, List<T> pieces);
    }
    public interface IRepartir<T>
    {
         void Repartir(IPlayers<T>[] players, List<T> pieces, int numero);
    }
    public interface IPieces
    {
        object UpValue { get; }
        object DownValue { get; }
        (int, int) Coord { get; }
        int ValorTotal { get; }
        bool Conect(IPieces r);
        string ToString();
        void Rotar();
        void AddCooRx(int a);
        void AddCooRy(int a);
        void AddValues(object a, object b);
    }
    public interface Mesa<T>
    {
        void AddRight(T jugada);
         void AddLeft(T jugada);
         void Paint();
         void Addp();
         T First { get; }
         T Last { get; }
        int Count { get; }
         List<object> Pasados { get; }
    }
}

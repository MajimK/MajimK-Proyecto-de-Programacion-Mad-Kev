using System;
using Interfaces;
using Pieces;
using System.Collections.Generic;
using System.Linq;

namespace Mesa
{
    public class MesaC<T> : Mesa<T> where T : IPieces
    {
        public List<object> Pasados { get; } = new List<object>();
        List<T> mesa = new List<T>();
        public int Count { get { return mesa.Count; } }
        public T First { get { return mesa.First(); } }
        public T Last { get { return mesa.Last(); } }
        public void AddRight(T jugada)
        {
            if (mesa.Count == 0)
            {
                mesa.Insert(mesa.Count, jugada);
                jugada.AddCooRx(6);
                jugada.AddCooRy(6);
                Painter<T>.Stat(jugada);

            }
            else if (mesa.Last().Coord.Item1 % 2 == 0)
            {
                jugada.AddCooRy(mesa.Last().Coord.Item2 + 1);
                if (jugada.Coord.Item2 > 12)
                {
                    jugada.AddCooRy(12);
                    jugada.AddCooRx(mesa.Last().Coord.Item1 - 1);
                    mesa.Insert(mesa.Count, jugada);
                    Rotar(jugada.Coord.Item1, jugada.Coord.Item2, jugada.UpValue, jugada.DownValue);
                }
                else
                {
                    jugada.AddCooRx(mesa.Last().Coord.Item1);
                    mesa.Insert(mesa.Count, jugada);
                    Painter<T>.Stat(jugada);

                }


            }
            else
            {
                jugada.AddCooRy(mesa.Last().Coord.Item2 - 1);
                if (jugada.Coord.Item2 < 0)
                {
                    jugada.AddCooRy(0);
                    //jugada.coorx = 12;
                    jugada.AddCooRx(mesa.Last().Coord.Item1 - 1);
                    //jugada.coory = mesa.Last().coory - 1;
                    mesa.Insert(mesa.Count, jugada);
                    Painter<T>.Stat(jugada);




                }
                else
                {
                    jugada.AddCooRx(mesa.Last().Coord.Item1);
                    //jugada.coory = mesa.Last().coory;
                    mesa.Insert(mesa.Count, jugada);
                    Rotar(jugada.Coord.Item1, jugada.Coord.Item2, jugada.UpValue, jugada.DownValue);





                }

            }
        }


        public void AddLeft(T jugada)
        {
            if (mesa.Count == 0)
            {
                mesa.Insert(mesa.Count, jugada);
                jugada.AddCooRx(6);
                jugada.AddCooRy(6);
                Painter<T>.Stat(jugada);




            }
            else if (mesa.First().Coord.Item1 % 2 == 0)
            {
                jugada.AddCooRy(mesa.First().Coord.Item2 - 1);
                if (jugada.Coord.Item2 < 0)
                {
                    jugada.AddCooRy(0);
                    jugada.AddCooRx(mesa.First().Coord.Item1 + 1);
                    mesa.Insert(0, jugada);
                    Rotar(jugada.Coord.Item1, jugada.Coord.Item2, jugada.UpValue, jugada.DownValue);



                }
                else
                {
                    jugada.AddCooRx(mesa.First().Coord.Item1);
                    mesa.Insert(0, jugada);
                    Painter<T>.Stat(jugada);



                }

            }
            else
            {
                jugada.AddCooRy(mesa.First().Coord.Item2 + 1);
                if (jugada.Coord.Item2 > 12)
                {
                    jugada.AddCooRy(12);
                    jugada.AddCooRx(mesa.First().Coord.Item1 + 1);
                    mesa.Insert(0, jugada);
                    Painter<T>.Stat(jugada);



                }
                else
                {
                    jugada.AddCooRx(mesa.First().Coord.Item1);
                    mesa.Insert(0, jugada);
                    Rotar(jugada.Coord.Item1, jugada.Coord.Item2, jugada.UpValue, jugada.DownValue);
                }

            }
        }
        public void Paint()
        {
            foreach (var item in mesa)
            {
                string a = item.ToString();
                System.Console.Write($"{a} ");
            }
            System.Console.WriteLine("");


        }
        public void Addp()
        {
            if (!Pasados.Contains(First.DownValue))
            {
                Pasados.Add(First.DownValue);

            }
            if (!Pasados.Contains(Last.UpValue))
            {
                Pasados.Add(Last.UpValue);
            }
        }
        private void Rotar(int x, int y, object up, object down)
        {
            IPieces n = new Fichas();
            n.AddValues(down, up);
            n.AddCooRx(x);
            n.AddCooRy(y);
            Painter<T>.Stat(n);

        }
    }


}
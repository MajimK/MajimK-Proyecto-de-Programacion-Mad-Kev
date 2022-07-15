using System;
using DominoesGame;
using Interfaces;
using Mesa;
using Pieces;
using System.Collections.Generic;
using System.Linq;
namespace PlayersGame
{
    //este es el jugador mongo
    //si quieres arreglalo para que implemente la interface
    public class Players<T> where T : IPieces
    {

        protected List<T> Hand { get; set; }
        public int Number
        {
            get
            {
                return Hand.Count;
            }
        }
        public int Puntuacion
        {
            get
            {
                int puntos = 0;
                for (int i = 0; i < Hand.Count; i++)
                {
                    puntos += Hand[i].ValorTotal;
                }
                return puntos;
            }
        }
        public Players()
        {
            Hand = new List<T>();
        }
        public void Add(T piece)
        {
            Hand.Add(piece);
        }
        public bool ValidFirst(Mesa<T> mesa, T jugada)
        {
            if (mesa.Count == 0)
            {
                return true;
            }
            else if (mesa.First.UpValue.Equals(jugada.DownValue))
            {
                return true;
            }
            //Si te das cuenta aqui rota la ficha
            //para que encajen
            else if (mesa.First.UpValue.Equals(jugada.UpValue))
            {
                jugada.Rotar();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidLast(Mesa<T> mesa, T jugada)
        {
            if (mesa.Count == 0)
            {
                return true;
            }
            else if (mesa.Last.DownValue.Equals(jugada.DownValue))
            {
                jugada.Rotar();
                return true;
            }
            else if (mesa.Last.DownValue.Equals(jugada.UpValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<T> Posibilities(Mesa<T> mesa)
        {
            List<T> posibles = new List<T>();
            for (int i = 0; i < Hand.Count; i++)
            {
                if (ValidFirst(mesa, Hand[i]) || ValidLast(mesa, Hand[i]))
                {
                    posibles.Add(Hand[i]);
                }
            }
            return posibles;
        }
        public void Pase()
        {
            IPieces g = new Fichas();
            Painter<T>.Stat(g);
        }



    }
    public class RandomPlayer<T> : Players<T>, IPlayers<T> where T : IPieces
    {
        public RandomPlayer()
        {
            Hand = base.Hand;
        }
        public void Strategy(Mesa<T> mesa)
        {
            List<T> posibles = this.Posibilities(mesa);
            if (posibles.Count != 0)
            {
                Random r = new Random();
                int v = r.Next(0, posibles.Count);
                T jugar = posibles[v];

                if (ValidFirst(mesa, jugar))
                {
                    mesa.AddLeft(jugar);
                    Hand.Remove(jugar);


                }
                else if (ValidLast(mesa, jugar))
                {
                    mesa.AddRight(jugar);
                    Hand.Remove(jugar);

                }
            }

        }

    }

    // Este es el Botagorda
    public class LightPlayer<T> : Players<T>, IPlayers<T> where T : IPieces
    {

        public LightPlayer()
        {
            Hand = base.Hand;
        }
        // La estrategia, el jugador es el que pone las fichas
        public void Strategy(Mesa<T> mesa)
        {
            int max = 0;
            List<T> posibles = this.Posibilities(mesa);
            if (posibles.Count != 0)
            {
                T jugar = posibles.First();
                foreach (var item in posibles)
                {
                    if (item.ValorTotal > max)
                    {
                        max = item.ValorTotal;
                        jugar = item;
                    }
                }
                if (ValidFirst(mesa, jugar))
                {
                    mesa.AddLeft(jugar);
                    Hand.Remove(jugar);


                }
                else if (ValidLast(mesa, jugar))
                {
                    mesa.AddRight(jugar);
                    Hand.Remove(jugar);

                }
            }
        }


    }
    // Jugador que lo unico que hace es joder
    // pasando a todos
    //Empece ahora no he terminado
    public class TrollPlayer<T> : Players<T>, IPlayers<T> where T : IPieces
    {

        public TrollPlayer()
        {
            Hand = base.Hand;
        }


        public void Strategy(Mesa<T> mesa)
        {
            List<T> posibles = this.Posibilities(mesa);
            if (posibles.Count != 0)
            {
                T jugar = posibles.First();
                for (int i = 0; i < posibles.Count; i++)
                {
                    for (int j = 0; j < mesa.Pasados.Count; j++)
                    {
                        bool Fichacom = posibles[i].UpValue.Equals(mesa.Pasados[j]) || posibles[i].DownValue.Equals(mesa.Pasados[j]);
                        bool mesacom = !mesa.First.UpValue.Equals(mesa.Pasados[j]) || !mesa.Last.DownValue.Equals(mesa.Pasados[j]);
                        if (Fichacom && mesacom)
                        {
                            jugar = posibles[i];
                        }
                    }
                }
                if (ValidFirst(mesa, jugar) && !mesa.Pasados.Contains(jugar.UpValue))
                {
                    mesa.AddLeft(jugar);
                    Hand.Remove(jugar);

                }
                else if (ValidLast(mesa, jugar) && !mesa.Pasados.Contains(jugar.DownValue))
                {
                    mesa.AddRight(jugar);
                    Hand.Remove(jugar);


                }
                else
                {
                    mesa.AddLeft(jugar);
                    Hand.Remove(jugar);
                }
            }

        }
    }
    //Este es el agachado
    public class BankPlayer<T> : Players<T>, IPlayers<T> where T : IPieces
    {
        public BankPlayer()
        {
            Hand = base.Hand;
        }
        public void Strategy(Mesa<T> mesa)
        {
            int mejor = 0;
            List<T> posibles = this.Posibilities(mesa);
            if (posibles.Count != 0)
            {
                T jugar = posibles.First();
                for (int i = 0; i < posibles.Count; i++)
                {
                    int mas = 0;
                    for (int j = 0; j < Hand.Count; j++)
                    {
                        if (posibles[i].Conect(Hand[j]))
                        {
                            mejor++;
                        }
                    }
                    if (mejor < mas)
                    {
                        jugar = posibles[i];
                    }
                }
                if (ValidFirst(mesa, jugar))
                {
                    mesa.AddLeft(jugar);
                    Hand.Remove(jugar);

                }
                else if (ValidLast(mesa, jugar))
                {
                    mesa.AddRight(jugar);
                    Hand.Remove(jugar);


                }
            }
        }
    }
}
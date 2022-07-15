using System;
using PlayersGame;
using Mesa;
using Interfaces;
using Pieces;
using System.Collections.Generic;
using System.Linq;
namespace DominoesGame
{

    public class Dominoes<T> where T : IPieces
    {
        public List<T> pieces { get; protected set; }
        public IPlayers<T>[] jugadores { get; protected set; }
        public int modalidad { get; }
        public Ruler<T> Judge { get; }
        public Mesa<T> mesa = new MesaC<T>();
        public Dominoes(int modalidad, Ruler<T> judge, IPlayers<T>[] jugadores)
        {

            this.modalidad = modalidad;
            this.jugadores = jugadores.ToArray();
            this.Judge = judge;
            pieces = Judge.Piezas.ToList();
        }
        public void Repartir()
        {
            Judge.Rep.Repartir(jugadores, pieces, modalidad);
        }
        public void Play()
        {
            
            Repartir();
            Judge.Juego.Play(jugadores, Judge.Cond, mesa, pieces);

        }
        
    }

    public class Ruler<T> where T : IPieces
    {
        public IWin<T> Cond { get; }
        public IPlay<T> Juego { get; }
        public IRepartir<T> Rep { get; }
        public List<T> Piezas { get; }
        public Ruler(IWin<T> cond, IPlay<T> juego, IRepartir<T> rep, List<T> piezas)
        {
            Cond = cond;
            Juego = juego;
            Rep = rep;
            Piezas = piezas;
        }
    }
}
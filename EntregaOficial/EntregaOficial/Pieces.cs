using System;
using Interfaces;
namespace Pieces
{
    public class Fichas : IPieces
    {

        public object UpNumber;
        public object DownNumber;
        public int coorx;
        public int coory;
        public object UpValue { get { return UpNumber; } }
        public object DownValue { get { return DownNumber; } }
        public (int, int) Coord { get { return (coorx, coory); } }
        public int ValorTotal
        {
            get
            {
                int a = int.Parse(UpNumber.ToString());
                int b = int.Parse(DownNumber.ToString());
                return a + b;

            }
        }

        //las fichas llevan otra interface
        //para hacer otro tipo de fichas

        //el metodo equals
        public bool Conect(IPieces obj)
        {
            return obj.UpValue.Equals(DownNumber) || obj.UpValue.Equals(UpNumber) || obj.DownValue.Equals(UpNumber) || obj.DownValue.Equals(DownNumber);
        }
        //para imprimirlas
        public override string ToString()
        {
            return $"[{this.UpNumber}|{this.DownNumber}]";
        }
        //y el de rotarlas para que encajen
        public void Rotar()
        {
            object up = this.UpNumber;
            UpNumber = this.DownNumber;
            DownNumber = up;

        }
        public void AddCooRx(int a)
        {
            coorx = a;

        }
        public void AddCooRy(int a)
        {
            coory = a;
        }

        public void AddValues(object a, object b)
        {
            UpNumber = a;
            DownNumber = b;
        }
    }

    public class Letrichas : IPieces
    {
        public object UpNumber;
        public object DownNumber;
        public int coorx;
        public int coory;
        public object UpValue { get { return UpNumber; } }
        public object DownValue { get { return DownNumber; } }
        public (int, int) Coord { get { return (coorx, coory); } }
        public int ValorTotal
        {
            get
            {
                int a = 0;
                int b = 0;
                string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                for (int i = 0; i < letras.Length; i++)
                {
                    if (UpNumber.Equals(letras[i]))
                    {
                        a = i;
                    }
                    else if (DownNumber.Equals(letras[i]))
                    {
                        b = i;
                    }
                }
                return a + b;
            }
        }
        public bool Conect(IPieces obj)
        {
            return obj.UpValue.Equals(DownNumber) || obj.UpValue.Equals(UpNumber) || obj.DownValue.Equals(UpNumber) || obj.DownValue.Equals(DownNumber);
        }
        public override string ToString()
        {
            return $"[{this.UpNumber}|{this.DownNumber}]";
        }
        public void Rotar()
        {
            object up = this.UpNumber;
            UpNumber = this.DownNumber;
            DownNumber = up;
        }
        public void AddCooRx(int a)
        {
            coorx = a;

        }
        public void AddCooRy(int a)
        {
            coory = a;

        }
        public void AddValues(object a, object b)
        {
            UpNumber = a;
            DownNumber = b;
        }
    }

    public class Cartas : IPieces
    {
        public object UpNumber;
        public object DownNumber;
        public int coorx;
        public int coory;
        public object UpValue { get { return UpNumber; } }
        public object DownValue { get { return DownNumber; } }
        public (int, int) Coord { get { return (coorx, coory); } }
        public int ValorTotal
        {
            get
            {
                int t = 0;
                if (int.TryParse(UpValue.ToString(), out t))
                {
                    return t;
                }
                else
                {
                    return int.Parse(DownValue.ToString());
                }
            }
        }
        public bool Conect(IPieces obj)
        {
            return obj.UpValue.Equals(DownNumber) || obj.UpValue.Equals(UpNumber) || obj.DownValue.Equals(UpNumber) || obj.DownValue.Equals(DownNumber);
        }
        public override string ToString()
        {
            return $"[{this.UpNumber}|{this.DownNumber}]";
        }
        public void Rotar()
        {
            object up = this.UpNumber;
            UpNumber = this.DownNumber;
            DownNumber = up;
        }
        public void AddCooRx(int a)
        {
            coorx = a;

        }
        public void AddCooRy(int a)
        {
            coory = a;

        }
        public void AddValues(object a, object b)
        {
            UpNumber = a;
            DownNumber = b;
        }
    }

    public class Lemojis : IPieces
    {
        public object UpNumber;
        public object DownNumber;
        public int coorx;
        public int coory;
        public object UpValue { get { return UpNumber; } }
        public object DownValue { get { return DownNumber; } }
        public (int, int) Coord { get { return (coorx, coory); } }
        public int ValorTotal
        {
            get
            {
                int a = 0;
                int b = 0;
                string[] emojis = { ":)", ":(", ":|", ":v", ";-;", ":D", "7w7", "XD", ":u", ":0", ";)", "<3" };
                for (int i = 0; i < emojis.Length; i++)
                {
                    if (UpNumber.Equals(emojis[i]))
                    {
                        a = i;
                    }
                    else if (DownNumber.Equals(emojis[i]))
                    {
                        b = i;
                    }
                }
                return a + b;
            }
        }
        public bool Conect(IPieces obj)
        {
            return obj.UpValue.Equals(DownNumber) || obj.UpValue.Equals(UpNumber) || obj.DownValue.Equals(UpNumber) || obj.DownValue.Equals(DownNumber);

        }
        public override string ToString()
        {
            return $"[{this.UpNumber}|{this.DownNumber}]";
        }
        public void Rotar()
        {
            object up = this.UpNumber;
            UpNumber = this.DownNumber;
            DownNumber = up;
        }
        public void AddCooRx(int a)
        {
            coorx = a;
        }
        public void AddCooRy(int a)
        {
            coory = a;
        }
        public void AddValues(object a, object b)
        {
            UpNumber = a;
            DownNumber = b;
        }
    }
}

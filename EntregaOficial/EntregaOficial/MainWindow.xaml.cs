using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Interfaces;
using DominoesGame;
using Repartir;
using KindGame;
using Condiciones;
using PlayersGame;
using Pieces;
using System.IO;

namespace EntregaOficial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //VARIABLES GLOBALES
        public static List<IPieces> m = new List<IPieces>();//listas para l move

        public static List<string> str = new List<string>();//same

        public static int ind;//para el move

        public static int indice = 1; // para saber si es letras o numeros

        public static int indiceRep = 0;//repartir

        public static int indiceGanar = 0;//winers conditions

        public static int indiceJuego = 0;//Forma de juego

        public static int indiceMod;//modalidad

        public static int indiceStruct = 1;

        public static int canti; //Cant de jugadores

        public static IRepartir<IPieces>[] Ropciones = { new ClasicR<IPieces>(), new All<IPieces>() };
        public static IRepartir<IPieces> a;

        public static IPlay<IPieces>[] Popciones = { new ClasicF<IPieces>(), new Thief<IPieces>(), new KeepPlaying<IPieces>() };
        public static IPlay<IPieces> b;

        public static IWin<IPieces>[] wopciones = { new ClasicC<IPieces>(), new Inverter<IPieces>(), new Pasado<IPieces>() };
        public static IWin<IPieces> c;

        public static IPlayers<IPieces>[] players;
        public static List<IPieces> pieces = new List<IPieces>();

        public static Ruler<IPieces> juez;

        public static List<IPieces> n;//lista de las fichas jugadas
        public static List<string> s;//historial del juego
        public int[] cantJug = new int[4];//array de jugadores

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Juegar()
        {
            List<Grid> ListaG = new List<Grid>
              {
                    El0A0,
                    El0A1,
                    El0A2,
                    El0A3,
                    El0A4,
                    El0A5,
                    El0A6,
                    El0A7,
                    El0A8,
                    El0A9,
                    El0A10,
                    El0A11,
                    El0A12,
                    El1A0,
                    El1A1,
                    El1A2,
                    El1A3,
                    El1A4,
                    El1A5,
                    El1A6,
                    El1A7,
                    El1A8,
                    El1A9,
                    Es1A10,
                    Es1A11,
                    Es1A12,
                    El2A0,
                    El2A1,
                    El2A2,
                    El2A3,
                    El2A4,
                    El2A5,
                    El2A6,
                    El2A7,
                    El2A8,
                    El2A9,
                    El2A10,
                    El2A11,
                    El2A12,
                    El3A0,
                    El3A1,
                    El3A2,
                    El3A3,
                    El3A4,
                    El3A5,
                    El3A6,
                    El3A7,
                    El3A8,
                    El3A9,
                    El3A10,
                    El3A11,
                    El3A12,
                    El4A0,
                    El4A1,
                    El4A2,
                    El4A3,
                    El4A4,
                    El4A5,
                    El4A6,
                    El4A7,
                    El4A8,
                    El4A9,
                    El4A10,
                    El4A11,
                    El4A12,
                    El5A0,
                    El5A1,
                    El5A2,
                    El5A3,
                    El5A4,
                    El5A5,
                    El5A6,
                    El5A7,
                    El5A8,
                    El5A9,
                    El5A10,
                    El5A11,
                    El5A12,
                    El6A0,
                    El6A1,
                    El6A2,
                    El6A3,
                    El6A4,
                    El6A5,
                    El6A6,
                    El6A7,
                    El6A8,
                    El6A9,
                    El6A10,
                    El6A11,
                    El6A12,
                    El7A0,
                    El7A1,
                    El7A2,
                    El7A3,
                    El7A4,
                    El7A5,
                    El7A6,
                    El7A7,
                    El7A8,
                    El7A9,
                    El7A10,
                    El7A11,
                    El7A12,
                    El8A0,
                    El8A1,
                    El8A2,
                    El8A3,
                    El8A4,
                    El8A5,
                    El8A6,
                    El8A7,
                    El8A8,
                    El8A9,
                    El8A10,
                    El8A11,
                    El8A12,
                    El9A0,
                    El9A1,
                    El9A2,
                    El9A3,
                    El9A4,
                    El9A5,
                    El9A6,
                    El9A7,
                    El9A8,
                    El9A9,
                    El9A10,
                    El9A11,
                    El9A12,
                    El10A0,
                    El10A1,
                    El10A2,
                    El10A3,
                    El10A4,
                    El10A5,
                    El10A6,
                    El10A7,
                    El10A8,
                    El10A9,
                    El10A10,
                    El10A11,
                    El10A12,
                    El11A0,
                    El11A1,
                    El11A2,
                    El11A3,
                    El11A4,
                    El11A5,
                    El11A6,
                    El11A7,
                    El11A8,
                    El11A9,
                    El11A10,
                    El11A11,
                    El11A12,
                    El12A0,
                    El12A1,
                    El12A2,
                    El12A3,
                    El12A4,
                    El12A5,
                    El12A6,
                    El12A7,
                    El12A8,
                    El12A9,
                    El12A10,
                    El12A11,
                    El12A12

                 };

            List<TextBlock> listextIzq = new List<TextBlock>
            {
                Izq0A0,
                Izq0A1,
                Izq0A2,
                Izq0A3,
                Izq0A4,
                Izq0A5,
                Izq0A6,
                Izq0A7,
                Izq0A8,
                Izq0A9,
                Izq0A10,
                Izq0A11,
                Izq0A12,
                Izq1A0,
                Izq1A1,
                Izq1A2,
                Izq1A3,
                Izq1A4,
                Izq1A5,
                Izq1A6,
                Izq1A7,
                Izq1A8,
                Izq1A9,
                Isq1A10,
                Isq1A11,
                Isq1A12,
                Izq2A0,
                Izq2A1,
                Izq2A2,
                Izq2A3,
                Izq2A4,
                Izq2A5,
                Izq2A6,
                Izq2A7,
                Izq2A8,
                Izq2A9,
                Izq2A10,
                Izq2A11,
                Izq2A12,
                Izq3A0,
                Izq3A1,
                Izq3A2,
                Izq3A3,
                Izq3A4,
                Izq3A5,
                Izq3A6,
                Izq3A7,
                Izq3A8,
                Izq3A9,
                Izq3A10,
                Izq3A11,
                Izq3A12,
                Izq4A0,
                Izq4A1,
                Izq4A2,
                Izq4A3,
                Izq4A4,
                Izq4A5,
                Izq4A6,
                Izq4A7,
                Izq4A8,
                Izq4A9,
                Izq4A10,
                Izq4A11,
                Izq4A12,
                Izq5A0,
                Izq5A1,
                Izq5A2,
                Izq5A3,
                Izq5A4,
                Izq5A5,
                Izq5A6,
                Izq5A7,
                Izq5A8,
                Izq5A9,
                Izq5A10,
                Izq5A11,
                Izq5A12,
                Izq6A0,
                Izq6A1,
                Izq6A2,
                Izq6A3,
                Izq6A4,
                Izq6A5,
                Izq6A6,
                Izq6A7,
                Izq6A8,
                Izq6A9,
                Izq6A10,
                Izq6A11,
                Izq6A12,
                Izq7A0,
                Izq7A1,
                Izq7A2,
                Izq7A3,
                Izq7A4,
                Izq7A5,
                Izq7A6,
                Izq7A7,
                Izq7A8,
                Izq7A9,
                Izq7A10,
                Izq7A11,
                Izq7A12,
                Izq8A0,
                Izq8A1,
                Izq8A2,
                Izq8A3,
                Izq8A4,
                Izq8A5,
                Izq8A6,
                Izq8A7,
                Izq8A8,
                Izq8A9,
                Izq8A10,
                Izq8A11,
                Izq8A12,
                Izq9A0,
                Izq9A1,
                Izq9A2,
                Izq9A3,
                Izq9A4,
                Izq9A5,
                Izq9A6,
                Izq9A7,
                Izq9A8,
                Izq9A9,
                Izq9A10,
                Izq9A11,
                Izq9A12,
                Izq10A0,
                Izq10A1,
                Izq10A2,
                Izq10A3,
                Izq10A4,
                Izq10A5,
                Izq10A6,
                Izq10A7,
                Izq10A8,
                Izq10A9,
                Izq10A10,
                Izq10A11,
                Izq10A12,
                Izq11A0,
                Izq11A1,
                Izq11A2,
                Izq11A3,
                Izq11A4,
                Izq11A5,
                Izq11A6,
                Izq11A7,
                Izq11A8,
                Izq11A9,
                Izq11A10,
                Izq11A11,
                Izq11A12,

                Izq12A0,
                Izq12A1,
                Izq12A2,
                Izq12A3,
                Izq12A4,
                Izq12A5,
                Izq12A6,
                Izq12A7,
                Izq12A8,
                Izq12A9,
                Izq12A10,
                Izq12A11,
                Izq12A12,
            };

            List<TextBlock> listextDer = new List<TextBlock>
            {
                Der0A0,
                Der0A1,
                Der0A2,
                Der0A3,
                Der0A4,
                Der0A5,
                Der0A6,
                Der0A7,
                Der0A8,
                Der0A9,
                Der0A10,
                Der0A11,
                Der0A12,

                Der1A0,
                Der1A1,
                Der1A2,
                Der1A3,
                Der1A4,
                Der1A5,
                Der1A6,
                Der1A7,
                Der1A8,
                Der1A9,
                Dor1A10,
                Dor1A11,
                Dor1A12,

                Der2A0,
                Der2A1,
                Der2A2,
                Der2A3,
                Der2A4,
                Der2A5,
                Der2A6,
                Der2A7,
                Der2A8,
                Der2A9,
                Der2A10,
                Der2A11,
                Der2A12,

                Der3A0,
                Der3A1,
                Der3A2,
                Der3A3,
                Der3A4,
                Der3A5,
                Der3A6,
                Der3A7,
                Der3A8,
                Der3A9,
                Der3A10,
                Der3A11,
                Der3A12,

                Der4A0,
                Der4A1,
                Der4A2,
                Der4A3,
                Der4A4,
                Der4A5,
                Der4A6,
                Der4A7,
                Der4A8,
                Der4A9,
                Der4A10,
                Der4A11,
                Der4A12,

                Der5A0,
                Der5A1,
                Der5A2,
                Der5A3,
                Der5A4,
                Der5A5,
                Der5A6,
                Der5A7,
                Der5A8,
                Der5A9,
                Der5A10,
                Der5A11,
                Der5A12,

                Der6A0,
                Der6A1,
                Der6A2,
                Der6A3,
                Der6A4,
                Der6A5,
                Der6A6,
                Der6A7,
                Der6A8,
                Der6A9,
                Der6A10,
                Der6A11,
                Der6A12,

                Der7A0,
                Der7A1,
                Der7A2,
                Der7A3,
                Der7A4,
                Der7A5,
                Der7A6,
                Der7A7,
                Der7A8,
                Der7A9,
                Der7A10,
                Der7A11,
                Der7A12,

                Der8A0,
                Der8A1,
                Der8A2,
                Der8A3,
                Der8A4,
                Der8A5,
                Der8A6,
                Der8A7,
                Der8A8,
                Der8A9,
                Der8A10,
                Der8A11,
                Der8A12,

                Der9A0,
                Der9A1,
                Der9A2,
                Der9A3,
                Der9A4,
                Der9A5,
                Der9A6,
                Der9A7,
                Der9A8,
                Der9A9,
                Der9A10,
                Der9A11,
                Der9A12,

                Der10A0,
                Der10A1,
                Der10A2,
                Der10A3,
                Der10A4,
                Der10A5,
                Der10A6,
                Der10A7,
                Der10A8,
                Der10A9,
                Der10A10,
                Der10A11,
                Der10A12,

                Der11A0,
                Der11A1,
                Der11A2,
                Der11A3,
                Der11A4,
                Der11A5,
                Der11A6,
                Der11A7,
                Der11A8,
                Der11A9,
                Der11A10,
                Der11A11,
                Der11A12,

                Der12A0,
                Der12A1,
                Der12A2,
                Der12A3,
                Der12A4,
                Der12A5,
                Der12A6,
                Der12A7,
                Der12A8,
                Der12A9,
                Der12A10,
                Der12A11,
                Der12A12,

            };

            for (int i = 0; i < m.Count; i++)
            {
                for (int j = 0; j < listextDer.Count; j++)
                {
                    if (m[i].Coord.Item1.ToString() + "A" + m[i].Coord.Item2.ToString() == listextIzq[j].Name.Substring(3))
                    {
                        if (m[i].UpValue == null)
                        {
                            continue;
                        }
                        listextDer[j].Text = "  " + m[i].DownValue.ToString(); //quitar la conversion a string !!
                        listextIzq[j].Text = "  " + m[i].UpValue.ToString();
                        ListaG[j].Visibility = Visibility.Visible;
                    }
                }
            }
        }

        public void Todo()
        {
            string dom = tdomino.Text;
            ValidarText(ref dom);
            indiceMod = int.Parse(dom);

            a = Ropciones[indiceRep];
            b = Popciones[indiceJuego];
            c = wopciones[indiceGanar];

            string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] emojis = { ":)", ":(", "<3", ":|", ":v", ";-;", ":D", "XD", ":u", ":0", ";)", "7w7" };

            players = new IPlayers<IPieces>[canti];

            int h = 0;

            for (int i = 0; i < cantJug.Length; i++)
            {
                for (int j = 0; j < cantJug[i]; j++)
                {
                    if (i == 0)
                    {
                        IPlayers<IPieces> g = new LightPlayer<IPieces>();
                        players[h] = g;
                        h += 1;
                    }
                    else if (i == 1)
                    {
                        IPlayers<IPieces> g = new TrollPlayer<IPieces>();
                        players[h] = g;
                        h++;
                    }
                    else if (i == 2)
                    {
                        IPlayers<IPieces> g = new BankPlayer<IPieces>();
                        players[h] = g;
                        h++;
                    }
                    else if (i == 3)
                    {
                        IPlayers<IPieces> g = new RandomPlayer<IPieces>();
                        players[h] = g;
                        h++;
                    }
                }
            }

            if (indice == 1)
            {
                for (int i = 0; i <= indiceMod; i++) //modalidad es el tipo de doble
                {
                    for (int k = i; k <= indiceMod; k++)
                    {
                        IPieces g = new Fichas();
                        g.AddValues(i, k);
                        pieces.Add(g);

                    }
                }
            }
            else if (indice == 2)
            {
                for (int i = 0; i <= indiceMod; i++)
                {
                    for (int k = i; k <= indiceMod; k++)
                    {
                        IPieces g = new Letrichas();
                        g.AddValues(letras[i], letras[k]);
                        pieces.Add(g);
                    }
                }
            }
            else if (indice == 3)
            {
                for (int i = 0; i <= indiceMod; i++)
                {
                    for (int k = i; k <= indiceMod; k++)
                    {
                        IPieces g = new Lemojis();
                        g.AddValues(emojis[i], emojis[k]);
                        pieces.Add(g);
                    }
                }
            }
        }

        public void Jugadores()
        {
            string uno = cant.Text;
            ValidarText(ref uno);
            cantJug[0] = int.Parse(uno);

            string dos = cant1.Text;
            ValidarText(ref dos);
            cantJug[1] = int.Parse(dos);

            string tres = cant2.Text;
            ValidarText(ref tres);
            cantJug[2] = int.Parse(tres);

            string cuatro = cant3.Text;
            ValidarText(ref cuatro);
            cantJug[3] = int.Parse(cuatro);

            if (cantJug[0] < 0)
            {
                cantJug[0] = 0;
            }
            else if (cantJug[1] < 0)
            {
                cantJug[1] = 0;
            }
            else if (cantJug[2] < 0)
            {
                cantJug[2] = 0;
            }
            else if (cantJug[3] < 0)
            {
                cantJug[3] = 0;
            }


            canti = cantJug[0] + cantJug[1] + cantJug[2] + cantJug[3];
        }

        public void ValidarText(ref string text)
        {
            string junto = "";
            var Moda = text.ToCharArray();
            if (Moda.Length >= 19)
            {
                text = "0";
                return;
            }
            for (int i = 0; i < Moda.Length; i++)
            {
                if (char.IsNumber(Moda[i]))
                {
                    junto = junto + Moda[i].ToString();
                }
            }
            if (junto == "")
            {
                junto = "0";
            }
            text = junto;
        }

        //EVENTOS DE LA INTERFAZ
        private void Salir(object sender, RoutedEventArgs e) //Grid 1
        {
            Close();
        }

        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            Portada.Visibility = Visibility.Hidden;
            PantallaDePersonalizacion.Visibility = Visibility.Visible;
        }

        private void Comenzar_Click(object sender, RoutedEventArgs e) //Grid 2
        {
            Jugadores();
            string dom = tdomino.Text;
            ValidarText(ref dom);
            indiceMod = int.Parse(dom);

            if (indiceStruct == 1)
            {
                if (indiceMod == 0)
                {
                    MessageBox.Show("FORMATO INCORRECTO");
                }
                else if (indiceMod > 12)
                {
                    MessageBox.Show("SOLO SE PUEDE JUGAR EN MODALIDAD MENOR O IGUAL A DOBLE 12");
                }
                else if (indice == 3 && indiceMod > 11)
                {
                    MessageBox.Show("ERROR. SOLO SE PUEDE JUGAR EN MODALIDAD MENOR O IGUAL A DOBLE 11");
                }
                else
                {
                    double cantFich = (indiceMod + 1) * (indiceMod + 2);
                    cantFich = cantFich / 2;
                    int f = (int)((float)cantFich / (float)canti);

                    if (f < 2)
                    {
                        MessageBox.Show("FORMATO INCORRECTO");
                    }
                    else
                    {
                        PantallaDePersonalizacion.Visibility = Visibility.Hidden;
                        Tablero.Visibility = Visibility.Visible;
                        Todo();
                        Ruler<IPieces> juez = new Ruler<IPieces>(c, b, a, pieces);
                        Dominoes<IPieces> juego = new Dominoes<IPieces>(indiceMod, juez, players);
                        juego.Play();

                        s = Painter<IPieces>.Devolver().Item2;
                        n = Painter<IPieces>.Devolver().Item1;
                    }
                }
            }

            else if (indiceStruct == 2)
            {
                if (indiceMod == 0)
                {
                    MessageBox.Show("FORMATO INCORRECTO");
                }
                else if (indice == 2 && indiceMod > 25)
                {
                    MessageBox.Show("ERROR. SOLO SE PUEDE JUGAR EN MODALIDAD MENOR O IGUAL A DOBLE 25");
                }
                else if (indice == 3 && indiceMod > 11)
                {
                    MessageBox.Show("ERROR. SOLO SE PUEDE JUGAR EN MODALIDAD MENOR O IGUAL A DOBLE 11");
                }
                else if (indiceMod > 70)
                {
                    MessageBox.Show("NO VEO MUY ENTRETENIDO JUGAR UNA PARTIDA TAN EXTENSA :(");
                }
                else
                {
                    double cantFich = (indiceMod + 1) * (indiceMod + 2);
                    cantFich = cantFich / 2;
                    int f = (int)((float)cantFich / (float)canti);

                    if (f < 2)
                    {
                        MessageBox.Show("NO TIENE SENTIDO QUE LOS JUGADORES JUEGUEN CON UNA FICHA");
                    }
                    else
                    {
                        PantallaDePersonalizacion.Visibility = Visibility.Hidden;
                        Tablero.Visibility = Visibility.Visible;
                        Todo();
                        Ruler<IPieces> juez = new Ruler<IPieces>(c, b, a, pieces);
                        Dominoes<IPieces> juego = new Dominoes<IPieces>(indiceMod, juez, players);
                        juego.Play();

                        n = Painter<IPieces>.Devolver().Item1;
                        s = Painter<IPieces>.Devolver().Item2;
                    }
                }
            }
        }

        private void RadioButtonClass_Click(object sender, RoutedEventArgs e)
        {
            indiceRep = 0;
        }

        private void RadioButtonAll_Click(object sender, RoutedEventArgs e)
        {
            indiceRep = 1;
        }

        private void RadioButtonClas_Click(object sender, RoutedEventArgs e)
        {
            indiceJuego = 0;
        }

        private void RadioButtonThi_Click(object sender, RoutedEventArgs e)
        {
            indiceJuego = 1;
        }

        private void RadioButtonKeep_Click(object sender, RoutedEventArgs e)
        {
            indiceJuego = 2;
        }

        private void RadioButtonCla_Click(object sender, RoutedEventArgs e)
        {
            indiceGanar = 0;
        }

        private void RadioButtonInv_Click(object sender, RoutedEventArgs e)
        {
            indiceGanar = 1;
        }

        private void RadioButtonHand_Click_1(object sender, RoutedEventArgs e)
        {
            indiceGanar = 2;
        }

        private void RadioButton_Num(object sender, RoutedEventArgs e)
        {
            indice = 1;
        }

        private void RadioButton_Letr(object sender, RoutedEventArgs e)
        {
            indice = 2;
        }

        private void RadioButton_Emoj(object sender, RoutedEventArgs e)
        {
            indice = 3;
        }

        private void Move_click(object sender, RoutedEventArgs e) //Grid 3
        {
            Para_Move(n);

            if (n.Count < ind)
            {
                MessageBox.Show("Ha terminado el juego");
            }
            else
            {
                if (indiceStruct == 1)
                {
                    Juegar();
                    Jugadasss.Text += "\n" + s[ind];
                    ind++;
                }
                else if (indiceStruct == 2)
                {
                    Jugadasss.Text += "\n" + s[ind];
                    ind++;
                }
            }
        }

        private void Para_Move(List<IPieces> n)
        {
            if (n.Count <= ind)
            {
                return;
            }
            m.Add(n[ind]);
        }

        private void Salir1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButton_Matrix(object sender, RoutedEventArgs e)
        {
            indiceStruct = 1;
        }

        private void RadioButton_Abstract(object sender, RoutedEventArgs e)
        {
            indiceStruct = 2;
        }
    }
}

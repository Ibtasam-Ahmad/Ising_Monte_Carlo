using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsingMonteCarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double E1, E2, delE, Pflip, r, M, s, E, mu = 0, H = 0, Z = 4;
            int size = 51, nsweeps = 5;
            int[,] spinsystem = new int[size, size];

            //Prepare Graphical setup
            Graphics gg = this.CreateGraphics();
            Random obj = new Random();
            SolidBrush bb = new SolidBrush(Color.Blue);
            SolidBrush br = new SolidBrush(Color.White);
            SolidBrush brr = new SolidBrush(Color.Red);
            Pen pb = new Pen(Color.Blue);
            Font f = new Font("Arial", 16);

            //Initialize the spin system
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Let the material is magnetized fully at the start
                    //at low temp
                    spinsystem[i, j] = +1;//all are spin up
                                          //show the spins, blue for spin up and red for spin down
                    gg.FillEllipse(bb, 50 + i * 10, 100 + j * 10, 5, 5);
                }

            }//end initialization

            /*Start to study 2nd order phase
                 transition (when H=constant, here H=0)*/

            for (double T = 0.001; T < 5; T = T + 0.01)
            {
                for (int sw = 0; sw < nsweeps; sw++)
                {
                    for (int i = 1; i < size - 1; i++)
                    {
                        for (int j = 1; j < size - 1; j++)
                        {
                            //Calculate Energy before flipping
                            E1 = -spinsystem[i, j] * (spinsystem[i - 1, j]
                                  + spinsystem[i + 1, j] + spinsystem[i, j - 1]
                                  + spinsystem[i, j + 1]);
                            //assumingly flip
                            spinsystem[i, j] = spinsystem[i, j] * -1;
                            //Calculate Energy after flipping
                            // double E2 = CalEnergy(arr, i, j);
                            //double E1 = CalEnergy(arr,i,j);
                            E2 = -spinsystem[i, j] * (spinsystem[i - 1, j]
                              + spinsystem[i + 1, j] + spinsystem[i, j - 1]
                                   + spinsystem[i, j + 1]);
                            delE = E2 - E1;
                            if (delE > 0)
                            {
                                Pflip = Math.Exp(-delE / (1 * T));
                                r = obj.NextDouble();
                                if (Pflip >= r)//accept the flipping
                                {
                                    if (spinsystem[i, j] == 1)
                                    {
                                        gg.FillEllipse(bb, 50 + i * 10, 100 + j * 10, 5, 5);
                                    }
                                    else
                                    {
                                        gg.FillEllipse(br, 50 + i * 10, 100 + j * 10, 5, 5);
                                    }
                                }
                                else
                                //reject the flipping
                                {
                                    spinsystem[i, j] = spinsystem[i, j] * -1;
                                }
                            }
                            else

                            //when delE<0, accept the flipping
                            {
                                if (spinsystem[i, j] == 1)
                                {
                                    gg.FillEllipse(bb, 50 + i * 10, 100 + j * 10, 5, 5);
                                }
                                else
                                {
                                    gg.FillEllipse(br, 50 + i * 10, 100 + j * 10, 5, 5);

                                }
                            }
                        }
                    }
                }

                //calculate thermal average spin
                //calculate thermal average energy
                E = 0; M = 0;
                for (int i = 1; i < size - 1; i++)
                {
                    for (int j = 1; j < size - 1; j++)
                    {
                        //M = M + spinsystem[i,j];
                        E = E - spinsystem[i, j] * (spinsystem[i - 1, j]
                        + spinsystem[i + 1, j] + spinsystem[i, j - 1]
                         + spinsystem[i, j + 1]);
                    }
                }

                //s = M / (size * size - 4 * size + 4);
                E = E / (size * size - 4 * size + 4) / 2;
                // gg.FillEllipse(bb, 750 + (float)T * 50,  200- (float)s * 80, 5, 5);
                gg.FillEllipse(bb, 600 + (float)T * 100, 300 - (float)E * 150, 5, 5);

                //      for (double sp = -1.1; sp < 1.1; sp = sp + 0.01)
                //      {
                //          if(Math.Abs(sp-Math.Tanh(Z*sp/(T)))<0.01)
                //gg.FillEllipse(brr, 750 + (float)T * 50, 200 - (float)sp * 80, 5, 5);

                //      }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double E1, E2, delE, Pflip, r, M, s, E, mu = 0, H = 0, Z = 4;
            int size = 51, nsweeps = 5;
            int[,] spinsystem = new int[size, size];

            //Prepare Graphical setup
            Graphics gg = this.CreateGraphics();
            Random obj = new Random();
            SolidBrush bb = new SolidBrush(Color.Blue);
            SolidBrush br = new SolidBrush(Color.White);
            SolidBrush brr = new SolidBrush(Color.Red);
            Pen pb = new Pen(Color.Blue);
            Font f = new Font("Arial", 16);

            //Initialize the spin system
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Let the material is magnetized fully at the start
                    //at low temp
                    spinsystem[i, j] = +1;//all are spin up
                                          //show the spins, blue for spin up and red for spin down
                    gg.FillEllipse(bb, 50 + i * 10, 100 + j * 10, 5, 5);
                }

            }//end initialization

            /*Start to study 2nd order phase
                 transition (when H=constant, here H=0)*/

            for (double T = 0.001; T < 5; T = T + 0.01)
            {
                for (int sw = 0; sw < nsweeps; sw++)
                {
                    for (int i = 1; i < size - 1; i++)
                    {
                        for (int j = 1; j < size - 1; j++)
                        {
                            //Calculate Energy before flipping
                            E1 = -spinsystem[i, j] * (spinsystem[i - 1, j]
                                  + spinsystem[i + 1, j] + spinsystem[i, j - 1]
                                  + spinsystem[i, j + 1]);
                            //assumingly flip
                            spinsystem[i, j] = spinsystem[i, j] * -1;
                            //Calculate Energy after flipping
                            // double E2 = CalEnergy(arr, i, j);
                            //double E1 = CalEnergy(arr,i,j);
                            E2 = -spinsystem[i, j] * (spinsystem[i - 1, j]
                              + spinsystem[i + 1, j] + spinsystem[i, j - 1]
                                   + spinsystem[i, j + 1]);
                            delE = E2 - E1;
                            if (delE > 0)
                            {
                                Pflip = Math.Exp(-delE / (1 * T));
                                r = obj.NextDouble();
                                if (Pflip >= r)//accept the flipping
                                {
                                    if (spinsystem[i, j] == 1)
                                    {
                                        gg.FillEllipse(bb, 50 + i * 10, 100 + j * 10, 5, 5);
                                    }
                                    else
                                    {
                                        gg.FillEllipse(br, 50 + i * 10, 100 + j * 10, 5, 5);
                                    }
                                }
                                else
                                //reject the flipping
                                {
                                    spinsystem[i, j] = spinsystem[i, j] * -1;
                                }
                            }
                            else

                            //when delE<0, accept the flipping
                            {
                                if (spinsystem[i, j] == 1)
                                {
                                    gg.FillEllipse(bb, 50 + i * 10, 100 + j * 10, 5, 5);
                                }
                                else
                                {
                                    gg.FillEllipse(br, 50 + i * 10, 100 + j * 10, 5, 5);

                                }
                            }
                        }
                    }
                }

                //calculate thermal average spin
                //calculate thermal average energy
                E = 0; M = 0;
                for (int i = 1; i < size - 1; i++)
                {
                    for (int j = 1; j < size - 1; j++)
                    {
                        M = M + spinsystem[i,j];
                        //E = E - spinsystem[i, j] * (spinsystem[i - 1, j]
                        //+ spinsystem[i + 1, j] + spinsystem[i, j - 1]
                        // + spinsystem[i, j + 1]);
                    }
                }

                s = M / (size * size - 4 * size + 4);
                //E = E / (size * size - 4 * size + 4) / 2;
                gg.FillEllipse(bb, 600 + (float)T * 50,  300- (float)s * 80, 5, 5);
                //gg.FillEllipse(bb, 600 + (float)T * 100, 300 - (float)E * 150, 5, 5);

                for (double sp = -1.1; sp < 1.1; sp = sp + 0.01)
                {
                    if (Math.Abs(sp - Math.Tanh(Z * sp / (T))) < 0.01)
                    {
                        gg.FillEllipse(brr, 600 + (float)T * 50, 300 - (float)sp * 80, 5, 5);
                    }
                }
            }
        }
    }
}

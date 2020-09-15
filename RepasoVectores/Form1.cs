using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoVectores
{
    public partial class Form1 : Form
    {
        Random aleatorio = new Random();
        int[] vector1 = new int[50];
        int[] vector2 = new int[50];

        public Form1()  
        {
            InitializeComponent();
        }

        private void BtnEjerc1_Click(object sender, EventArgs e)
        {
            lbEjerc1.Items.Clear();
            for (int i = 0; i < vector1.Length; i++)
            {
                vector1[i] = aleatorio.Next(100);
                lbEjerc1.Items.Add(vector1[i]);
            }
            
            // Limpieza de campos y activación de botones  
                     
            btnEjerc2.Enabled = true;
            lbEjerc2.Items.Clear();
            btnEjerc3.Enabled = true;
            lbEjerc3.Items.Clear();
            btnEjerc4.Enabled = true;
            lbEjerc4.Items.Clear();
            btnEjerc5.Enabled = true;
            lbEjerc5.Items.Clear();
            btnEjerc6.Enabled = true;
            textBoxEjerc6.Clear();
            lbEjerc6.Items.Clear();
            btnEjerc7.Enabled = true;
            lbEjerc7.Items.Clear();
            btnEjerc8.Enabled = true;
            lbEjerc8.Items.Clear();
        }

        private void BtnEjerc2_Click(object sender, EventArgs e)
        {
            lbEjerc2.Items.Clear();
            int mayor = 0,
                menor = 100;
            
            for (int i = 0; i < vector1.Length; i++)
            {
                mayor = (vector1[i] > mayor) ? vector1[i] : mayor;
                menor = (vector1[i] < menor) ? vector1[i] : menor;
            }
            lbEjerc2.Items.Add("El mayor es " + mayor);
            lbEjerc2.Items.Add("El menor es " + menor);
        }

        private void BtnEjerc3_Click(object sender, EventArgs e)
        {
            lbEjerc3.Items.Clear();
            lbEjerc3.Items.Add("Contenido 20: " + vector1[20]);
            lbEjerc3.Items.Add("Contenido 30: " + vector1[30]);
        }

        private void BtnEjerc4_Click(object sender, EventArgs e)
        {
            lbEjerc4.Items.Clear();
            float suma = 0f;
            for (int i = 0; i < vector1.Length; i++)
            {
                suma += vector1[i];
            }
            lbEjerc4.Items.Add("La media es: " + suma / vector1.Length);
        }

        /*
         * Método para mostrar los números de un vector (parámetro) como
         * elementos de un List Box (parámetro)
         */ 
        private void mostrarVector(int[] vNum, ListBox lb)
        {
            for (int i = 0; i < vNum.Length; i++)
            {
                lb.Items.Add(vNum[i]);
            }
        }

        private void BtnEjerc5_Click(object sender, EventArgs e)
        {
            lbEjerc5.Items.Clear();
            int aux;
            for (int i = 0; i < vector1.Length - 1; i++)
            {
                for (int j = 0; j < vector1.Length - 1; j++)
                {
                    if (vector1[j] > vector1[j + 1])
                    {
                        aux = vector1[j];
                        vector1[j] = vector1[j + 1];
                        vector1[j + 1] = aux;
                    }
                }
            }
            mostrarVector(vector1, lbEjerc5);
        }

        private void BtnEjerc6_Click(object sender, EventArgs e)
        {
            lbEjerc6.Items.Clear();

            /*
                The TryParse method is like the Parse method, except the TryParse method does not 
                throw an exception if the conversion fails. It eliminates the need to use exception 
                handling to test for a FormatException in the event that the string parameter is 
                invalid and cannot be successfully parsed.
            */

            //int num = 0;
            //Int32.TryParse(textBoxEjerc6.Text, out num);

            int num, cont = 0;
            try
            {
                num = Int16.Parse(textBoxEjerc6.Text);
                for (int i = 0; i < vector1.Length; i++)
                {
                    if (vector1[i] == num)
                    {
                        cont++;
                    }
                }
                lbEjerc6.Items.Add("Mi número: " + num);
                lbEjerc6.Items.Add("Aparece: " + cont);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                lbEjerc6.Items.Add("Escriba un número");
            }
        }

        private void BtnEjerc7_Click(object sender, EventArgs e)
        {
            lbEjerc7.Items.Clear();
            int aux;
            for (int i = 0; i < vector1.Length / 2; i++)
            {
                aux = vector1[i];
                vector1[i] = vector1[(vector1.LongLength - 1) - i];
                vector1[(vector1.LongLength - 1) - i] = aux;
            }
            mostrarVector(vector1, lbEjerc7);
        }

        private void BtnEjerc8_Click(object sender, EventArgs e)
        {
            lbEjerc8.Items.Clear();
            for (int i = 0; i < vector1.Length; i++)
            {
                if (vector1[i] != -1)
                {
                    for (int j = i + 1; j < vector1.Length; j++)
                    {
                        vector1[j] = (vector1[j] == vector1[i]) ? -1 : vector1[j];
                    }
                }               
            }
            mostrarVector(vector1, lbEjerc8);
        }

        /*
         * Método que itera sobre los elementos de un vector numérico (parámetro) anteriores 
         * a una posición límite (parámetro) en busca de un número repetido (parámetro) 
         * devolviendo true si lo encuentra y false si no. 
         */
        private bool EsRepe(int[] vNum, int limite, int num)
        {
            int i = 0;
            bool repetido = false;
            while (!repetido && i < limite)
            {
                repetido = (vNum[i] == num);
                i++; 
            }
            return repetido;
        }

        private void BtnEjerc9_Click(object sender, EventArgs e)
        {
            lbEjerc9.Items.Clear();
            int num;
            for (int i = 0; i < vector2.Length; i++)
            {
                do
                {
                    num = aleatorio.Next(1, 101);
                } while (EsRepe(vector2, i, num));
                vector2[i] = num;
                lbEjerc9.Items.Add(vector2[i]);
            }

            // Limpieza de campos y activación de botones

            btnEjerc10.Enabled = true;
            lbEjerc10.Items.Clear();
            btnEjerc11.Enabled = true;
            lbEjerc11.Items.Clear();
            btnEjerc12.Enabled = true;
            textBoxEjerc12.Clear();
            lbEjerc12.Items.Clear();
            btnEjerc13.Enabled = true;
            textBoxEjerc13.Clear();
            lbEjerc13.Items.Clear();
        }

        private void BtnEjerc10_Click(object sender, EventArgs e)
        {
            lbEjerc10.Items.Clear();
            int mayor25 = 0,
                menor25 = 0;
            for (int i = 0; i < vector2.Length; i++)
            {
                if (vector2[i] >= 25)
                {
                    mayor25++;
                } else
                {
                    menor25++;
                }
            }
            lbEjerc10.Items.Add("Mayor (25): " + mayor25);
            lbEjerc10.Items.Add("Menor (25): " + menor25);
        }

        private void BtnEjerc11_Click(object sender, EventArgs e)
        {
            lbEjerc11.Items.Clear();
            int aux;
            for (int i = 0; i < vector2.Length - 1; i++)
            {
                for (int j = 0; j < vector2.Length - 1; j++)
                {
                    if (vector2[j] < vector2[j + 1])
                    {
                        aux = vector2[j];
                        vector2[j] = vector2[j + 1];
                        vector2[j + 1] = aux;
                    }
                }
            }
            mostrarVector(vector2, lbEjerc11);
        }

        /*
         * Método que devuelve el índice que ocupa un número (parámetro) en vector numérico 
         * (parámetro) o bien -1 si no hay coincidencia.
         */
        private int GetIndexNum(int[] vNum, int num)
        {
            int i = 0,
                index = -1;
            bool encontrado = false;
            while (!encontrado && i < vector2.Length)
            {
                if (vector2[i] == num)
                {
                    encontrado = true;
                    index = i;
                }              
                i++;
            }
            return index;
        }

        private void BtnEjerc12_Click(object sender, EventArgs e)
        {
            lbEjerc12.Items.Clear();
            int num, index, nuevo;
            try
            {
                num = Int16.Parse(textBoxEjerc12.Text);
                index = GetIndexNum(vector2, num);
                if (index == -1)
                {
                    lbEjerc12.Items.Add("Valor no contenido");
                } else
                {
                    do
                    {
                        nuevo = aleatorio.Next(100);
                    } while (GetIndexNum(vector2, nuevo) != -1);
                    vector2[index] = nuevo;
                    mostrarVector(vector2, lbEjerc12);                  
                }              
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                lbEjerc12.Items.Add("Escriba un número");
            }
        }

        private void BtnEjerc13_Click(object sender, EventArgs e)
        {
            lbEjerc13.Items.Clear();
            int num;
            int mayorNum = 0;
            int menorNum = 0;
            try
            {
                num = Int16.Parse(textBoxEjerc13.Text);                
                for (int i = 0; i < vector2.Length; i++)
                {
                    if (vector2[i] >= num)
                    {
                        mayorNum++;
                    }
                    else
                    {
                        menorNum++;
                    }
                }
                lbEjerc13.Items.Add("Mayor (" + num + "): " + mayorNum);
                lbEjerc13.Items.Add("Menor (" + num + "): " + menorNum);

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                lbEjerc13.Items.Add("Escriba un número");
            }
        }
    }
}

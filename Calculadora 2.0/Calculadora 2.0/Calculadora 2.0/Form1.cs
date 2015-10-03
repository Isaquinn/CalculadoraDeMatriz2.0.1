using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace Calculadora_2._0
{
    public partial class  Form1 : Form
    {
        int batata = 0;
        int adicionar = 0;
        TextBox[,] matriz;
        TextBox[,] matriz2;
        TextBox[,] matrizextra;
        TextBox[,] matrizextra2;
        TextBox[,] resultante;
        Graphics cartesiano;
        Graphics malhaquadriculada;
        int grid;
        int linhas, colunas, linhas2, colunas2;
        public Form1()
        {
            //groupBox3.Enabled = false;
            InitializeComponent();
            button12.Visible = false;
            
            textBox5.Visible = false;
            cartesiano = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            groupBox5.Visible = false;

           
          //cartesiano.DrawLine(pen, 20, 10, 300, 100);
            textBox1.Visible = false;
            label11.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label12.Visible = false;
            button7.Visible = false;
            radioButton3.Visible = false;
            textBox3.Visible = false;
            label13.Visible = false;
            button8.Visible = false;
            textBox3.Visible = false;
            label13.Visible = false;
            textBox4.Visible = false;
            label14.Visible = false;
            button9.Visible = false;


        }
    
       
     

        private void button1_Click(object sender, EventArgs e)
        {
           
            groupBox1.Controls.Clear();
            /*if (textBox1.Text == "0" || textBox1.Text == "" || textBox2.Text == "0" || textBox2.Text == "")
            {
                return;
            }*/
            if (comboBox1.SelectedItem == null && comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione o número de linhas e de colunas ");
                return;
            }
            if(comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione o número de linhas e de colunas ");
                return;
            }
            linhas = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            colunas = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            int TamanhoText = groupBox1.Width / colunas;
            if (linhas > 10 || colunas > 10)
            {
                return;
            }

            matriz = new TextBox[linhas, colunas];

            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    matriz[x, y] = new TextBox();
                    matriz[x, y].Text = "0";
                    matriz[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    matriz[x, y].TextAlign = HorizontalAlignment.Center;
                    matriz[x, y].Top = (x * matriz[x, y].Height) + 20;
                    matriz[x, y].Left = y * TamanhoText;
                    matriz[x, y].Width = TamanhoText;
                    groupBox1.Controls.Add(matriz[x, y]);




                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Controls.Clear();
            /*if (textBox1.Text == "0" || textBox1.Text == "" || textBox2.Text == "0" || textBox2.Text == "")
            {
                return;
            }*/
            if (comboBox3.SelectedItem == null && comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione o número de linhas e de colunas ");
                return;
            }
            if (comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione o número de linhas e de colunas ");
                return;
            }
            linhas2 = Convert.ToInt32(comboBox3.SelectedItem.ToString());

            colunas2 = Convert.ToInt32(comboBox4.SelectedItem.ToString());

            int TamanhoText = groupBox2.Width / colunas2;
            if (linhas2 > 10 || colunas2 > 10)
            {
                return;
            }

            matriz2 = new TextBox[linhas2, colunas2];

            for (int x = 0; x < matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < matriz2.GetLength(1); y++)
                {
                    matriz2[x, y] = new TextBox();
                    matriz2[x, y].Text = "0";
                    matriz2[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    matriz2[x, y].TextAlign = HorizontalAlignment.Center;
                    matriz2[x, y].Top = (x * matriz2[x, y].Height) + 20;
                    matriz2[x, y].Left = y * TamanhoText;
                    matriz2[x, y].Width = TamanhoText;
                    groupBox2.Controls.Add(matriz2[x, y]);




                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Selecione alguma operação");
                return;
            }
            if (comboBox5.SelectedItem.ToString() == "Adição")
            {
                radioButton3.Visible = true;
                groupBox3.Enabled = true;
                if (groupBox1.Controls.Count == 0 || groupBox2.Controls.Count == 0)
                {
                    return;
                }
                float[,] tempMatriz1 = new float[matriz.GetLength(0), matriz.GetLength(1)];
                float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                {
                    MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                    return;
                }



                for (int x = 0; x < matriz.GetLength(0); x++)
                {

                    for (int y = 0; y < matriz.GetLength(1); y++)
                    {

                        float n = 0;
                        float.TryParse(matriz[x, y].Text, out n);
                        tempMatriz1[x, y] = n;


                    }
                }
                for (int x = 0; x < matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < matriz2.GetLength(1); y++)
                    {

                        float n = 0;
                        float.TryParse(matriz2[x, y].Text, out n);
                        tempMatriz2[x, y] = n;


                    }
                }
                
                float[,] tempMatrizResultante = Calculos.SomarMatrizes(tempMatriz1, tempMatriz2);
                resultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                int TamanhoText = groupBox3.Width / resultante.GetLength(1);
                groupBox3.Controls.Clear();
                for (int x = 0; x < resultante.GetLength(0); x++)
                {
                    for (int y = 0; y < resultante.GetLength(1); y++)
                    {
                        resultante[x, y] = new TextBox();
                        resultante[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                        resultante[x, y].TextAlign = HorizontalAlignment.Center;
                        resultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                        resultante[x, y].Top = (x * resultante[x, y].Height) + 20;
                        resultante[x, y].Left = y * TamanhoText;
                        resultante[x, y].Width = TamanhoText;
                        groupBox3.Controls.Add(resultante[x, y]);
                    }
                }

            }
            ////
            if (comboBox5.SelectedItem.ToString() == "Subtração")
            {
                radioButton3.Visible = true;
                groupBox3.Enabled = true;
                if (groupBox1.Controls.Count == 0 || groupBox2.Controls.Count == 0)
                {
                    return;
                }
                float[,] tempMatriz1 = new float[matriz.GetLength(0), matriz.GetLength(1)];
                float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                {
                    MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                    return;
                }



                for (int x = 0; x < matriz.GetLength(0); x++)
                {

                    for (int y = 0; y < matriz.GetLength(1); y++)
                    {

                        float n = 0;
                        float.TryParse(matriz[x, y].Text, out n);
                        tempMatriz1[x, y] = n;


                    }
                }
                for (int x = 0; x < matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < matriz2.GetLength(1); y++)
                    {

                        float n = 0;
                        float.TryParse(matriz2[x, y].Text, out n);
                        tempMatriz2[x, y] = n;


                    }
                }

                float[,] tempMatrizResultante = Calculos.SubtrairMatrizes(tempMatriz1, tempMatriz2);
                 resultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                int TamanhoText = groupBox3.Width / resultante.GetLength(1);
                groupBox3.Controls.Clear();
                for (int x = 0; x < resultante.GetLength(0); x++)
                {
                    for (int y = 0; y < resultante.GetLength(1); y++)
                    {
                        resultante[x, y] = new TextBox();
                        resultante[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                        resultante[x, y].TextAlign = HorizontalAlignment.Center;
                        resultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                        resultante[x, y].Top = (x * resultante[x, y].Height) + 20;
                        resultante[x, y].Left = y * TamanhoText;
                        resultante[x, y].Width = TamanhoText;
                        groupBox3.Controls.Add(resultante[x, y]);
                    }
                }

            }
            if (comboBox5.SelectedItem.ToString() == "Multiplicação")
            {
                radioButton3.Visible = true;
                groupBox3.Enabled = true;
                if (groupBox1.Controls.Count == 0 || groupBox2.Controls.Count == 0)
                {
                    return;
                }
                float[,] tempMatriz1 = new float[matriz.GetLength(0), matriz.GetLength(1)];
                float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];




                for (int x = 0; x < matriz.GetLength(0); x++)
                {

                    for (int y = 0; y < matriz.GetLength(1); y++)
                    {

                        float n = 0;
                        float.TryParse(matriz[x, y].Text, out n);
                        tempMatriz1[x, y] = n;


                    }
                }
                for (int x = 0; x < matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < matriz2.GetLength(1); y++)
                    {

                        float n = 0;
                        float.TryParse(matriz2[x, y].Text, out n);
                        tempMatriz2[x, y] = n;


                    }
                }

                float[,] tempMatrizResultante = Calculos.MultiplicarMatrizes(tempMatriz1, tempMatriz2);
                resultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                int TamanhoText = groupBox3.Width / resultante.GetLength(1);
                groupBox3.Controls.Clear();
                for (int x = 0; x < resultante.GetLength(0); x++)
                {
                    for (int y = 0; y < resultante.GetLength(1); y++)
                    {
                        resultante[x, y] = new TextBox();
                        resultante[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                        resultante[x, y].TextAlign = HorizontalAlignment.Center;
                        resultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                        resultante[x, y].Top = (x * resultante[x, y].Height) + 20;
                        resultante[x, y].Left = y * TamanhoText;
                        resultante[x, y].Width = TamanhoText;
                        groupBox3.Controls.Add(resultante[x, y]);
                    }
                }

            }

            //////////////////////////
            if (radioButton1.Checked == true)
            {
                ///MatirzFormula
                if (comboBox5.SelectedItem.ToString() == "GerarMatrizAtravésDeFormula")
                {

                    MessageBox.Show("Digite a formula na caixa que apareceu na parte de baixo da calculadora, com qual você quer que seja gerada   a matriz 1");
                    label14.Visible = true;
                    textBox4.Visible = true;
                    button9.Visible = true;



                }
                else if (comboBox5.SelectedItem.ToString() != "GerarMatrizAtravésDeFormula")
                {
                    label14.Visible = false;
                    textBox4.Visible = false;
                    button9.Visible = false;

                }
                ///Multiplicação por número real
                if (comboBox5.SelectedItem.ToString() == "Multiplicação Por Número Real") 
                {
                    if (matriz == null)
                    {
                        MessageBox.Show("Primeiro você deve gerar a matriz");
                        return;
                    }
                    MessageBox.Show("Digite o valor na caixa que apareceu abaixo da matriz 1, com qual você quer que seja multiplicado a matriz 1");
                    label11.Visible = true;
                    textBox1.Visible = true;
                    button6.Visible = true;
                   
                     

                }
                else if (comboBox5.SelectedItem.ToString() != "Multiplicação Por Número Real")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label11.Visible = false;
                    textBox1.Visible = false;
                    button6.Visible = false;
                    label12.Visible= false;
                    textBox2.Visible = false;
                    button7.Visible = false;
                    label13.Visible = false;
                    textBox3.Visible = false;
                    button8.Visible = false;
                
                }
                if (comboBox5.SelectedItem.ToString() == "Transposta")
                {
                    if (matriz == null)
                    {
                        MessageBox.Show("Primeiro você deve gerar a matriz");
                        return;
                    }
                    groupBox1.Controls.Clear();
                    float[,] tempMatriz1 = new float[matriz.GetLength(0), matriz.GetLength(1)];
                    //float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                    //if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                    /*{
                        MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                        return;
                    }*/



                    for (int x = 0; x < matriz.GetLength(0); x++)
                    {

                        for (int y = 0; y < matriz.GetLength(1); y++)
                        {

                            float n = 0;
                            float.TryParse(matriz[x, y].Text, out n);
                            tempMatriz1[x, y] = n;


                        }
                    }
                    /* for (int x = 0; x < matriz2.GetLength(0); x++)
                     {
                         for (int y = 0; y < matriz2.GetLength(1); y++)
                         {

                             float n = 0;
                             float.TryParse(matriz2[x, y].Text, out n);
                             tempMatriz2[x, y] = n;


                         }
                     }*/

                    float[,] tempMatrizResultante = Calculos.Transposta1(tempMatriz1);
                    matriz = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                    int TamanhoText = groupBox1.Width / matriz.GetLength(1);

                    for (int x = 0; x < matriz.GetLength(0); x++)
                    {
                        for (int y = 0; y < matriz.GetLength(1); y++)
                        {
                            matriz[x, y] = new TextBox();
                            matriz[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                            matriz[x, y].TextAlign = HorizontalAlignment.Center;
                            matriz[x, y].Text = tempMatrizResultante[x, y].ToString();
                            matriz[x, y].Top = (x * matriz[x, y].Height) + 20;
                            matriz[x, y].Left = y * TamanhoText;
                            matriz[x, y].Width = TamanhoText;
                            groupBox1.Controls.Add(matriz[x, y]);
                        }
                    }


                }
                if (comboBox5.SelectedItem.ToString() == "Oposta")
                {
                    groupBox1.Controls.Clear();
                    if (matriz == null)
                    {
                        MessageBox.Show("Primeiro você deve gerar a matriz");
                        return;
                    }
                    float[,] tempMatriz1 = new float[matriz.GetLength(0), matriz.GetLength(1)];
                    //float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                    //if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                    /*{
                        MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                        return;
                    }*/



                    for (int x = 0; x < matriz.GetLength(0); x++)
                    {

                        for (int y = 0; y < matriz.GetLength(1); y++)
                        {

                            float n = 0;
                            float.TryParse(matriz[x, y].Text, out n);
                            tempMatriz1[x, y] = n;


                        }
                    }
                    /* for (int x = 0; x < matriz2.GetLength(0); x++)
                     {
                         for (int y = 0; y < matriz2.GetLength(1); y++)
                         {

                             float n = 0;
                             float.TryParse(matriz2[x, y].Text, out n);
                             tempMatriz2[x, y] = n;


                         }
                     }*/

                    float[,] tempMatrizResultante = Calculos.Oposta(tempMatriz1);
                    matriz = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                    int TamanhoText = groupBox1.Width / matriz.GetLength(1);

                    for (int x = 0; x < matriz.GetLength(0); x++)
                    {
                        for (int y = 0; y < matriz.GetLength(1); y++)
                        {
                            matriz[x, y] = new TextBox();
                            matriz[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                            matriz[x, y].TextAlign = HorizontalAlignment.Center;
                            matriz[x, y].Text = tempMatrizResultante[x, y].ToString();
                            matriz[x, y].Top = (x * matriz[x, y].Height) + 20;
                            matriz[x, y].Left = y * TamanhoText;
                            matriz[x, y].Width = TamanhoText;
                            groupBox1.Controls.Add(matriz[x, y]);
                        }
                    }
                }
                string value;
                if (comboBox5.SelectedItem.ToString() == "Determinate")
                {
                    if (matriz == null)
                    {
                        MessageBox.Show("Primeiro você deve gerar a matriz");
                        return;
                    }

                    if (comboBox1.SelectedItem.ToString() != comboBox2.SelectedItem.ToString())
                    {
                        return;
                    }
                    else if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
                    {

                        //cria uma matriz e seta os valores para serem a da matriz que usaremos
                        double[,] MT = new double[(matriz.GetLength(0)), (matriz.GetLength(1))];
                        for (int i = 0; i < matriz.GetLength(0); i++)
                        {
                            for (int j = 0; j < matriz.GetLength(1); j++)
                            {
                                double n = 0;
                                double.TryParse(matriz[i, j].Text, out n);
                                MT[i, j] = n;
                                matriz[i, j].KeyPress += new KeyPressEventHandler(keypressed);
                            }
                        }
                        // escreve na caixa de texto o retorno da det
                        value = Calculos.DET(MT, int.Parse(comboBox2.SelectedItem.ToString())).ToString();
                        MessageBox.Show( value);
                    }

                  



                }
                if (comboBox5.SelectedItem.ToString() == "Inversa")
                {
                    if (matriz == null)
                    {
                        MessageBox.Show("Primeiro você deve gerar a matriz");
                        return;
                    }
                    double[,] MT = new double[(matriz.GetLength(0)), (matriz.GetLength(1))];
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            double n = 0;
                            double.TryParse(matriz[i, j].Text, out n);
                            matriz[i, j].KeyPress += new KeyPressEventHandler(keypressed);
                            MT[i, j] = n;
                        }
                    }
                    double det = Calculos.DET(MT, int.Parse(comboBox1.SelectedItem.ToString()));
                    if (det != 0)
                    {
                        // seta o tamanho da matriz do resultado
                   
                        
                       
                        // pega a inversa e coloca em cada caixa de texto
                        MT = Calculos.Invert(det, MT, int.Parse(comboBox1.SelectedItem.ToString()));
                        for (int i = 0; i < int.Parse(comboBox1.SelectedItem.ToString()); i++)
                        {
                            for (int j = 0; j < int.Parse(comboBox2.SelectedItem.ToString()); j++)
                            {
                                matriz[i, j].Text = MT[i, j].ToString();
                            }
                        }
                    }


                }
                }
               
                if (radioButton2.Checked == true)
                {

                    if (comboBox5.SelectedItem.ToString() == "Multiplicação Por Número Real")
                    {
                        if (matriz2 == null)
                        {
                            MessageBox.Show("Primeiro você deve gerar a matriz");
                            return;
                        }

                        MessageBox.Show("Digite o valor na caixa que apareceu abaixo da matriz 1, com qual você quer que seja multiplicado a matriz 1");
                        label12.Visible = true;
                        textBox2.Visible= true;
                        button7.Visible = true;



                    }
                    else if (comboBox5.SelectedItem.ToString() != "Multiplicação Por Número Real")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        label11.Visible = false;
                        textBox1.Visible = false;
                        button6.Visible = false;
                        label12.Visible = false;
                        textBox2.Visible = false;
                        button7.Visible = false;
                        label13.Visible = false;
                        textBox3.Visible = false;
                        button8.Visible = false;

                    }
                    if (comboBox5.SelectedItem.ToString() == "Transposta")
                    {
                        groupBox2.Controls.Clear();
                        if (matriz2 == null)
                        {
                            MessageBox.Show("Primeiro você deve gerar a matriz");
                            return;
                        }
                        float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                        //float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                        //if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                        /*{
                            MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                            return;
                        }*/



                        for (int x = 0; x < matriz2.GetLength(0); x++)
                        {

                            for (int y = 0; y < matriz2.GetLength(1); y++)
                            {

                                float n = 0;
                                float.TryParse(matriz2[x, y].Text, out n);
                                tempMatriz2[x, y] = n;


                            }
                        }
                        /* for (int x = 0; x < matriz2.GetLength(0); x++)
                         {
                             for (int y = 0; y < matriz2.GetLength(1); y++)
                             {

                                 float n = 0;
                                 float.TryParse(matriz2[x, y].Text, out n);
                                 tempMatriz2[x, y] = n;


                             }
                         }*/

                        float[,] tempMatrizResultante = Calculos.Transposta1(tempMatriz2);
                        matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                        int TamanhoText = groupBox2.Width /matriz2.GetLength(1);

                        for (int x = 0; x < matriz2.GetLength(0); x++)
                        {
                            for (int y = 0; y < matriz2.GetLength(1); y++)
                            {
                                matriz2[x, y] = new TextBox();
                                matriz2[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                                matriz2[x, y].TextAlign = HorizontalAlignment.Center;
                                matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                                matriz2[x, y].Top = (x * matriz2[x, y].Height) + 20;
                                matriz2[x, y].Left = y * TamanhoText;
                                matriz2[x, y].Width = TamanhoText;
                                groupBox2.Controls.Add(matriz2[x, y]);
                            }
                        }


                    }
                    if (comboBox5.SelectedItem.ToString() == "Oposta")
                    {
                        groupBox2.Controls.Clear();
               
                        
                        if(matriz2 == null)
                        {
                            MessageBox.Show("Primeiro você deve gerar a matriz");
                            return;
                        }
                        float[,] tempMatriz1 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                        //float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                        //if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                        /*{
                            MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                            return;
                        }*/



                        for (int x = 0; x < matriz2.GetLength(0); x++)
                        {

                            for (int y = 0; y < matriz2.GetLength(1); y++)
                            {

                                float n = 0;
                                float.TryParse(matriz2[x, y].Text, out n);
                                tempMatriz1[x, y] = n;


                            }
                        }
                        /* for (int x = 0; x < matriz2.GetLength(0); x++)
                         {
                             for (int y = 0; y < matriz2.GetLength(1); y++)
                             {

                                 float n = 0;
                                 float.TryParse(matriz2[x, y].Text, out n);
                                 tempMatriz2[x, y] = n;


                             }
                         }*/

                        float[,] tempMatrizResultante = Calculos.Oposta(tempMatriz1);
                        matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                        int TamanhoText = groupBox1.Width / matriz2.GetLength(1);

                        for (int x = 0; x < matriz2.GetLength(0); x++)
                        {
                            for (int y = 0; y < matriz2.GetLength(1); y++)
                            {
                                matriz2[x, y] = new TextBox();
                                matriz2[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                                matriz2[x, y].TextAlign = HorizontalAlignment.Center;
                                matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                                matriz2[x, y].Top = (x * matriz2[x, y].Height) + 20;
                                matriz2[x, y].Left = y * TamanhoText;
                                matriz2[x, y].Width = TamanhoText;
                                groupBox2.Controls.Add(matriz2[x, y]);
                            }
                        }
                    }



                    string value2;
                    if (comboBox5.SelectedItem.ToString() == "Determinate")
                    {
                        if (matriz2 == null)
                        {
                            MessageBox.Show("Primeiro você deve gerar a matriz");
                            return;
                        }

                        if (comboBox3.SelectedItem.ToString() != comboBox4.SelectedItem.ToString())
                        {
                            return;
                        }
                        else if (comboBox3.SelectedItem.ToString() == comboBox4.SelectedItem.ToString())
                        {

                            //cria uma matriz e seta os valores para serem a da matriz que usaremos
                            double[,] MT = new double[(matriz2.GetLength(0)), (matriz2.GetLength(1))];
                            for (int i = 0; i < matriz2.GetLength(0); i++)
                            {
                                for (int j = 0; j < matriz2.GetLength(1); j++)
                                {
                                    double n = 0;
                                    double.TryParse(matriz2[i, j].Text, out n);
                                    matriz2[i, j].KeyPress += new KeyPressEventHandler(keypressed);
                                    MT[i, j] = n;
                                }
                            }
                            // escreve na caixa de texto o retorno da det
                            value2 = Calculos.DET(MT, int.Parse(comboBox4.SelectedItem.ToString())).ToString();
                            MessageBox.Show(value2);
                        }



                    }

                }
            ////Calculos para matrizresultante
            if(radioButton3.Checked == true)
            {

               if (comboBox5.SelectedItem.ToString() == "Multiplicação Por Número Real")
                    {
                        if (resultante == null)
                        {
                            MessageBox.Show("Primeiro a matriz deve ser gerada");
                            return;
                        }

                        MessageBox.Show("Digite o valor na caixa que apareceu abaixo da matriz 1, com qual você quer que seja multiplicado a matriz 1");
                        label13.Visible = true;
                        textBox3.Visible = true;
                        button8.Visible = true;



                    }
                    else if (comboBox5.SelectedItem.ToString() != "Multiplicação Por Número Real")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        label11.Visible = false;
                        textBox1.Visible = false;
                        button6.Visible = false;
                        label12.Visible = false;
                        textBox2.Visible = false;
                        button7.Visible = false;
                        label13.Visible = false;
                        textBox3.Visible = false;
                        button8.Visible = false;

                    }
                    if (comboBox5.SelectedItem.ToString() == "Transposta")
                    {
                        groupBox3.Controls.Clear();
                        if (resultante == null)
                        {
                            MessageBox.Show("Primeiro a matriz deve ser gerada");
                            return;
                        }
                        float[,] tempMatriz2 = new float[resultante.GetLength(0), resultante.GetLength(1)];
                        //float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                        //if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                        /*{
                            MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                            return;
                        }*/



                        for (int x = 0; x < resultante.GetLength(0); x++)
                        {

                            for (int y = 0; y < resultante.GetLength(1); y++)
                            {

                                float n = 0;
                                float.TryParse(resultante[x, y].Text, out n);
                                tempMatriz2[x, y] = n;


                            }
                        }
                        /* for (int x = 0; x < matriz2.GetLength(0); x++)
                         {
                             for (int y = 0; y < matriz2.GetLength(1); y++)
                             {

                                 float n = 0;
                                 float.TryParse(matriz2[x, y].Text, out n);
                                 tempMatriz2[x, y] = n;


                             }
                         }*/

                        float[,] tempMatrizResultante = Calculos.Transposta1(tempMatriz2);
                        resultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                        int TamanhoText = groupBox3.Width / resultante.GetLength(1);

                        for (int x = 0; x < resultante.GetLength(0); x++)
                        {
                            for (int y = 0; y < resultante.GetLength(1); y++)
                            {
                                resultante[x, y] = new TextBox();
                                resultante[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                                resultante[x, y].TextAlign = HorizontalAlignment.Center;
                                resultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                                resultante[x, y].Top = (x * resultante[x, y].Height) + 20;
                                resultante[x, y].Left = y * TamanhoText;
                                resultante[x, y].Width = TamanhoText;
                                groupBox3.Controls.Add(resultante[x, y]);
                            }
                        }


                    }
                    if (comboBox5.SelectedItem.ToString() == "Oposta")
                    {
                        groupBox3.Controls.Clear();
                        if (resultante == null)
                        {
                            MessageBox.Show("Primeiro a matriz deve ser gerada");
                            return;
                        }
                        float[,] tempMatriz1 = new float[resultante.GetLength(0), resultante.GetLength(1)];
                        //float[,] tempMatriz2 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                        //if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                        /*{
                            MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                            return;
                        }*/



                        for (int x = 0; x < resultante.GetLength(0); x++)
                        {

                            for (int y = 0; y < resultante.GetLength(1); y++)
                            {

                                float n = 0;
                                float.TryParse(resultante[x, y].Text, out n);
                                tempMatriz1[x, y] = n;


                            }
                        }
                        /* for (int x = 0; x < matriz2.GetLength(0); x++)
                         {
                             for (int y = 0; y < matriz2.GetLength(1); y++)
                             {

                                 float n = 0;
                                 float.TryParse(matriz2[x, y].Text, out n);
                                 tempMatriz2[x, y] = n;


                             }
                         }*/

                        float[,] tempMatrizResultante = Calculos.Oposta(tempMatriz1);
                        resultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                        int TamanhoText = groupBox3.Width / resultante.GetLength(1);

                        for (int x = 0; x < resultante.GetLength(0); x++)
                        {
                            for (int y = 0; y < resultante.GetLength(1); y++)
                            {
                                resultante[x, y] = new TextBox();
                                resultante[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                                resultante[x, y].TextAlign = HorizontalAlignment.Center;
                                resultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                                resultante[x, y].Top = (x * resultante[x, y].Height) + 20;
                                resultante[x, y].Left = y * TamanhoText;
                                resultante[x, y].Width = TamanhoText;
                                groupBox3.Controls.Add(resultante[x, y]);
                            }
                        }
                    }



                    string value2;
                    if (comboBox5.SelectedItem.ToString() == "Determinate")
                    {
                        if (resultante == null)
                        {
                            MessageBox.Show("Primeiro a matriz deve ser gerada");
                            return;
                        }

                      

                            //cria uma matriz e seta os valores para serem a da matriz que usaremos
                        double[,] MT = new double[(resultante.GetLength(0)), (resultante.GetLength(1))];
                        for (int i = 0; i < resultante.GetLength(0); i++)
                            {
                                for (int j = 0; j < resultante.GetLength(1); j++)
                                {
                                    double n = 0;
                                    double.TryParse(resultante[i, j].Text, out n);
                                    resultante[i, j].KeyPress += new KeyPressEventHandler(keypressed);
                                    MT[i, j] = n;
                                }
                            }
                            // escreve na caixa de texto o retorno da det
                            value2 = Calculos.DET(MT, int.Parse(comboBox4.SelectedItem.ToString())).ToString();
                            MessageBox.Show(value2);
                        



                    }
            }
            }
        
        int linhasDesenho;
        int colunasDesenho;
        TextBox[,] desenho;
        TextBox[,] matrizrotacao;
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            groupBox4.Controls.Clear();
            groupBox6.Controls.Clear();
            button12.Visible = false;
            g.Clear(Color.White);
            if(comboBox6.SelectedItem == null && comboBox7.SelectedItem == null)
            {
                MessageBox.Show("Selecione o número de linhas e colunas");
                return;
            }
            if (comboBox6.SelectedItem == null || comboBox7.SelectedItem == null)
            {
                MessageBox.Show("Selecione o número de linhas e colunas");
                return;
            }
            linhasDesenho = Convert.ToInt32(comboBox6.SelectedItem.ToString());

            colunasDesenho = Convert.ToInt32(comboBox7.SelectedItem.ToString());

            int TamanhoText = groupBox4.Width / colunasDesenho;
           

            desenho = new TextBox[linhasDesenho, colunasDesenho];

            for (int x = 0; x < desenho.GetLength(0); x++)
            {
                for (int y = 0; y < desenho.GetLength(1); y++)
                {
                    desenho[x, y] = new TextBox();
                    desenho[x, y].Text = "0";
                    //matriz[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    desenho[x, y].TextAlign = HorizontalAlignment.Center;
                    desenho[x, y].Top = (x * desenho[x, y].Height) + 20;
                    desenho[x, y].Left = y * TamanhoText;
                    desenho[x, y].Width = TamanhoText;
                    groupBox4.Controls.Add(desenho[x, y]);




                }
            }
            
            groupBox2.Controls.Clear();
            linhas2 = 2;
            colunas2 = 2;
            int TamanhoText2 = groupBox5.Width / colunas2;


            matrizrotacao = new TextBox[linhas2, colunas2];
            for (int x = 0; x < matrizrotacao.GetLength(0); x++)
            {

                for (int y = 0; y < matrizrotacao.GetLength(1); y++)
                {
                    matrizrotacao[x, y] = new TextBox();
                    matrizrotacao[x, y].Text = "0";
                    matrizrotacao[x, y].TextAlign = HorizontalAlignment.Center;
                    matrizrotacao[x, y].Top = (x * matrizrotacao[x, y].Height) + 20;
                    matrizrotacao[x, y].Left = y * TamanhoText2;
                    matrizrotacao[x, y].Width = TamanhoText2;
                    groupBox5.Controls.Add(matrizrotacao[x, y]);
                }
            }

        }

        Point[] pontos;
        private void button5_Click(object sender, EventArgs e)
        {
          
            if(desenho == null)
            {
                MessageBox.Show("Primeiro crier a matriz e escreva seus pontos");
                return;
            
            }
            batata += 1;
          
          

                            Pen blackPen = new Pen(Color.Red, 1);
                            
                            

                            pontos = new Point[desenho.GetLength(1)];
                            List<Point> point2 = new List<Point>();
                            //pontos = new Point(x, y);
                            for (int i = 0; i < desenho.GetLength(1); i++) 
                            {


                                pontos[i] = new Point(Convert.ToInt32(desenho[0, i].Text) , -Convert.ToInt32(desenho[1, i].Text ) );
                                pontos[i].X += pictureBox1.Width / 2;
                                pontos[i].Y += pictureBox1.Height /2;
                                                  
                                //g.DrawPolygon(blackPen, pontos);

                                //MessageBox.Show("allahu akbar :" + desenho[0, i].Text + ", " + desenho[1, i].Text);
                            }
                           
                            Graphics g = pictureBox1.CreateGraphics();
                            g.Clear(Color.White);
                            g.DrawPolygon(blackPen, pontos);
                           
                            
                            

                            


                           
                           
                
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Calculos.number = Convert.ToInt32(textBox1.Text);


            groupBox1.Controls.Clear();
            float[,] tempMatriz1 = new float[matriz.GetLength(0), matriz.GetLength(1)];

            for (int x = 0; x < matriz.GetLength(0); x++)
            {

                for (int y = 0; y < matriz.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(matriz[x, y].Text, out n);
                    tempMatriz1[x, y] = n;


                }
            }


            float[,] tempMatrizResultante = Calculos.NumeroReal(tempMatriz1);
            matriz = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBox1.Width / matriz.GetLength(1);

            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    matriz[x, y] = new TextBox();
                    matriz[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    matriz[x, y].TextAlign = HorizontalAlignment.Center;
                    matriz[x, y].Text = tempMatrizResultante[x, y].ToString();
                    matriz[x, y].Top = (x * matriz[x, y].Height) + 20;
                    matriz[x, y].Left = y * TamanhoText;
                    matriz[x, y].Width = TamanhoText;
                    groupBox1.Controls.Add(matriz[x, y]);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Calculos.number = Convert.ToInt32(textBox2.Text);


            groupBox2.Controls.Clear();
            float[,] tempMatriz1 = new float[matriz2.GetLength(0), matriz2.GetLength(1)];

            for (int x = 0; x < matriz2.GetLength(0); x++)
            {

                for (int y = 0; y < matriz2.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(matriz2[x, y].Text, out n);
                    tempMatriz1[x, y] = n;


                }
            }


            float[,] tempMatrizResultante = Calculos.NumeroReal(tempMatriz1);
            matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBox2.Width / matriz2.GetLength(1);

            for (int x = 0; x < matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < matriz2.GetLength(1); y++)
                {
                    matriz2[x, y] = new TextBox();
                    matriz2[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    matriz2[x, y].TextAlign = HorizontalAlignment.Center;
                    matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    matriz2[x, y].Top = (x * matriz2[x, y].Height) + 20;
                    matriz2[x, y].Left = y * TamanhoText;
                    matriz2[x, y].Width = TamanhoText;
                    groupBox2.Controls.Add(matriz2[x, y]);
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Calculos.number = Convert.ToInt32(textBox3.Text);


            groupBox3.Controls.Clear();
            float[,] tempMatriz1 = new float[resultante.GetLength(0), resultante.GetLength(1)];

            for (int x = 0; x < resultante.GetLength(0); x++)
            {

                for (int y = 0; y < resultante.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(resultante[x, y].Text, out n);
                    tempMatriz1[x, y] = n;


                }
            }


            float[,] tempMatrizResultante = Calculos.NumeroReal(tempMatriz1);
            resultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBox3.Width / resultante.GetLength(1);

            for (int x = 0; x < resultante.GetLength(0); x++)
            {
                for (int y = 0; y < resultante.GetLength(1); y++)
                {
                    resultante[x, y] = new TextBox();
                    resultante[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    resultante[x, y].TextAlign = HorizontalAlignment.Center;
                    resultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    resultante[x, y].Top = (x * resultante[x, y].Height) + 20;
                    resultante[x, y].Left = y * TamanhoText;
                    resultante[x, y].Width = TamanhoText;
                    groupBox3.Controls.Add(resultante[x, y]);
                }
            }
        }
        //Função para bloquear certos caracteres na matriz
        private void keypressed(Object o, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                if (matriz == null)
                {
                    return;
                }


                adicionar += 1;
                if (adicionar == 1)
                {
                    button9.Text = "Resultado Da Equação";
                    float[,] tempResultante = new float[matriz.GetLength(0), matriz.GetLength(1)];
                    for (int x = 0; x < matriz.GetLength(0); x++)
                    {

                        for (int y = 0; y < matriz.GetLength(1); y++)
                        {
                            textBox4.Text.Replace("i", x.ToString());
                            textBox5.Text = textBox4.Text.Replace("j", y.ToString()).Replace("i", x.ToString());
                            float n = 0;
                            float.TryParse(matriz[x, y].Text, out n);
                            tempResultante[x, y] = n;
                            //textBox10.Text = textBox8.Text.Replace("i", x.ToString());

                            //matriz[x, y].Text = "";
                            matriz[x, y].Text = textBox5.Text;



                            //tempResultante[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                        }
                    }


                    String expressao = textBox5.Text;
                    expressao = expressao.Replace('{', '(');
                    expressao = expressao.Replace('}', ')');
                    expressao = expressao.Replace('[', '(');
                    expressao = expressao.Replace(']', ')');
                    String classeMetodo = String.Format("public static class Func{{ public static int func(){{ return {0};}}}}", expressao);
                    CompilerParameters param = new CompilerParameters();
                    param.GenerateExecutable = false;
                    param.GenerateInMemory = true;
                    param.IncludeDebugInformation = false;
                    CodeDomProvider provider = CSharpCodeProvider.CreateProvider("CSharp");
                    CompilerResults preAssembly = provider.CompileAssemblyFromSource(param, classeMetodo);
                    if (preAssembly.Errors.HasErrors)
                    {
                        Console.WriteLine("Erro na expressão!");
                    }
                    else
                    {
                        Assembly assembly = preAssembly.CompiledAssembly;
                        var resultado = assembly.GetType("Func").GetMethod("func").Invoke(null, null);
                        //textBox9.Text = (String.Format("{0}  {1}", "", resultado));
                       // haha = (String.Format("{0}  {1}", "", resultado));
                        // textBox10.Text = (String.Format("{0}  {1}", "", resultado));


                    }






                }
                if (adicionar == 2)
                {
                    button9.Text = "Gerar E Mostrar A Equação Da Matriz1";
                    float[,] tempResultante = new float[matriz.GetLength(0), matriz.GetLength(1)];
                    for (int x = 0; x < matriz.GetLength(0); x++)
                    {

                        for (int y = 0; y < matriz.GetLength(1); y++)
                        {
                            String expressao = matriz[x, y].Text;
                            expressao = expressao.Replace('{', '(');
                            expressao = expressao.Replace('}', ')');
                            expressao = expressao.Replace('[', '(');
                            expressao = expressao.Replace(']', ')');
                            String classeMetodo = String.Format("public static class Func{{ public static int func(){{ return {0};}}}}", expressao);
                            CompilerParameters param = new CompilerParameters();
                            param.GenerateExecutable = false;
                            param.GenerateInMemory = true;
                            param.IncludeDebugInformation = false;
                            CodeDomProvider provider = CSharpCodeProvider.CreateProvider("CSharp");
                            CompilerResults preAssembly = provider.CompileAssemblyFromSource(param, classeMetodo);
                            if (preAssembly.Errors.HasErrors)
                            {
                                Console.WriteLine("Erro na expressão!");
                            }
                            else
                            {
                                Assembly assembly = preAssembly.CompiledAssembly;
                                var resultado = assembly.GetType("Func").GetMethod("func").Invoke(null, null);

                                matriz[x, y].Text = (String.Format("{0}  {1}", "", resultado));



                            }

                            textBox5.Text = textBox4.Text.Replace("j", y.ToString()).Replace("i", x.ToString());
                            float n = 0;
                            float.TryParse(matriz[x, y].Text, out n);
                            tempResultante[x, y] = n;

                        }
                    }
                    adicionar = 0;




                }
            
            }
            if (radioButton2.Checked == true)
            {
                if (matriz2 == null)
                {
                    return;
                }


                adicionar += 1;
                if (adicionar == 1)
                {
                    button9.Text = "Resultado Da Equação";
                    float[,] tempResultante = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                    for (int x = 0; x < matriz2.GetLength(0); x++)
                    {

                        for (int y = 0; y < matriz2.GetLength(1); y++)
                        {
                            textBox4.Text.Replace("i", x.ToString());
                            textBox5.Text = textBox4.Text.Replace("j", y.ToString()).Replace("i", x.ToString());
                            float n = 0;
                            float.TryParse(matriz2[x, y].Text, out n);
                            tempResultante[x, y] = n;
                            //textBox10.Text = textBox8.Text.Replace("i", x.ToString());

                            //matriz[x, y].Text = "";
                            matriz2[x, y].Text = textBox5.Text;



                            //tempResultante[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                        }
                    }


                    String expressao = textBox5.Text;
                    expressao = expressao.Replace('{', '(');
                    expressao = expressao.Replace('}', ')');
                    expressao = expressao.Replace('[', '(');
                    expressao = expressao.Replace(']', ')');
                    String classeMetodo = String.Format("public static class Func{{ public static int func(){{ return {0};}}}}", expressao);
                    CompilerParameters param = new CompilerParameters();
                    param.GenerateExecutable = false;
                    param.GenerateInMemory = true;
                    param.IncludeDebugInformation = false;
                    CodeDomProvider provider = CSharpCodeProvider.CreateProvider("CSharp");
                    CompilerResults preAssembly = provider.CompileAssemblyFromSource(param, classeMetodo);
                    if (preAssembly.Errors.HasErrors)
                    {
                        Console.WriteLine("Erro na expressão!");
                    }
                    else
                    {
                        Assembly assembly = preAssembly.CompiledAssembly;
                        var resultado = assembly.GetType("Func").GetMethod("func").Invoke(null, null);
                        //textBox9.Text = (String.Format("{0}  {1}", "", resultado));
                        // haha = (String.Format("{0}  {1}", "", resultado));
                        // textBox10.Text = (String.Format("{0}  {1}", "", resultado));


                    }






                }
                if (adicionar == 2)
                {
                    button9.Text = "Gerar E Mostrar A Equação Da Matriz1";
                    float[,] tempResultante = new float[matriz2.GetLength(0), matriz2.GetLength(1)];
                    for (int x = 0; x < matriz2.GetLength(0); x++)
                    {

                        for (int y = 0; y < matriz2.GetLength(1); y++)
                        {
                            String expressao = matriz2[x, y].Text;
                            expressao = expressao.Replace('{', '(');
                            expressao = expressao.Replace('}', ')');
                            expressao = expressao.Replace('[', '(');
                            expressao = expressao.Replace(']', ')');
                            String classeMetodo = String.Format("public static class Func{{ public static int func(){{ return {0};}}}}", expressao);
                            CompilerParameters param = new CompilerParameters();
                            param.GenerateExecutable = false;
                            param.GenerateInMemory = true;
                            param.IncludeDebugInformation = false;
                            CodeDomProvider provider = CSharpCodeProvider.CreateProvider("CSharp");
                            CompilerResults preAssembly = provider.CompileAssemblyFromSource(param, classeMetodo);
                            if (preAssembly.Errors.HasErrors)
                            {
                                Console.WriteLine("Erro na expressão!");
                            }
                            else
                            {
                                Assembly assembly = preAssembly.CompiledAssembly;
                                var resultado = assembly.GetType("Func").GetMethod("func").Invoke(null, null);

                                matriz2[x, y].Text = (String.Format("{0}  {1}", "", resultado));



                            }

                            textBox5.Text = textBox4.Text.Replace("j", y.ToString()).Replace("i", x.ToString());
                            float n = 0;
                            float.TryParse(matriz2[x, y].Text, out n);
                            tempResultante[x, y] = n;

                        }
                    }
                    adicionar = 0;




                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //textBox6.Text = "Em matemática, uma matriz m X n é uma tabela de m linhas e n colunas de símbolos sobre um conjunto, normalmente um corpo, F, representada sob a forma de um quadro. As matrizes são muito utilizadas para a resolução de sistemas de equações lineares e transformações lineares.";
         
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
         
            if(desenho == null)
            {
                MessageBox.Show("Primeiro crie e desenhe a figura");

                return;
            }
            if(textBox7.Text == "")
            {
                MessageBox.Show("Escreva o angulo na qual o desenho será rotacionado");
                return;

            }
            matrizrotacao[0, 0].Text = Math.Cos(Convert.ToDouble(textBox7.Text) * (Math.PI / 180)).ToString();
            matrizrotacao[0, 1].Text = Math.Sin(-Convert.ToDouble(textBox7.Text) * (Math.PI / 180)).ToString();
            matrizrotacao[1, 0].Text = Math.Sin(Convert.ToDouble(textBox7.Text) * (Math.PI / 180)).ToString();
            matrizrotacao[1, 1].Text = Math.Cos(Convert.ToDouble(textBox7.Text) * (Math.PI / 180)).ToString();
            double[,] tempMatriz1 =  new double[desenho.GetLength(0), desenho.GetLength(1)];
            double[,] tempMatriz2 = new double[matrizrotacao.GetLength(0), matrizrotacao.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a multiplicacao de matrizes onde a coluna da matriz 1 e igual a linha da matriz 2  !", "Erro - Multiplicacao Matrizes");

                return;
            }



            for (int x = 0; x < desenho.GetLength(0); x++)
            {
                for (int y = 0; y < desenho.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(desenho[x, y].Text, out n);
                    tempMatriz1[x, y] = n;


                }
            }
            for (int x = 0; x < matrizrotacao.GetLength(0); x++)
            {

                for (int y = 0; y < matrizrotacao.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(matrizrotacao[x, y].Text, out n);
                    tempMatriz2[x, y] = n;


                }
            }

            double[,] tempMatrizResultante = Calculos.MultiplicarMatrizesDesenho(tempMatriz1, tempMatriz2);
            desenho = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBox4.Width / desenho.GetLength(1);
            groupBox4.Controls.Clear();
            for (int x = 0; x < desenho.GetLength(0); x++)
            {
                for (int y = 0; y < desenho.GetLength(1); y++)
                {
                    desenho[x, y] = new TextBox();
                    desenho[x, y].TextAlign = HorizontalAlignment.Center;

                    desenho[x, y].Text = tempMatrizResultante[x, y].ToString();
                    desenho[x, y].Top = (x * desenho[x, y].Height) + 20;
                    desenho[x, y].Left = y * TamanhoText;
                    desenho[x, y].Width = TamanhoText;
                    groupBox4.Controls.Add(desenho[x, y]);
                    //MessageBox.Show("" + resultante[x,y]);
                }
            }

            Graphics j = pictureBox1.CreateGraphics();

            j.Clear(Color.White);
            Pen blackPen = new Pen(Color.Red, 1);

            PointF[] pontos;

            pontos = new PointF[desenho.GetLength(1)];
            List<Point> point2 = new List<Point>();
            //pontos = new Point(x, y);
            for (int i = 0; i < desenho.GetLength(1); i++)
            {


                pontos[i] = new PointF(Convert.ToSingle(desenho[0, i].Text), -Convert.ToSingle(desenho[1, i].Text));
                pontos[i].X += pictureBox1.Width / 2;
                pontos[i].Y += pictureBox1.Height / 2;

                //j.DrawPolygon(blackPen, pontos);

                //MessageBox.Show("allahu akbar :" + desenho[0, i].Text + ", " + desenho[1, i].Text);
            }
            j.DrawPolygon(blackPen, pontos);
           
          
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        TextBox[,] translacaomatriz;
        int linhast;
        int colunast;
        private void button11_Click_1(object sender, EventArgs e)
        {
            
            if(desenho == null)
            {
                MessageBox.Show("Primeiro crie a matriz prinpal e desenhe a figura");
                return;
            }
            button12.Visible = true;
            linhast = Convert.ToInt32(comboBox6.SelectedItem.ToString());
            colunast = Convert.ToInt32(comboBox7.SelectedItem.ToString());
            translacaomatriz =  new TextBox[linhast,colunast];
            int TamanhoText = groupBox4.Width / colunast;

            for (int x = 0; x < translacaomatriz.GetLength(0); x++)
            {
                for (int y = 0; y < translacaomatriz.GetLength(1); y++)
                {
                    translacaomatriz[x, y] = new TextBox();
                    translacaomatriz[x, y].Text = "0";
                    translacaomatriz[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    translacaomatriz[x, y].TextAlign = HorizontalAlignment.Center;
                    translacaomatriz[x, y].Top = (x * translacaomatriz[x, y].Height) + 20;
                    translacaomatriz[x, y].Left = y * TamanhoText;
                    translacaomatriz[x, y].Width = TamanhoText;
                    groupBox6.Controls.Add(translacaomatriz[x, y]);




                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            float[,] tempMatriz1 = new float[desenho.GetLength(0), desenho.GetLength(1)];
            float[,] tempMatriz2 = new float[translacaomatriz.GetLength(0), translacaomatriz.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }



            for (int x = 0; x < desenho.GetLength(0); x++)
            {

                for (int y = 0; y < desenho.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(desenho[x, y].Text, out n);
                    tempMatriz1[x, y] = n;


                }
            }
            for (int x = 0; x < translacaomatriz.GetLength(0); x++)
            {
                for (int y = 0; y < translacaomatriz.GetLength(1); y++)
                {

                    float n = 0;
                    float.TryParse(translacaomatriz[x, y].Text, out n);
                    tempMatriz2[x, y] = n;


                }
            }

            float[,] tempMatrizResultante = Calculos.SomarMatrizes(tempMatriz1, tempMatriz2);
             desenho = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBox4.Width / desenho.GetLength(1);
            groupBox4.Controls.Clear();
            for (int x = 0; x < desenho.GetLength(0); x++)
            {
                for (int y = 0; y < desenho.GetLength(1); y++)
                {
                    desenho[x, y] = new TextBox();
                    desenho[x, y].KeyPress += new KeyPressEventHandler(keypressed);
                    desenho[x, y].TextAlign = HorizontalAlignment.Center;
                    desenho[x, y].Text = tempMatrizResultante[x, y].ToString();
                    desenho[x, y].Top = (x * desenho[x, y].Height) + 20;
                    desenho[x, y].Left = y * TamanhoText;
                    desenho[x, y].Width = TamanhoText;
                    groupBox4.Controls.Add(desenho[x, y]);
                }
            }
            Pen blackPen = new Pen(Color.Blue );

            

            pontos = new Point[desenho.GetLength(1)];
            List<Point> point2 = new List<Point>();
            //pontos = new Point(x, y);
            for (int i = 0; i < desenho.GetLength(1); i++)
            {


                pontos[i] = new Point(Convert.ToInt32(desenho[0, i].Text), -Convert.ToInt32(desenho[1, i].Text));
                pontos[i].X += pictureBox1.Width / 2;
                pontos[i].Y += pictureBox1.Height / 2;

                //g.DrawPolygon(blackPen, pontos);

                //MessageBox.Show("allahu akbar :" + desenho[0, i].Text + ", " + desenho[1, i].Text);
            }

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.DrawPolygon(blackPen, pontos);
                           
                            
                            

                            


                           
                           
                
         
        }
       

    }
}

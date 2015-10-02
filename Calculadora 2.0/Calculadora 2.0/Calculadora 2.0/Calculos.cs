using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_2._0
{
    class Calculos
    {
        ////Somar
        public static float[,] SomarMatrizes(float[,] matriz, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz.GetLongLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {

                    matrizResultante[x, y] = matriz[x, y] += matriz2[x, y];

                }
            }
            return matrizResultante;

        }
        //Subtração
        public static float[,] SubtrairMatrizes(float[,] matriz, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz.GetLongLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {

                    matrizResultante[x, y] = matriz[x, y] -= matriz2[x, y];

                }
            }
            return matrizResultante;

        }
        //Multiplicar Matrizes
        public static float[,] MultiplicarMatrizes(float[,] matriz, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz.GetLength(0), matriz2.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    for (int n = 0; n < matriz2.GetLength(0); n++)
                    {

                        matrizResultante[x, y] += matriz[x, n] * matriz2[n, y];
                    }
                }
            }
            return matrizResultante;
        }
        
        public static double[,] matrizResultante2;
        public static double[,] MultiplicarMatrizesDesenho(double[,] desenho, double[,] matrizrotacao)
        {   
          
            matrizResultante2 = new double[desenho.GetLength(0), matrizrotacao.GetLength(1)];
            for (int x = 0; x < matrizResultante2.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante2.GetLength(1); y++)
                {
                    for (int n = 0; n < matrizrotacao.GetLength(0); n++)
                    {

                        matrizResultante2[x, y] += desenho[x, n] * matrizrotacao[n, y];
                    }
                }
            }
            return matrizResultante2;
        }
        public static int number;
        
        //Multiplicar por número real
        public static float[,] NumeroReal(float[,] matriz) 
        {
            

            float[,] matrizResultante = new float[matriz.GetLongLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {

                    matrizResultante[x, y] += matriz[x, y] * number;


                }
            }
            return matrizResultante;
        }
        //Transposta
        public static float[,] Transposta1(float[,] matriz)
        {
            float[,] matrizTransposta = new float[matriz.GetLength(1), matriz.GetLength(0)];
            for (int x = 0; x < matrizTransposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizTransposta.GetLength(1); y++)
                {
                    matrizTransposta[x, y] += matriz[y, x];
                }
            }
            return matrizTransposta;
        }
        public static float[,] Oposta(float[,] matriz)
        {
            float[,] matrizOposta = new float[matriz.GetLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizOposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizOposta.GetLength(1); y++)
                {
                   matrizOposta[x, y] += matriz[x, y] * -1;
                }
            }
            return matrizOposta;
        }
       ///sdsd
        public static double DET(double[,] mat, int ord)
        {
            // pede uma matriz e seu tamanho
            // se ela for 2x2, retorna do jeito simples
            double myDet = 0;
            if (ord.Equals(2))
                return (mat[0, 0] * mat[1, 1] - mat[1, 0] * mat[0, 1]);
            // se ela for 1x1, retorna ela msm
            else if (ord.Equals(1))
                return (mat[0, 0]);
            else
            {
                double[,] matAux = new double[ord - 1, ord - 1];
                int colAux = 0;

                for (int i = 0; i < ord; i++)
                {

                    for (int linha = 1; linha < ord; linha++)
                    {
                        for (int coluna = 0; coluna < ord; coluna++)
                        {
                            if (i != coluna)
                                matAux[linha - 1, colAux++] = mat[linha, coluna];
                        }

                        colAux = 0;
                    }

                    if (mat[0, i] != 0)
                        myDet += (int)Math.Pow((-1), i) * mat[0, i] * DET(matAux, ord - 1);
                }
            }
            return (myDet);
        }
        // matriz de cofatores
        public static double[,] Cofatores(double[,] mat, int ord)
        {
            
            // pede uma matriz e seu tamanho
            // determina uma matriz auxiliar com o mesmo tamanho
            double[,] matAux = new double[ord, ord];
            for (int linha = 0; linha < ord; linha++)
            {
                for (int coluna = 0; coluna < ord; coluna++)
                {
                    //para cada valor da matriz original, cria-se uma matriz igual, excluindo-se todos os valores da linha e coluna desse valor.
                    double[,] sub = new double[ord - 1, ord - 1];
                    int C = 0;
                    int L = 0;
                    for (int i = 0; i < ord; i++)
                    {
                        if (i.Equals(linha)) continue;
                        for (int j = 0; j < ord; j++)
                        {
                            if (j.Equals(coluna)) continue;
                            sub[L, C] = mat[i, j];
                            C++;
                        }
                        L++;
                        C = 0;
                    }
                    // determina que no lugar daqle valor fica o determinante da matriz criada pra ele, multiplicada por -1 elevado a soma da linha e coluna dele
                    matAux[linha, coluna] = Math.Pow(-1, linha + coluna) * DET(sub, ord - 1);

                }
            }
            return matAux;
        }
        // inversa
        public static double[,] Invert(double det, double[,] mat, int ord)
        {
            // pede o det de uma matriz, essa matriz e seu tamanho
            // o valor a ser multiplicado, matriz cofator dessa matriz, matriz adjunta e matriz inversa
            double FirstValue = 1 / double.Parse(det.ToString());
            double[,] cof = Cofatores(mat, ord);
            double[,] Adjunt = cof;
            double[,] Inver = Adjunt;
            // seta q a matriz adjunta é a transposta da cofator
            // seta q a inversa é o produto do valor a ser multiplicado com a adjunta
            for (int i = 0; i < ord; i++)
            {
                for (int j = 0; j < ord; j++)
                {
                    Adjunt[i, j] = cof[j, i];
                    Inver[i, j] = FirstValue * Adjunt[i, j];
                }
            }
            return Inver;
        }


    }
}

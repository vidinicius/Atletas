using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Atletas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual é o número de atletas?");
            int n = int.Parse(Console.ReadLine());
            string[] nome = new string[n + 1];
            double[] vetorAltura = new double[n + 1];
            double[] vetorPeso = new double[n + 1];
            double[] vetorAltMulheres = new double[n + 1];
            int quantHomens = 0;
            int quantMulheres = 0;
            double somaAlturaMulheres = 0;

            //ENTRADA DE DADOS DOS N ATLETAS (NOME, SEXO, ALTURA E PESO)
            //----------------------------------------------------------------
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Digite os dados do atleta nº {0}: ", i);
                Console.Write("Nome: ");
                nome[i] = Console.ReadLine();

                Console.Write("Sexo: ");
                char sexo = char.Parse(Console.ReadLine());
                while (sexo != 'F' && sexo != 'f' && sexo != 'M' && sexo != 'm')
                {
                    Console.WriteLine("Valor inválido! Digite o valor F ou M para o sexo: ");
                    sexo = char.Parse(Console.ReadLine());
                }

                Console.Write("Altura [m]: ");
                vetorAltura[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                while (vetorAltura[i] < 0)
                {
                    Console.WriteLine("Valor inválido! Digite um valor positivo para altura [m]: ");
                    vetorAltura[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                if (sexo == 'M' || sexo == 'm')
                {
                    quantHomens++;
                }
                else
                {
                    somaAlturaMulheres = somaAlturaMulheres + vetorAltura[i];
                    quantMulheres++;
                }

                Console.Write("Peso [kg]: ");
                vetorPeso[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                while (vetorPeso[i] < 0)
                {
                    Console.WriteLine("Valor inválido! Digite um valor positivo para o peso [kg]: ");
                    vetorPeso[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

            }

            //DEFINIÇÃO DA MÉDIA DO PESO
            //------------------------------------------------------

            double somaPeso = 0;
            for (int i = 1; i <= n; i++)
            {
                somaPeso = somaPeso + vetorPeso[i];
            }
            double mediaPeso = somaPeso / n;

            //DEFINIÇÃO DO ATLETA MAIS ALTO
            //--------------------------------------------------------

            int indiceMaiorAltura = Maior(vetorAltura, n); //função para achar maior valor está desenvolvida abaixo
            int?[] indiceEmpatado = new int?[n + 1];
            for (int i = 1; i <= n; i++)
            {
                if (vetorAltura[i] == vetorAltura[indiceMaiorAltura])
                {
                    indiceEmpatado[i] = i;

                }
                else
                {
                    indiceEmpatado[i] = null;
                }
            }
            int empatados = 0;
            for (int i = 1; i <= n; i++)
            {
                if (indiceEmpatado[i] != null)
                {
                    empatados++;
                }
            }


            //DEFINIÇÃO DA PORCENTAGEM DE HOMENS
            //-------------------------------------------------------------------


            double porcentagemHomens = ((double)quantHomens / n) * 100.0;

            //DEFINIÇÃO DA MÉDIA DA ALTURA DAS MULHERES
            //--------------------------------------------------------------------

            double mediaAlturaMulheres = somaAlturaMulheres / quantMulheres;



            //IMPRESSÃO DO RELATÓRIO
            //------------------------------------------------------------------------
            
            Console.WriteLine("Relatório: ");

            Console.WriteLine("Peso médio dos atletas: " + mediaPeso.ToString("F1", CultureInfo.InvariantCulture));
            
            //Fiz o programa para também indicar o nome dos atletas mais altos caso existam atletas mais altos com alturas iguais


            if (empatados >= 2) //empatados tem que ser maior ou igual a 2 porque se for somente 1 será referente a um único valor de altura maior
            {
                Console.Write("Atletas mais altos: ");
                for (int i = 1; i <= n; i++)
                {
                    if (indiceEmpatado[i].HasValue)
                    {
                        Console.Write(nome[indiceEmpatado[i].Value] + ", ");
                    }

                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Atleta mais alto: " + nome[indiceMaiorAltura]);
            }


            Console.WriteLine("Porcentagem de homens: " + porcentagemHomens.ToString("F1", CultureInfo.InvariantCulture) + "%");

            if (quantMulheres == 0)
            {
                Console.WriteLine("Não há mulheres cadastradas!");
            }
            else
            {
                Console.WriteLine("Altura média das mulheres: " + mediaAlturaMulheres.ToString("F2", CultureInfo.InvariantCulture));
            }

        }

        static int Maior(double[] vetor, int a)
        {
            int indiceMaior = 0;
            int j = a;

            for (int i = 1; i < a; i++)
            {
                if (vetor[j] > vetor[a - i])
                {
                    indiceMaior = j;
                }
                else
                {
                    indiceMaior = a - i;
                    j = a - i;
                }
            }

            return indiceMaior;
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batalha
{
    internal class Program
    {

 class BatalhaNaval
        {
            static char[,] tabuleiroJogador1 = new char[10, 10];
            static char[,] tabuleiroJogador2 = new char[10, 10];
            static int barcosJogador1 = 5;
            static int barcosJogador2 = 5;
            static Random random = new Random();

            static void Main(string[] args)
            {
                InicializarTabuleiros();
                DistribuirBarcos(tabuleiroJogador1);
                DistribuirBarcos(tabuleiroJogador2);

                while (barcosJogador1 > 0 && barcosJogador2 > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Jogador 1:");
                    MostrarTabuleiro(tabuleiroJogador1);
                    Console.WriteLine("Placar: Jogador 1 - {0} | Jogador 2 - {1}", barcosJogador1, barcosJogador2);
                    FazerJogada(tabuleiroJogador2, ref barcosJogador2);

                    Console.Clear();
                    Console.WriteLine("Jogador 2:");
                    MostrarTabuleiro(tabuleiroJogador2);
                    Console.WriteLine("Placar: Jogador 1 - {0} | Jogador 2 - {1}", barcosJogador1, barcosJogador2);
                    FazerJogada(tabuleiroJogador1, ref barcosJogador1);
                }

                Console.Clear();
                Console.WriteLine("Jogo terminado!");
                Console.WriteLine("Placar final: Jogador 1 - {0} | Jogador 2 - {1}", barcosJogador1, barcosJogador2);
                Console.WriteLine("Pressione qualquer tecla para reiniciar...");
                Console.ReadKey();
                Main(args);
            }

            static void InicializarTabuleiros()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        tabuleiroJogador1[i, j] = ' ';
                        tabuleiroJogador2[i, j] = ' ';
                    }
                }
            }

            static void DistribuirBarcos(char[,] tabuleiro)
            {
                for (int i = 0; i < 5; i++)
                {
                    int x, y;
                    do
                    {
                        x = random.Next(10);
                        y = random.Next(10);
                    } while (tabuleiro[x, y] == 'X');
                    tabuleiro[x, y] = 'X';
                }
            }

            static void MostrarTabuleiro(char[,] tabuleiro)
            {
                Console.WriteLine("  A B C D E F G H I J");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(i + " ");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(tabuleiro[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            static void FazerJogada(char[,] tabuleiro, ref int barcosRestantes)
            {
                Console.Write("Informe a jogada (linha coluna): ");
                string jogada = Console.ReadLine();
                if (jogada.Length != 2)
                {
                    Console.WriteLine("Jogada inválida. Use o formato 'linha coluna' (por exemplo, '3 A').");
                    FazerJogada(tabuleiro, ref barcosRestantes);
                    return;
                }

                int linha = int.Parse(jogada[0].ToString());
                int coluna = char.ToUpper(jogada[1]) - 'A';

                if (linha < 0 || linha >= 10 || coluna < 0 || coluna >= 10)
                {
                    Console.WriteLine("Jogada fora do tabuleiro. Tente novamente.");
                    FazerJogada(tabuleiro, ref barcosRestantes);
                    return;
                }

                if (tabuleiro[linha, coluna] == 'X')
                {
                    Console.WriteLine("Jogador acertou um barco!");
                    tabuleiro[linha, coluna] = 'X';
                    barcosRestantes--;
                }
                else if (tabuleiro[linha, coluna] == 'O')
                {
                    Console.WriteLine("Jogada repetida. Tente novamente.");
                }
                else
                {
                    Console.WriteLine("Jogador acertou a água.");
                    tabuleiro[linha, coluna] = 'O';
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

    }
}

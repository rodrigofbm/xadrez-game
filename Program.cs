using System;
using tabuleiro;
using xadrez;

namespace Xadrez {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.gameOver) {
                    try {
                        Tela.ImprimirPartida(partida);

                        Console.Write("\n\nOrigem: ");
                        Posicao origem =  Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarOrigem(origem);
                        
                        bool[,] movPossiveis = partida.tabuleiro.GetPeca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tabuleiro, movPossiveis);

                        Console.Write("\nDestino: ");
                        Posicao destino =  Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarDestino(origem, destino);
                        
                        partida.RealizaJogada(origem, destino);
                        
                    } catch (TabuleiroException e) {
                        Console.WriteLine("\n" + e.Message);
                        Console.ReadLine();
                    }
                }
                
                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e) {
                
                Console.WriteLine(e.Message);
            }
        }
    }
}

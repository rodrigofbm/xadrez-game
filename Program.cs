using System;
using tabuleiro;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while(!partida.gameOver){
                Console.Clear();
                Screen.ImprimeTabuleiro(partida.tabuleiro);

                Console.Write("\nOrigem: ");
                Posicao origem = Screen.LerPosicaoXadrez().ToPosicao();

                bool[,] movPoss = partida.tabuleiro.Peca(origem).MovimentosPossiveis();
                Console.Clear();
                Screen.ImprimeTabuleiro(partida.tabuleiro, movPoss);
                Console.WriteLine();

                Console.Write("\nDestino: ");
                Posicao destino = Screen.LerPosicaoXadrez().ToPosicao();

                partida.ExecutaMovimento(origem, destino);
            }
            
            Console.ReadLine();
        }
    }
}

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

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Screen.LerPosicaoXadrez().ToPosicao();
                Console.Write("Destino: ");
                Posicao destino = Screen.LerPosicaoXadrez().ToPosicao();

                partida.ExecutaMovimento(origem, destino);
            }
            
            Console.ReadLine();
        }
    }
}

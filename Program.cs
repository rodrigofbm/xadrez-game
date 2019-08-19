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
                try{
                    Console.Clear();
                    Screen.ImprimeTabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.WriteLine("Turno " + partida.turno);
                    Console.WriteLine("Aguardando jogada. Peça " + partida.jogadorAtual);

                    Console.Write("\nOrigem: ");
                    Posicao origem = Screen.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDeOrigem(origem);

                    bool[,] movPoss = partida.tabuleiro.Peca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Screen.ImprimeTabuleiro(partida.tabuleiro, movPoss);
                    Console.WriteLine();

                    Console.Write("\nDestino: ");
                    Posicao destino = Screen.LerPosicaoXadrez().ToPosicao();

                    partida.ValidarPosicaoDeDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);
                }catch(TabuleiroException e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Aperte ENTER para tentar novamente...");
                    Console.ReadLine();
                }
            }
            
            Console.ReadLine();
        }
    }
}

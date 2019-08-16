using System;
using tabuleiro;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez tabuleiro = new PartidaDeXadrez();

            Screen.ImprimeTabuleiro(tabuleiro.tabuleiro);
            
            Console.ReadLine();
        }
    }
}

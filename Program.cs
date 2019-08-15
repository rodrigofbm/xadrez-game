using System;
using tabuleiro;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Tabuleiro tabuleiro = new Tabuleiro(8,8);

            tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(0,0));
            tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(1,3));
            tabuleiro.AdicionaPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2,4));
            Screen.ImprimeTabuleiro(tabuleiro);
            
            Console.ReadLine();

        }
    }
}

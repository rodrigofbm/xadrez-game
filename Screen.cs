using System;
using tabuleiro;
using xadrez;

namespace xadrez {
    class Screen {
        public static void ImprimeTabuleiro(Tabuleiro tabuleiro) {
            for(int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write( 8-i + " ");
                for(int j = 0; j < tabuleiro.colunas; j++) {
                    if(tabuleiro.Peca(i,j) == null) {
                        Console.Write("- ");
                    }else {
                        Screen.ImprimePeca(tabuleiro.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  a b c d e f g h");
        }

        public static void ImprimePeca(Peca peca) {
            if(peca.cor == Cor.Branca) {
                Console.Write(peca);
            }else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
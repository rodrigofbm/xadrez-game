using System;
using tabuleiro;
using xadrez;

namespace xadrez {
    class Screen {
        public static void ImprimeTabuleiro(Tabuleiro tabuleiro) {
            for(int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write( 8-i + " ");
                for(int j = 0; j < tabuleiro.colunas; j++) {
                    Screen.ImprimePeca(tabuleiro.Peca(i, j));
                }
                Console.WriteLine();
            }

            Console.Write("  a b c d e f g h");
            Console.WriteLine();
        }

        public static void ImprimeTabuleiro(Tabuleiro tabuleiro, bool[,] movimentoPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado= ConsoleColor.DarkGreen;

            for(int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write( 8-i + " ");
                for(int j = 0; j < tabuleiro.colunas; j++) {
                    if(movimentoPossiveis[i,j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Screen.ImprimePeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void ImprimePeca(Peca peca) {
            if(peca == null) {
                Console.Write("- ");
            }else {
                if(peca.cor == Cor.Branca) {
                    Console.Write(peca + " ");
                }else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(peca + " ");
                    Console.ForegroundColor = aux;
                }
            }
            
        }

        public static PosicaoXadrez LerPosicaoXadrez() {
            string pos = Console.ReadLine();
            char coluna = pos[0];
            int linha = int.Parse(pos[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }
    }
}
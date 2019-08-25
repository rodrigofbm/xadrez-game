using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez {
    class Screen {
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            Screen.ImprimeTabuleiro(partida.tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            if(!partida.gameOver) {
                Console.WriteLine("\nTurno " + partida.turno);
                Console.WriteLine("Aguardando jogada. Peça " + partida.jogadorAtual);

                if(partida.xeque) {
                    Console.WriteLine("XEQUE!");
                }
            }else {
                Console.WriteLine("\nXEQUEMATE");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("\nPeças Capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nAmarelas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Amarela));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ImprimirConjunto(HashSet<Peca> pecas) {
            Console.Write("[");
            foreach (Peca x in pecas) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

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
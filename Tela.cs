using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Xadrez {
    class Tela {
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tabuleiro);
            Tela.ImprimirPecasCapturadas(partida);
            Console.WriteLine("\n\nTurno: " + partida.turno);
            if(!partida.gameOver) {
                Console.WriteLine("\nAguardando jogada: " + partida.jogadorAtual);
                if(partida.xeque) Console.WriteLine("\nXEQUE!");
            }else {
                Console.WriteLine("\nO jogador da peça " + partida.jogadorAtual + " venceu!!");
                Console.ReadLine();
            }
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    Peca p = tabuleiro.GetPeca(i,j);
                    Tela.ImprimirPecas(p);
                }
                Console.WriteLine();
            }
             Console.WriteLine("   a b c d e f g h");
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            ConsoleColor aux = Console.ForegroundColor;

            HashSet<Peca> capturadas = partida.PecasCapturadas(Cor.Branca);
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            Tela.ImprimirConjuntoPecas(capturadas);

            capturadas = partida.PecasCapturadas(Cor.Amarela);
            Console.Write("\nAmarelas: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Tela.ImprimirConjuntoPecas(capturadas);

            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjuntoPecas(HashSet<Peca> pecas) {
            Console.Write("[");
            foreach (Peca p in pecas) {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] movimentosPossiveis) {
            ConsoleColor backgroundOriginal  = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    Peca p = tabuleiro.GetPeca(i,j);

                    if(movimentosPossiveis[i,j]){
                        Console.BackgroundColor = fundoAlterado;
                    }else {
                        Console.BackgroundColor = backgroundOriginal;
                    }

                    Tela.ImprimirPecas(p);
                    Console.BackgroundColor = backgroundOriginal;
                }
                Console.WriteLine();
            }

            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = backgroundOriginal;
        }

        private static void ImprimirPecas(Peca p) {
            ConsoleColor curr = Console.ForegroundColor;

            if(p == null) {
                Console.Write(" -");
            }else {
                if(p.cor == Cor.Amarela) {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }

                Console.Write(" " +  p);
                Console.ForegroundColor = curr;
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
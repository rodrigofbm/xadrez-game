using System;

namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; private set; }
        public int colunas { get; private set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public Peca GetPeca(Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public void ColocaPeca(Peca p, Posicao pos) {
            ExistePeca(pos);
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca RetiraPeca(Posicao pos) {
            if(GetPeca(pos) == null) {
                return null;
            }

            Peca aux = GetPeca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;

            return aux;
        }

        public bool ValidaPosicao(Posicao pos) {
            if((pos.linha >= 0 && pos.linha < linhas) && (pos.coluna >= 0 && pos.coluna < colunas)) {
                return true;
            }

            return false;
        }

        public void ChecaValidadePosicao(Posicao pos) {
            if(!ValidaPosicao(pos)) 
                throw new TabuleiroException("A posição escolhida é inválida");
        }

        public void ExistePeca(Posicao pos) {
            ChecaValidadePosicao(pos);
            if(pecas[pos.linha, pos.coluna] != null)
                throw new TabuleiroException("Já existe uma peça nessa posição");
        }
    }
}
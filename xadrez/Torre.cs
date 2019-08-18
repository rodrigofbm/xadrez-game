using tabuleiro;

namespace xadrez {
    class Torre: Peca {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {}

        public override string ToString() {
            return "T";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos =  new Posicao(0,0);

            // acima
            pos.DefinirPosicoesMatriz(this.posicao.linha - 1, this.posicao.coluna);
            while(tabuleiro.isValidPos(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != this.cor)
                    break;

                pos.linha--;
            }

            // abaixo
            pos.DefinirPosicoesMatriz(this.posicao.linha + 1, this.posicao.coluna);
            while(tabuleiro.isValidPos(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != this.cor)
                    break;

                pos.linha++;
            }

            // direita
            pos.DefinirPosicoesMatriz(this.posicao.linha, this.posicao.coluna + 1);
            while(tabuleiro.isValidPos(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != this.cor)
                    break;

                pos.coluna++;
            }

            // esquerda
            pos.DefinirPosicoesMatriz(this.posicao.linha, this.posicao.coluna - 1);
            while(tabuleiro.isValidPos(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != this.cor)
                    break;

                pos.coluna--;
            }

            return mat;
        }
    }
}
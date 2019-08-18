using tabuleiro;

namespace xadrez {
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {}

        public override string ToString() {
            return "R";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos =  new Posicao(0,0);

            // cima
            pos.DefinirPosicoesMatriz(this.posicao.linha - 1, this.posicao.coluna);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // nordeste
            pos.DefinirPosicoesMatriz(this.posicao.linha - 1, this.posicao.coluna + 1);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // direita
            pos.DefinirPosicoesMatriz(this.posicao.linha, this.posicao.coluna + 1);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // sudeste
            pos.DefinirPosicoesMatriz(this.posicao.linha + 1, this.posicao.coluna + 1);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // abaixo
            pos.DefinirPosicoesMatriz(this.posicao.linha + 1, this.posicao.coluna);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Sudoeste
            pos.DefinirPosicoesMatriz(this.posicao.linha + 1, this.posicao.coluna - 1);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // esquerda
            pos.DefinirPosicoesMatriz(this.posicao.linha, this.posicao.coluna - 1);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // noroeste
            pos.DefinirPosicoesMatriz(this.posicao.linha - 1, this.posicao.coluna - 1);
            if(tabuleiro.isValidPos(pos) && this.PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
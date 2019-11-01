using tabuleiro;

namespace xadrez {

    class Cavalo : Peca {

        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro) {
        }

        public override string ToString() {
            return "C";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.GetPeca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna - 2);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha - 2, posicao.coluna - 1);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha - 2, posicao.coluna + 1);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 2);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna + 2);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha + 2, posicao.coluna + 1);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha + 2, posicao.coluna - 1);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna - 2);
            if (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}

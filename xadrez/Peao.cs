using tabuleiro;

namespace xadrez {

    class Peao : Peca {

        private PartidaDeXadrez partida;

        public Peao(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partida) : base(cor, tabuleiro) {
            this.partida = partida;
        }

        public override string ToString() {
            return "P";
        }

        private bool existeInimigo(Posicao pos) {
            Peca p = tabuleiro.GetPeca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos) {
            return tabuleiro.GetPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.ValidaPosicao(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirPosicao(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.ValidaPosicao(p2) && livre(p2) && tabuleiro.ValidaPosicao(pos) && livre(pos) && qtdMovimento == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirPosicao(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.ValidaPosicao(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.ValidaPosicao(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            } else {
                pos.DefinirPosicao(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.ValidaPosicao(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirPosicao(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.ValidaPosicao(p2) && livre(p2) && tabuleiro.ValidaPosicao(pos) && livre(pos) && qtdMovimento == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirPosicao(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.ValidaPosicao(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirPosicao(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.ValidaPosicao(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;
        }
    }
}

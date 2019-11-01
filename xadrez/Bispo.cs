using tabuleiro;

namespace xadrez {

    class Bispo : Peca {

        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro) {
        }

        public override string ToString() {
            return "B";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.GetPeca(pos);
            return p == null || p.cor != cor;
        }
        
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // NO
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.GetPeca(pos) != null && tabuleiro.GetPeca(pos).cor != cor) {
                    break;
                }
                pos.DefinirPosicao(pos.linha - 1, pos.coluna - 1);
            }

            // NE
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.GetPeca(pos) != null && tabuleiro.GetPeca(pos).cor != cor) {
                    break;
                }
                pos.DefinirPosicao(pos.linha - 1, pos.coluna + 1);
            }

            // SE
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.GetPeca(pos) != null && tabuleiro.GetPeca(pos).cor != cor) {
                    break;
                }
                pos.DefinirPosicao(pos.linha + 1, pos.coluna + 1);
            }

            // SO
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.ValidaPosicao(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.GetPeca(pos) != null && tabuleiro.GetPeca(pos).cor != cor) {
                    break;
                }
                pos.DefinirPosicao(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}

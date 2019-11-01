using tabuleiro;

namespace xadrez {
    class Torre: Peca {
        public Torre(Cor cor, Tabuleiro tab): base(cor, tab) {}

        public override string ToString() {
            return "T";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] posicoes = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0,0);

            //Acima
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
            while(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)) {
                posicoes[pos.linha, pos.coluna] = true;
                if(tabuleiro.GetPeca(pos) != null) {
                    break;
                }
                pos.DefinirPosicao(pos.linha - 1, pos.coluna);
            }

            //Direita
            pos.DefinirPosicao(posicao.linha, posicao.coluna + 1);
            while(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)) {
                posicoes[pos.linha, pos.coluna] = true;
                if(tabuleiro.GetPeca(pos) != null) {
                    break;
                }
                pos.DefinirPosicao(pos.linha, pos.coluna + 1);
            }

            //Abaixo
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna);
            while(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)) {
                posicoes[pos.linha, pos.coluna] = true;
                if(tabuleiro.GetPeca(pos) != null) {
                    break;
                }
                pos.DefinirPosicao(pos.linha + 1, pos.coluna);
            }

            //Esquerda
            pos.DefinirPosicao(posicao.linha, posicao.coluna - 1);
            while(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)) {
                posicoes[pos.linha, pos.coluna] = true;
                if(tabuleiro.GetPeca(pos) != null) {
                    break;
                }
                pos.DefinirPosicao(pos.linha, pos.coluna - 1);
            }

            return posicoes;
        }
    }
}
using tabuleiro;

namespace xadrez {
    class Rei: Peca {
        private PartidaDeXadrez partida;

        public Rei(Cor cor, Tabuleiro tab, PartidaDeXadrez partida): base(cor, tab) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] posicoes = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0,0);

            //acima
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)) {
                posicoes[pos.linha, pos.coluna] = true;
            }
            //nordeste
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 1);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)) {
                posicoes[pos.linha, pos.coluna] = true;
            }
            //direita
            pos.DefinirPosicao(posicao.linha, posicao.coluna + 1);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)){
                posicoes[pos.linha, pos.coluna] = true;
            }
            //sudeste
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna + 1);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)){
                posicoes[pos.linha, pos.coluna] = true;
            }
            //abaixo
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)){
                posicoes[pos.linha, pos.coluna] = true;
            }
            //sudoeste
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna - 1);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)){
                posicoes[pos.linha, pos.coluna] = true;
            }
            //esquerda
            pos.DefinirPosicao(posicao.linha, posicao.coluna -1);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)){
                posicoes[pos.linha, pos.coluna] = true;
            }
            //noroeste
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna -1);
            if(tabuleiro.ValidaPosicao(pos) && PodeMover(pos)){
                posicoes[pos.linha, pos.coluna] = true;
            }

            return posicoes;
        }
    }
}
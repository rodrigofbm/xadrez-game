using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char colula, int linha) {
            this.coluna = colula;
            this.linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString() {
            return "" + coluna + linha;
        }

    }
}
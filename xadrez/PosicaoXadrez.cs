using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {
        public int linha { get; set; }
        public char coluna { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }
    }
}
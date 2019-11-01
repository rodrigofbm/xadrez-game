namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimento { get; protected set; }
        public Tabuleiro tabuleiro { get; private set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.qtdMovimento = 0;
        }

        public void IncrementaQtdMovimento() {
            this.qtdMovimento++;
        }

        public void DecrementaQtdMovimento() {
            this.qtdMovimento--;
        }

        protected virtual bool PodeMover(Posicao pos) {
            Peca p = tabuleiro.GetPeca(pos);

            return p == null || p.cor != this.cor;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] posicoes = MovimentosPossiveis();

            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if(posicoes[i,j]) return true;
                }
            }

            return false;
        }

        public bool MovimentoPossivel(Posicao pos) {
            return  MovimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] MovimentosPossiveis();

    }
}
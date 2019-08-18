namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }   
        public int qtdMovimentos { get; protected set; } 
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        public void IncrementaMovimento() {
            qtdMovimentos++;
        }

        protected bool PodeMover(Posicao pos) {
            Peca p = tabuleiro.Peca(pos);

            return p == null || p.cor != this.cor;
        }

        abstract public bool[,] MovimentosPossiveis();
    }
}
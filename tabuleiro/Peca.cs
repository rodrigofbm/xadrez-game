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

        public void DecrementaMovimento() {
            qtdMovimentos--;
        }

        protected bool PodeMover(Posicao pos) {
            Peca p = tabuleiro.Peca(pos);

            return p == null || p.cor != this.cor;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();

            for(var i = 0; i < tabuleiro.linhas; i++) {
                for(var j = 0; j < tabuleiro.colunas; j++) {
                    if(mat[i,j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }

        abstract public bool[,] MovimentosPossiveis();
    }
}
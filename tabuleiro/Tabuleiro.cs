namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public void AdicionaPeca(Peca peca, Posicao pos) {
            if(!ExistePeca(pos)) {
                pecas[pos.linha, pos.coluna] = peca;
                peca.posicao = pos;
            }else {
                throw new TabuleiroException("Já existe peça nesta posição");
            }  
        }

        public Peca RetirarPeca(Posicao pos) {
            if(Peca(pos) == null) 
                return null;
            
            Peca aux = Peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;

            return aux;
        }

        public bool isValidPos(Posicao pos) {
            if((pos.linha < 0 || pos.linha >= linhas) || (pos.coluna < 0 || pos.coluna >= colunas)) 
                return false;
            
            return true;
        }

        public void ValidarPosicao(Posicao pos) {
            if(!isValidPos(pos))
                throw new TabuleiroException("Posição inválida");
        }

        public bool ExistePeca(Posicao pos) {
            this.ValidarPosicao(pos);
            return Peca(pos) != null;
        }
    }
}
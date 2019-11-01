using System.Collections.Generic;
using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tabuleiro {get; private set;}
        public bool gameOver {get; set;}
        public bool xeque {get; private set;}
        public int turno {get; private set;}
        public Cor jogadorAtual {get; private set;}
        private HashSet<Peca> pecas;
        private HashSet<Peca> pecasCapturadas;

        public PartidaDeXadrez() {
            this.tabuleiro = new Tabuleiro(8,8);
            gameOver = false;
            xeque = false;
            this.pecas = new HashSet<Peca>();
            this.pecasCapturadas = new HashSet<Peca>();
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;

            ImprimePecas();
        }

        public void ValidarOrigem(Posicao pos) {
            Peca peca = tabuleiro.GetPeca(pos);

            if(peca == null ) {
                throw new TabuleiroException("Não existe peça nessa posição");
            }

            if(peca.cor != jogadorAtual) {
                throw new TabuleiroException("Você não pode mexer na peça do adversário");
            }

            if(!peca.ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Essa peça está bloqueada");
            }
        }

        public void ValidarDestino(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.GetPeca(origem);

            if(!peca.MovimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida.");
            }
            
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = tabuleiro.RetiraPeca(origem);
            p.IncrementaQtdMovimento();
            Peca pecaCapturada = tabuleiro.RetiraPeca(destino);

            if(pecaCapturada != null) pecasCapturadas.Add(pecaCapturada);

            tabuleiro.ColocaPeca(p, destino);
            return pecaCapturada;
        }

        public bool EstaEmXeque(Cor cor) {
            Peca r = GetRei(cor);

            if(r == null) throw new TabuleiroException("Não existe rei no tabuleiro");

            foreach(Peca x in PecasEmJogo(JogadorAdversario(cor))) {
                if(x.MovimentosPossiveis()[r.posicao.linha, r.posicao.coluna]){
                    return true;
                }
            } 

            return false;
        }

        public bool EstaEmXequeMate(Cor cor) {
            if(!EstaEmXeque(cor)) return false;

            Posicao destino;
            Peca pecaCapturada;
            Posicao origem;
            foreach(Peca p in PecasEmJogo(cor)) {
                bool[,] mat = p.MovimentosPossiveis();
                
                for (int i = 0; i < tabuleiro.linhas; i++) {
                    for (int j = 0; j < tabuleiro.linhas; j++) {
                        if(mat[i,j]) {
                            destino = new Posicao(i,j);
                            origem = p.posicao;
                            pecaCapturada = ExecutaMovimento(origem, destino);
                            bool verificaXeque = EstaEmXeque(cor);
                            ResetarJogada(origem, destino, pecaCapturada);

                            if(!verificaXeque) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if(EstaEmXeque(jogadorAtual)){
                ResetarJogada(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if(EstaEmXeque(JogadorAdversario(jogadorAtual))){
                xeque = true;
            }else {
                xeque = false;
            }

            if(EstaEmXequeMate(JogadorAdversario(jogadorAtual))) {
                gameOver = true;

            }else {
                turno++;
                MudaJogador();
            }
        }

        public void ResetarJogada(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tabuleiro.RetiraPeca(destino);
            p.DecrementaQtdMovimento();
            
            if(pecaCapturada != null) {
                tabuleiro.ColocaPeca(pecaCapturada, destino);
                pecasCapturadas.Remove(pecaCapturada);
            }

            tabuleiro.ColocaPeca(p, origem);
        }

        public void MudaJogador() {
            if(jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Amarela;
            }else {
                jogadorAtual = Cor.Branca;
            }
        }

        public Cor JogadorAdversario(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Amarela;
            }

            return Cor.Branca;
        }

        private Peca GetRei(Cor cor) {
            foreach (var p in PecasEmJogo(cor)) {
                if(p is Rei) return p;
            }

            return null;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca p in pecasCapturadas) {
                if(p.cor == cor) aux.Add(p);
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca p in pecas) {
                if(p.cor == cor) aux.Add(p);
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            tabuleiro.ColocaPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ImprimePecas() {
            //==========Peças Brancas======== 
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, tabuleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, tabuleiro));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branca, tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, tabuleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branca, tabuleiro, this));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branca, tabuleiro, this));

            //==========Peças Amarelas========
            ColocarNovaPeca('a', 8, new Torre(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('d', 8, new Dama(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('a', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('b', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('c', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('d', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('e', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('f', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('g', 7, new Peao(Cor.Amarela, tabuleiro, this));
            ColocarNovaPeca('h', 7, new Peao(Cor.Amarela, tabuleiro, this));
        }
    }
}
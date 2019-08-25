using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool gameOver { get; private set; }
        public bool xeque { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            this.tabuleiro = new Tabuleiro(8,8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            this.gameOver = false;
            this.xeque = false;
            this.pecas = new HashSet<Peca>();
            this.capturadas = new HashSet<Peca>();

            this.ColocarPecas();
        }

        public bool EstaEmXeque(Cor cor) {
            Peca r = Rei(cor);

            if(r == null) 
                throw new TabuleiroException("Não existe rei no tabuleiro");

            foreach(Peca x in PecasEmJogo(JogadorAdversario(cor))) {
                if(x.MovimentosPossiveis()[r.posicao.linha, r.posicao.coluna]){
                    return true;
                }
            } 

            return false;
        }

        public bool EstaEmXequeMate(Cor cor) {
            if(!EstaEmXeque(cor)) {
                return false;
            }
            //se o rei adversário estiver em xeque, verificamos se é possível sair do xeque
            foreach(Peca x in PecasEmJogo(cor)) {
                Posicao destino;
                Posicao origem = x.posicao;
                bool[,] mat = x.MovimentosPossiveis();

                for (int i = 0; i < tabuleiro.linhas; i++) {
                    for (int j = 0; j < tabuleiro.colunas; j++) {
                        if(mat[i,j]) {
                            destino = new Posicao(i,j);
                            Peca pecaCapturada =  ExecutaMovimento(origem, destino);
                            bool estaEmXeque = EstaEmXeque(cor);
                            ResetarJogada(origem, destino, pecaCapturada);

                            if(!estaEmXeque) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void ResetarJogada(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tabuleiro.RetirarPeca(destino);
            p.DecrementaMovimento();
            
            if(pecaCapturada != null) {
                tabuleiro.AdicionaPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            tabuleiro.AdicionaPeca(p, origem);
        }

        public Peca Rei(Cor cor) {
            foreach(Peca x in PecasEmJogo(cor)) {
                if(x is Rei) {
                    return x;
                }
            }

            return null;
        }

        public Cor JogadorAdversario(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Amarela;
            }

            return Cor.Branca;
        }

        private void ColocarPecas() {
            try{
                // peças brancas
                ColocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
                ColocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
                ColocarNovaPeca('h', 7, new Torre(tabuleiro, Cor.Branca));
                /* ColocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branca));
                ColocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.Branca));
                ColocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
                 */

                // peças amarelas
                ColocarNovaPeca('a', 8, new Rei(tabuleiro, Cor.Amarela));
                ColocarNovaPeca('b', 8, new Torre(tabuleiro, Cor.Amarela));
                /* ColocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Amarela));
                ColocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Amarela));
                ColocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Amarela));
                ColocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Amarela)); */
            }catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }            
        }

        private void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            tabuleiro.AdicionaPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if(tabuleiro.Peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição selecionada!");
            }
            if(jogadorAtual != tabuleiro.Peca(pos).cor) {
                throw new TabuleiroException("Essa peça não é sua!");
            }
            if(!tabuleiro.Peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Atualmente não é possível movimentar essa peça!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if(!tabuleiro.Peca(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementaMovimento();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);

            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }

            tabuleiro.AdicionaPeca(p, destino);

            return pecaCapturada;
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = this.ExecutaMovimento(origem, destino);

            if(EstaEmXeque(jogadorAtual)) {
                ResetarJogada(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if(EstaEmXeque(JogadorAdversario(jogadorAtual))) {
                xeque = true;
            }else {
                xeque = false;
            }

            if(EstaEmXequeMate(JogadorAdversario(jogadorAtual))) {
                gameOver = true;
            }else {
                this.turno++;
                this.MudaJogador();
            }
        }

        private void MudaJogador() {
            if(this.jogadorAtual == Cor.Branca) {
                this.jogadorAtual = Cor.Amarela;
            }else {
                 this.jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in capturadas) {
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas) {
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
    }
}
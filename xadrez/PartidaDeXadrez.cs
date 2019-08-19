using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool gameOver { get; private set; }

        public PartidaDeXadrez()
        {
            this.tabuleiro = new Tabuleiro(8,8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            this.gameOver = false;
            
            this.ColocarPecas();
        }

        private void ColocarPecas()
        {
            try{
                // peças brancas
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c',1).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c',2).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('d',2).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('e',2).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('e',1).ToPosicao());
                tabuleiro.AdicionaPeca(new Rei(tabuleiro, Cor.Branca), new PosicaoXadrez('d',1).ToPosicao());

                // peças amarelas
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Amarela), new PosicaoXadrez('c',8).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Amarela), new PosicaoXadrez('c',7).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Amarela), new PosicaoXadrez('d',7).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Amarela), new PosicaoXadrez('e',7).ToPosicao());
                tabuleiro.AdicionaPeca(new Torre(tabuleiro, Cor.Amarela), new PosicaoXadrez('e',8).ToPosicao());
                tabuleiro.AdicionaPeca(new Rei(tabuleiro, Cor.Amarela), new PosicaoXadrez('d',8).ToPosicao());
            }catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }            
        }

        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if(tabuleiro.Peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição selecionada!");
            }
            if(tabuleiro.Peca(pos).cor != jogadorAtual) {
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

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementaMovimento();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);

            tabuleiro.AdicionaPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            this.ExecutaMovimento(origem, destino);
            this.turno++;
            this.MudaJogador();
        }

        private void MudaJogador() {
            if(this.jogadorAtual == Cor.Branca) {
                this.jogadorAtual = Cor.Amarela;
            }else {
                 this.jogadorAtual = Cor.Branca;
            }
        }
    }
}
using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual;

        public PartidaDeXadrez()
        {
            this.tabuleiro = new Tabuleiro(8,8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;

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

        public void ExecutaMovimento(Posicao origim, Posicao destino) {
            Peca p = tabuleiro.RetirarPeca(origim);
            p.IncrementaMovimento();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);

            tabuleiro.AdicionaPeca(p, destino);
        }
    }
}
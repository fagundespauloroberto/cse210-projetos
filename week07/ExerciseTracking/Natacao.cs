using System;

namespace MonitoramentoExercicios
{
    public class Natacao : Atividade
    {
        //atributo privado especifico da Natação
        private int _voltas;

        //construtor que passa a data e a duração para a classe base
        public Natacao(string data, int duracaoMinutos, int voltas) 
            : base(data, duracaoMinutos)
        {
            _voltas = voltas;
        }

        //sobrescrita dos metodos de calculo
        public override double ObterDistancia()
        {
            //calculo para converter para km.
            return (_voltas * 50.0) / 1000.0;
        }

        public override double ObterVelocidade()
        {
            return (ObterDistancia() / ObterDuracaoMinutos()) * 60.0;
        }

        public override double ObterRitmo()
        {
            return ObterDuracaoMinutos() / ObterDistancia();
        }
    }
}
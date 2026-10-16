using System;

namespace MonitoramentoExercicios
{
    public class Ciclismo : Atividade
    {
        //atributo privado especifico do Ciclismo
        private double _velocidade;

        //construtor que passa a data e a duração para a classe base
        public Ciclismo(string data, int duracaoMinutos, double velocidade) 
            : base(data, duracaoMinutos)
        {
            _velocidade = velocidade;
        }

        //sobrescrita dos metodos de calculo
        public override double ObterDistancia()
        {
            return (_velocidade * ObterDuracaoMinutos()) / 60.0;
        }

        public override double ObterVelocidade()
        {
            return _velocidade;
        }

        public override double ObterRitmo()
        {
            return 60.0 / _velocidade;
        }
    }
}
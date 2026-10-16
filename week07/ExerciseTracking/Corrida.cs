using System;

namespace MonitoramentoExercicios
{
    public class Corrida : Atividade
    {
        //atributo privado específico da Corrida
        private double _distancia;

        //construtor repassa data e duração para classe base
        public Corrida(string data, int duracaoMinutos, double distancia) 
            : base(data, duracaoMinutos)
        {
            _distancia = distancia;
        }

        //sobrescrita dos metodos de calculo
        public override double ObterDistancia()
        {
            return _distancia;
        }

        public override double ObterVelocidade()
        {
            return (_distancia / ObterDuracaoMinutos()) * 60;
        }

        public override double ObterRitmo()
        {
            return ObterDuracaoMinutos() / _distancia;
        }
    }
}
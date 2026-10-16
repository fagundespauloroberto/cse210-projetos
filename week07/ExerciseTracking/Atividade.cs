using System;

namespace MonitoramentoExercicios
{
    public abstract class Atividade
    {
        //atributos privados (Encapsulamento)
        private string _data;
        private int _duracaoMinutos;

        public Atividade(string data, int duracaoMinutos)
        {
            _data = data;
            _duracaoMinutos = duracaoMinutos;
        }

        // Getters protegidos/publicos para acesso a duração e data
        public int ObterDuracaoMinutos() => _duracaoMinutos;
        public string ObterData() => _data;

        //metodos abstratos/virtuais que TODA atividade deve implementar
        public abstract double ObterDistancia();
        public abstract double ObterVelocidade();
        public abstract double ObterRitmo();

        //metodo comum reutilizado por todas as subclasses (Polimorfismo)
        public virtual string ObterResumo()
        {
            return $"{_data} {GetType().Name} ({_duracaoMinutos} min) - " +
                   $"Distância: {ObterDistancia():0.0} km, " +
                   $"Velocidade: {ObterVelocidade():0.0} km/h, " +
                   $"Ritmo: {ObterRitmo():0.00} min por km";
        }
    }
}
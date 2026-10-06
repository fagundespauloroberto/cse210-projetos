using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week06.Colaborador
{
    public class Horista : Colaborador
    {
        private float _valorHora = 0;
        private float _horasTrabalhadas = 0;

        public float ObterValorHora()
        {
            return _valorHora;
        }

        public void DefinirValorHora(float _valorHora)
        {
            _valorHora = valorHora;
        }

        public float ObterHorasTrabalhadas()
        {
            return _horasTrabalhadas;
        }

        public void DefinirHorasTrabalhadas(float _valorHora)
        {
            _horasTrabalhadas = horasTrabalhadas;
        }

        public override float Pagamento()
        {
            return _horasTrabalhadas * _valorHora;
        }

    }
}
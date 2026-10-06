using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circulo : Figura
    {
        private double _raio;

        public Circulo(string cor, double raio) : base (cor)
        {
            _raio = raio;
        }

        // Observe o uso da palavra-chave override aqui
        public override double ObterArea()
        {
            return _raio * _raio * Math.PI;
        }
    }
}
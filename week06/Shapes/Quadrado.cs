using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Quadrado : Figura
    {
        private double _lado;

        public Quadrado(string cor, double lado) : base (cor)
        {
            _lado = lado;
        }

        // Observe o uso da palavra-chave override aqui
        public override double ObterArea()
        {
            return _lado * _lado;
        }
    }
}
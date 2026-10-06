using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week06.Colaborador
{
    public class Colaborador
    {
        private string _nome;
        private string _Id;

        public string ObterNome()
        {
            return _nome;
        }

        public void definirNome(string nome)
        {
            _nome = nome;
        }

        public string ObterId()
        {
            return _Id;
        }

        public void DefinirId(string Id)
        {
            _Id = Id;
        }

        public virtual float Pagamento()
        {
            return -1;
        }
        
    }
}
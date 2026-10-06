using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week06.Colaborador
{
    public struct Program
    {

        public static void Main(string[] args)
        {
            Horista horista = new Horista();
            horista.definirNome("Joao");
            horista.DefinirId("123abc");
            horista.DefinirValorHora(100);
            horista.DefinirHorasTrabalhadas(55);

            Mensalista mensalista = new Mensalista();
            mensalista.definirNome("Pedro");
            mensalista.DefinirId("123abc");
            mensalista.DefinirSalarioMensal(5000);

            ExibirInformacoesColaborador(horista);
            ExibirInformacoesColaborador(mensalista);

        }

        public static void ExibirInformacoesColaborador(Colaborador colaborador)
        {
            float contracheque = colaborador.Pagamento();
            Console.WriteLine($"{colaborador.ObterNome()} - {colaborador.ObterId()} - Pagamento: {contracheque} ");
        }
        
    }
}
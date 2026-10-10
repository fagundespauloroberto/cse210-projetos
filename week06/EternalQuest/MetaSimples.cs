using System;

namespace QuestDeMetas
{
    public class MetaSimples : Meta
    {
        // Atributo privado para controlar o estado de conclusão
        private bool _estaConcluida;

        // Construtor
        public MetaSimples(string nome, string descricao, int pontos) 
            : base(nome, descricao, pontos)
        {
            _estaConcluida = false; // Toda meta simples começa não concluída por padrão
        }

        // Implementação do método abstrato RegistrarEvento
        public override void RegistrarEvento()
        {
            _estaConcluida = true;
        }

        // Implementação do método abstrato EstaConcluida
        public override bool EstaConcluida()
        {
            return _estaConcluida;
        }

        // Formatação dos dados para salvar em arquivo (ex: MetaSimples:Nome,Descrição,Pontos,Concluida)
        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaSimples:{ObterNome()},{ObterDescricao()},{_pontos},{_estaConcluida}";
        }
    }
}
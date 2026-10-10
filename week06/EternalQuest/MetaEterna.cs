using System;

namespace QuestDeMetas
{
    public class MetaEterna : Meta
    {
        // Construtor
        public MetaEterna(string nome, string descricao, int pontos) 
            : base(nome, descricao, pontos)
        {
        }

        // Implementação do método abstrato RegistrarEvento
        public override void RegistrarEvento()
        {
            // Metas eternas não alteram estado interno de conclusão, 
            // apenas concedem os pontos a cada registro.
        }

        // Metas eternas nunca estão concluídas
        public override bool EstaConcluida()
        {
            return false;
        }

        // Formatação dos dados para salvar em arquivo (ex: MetaEterna:Nome,Descrição,Pontos)
        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaEterna:{ObterNome()},{ObterDescricao()},{_pontos}";
        }
    }
}
using System;

namespace QuestDeMetas
{
    public class MetaDeListaDeTarefas : Meta
    {
        // Atributos privados (Encapsulamento)
        private int _concluidas;
        private int _total;
        private int _bonus;

        // Construtor
        public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int total, int bonus) 
            : base(nome, descricao, pontos)
        {
            _concluidas = 0;
            _total = total;
            _bonus = bonus;
        }

        // Permite ajustar o contador ao carregar do arquivo
        public void DefinirConcluidas(int concluidas)
        {
            _concluidas = concluidas;
        }

        // Implementação do método RegistrarEvento
        public override void RegistrarEvento()
        {
            _concluidas++;
        }

        // Verifica se atingiu a quantidade total estipulada
        public override bool EstaConcluida()
        {
            return _concluidas >= _total;
        }

        // Sobrescreve (override) a exibição para incluir o progresso atual (ex: [ ] Nome (Descrição) -- Concluído: 3/5)
        public override string ObterDetalhesEmTexto()
        {
            string status = EstaConcluida() ? "[X]" : "[ ]";
            return $"{status} {ObterNome()} ({ObterDescricao()}) -- Concluído atualmente: {_concluidas}/{_total}";
        }

        // Formatação dos dados para salvar em arquivo (ex: MetaDeListaDeTarefas:Nome,Descrição,Pontos,Bónus,Total,Concluídas)
        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaDeListaDeTarefas:{ObterNome()},{ObterDescricao()},{_pontos},{_bonus},{_total},{_concluidas}";
        }
    }
}
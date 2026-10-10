using System;

namespace QuestDeMetas
{
    public abstract class Meta
    {
        // Atributos protegidos/privados (Encapsulamento)
        private string _nome;
        private string _descricao;
        protected int _pontos;

        // Construtor
        public Meta(string nome, string descricao, int pontos)
        {
            _nome = nome;
            _descricao = descricao;
            _pontos = pontos;
        }

        // Métodos Getters para acesso seguro
        public string ObterNome() => _nome;
        public string ObterDescricao() => _descricao;
        public int ObterPontos() => _pontos;

        // Método abstrato: TODA classe filha DEVE implementar sua própria regra de evento
        public abstract void RegistrarEvento();

        // Método abstrato ou virtual: verifica se a meta foi concluída
        public abstract bool EstaConcluida();

        // Retorna a formatação padrão em texto para exibição no console
        public virtual string ObterDetalhesEmTexto()
        {
            string status = EstaConcluida() ? "[X]" : "[ ]";
            return $"{status} {_nome} ({_descricao})";
        }

        // Método abstrato: formatação para salvar e carregar dados em arquivo
        public abstract string ObterRepresentacaoEmTexto();
    }
}
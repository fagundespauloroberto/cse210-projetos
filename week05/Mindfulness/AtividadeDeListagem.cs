using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class AtividadeDeListagem : Atividade
    {
        // Atributos privados (Encapsulamento)
        private int _contador;
        private List<String> _perguntas;
        private Random _random;

        // Construtor
        public AtividadeDeListagem() 
            : base("Atividade de Listagem", 
                   "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
        {
            _contador = 0;
            _random = new Random();

            // Inicialização da lista de perguntas/prompts
            _perguntas = new List<String>
            {
                "Quem são as pessoas que você aprecia?",
                "Quais são seus pontos fortes pessoais?",
                "Quem são as pessoas que você ajudou esta semana?",
                "Quando você sentiu o Espírito Santo neste mês?",
                "Quem são alguns dos seus heróis pessoais?"
            };
        }

        // Seleciona um prompt aleatório
        public string ObterPerguntaAleatoria()
        {
            int index = _random.Next(_perguntas.Count);
            return _perguntas[index];
        }

        // Lê os itens digitados pelo usuário até esgotar o tempo estipulado
        public List<String> ObterListaDoUsuario()
        {
            List<String> itens = new List<String>();
            DateTime tempoFinal = DateTime.Now.AddSeconds(ObterDuracao());

            while (DateTime.Now < tempoFinal)
            {
                Console.Write("> ");
                
                // Console.ReadLine bloqueia até o usuário apertar Enter
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    itens.Add(entrada);
                }
            }

            _contador = itens.Count;
            return itens;
        }

        // Método principal de execução da atividade
        public void Executar()
        {
            // 1. Exibe a mensagem inicial padrão
            ExibirMensagemInicial();

            // 2. Apresenta o prompt aleatório
            Console.WriteLine("\nListe o máximo de itens que puder sobre a seguinte instrução:");
            Console.WriteLine($"--- {ObterPerguntaAleatoria()} ---");
            Console.Write("Você pode começar em: ");
            ExibirContagemRegressiva(5);
            Console.WriteLine();

            // 3. Captura as entradas do usuário
            ObterListaDoUsuario();

            // 4. Exibe a quantidade de itens listados
            Console.WriteLine($"\nVocê listou {_contador} itens!");

            // 5. Exibe a mensagem final padrão
            ExibirMensagemFinal();
        }
    }
}
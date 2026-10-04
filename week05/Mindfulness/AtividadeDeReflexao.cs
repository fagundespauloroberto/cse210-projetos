using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class AtividadeDeReflexao : Atividade
    {

        private List<String> _reflexoes;
        private List<String> _perguntas;
        private Random _random;


        public AtividadeDeReflexao() 
            : base("Atividade de Reflexão", 
                   "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
        {
            _random = new Random();

            //lista de temas de reflexão
            _reflexoes = new List<String>
            {
                "Pense em uma ocasião em que você defendeu outra pessoa.",
                "Pense em uma ocasião em que você fez algo realmente difícil.",
                "Pense em uma ocasião em que você ajudou alguém necessitado.",
                "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
            };

            // lista de perguntas
            _perguntas = new List<String>
            {
                "Por que essa experiência foi significativa para você?",
                "Você já fez algo assim antes?",
                "Como você começou?",
                "Como você se sentiu quando terminou?",
                "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
                "Qual é a sua coisa favorita sobre essa experiência?",
                "O que você pode aprender com essa experiência que se aplica a outras situações?",
                "O que você aprendeu sobre si mesmo por meio dessa experiência?",
                "Como você pode manter essa experiência em mente no futuro?"
            };
        }

        public string ObterReflexoesAleatorias()
        {
            int index = _random.Next(_reflexoes.Count);
            return _reflexoes[index];
        }

        public string ObterPerguntasAleatorias()
        {
            int index = _random.Next(_perguntas.Count);
            return _perguntas[index];
        }

        public void ExibirReflexoes()
        {
            Console.WriteLine("\nConsidere o seguinte prompt:\n");
            Console.WriteLine($"--- {ObterReflexoesAleatorias()} ---");
            Console.WriteLine("\nQuando você tiver algo em mente, pressione Enter para continuar.");
            Console.ReadLine();
            Console.WriteLine("Agora reflita sobre cada uma das seguintes perguntas relacionadas a esta experiência.");
            Console.Write("Você pode começar em: ");
            ExibirContagemRegressiva(5);
            Console.Clear();
        }

        public void Executar()
        {
            ExibirMensagemInicial();

            ExibirReflexoes();

            // perguntas aleatórias com spinner enquanto houver tempo
            DateTime tempoFinal = DateTime.Now.AddSeconds(ObterDuracao());

            while (DateTime.Now < tempoFinal)
            {
                string pergunta = ObterPerguntasAleatorias();
                Console.Write($"\n> {pergunta} ");
                ExibirProgresso(10); //pausa por 10 segundos com o spinner
            }

            ExibirMensagemFinal();
        }
    }
}
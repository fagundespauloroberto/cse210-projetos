using System;

namespace Mindfulness
{
    //sintaxe : *Atividade* define que esta classe herda de Atividade
    public class ActividadeDeRespiracao : Atividade
    {
        //construtor passa o Nome e a Descrição padrão para a classe pai (base)
        public ActividadeDeRespiracao() 
            : base("Atividade de Respiração", 
                   "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
        {
        }

        // Método principal de execução da atividade
        public void Executar()
        {
            //chama a mensagem inicial da classe pai (pede o tempo e aguarda)
            ExibirMensagemInicial();

            int tempoRestante = ObterDuracao();

            //loop de respiração enquanto houver tempo restante
            while (tempoRestante > 0)
            {
                Console.Write("\nInspire...");
                ExibirContagemRegressiva(4);
                tempoRestante -= 4;

                if (tempoRestante <= 0) break;

                Console.Write("\nExpire...");
                ExibirContagemRegressiva(6);
                tempoRestante -= 6;
            }

            //mensagem final padrão da classe pai
            ExibirMensagemFinal();
        }
    }
}
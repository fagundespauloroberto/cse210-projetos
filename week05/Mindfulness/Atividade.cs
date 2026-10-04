using System;
using System.Collections.Generic;
using System.Threading;

// Usmos no namespace para evitar conflitos com bibliotecas externas(anotação para aprendizado)
namespace Mindfulness
{
    public class Atividade
    {
        private string _nome;
        private string _descricao;
        protected int _duracao; // protected para permitir leitura facil nas derivadas se necessario

        public Atividade(string nome, string descricao)
        {
            _nome = nome;
            _descricao = descricao;
            _duracao = 0;
        }

        //mensagem inicial padronizada
        public void ExibirMensagemInicial()
        {
            Console.Clear();
            Console.WriteLine($"Bem-vindo à {_nome}.\n");
            Console.WriteLine($"{_descricao}\n");
            Console.Write("Por quanto tempo, em segundos, você gostaria que a sessão durasse? ");
            
            int duracaoEntrada;
            while (!int.TryParse(Console.ReadLine(), out duracaoEntrada) || duracaoEntrada <= 0)
            {
                Console.Write("Por favor, insira um número inteiro válido maior que zero: ");
            }
            _duracao = duracaoEntrada;

            Console.Clear();
            Console.WriteLine("Prepare-se...");
            ExibirProgresso(5); //pausa com spinner por 5 segundos
        }

        public void ExibirMensagemFinal()
        {
            Console.WriteLine("\nMandou muito bem!!");
            ExibirProgresso(3);
            Console.WriteLine($"\nVocê concluiu mais {_duracao} segundos da atividade {_nome}.");
            ExibirProgresso(5);
        }

        // Animação de progresso (Spinner)
        public void ExibirProgresso(int segundos)
        {
            List<String> animacaoSpinner = new List<String> { "|", "/", "-", "\\" };
            DateTime tempoInicio = DateTime.Now;
            DateTime tempoFim = tempoInicio.AddSeconds(segundos);

            int i = 0;
            while (DateTime.Now < tempoFim)
            {
                string simbolo = animacaoSpinner[i];
                Console.Write(simbolo);
                Thread.Sleep(250);
                Console.Write("\b \b"); // Apaga o caractere anterior no console

                i++;
                if (i >= animacaoSpinner.Count)
                {
                    i = 0;
                }
            }
        }

        //animação de contagem regressiva numérica
        public void ExibirContagemRegressiva(int segundos)
        {
            for (int i = segundos; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                
                //trata o apagar de números com mais de um dígito
                if (i >= 10)
                {
                    Console.Write("\b\b  \b\b");
                }
                else
                {
                    Console.Write("\b \b");
                }
            }
        }

        public int ObterDuracao()
        {
            return _duracao;
        }

    }
}
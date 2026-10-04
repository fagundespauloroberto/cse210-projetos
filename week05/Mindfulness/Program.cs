using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("************************************");
                Console.WriteLine("    Programa de Introspecção        ");
                Console.WriteLine("************************************");
                Console.WriteLine("  1. Iniciar Atividade de Respiração");
                Console.WriteLine("  2. Iniciar Atividade de Reflexão  ");
                Console.WriteLine("  3. Iniciar Atividade de Listagem  ");
                Console.WriteLine("  4. Sair                           ");
                Console.WriteLine("************************************");
                Console.Write("Selecione uma escolha no menu (1-4): ");

                string opcao = Console.ReadLine()?.Trim().ToLower();

                switch (opcao)
                {
                    case "1":
                        ActividadeDeRespiracao atividadeResp = new ActividadeDeRespiracao();
                        atividadeResp.Executar();
                        break;

                    case "2":
                        AtividadeDeReflexao atividadeRefl = new AtividadeDeReflexao();
                        atividadeRefl.Executar();
                        break;

                    case "3":
                        AtividadeDeListagem atividadeList = new AtividadeDeListagem();
                        atividadeList.Executar();
                        break;

                    case "4":
                    case "sair":
                        Console.WriteLine("\nObrigado por usar o aplicativo de Introspecção!");
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Escolha um número de 1 a 4 ou digite 'sair'.");
                        Console.WriteLine("Pressione Enter para tentar novamente...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
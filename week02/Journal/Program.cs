using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! Projeto da semana 2- Diário.");
        
        //aqui instanciamos as classes, Diario e Gerenciados
        Diario meuDiario = new Diario();
        GeradorDePerguntas meuGerador = new GeradorDePerguntas();

        bool executando = true;

        while (executando)
        {
            Console.WriteLine("*** DIÁRIO **");
            Console.WriteLine("1. Escrever novo registro");
            Console.WriteLine("2. Exibir todos os registros");
            Console.WriteLine("3. Salvar em arquivo (Não implementado)");
            Console.WriteLine("4. Carregar de arquivo (Não Implementado)");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":        
                    // sorteio pergunta aleatória
                    string pergunta = meuGerador.ObterPerguntaAleatoria();
                    Console.WriteLine($"\nPergunta do dia: {pergunta}");

                    // pegamos a resposta do usuário
                    Console.Write("Sua resposta: ");
                    string resposta = Console.ReadLine();
                    //data atual formatada
                    string dataHoje = DateTime.Now.ToShortDateString();

                    // objeto Registro passando os dados no construtor
                    Registro novoRegistro = new Registro(dataHoje, pergunta, resposta);
                    //Do registro ao Diário e exibimos a lista
                    meuDiario.AdicionarRegistro(novoRegistro);

                    Console.WriteLine("\nRegistro adicionado com sucesso!\n");
                    break;
                
                case "2":
                    meuDiario.ExibirTodos();
                    break;
                
                case "3":
                    Console.WriteLine("Funcionalidade de salvar não implementada.\n");
                    break;

                case "4":
                    Console.WriteLine("Funcionalidade de carregar não implementada.\n");
                    break;

                case "5":
                    executando = false;
                    Console.WriteLine("Encerrando o Diário.!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.\n");
                    break;
            }
        }       
    }
}
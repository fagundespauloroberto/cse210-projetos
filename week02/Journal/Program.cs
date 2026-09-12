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
            Console.WriteLine("** MEU DIÁRIO **");
            Console.WriteLine("1. Escrever novo registro");
            Console.WriteLine("2. Exibir todos os registros");
            Console.WriteLine("3. Salvar em arquivo(informe o nome do arquivo seguido de .txt)");
            Console.WriteLine("4. Carregar de arquivo (informe o nome do arquivo seguido de .txt)");
            Console.WriteLine("0. Sair");
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
                    Console.Write("Por favor, informe o nome do arquivo para salvar (ex: diario.txt): ");
                    string nomeArquivoSalvar = Console.ReadLine();
                    meuDiario.SalvarNoArquivo(nomeArquivoSalvar);
                    break;

                case "4":
                    Console.Write("Por favor, informe o nome do arquivo para carregar (ex: diario.txt): ");
                    string nomeArquivoCarregar = Console.ReadLine();
                    meuDiario.CarregarDoArquivo(nomeArquivoCarregar);
                    break;

                case "0":
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
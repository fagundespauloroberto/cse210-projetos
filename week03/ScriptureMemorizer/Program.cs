using System;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao sistema para ajudar a memorizar escrituras.");
            Console.WriteLine(" **PRATIC THE ESCRIPTURES * ");
            Console.WriteLine("1. Praticar uma escritura aleatória:");
            Console.WriteLine("2. Cadastrar nova escritura:");
            Console.WriteLine("3. Salvar biblioteca em arquivo:");
            Console.WriteLine("4. Carregar biblioteca de arquivo:");
            Console.WriteLine("5. Apresentar lista de Escrituras Salvas:");
            Console.WriteLine("OBS.: Se deseja manter os registro em seu arquivo, nunca grave sem carregar o arquivo antes.");
            Console.WriteLine("Digite 'sair' para encerrar o sistema.");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine()?.Trim().ToLower();

            if (opcao == "sair")
            {
                executando = false;
            }
            else if (opcao == "1")
            {
                PraticarEscritura(biblioteca.ObterEscrituraAleatoria());
            }
            else if (opcao == "2")
            {
                CadastrarNovaEscritura(biblioteca);
            }
            else if (opcao == "3")
            {
                Console.Write("Digite o nome do arquivo para salvar (ex: escrituras.txt): ");
                string arquivo = Console.ReadLine();
                biblioteca.SalvarEmArquivo(arquivo);
                Console.ReadLine();
            }
            else if (opcao == "4")
            {
                Console.Write("Digite o nome do arquivo para carregar (ex: escrituras.txt): ");
                string arquivo = Console.ReadLine();
                biblioteca.CarregarDeArquivo(arquivo);
                Console.ReadLine();
            }
            else if (opcao == "5")
            {
                biblioteca.ExibirTodas();
            }
        }

        Console.WriteLine("\nPrograma encerrado. Obrigado pelo seu empenho em conhecer mais o Senhor!");
    }

    static void PraticarEscritura(Escritura escritura)
    {
        if (escritura == null) return;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(escritura.ObterTextoExibicao());
            Console.WriteLine();

            if (escritura.CompletamenteEscondida())
            {
                Console.WriteLine("Parabéns! Você concluiu esta escritura.");
                Console.WriteLine("Espero que tenha te ajudado a memorizar, mas se sim a vontade para voltar quando quiser.");
                Console.WriteLine("Pressione Enter para voltar ao menu principal...");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("Pressione 'Enter' para esconder mais palavras ou digite 'sair' para voltar ao menu:");
            string entrada = Console.ReadLine()?.Trim().ToLower();

            if ((entrada == "sair") || (entrada == "SAIR") || (entrada == "Sair"))
            {
                break;
            }

            escritura.EsconderPalavrasAleatorias(3);
        }
    }

    static void CadastrarNovaEscritura(Biblioteca biblioteca)
    {
        Console.Clear();
        Console.WriteLine(" =**** CADASTRO DE ESCRITURA ****= ");
        
        Console.Write("Livro (ex: Nefi ou Nf): ");
        string livro = Console.ReadLine();

        // tratamento para evitar entrada de texto e erro quando isso acontece...
        //Console.Write("Capítulo: ");
        //int capitulo = int.Parse(Console.ReadLine());
        //Console.Write("Versículo inicial: ");
        //int vInicial = int.Parse(Console.ReadLine());
        int capitulo = LerNumeroInteiro("Capítulo: ");
        int vInicial = LerNumeroInteiro("Versículo inicial: ");
        
        // não foi possivel tratar, devido a necessidade de deixar mais usual, onde o usuário clica e pode gravar o mesmo versiculo...
        // analisar como poderiamos tratar aqui...
        //int vFinal   = LerNumeroInteiro("Versículo final (pressione 'Enter' se for apenas um versículo): ");
        Console.Write("Versículo final (se for apenas um, repita o versículo.): ");
        string vFinalInput = Console.ReadLine();

        Referencia novaReferencia;

        if (string.IsNullOrWhiteSpace(vFinalInput))
        {
            novaReferencia = new Referencia(livro, capitulo, vInicial);
        }
        else
        {
            int vFinal;
            while(!int.TryParse(vFinalInput, out vFinal) || vFinal < vInicial)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Versículo final inválido! Deve ser um número maior ou igual ao versículo inicial.");
                Console.ResetColor();

                Console.Write("Versículo final (pressione Enter se for o mesmo): ");
                vFinalInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(vFinalInput))
                {
                    break;
                }
            }

        if (string.IsNullOrWhiteSpace(vFinalInput))
        {
            novaReferencia = new Referencia(livro, capitulo, vInicial);
        }
        else
        {
            //int vFinal = int.Parse(vFinalInput);
            novaReferencia = new Referencia(livro, capitulo, vInicial, vFinal);
        }

        Console.Write("Texto da escritura: ");
        string texto = Console.ReadLine();

        biblioteca.AdicionarEscritura(novaReferencia, texto);
        Console.WriteLine("\nEscritura cadastrada com sucesso! Pressione Enter para continuar...");
        Console.ReadLine();

    }

    // validação pra evitar texto nas entradas dos numeros
    static int LerNumeroInteiro(string mensagem)
    {
        int numero;
        Console.Write(mensagem);
        string entrada = Console.ReadLine();

        // Enquanto a conversão falhar ou o número for menor/igual a zero
        while (!int.TryParse(entrada, out numero) || numero <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrada inválida! Por favor, digite apenas números inteiros maiores que zero.");
            Console.ResetColor();

            Console.Write(mensagem);
            entrada = Console.ReadLine();
        }

        return numero;
    }
}
}
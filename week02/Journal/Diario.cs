using System;
using System.Collections.Generic; //usamos a biblioteca para reconher a lista...
using System.IO; // usamos essa biblioteca para trabalhar com arquivos...

public class Diario
{
    // privada para garantir o encapsulamento
    private List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        Console.WriteLine("Registros do Diário");

        // Notice the use of the custom data type "Job" in this loop
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }

    }
    public void SalvarNoArquivo(string arquivo)
    {
        // tratamento com *using* para garantir o fechamento do arquivo ao terminar
        using (StreamWriter nomeDoArquivo = new StreamWriter(arquivo))
        {
            foreach (Registro registro in _registros)
            {
                //formatamos os registro separados por ; (ponto e virgula) na linha
                // Acessamos os dados via concatenação ou métodos auxiliares
                nomeDoArquivo.WriteLine($"{registro.GetData()};{registro.GetPergunta()};{registro.GetResposta()}");
            }
        }

        Console.WriteLine($"Diário salvo com sucesso no arquivo '{arquivo}'!\n");
    }

    public void CarregarDoArquivo(string arquivo)
    {
        // validação do arquivo existe no disco
        if (!File.Exists(arquivo))
        {
            Console.WriteLine($"Erro: O arquivo '{arquivo}' não foi encontrado.\n");
            return;
        }

        //limpa registros em memória para carregar do arquivo
        _registros.Clear();

        //leitura das linhas do arquivo de uma só vez
        string[] linhas = File.ReadAllLines(arquivo);

        foreach (string linha in linhas)
        {
            // Separa a linha em partes onde houver o caractere ';'
            string[] partes = linha.Split(';');

            // valida na linha se possui exatamente os 3 campos (Data, Pergunta, Resposta)
            if (partes.Length == 3)
            {
                string data = partes[0];
                string pergunta = partes[1];
                string resposta = partes[2];

                //objeto Registro e adiciona à lista
                Registro registro = new Registro(data, pergunta, resposta);
                _registros.Add(registro);
            }
        }

        Console.WriteLine($"Diário carregado com sucesso! {linhas.Length} registro(s) importado(s).\n");
    }

}
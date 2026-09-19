using System;
using System.Collections.Generic;

public class Biblioteca
{
    private List<Escritura> _escrituras = new List<Escritura>();
    private Random _random = new Random();

    public Biblioteca()
    {
        // escrituras de exemplo
        // carga inicial
        AdicionarEscritura(new Referencia("1 Nefi", 3, 7), "Eu irei e cumprirei as ordens do Senhor, porque sei que o Senhor nunca dá ordens aos filhos dos homens sem antes preparar um caminho pelo qual suas ordens possam ser cumpridas");
        AdicionarEscritura(new Referencia("D&C", 84, 88), "E quem vos receber, lá estarei também, pois irei adiante de vós. Estarei à vossa direita e à vossa esquerda e meu Espírito estará em vosso coração e meus anjos ao vosso redor para vos suster.");
        AdicionarEscritura(new Referencia("Provérbios", 3, 5, 6), "Confia no Senhor de todo o teu coração e não te estribes no teu próprio entendimento.");
        AdicionarEscritura(new Referencia("João", 3, 16), "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito.");
        AdicionarEscritura(new Referencia("Romanos", 3, 24), "Sendo justificados gratuitamente pela sua graça, pela redenção que há em Cristo Jesus");
        AdicionarEscritura(new Referencia("Filipenses", 4, 13), "Tudo posso naquele que me fortalece.");
    }

    public void AdicionarEscritura(Referencia referencia, string texto)
    {
        _escrituras.Add(new Escritura(referencia, texto));
    }

    public Escritura ObterEscrituraAleatoria()
    {
        if (_escrituras.Count == 0) return null;

        int indice = _random.Next(_escrituras.Count);
        //nova instância da escritura para resetar o estado das palavras
        Referencia refOriginal = _escrituras[indice].ObterReferencia();
        string textoOriginal = _escrituras[indice].ObterTextoBruto();

        return new Escritura(refOriginal, textoOriginal);
    }

    public void SalvarEmArquivo(string arquivo)
    {
        using (StreamWriter writer = new StreamWriter(arquivo))
        {
            foreach (Escritura escritura in _escrituras)
            {
                Referencia refObj = escritura.ObterReferencia();
                
            //formato: Livro;Capitulo;VersiculoInicial;VersiculoFinal;Texto
                string linha = $"{refObj.GetLivro()};{refObj.GetCapitulo()};{refObj.GetVersiculoInicial()};{refObj.GetVersiculoFinal()};{escritura.ObterTextoBruto()}";
                writer.WriteLine(linha);
            }
        }

        Console.WriteLine($"\nBiblioteca salva com sucesso no arquivo '{arquivo}'!");
    }

    public void CarregarDeArquivo(string arquivo)
    {
        if (!File.Exists(arquivo))
        {
            Console.WriteLine($"\nErro: O arquivo '{arquivo}' não foi encontrado.");
            return;
        }

        _escrituras.Clear(); // Limpa as escrituras padrão para carregar as do arquivo
        string[] linhas = File.ReadAllLines(arquivo);

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split(';');

            if (partes.Length == 5)
            {
                string livro = partes[0];
                int capitulo = int.Parse(partes[1]);
                int vInicial = int.Parse(partes[2]);
                int vFinal = int.Parse(partes[3]);
                string texto = partes[4];

                Referencia referencia = new Referencia(livro, capitulo, vInicial, vFinal);
                AdicionarEscritura(referencia, texto);
            }
        }

        Console.WriteLine($"\n{linhas.Length} escritura(s) carregada(s) com sucesso!");
    }

    public void ExibirTodas()
    {
        Console.Clear();
        Console.WriteLine("Registros do Arquivo");
        
        if (_escrituras.Count == 0)
        {
            Console.WriteLine("Nenhuma escritura encontrada na Biblioteca.");   
        }
        else
        {
            foreach (Escritura registro in _escrituras)
            {
                Console.WriteLine($"{registro.ObterTextoExibicao()}");
            }
        }
        Console.WriteLine("\nPressione Enter para voltar ao menu...");
        Console.ReadLine();
    }    

}
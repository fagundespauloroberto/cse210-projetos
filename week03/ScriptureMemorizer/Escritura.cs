using System;
using System.Collections.Generic;

public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras = new List<Palavra>();
    private string _textoBruto;
    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _textoBruto = texto;
        
        //quebra o texto completo em palavras individuais separadas por espaco
        string[] palavrasBrutas = texto.Split(' ');
        
        //transforma cada string em um objeto do tipo Palavra
        foreach (string palavra in palavrasBrutas)
        {
            _palavras.Add(new Palavra(palavra));
        }
    }

    //esconde uma quantidade especificada de palavras aleatórias(palavras ainda não escondidas)
    public void EsconderPalavrasAleatorias(int quantidadeParaEsconder)
    {
        Random random = new Random();

        // filtramos apenas as palavras que ainda estão visíveis
        List<Palavra> palavrasVisiveis = _palavras.FindAll(p => !p.EstaOculta());

        // não houvendo palavras visíveis suficientes, esconde as restantes
        int quantidadeEfetiva = Math.Min(quantidadeParaEsconder, palavrasVisiveis.Count);

        for (int i = 0; i < quantidadeEfetiva; i++)
        {
            int indiceSorteado = random.Next(palavrasVisiveis.Count);
            palavrasVisiveis[indiceSorteado].Ocultar();
            
            // Tira da lista auxiliar para não sortear a mesma palavra duas vezes no mesmo ciclo
            palavrasVisiveis.RemoveAt(indiceSorteado);
        }
    }

    //linha completa para exibição no console (Referência + Texto com sublinhados)
    public string ObterTextoExibicao()
    {
        List<string> textosPalavras = new List<string>();

        foreach (Palavra palavra in _palavras)
        {
            textosPalavras.Add(palavra.GetTexto());
        }

        string textoFormatado = string.Join(" ", textosPalavras);
        return $"{_referencia.GetTextoExibicao()} - {textoFormatado}";
    }

    //retorna true quando TODAS as palavras da escritura já estiverem escondidas
    public bool CompletamenteEscondida()
    {
        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaOculta())
            {
                return false; //encontrando ao menos uma visível, ainda não terminou
            }
        }

        return true;
    }   

    public Referencia ObterReferencia() => _referencia.ObterCopia();
    public string ObterTextoBruto() => _textoBruto;

}
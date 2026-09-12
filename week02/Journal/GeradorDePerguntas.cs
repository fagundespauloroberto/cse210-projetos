using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    // privada para garantir o encapsulamento
    private List<String> _perguntas = new List<String>();

    public GeradorDePerguntas()
    {
        _perguntas.Add("Quem foi a pessoa mais interessante com quem conversou hoje?");
        _perguntas.Add("Qual foi a melhor parte do seu dia?");
        _perguntas.Add("Como você viu a mão do Senhor no seu viver hoje?");
        _perguntas.Add("Qual foi uma emoção forte que sentiu hoje?");
        _perguntas.Add("Se pudesse repetir algo que fez hoje, o que seria?");
        _perguntas.Add("Você conseguiu de alguma forma se aproximar do Pai Celestial hoje?");
        _perguntas.Add("Você conseguiu ajudar alguém hoje?");
    }

    public string ObterPerguntaAleatoria()
    {
        // metodo randomico para sorterar entre as perguntas, de forma aleatoria...
        Random random = new Random();
        int indice = random.Next(_perguntas.Count);
        return _perguntas[indice];   
    }

}
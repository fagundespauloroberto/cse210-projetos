using System;

public class Registro
{
    public string _data;
    public string _textoPergunta;
    public string _textoResposta;

    public Registro(string data, string textoPergunta, string textoResposta)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoResposta = textoResposta;
    }

    // metodos necessários para a leitura dos dados quando privados...
    public string GetData()
    {
        return _data;
    }

    public string GetPergunta()
    {
        return _textoPergunta;
    }

    public string GetResposta()
    {
        return _textoResposta;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} - Pergunta: {_textoPergunta}");
        Console.WriteLine($"Resposta: {_textoResposta}");
        Console.WriteLine();
    }    
    public void Exibir2()
    {
        Console.WriteLine($"{_data} ({_textoPergunta}) {_textoResposta}");
    }

}
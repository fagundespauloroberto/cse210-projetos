using System;

public class Palavra
{
    private string _texto;
    private bool _estaOculta;

    public Palavra(string texto)
    {
        _texto = texto;
        _estaOculta = false;
    }

    public void Ocultar()
    {
        _estaOculta = true;
    }    
    public void Exibir()
    {
        Console.WriteLine($"Pergunta: {_texto}");
        Console.WriteLine();
    }

    public bool EstaOculta()
    {
        return _estaOculta;
    }

    // metodos necessários para a leitura dos dados quando privados...
    public string GetTexto()
    {
        if (_estaOculta)
        {
            //string com o caractere '_' repetido N vezes (tamanho da palavra)
            return new string('_', _texto.Length);
        }

        return _texto;
    }

}
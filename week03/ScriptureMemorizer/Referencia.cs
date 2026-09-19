using System;

public class Referencia
{
    public string _livro;
    public int _capitulo;
    public int _versiculoInicial;
    public int _versiculoFinal;
    public string GetLivro() => _livro;
    public int GetCapitulo() => _capitulo;
    public int GetVersiculoInicial() => _versiculoInicial;
    public int GetVersiculoFinal() => _versiculoFinal;    

    public Referencia(string livro, int capitulo, int versiculo)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculoInicial = versiculo;
        _versiculoFinal = versiculo; // tratativa para quando o final é igual ao inicio
    }

    public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculoInicial = versiculoInicial;
        _versiculoFinal = versiculoFinal;
    }

    public string GetTextoExibicao()
    {
        if (_versiculoInicial == _versiculoFinal)
        {
            return $"{_livro} {_capitulo}:{_versiculoInicial}";
        }

        return $"{_livro} {_capitulo}:{_versiculoInicial}-{_versiculoFinal}";
    }

    public Referencia ObterCopia()
    {
        return new Referencia(_livro, _capitulo, _versiculoInicial, _versiculoFinal);
    }

}
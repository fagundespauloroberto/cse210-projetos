using System;

public class Fracao
{
    private int _numerador;
    private int _denominador;

    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    public Fracao(int numInteiro)
    {
        _numerador = numInteiro;
        _denominador = 1;
    }

    public Fracao(int numerador, int denominador)
    {
        _numerador = numerador;
        _denominador = denominador;
    }

    public string GetFracaoEmTexto()
    {
        //variável temporária e local que será recalculada cada vez que for chamada.
        string texto = $"{_numerador}/{_denominador}";
        return texto;
    }

    public double GetFracaoEmDecimal()
    {
        //recalculado cada vez que for chamada.
        return (double)_numerador / (double)_denominador;
    }
}
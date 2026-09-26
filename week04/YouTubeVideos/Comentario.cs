using System;
using System.Collections.Generic;

public class Comentario
{
    public string _nomePessoa;
    public string _texto;   

    public Comentario(string nomePessoa, string texto)
    {
        _nomePessoa = nomePessoa;
        _texto = texto;
    }
    public string ObterNomeAutor() => _nomePessoa;
    public string ObterTexto() => _texto;
}
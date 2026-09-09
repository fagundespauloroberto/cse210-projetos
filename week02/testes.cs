    // Um modelo de código para a categoria de coisas conhecida como Pessoa. A
    // responsabilidade de Pessoa é manter e exibir informações pessoais.

using System;

public class Pessoa
{
    // A convenção C# é iniciar variáveis membro com um sublinhado _
    public string _primeiroNome = "";
    public string _sobrenome = "";

    // Um método especial, chamado construtor, que é invocado usando a  
    // nova palavra-chave seguida pelo nome da classe e parênteses.
    static void Main(string[] args)
    {
        Pessoa pessoa = new Pessoa();
        pessoa._primeiroNome = "Joseph";
        pessoa._sobrenome = "Smith";
        pessoa.ObterNomeSobrenome();
        pessoa.ObterSobrenomeNome();
    }

    // Um método que exibe o nome da pessoa no formato 
    // <primeiro nome e sobrenome>.
    public void ObterNomeSobrenome()
    {
        Console.WriteLine($"{_primeiroNome} {_sobrenome}");
    }

    // Um método que exibe o nome da pessoa no formato 
    // <sobrenome, primeiro nome>.
    public void ObterSobrenomeNome()
    {
        Console.WriteLine($"{_sobrenome}, {_primeiroNome}");
    }
}
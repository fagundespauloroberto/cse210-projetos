using System;

class Program
{
    static void Main(string[] args)
    {
        MensagemBoasVindas();

        string respnomeUsuario = NomeUsuario();
        int respnumeroUsuario = NumeroUsuario();

        int numeroAoQuadrado = NumeroAoQuadrado(respnumeroUsuario);

        ExibirResultado(respnomeUsuario, numeroAoQuadrado);
    }

    static void MensagemBoasVindas()
    {
        Console.WriteLine("Olá, seja bem vindo ao sistema!");
    }

    static string NomeUsuario()
    {
        Console.Write("Por favor digite seu nome: ");
        string nome = Console.ReadLine();

        return nome;
    }

    static int NumeroUsuario()
    {
        Console.Write("Por favor digite seu numero favorito: ");
        int numero = int.Parse(Console.ReadLine());

        return numero;
    }

    static int NumeroAoQuadrado(int numero)
    {
        int quadrado = numero * numero;
        return quadrado;
    }

    static void ExibirResultado(string nome, int quadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {quadrado}");
    }
}
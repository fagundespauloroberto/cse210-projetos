using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seja bem vindo ao Projeto de Frações.");
        
        Fracao f1 = new Fracao();
        Console.WriteLine(f1.GetFracaoEmTexto());
        Console.WriteLine(f1.GetFracaoEmDecimal());

        Fracao f2 = new Fracao(5);
        Console.WriteLine(f2.GetFracaoEmTexto());
        Console.WriteLine(f2.GetFracaoEmDecimal());

        Fracao f3 = new Fracao(3, 4);
        Console.WriteLine(f3.GetFracaoEmTexto());
        Console.WriteLine(f3.GetFracaoEmDecimal());

        Fracao f4 = new Fracao(1, 3);
        Console.WriteLine(f4.GetFracaoEmTexto());
        Console.WriteLine(f4.GetFracaoEmDecimal());
    }
}
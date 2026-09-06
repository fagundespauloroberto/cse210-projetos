using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, seja bem vindo ao sistema.");

         //Console.Write("Qual é o número mágico? ");
         //int numeroMagico = int.Parse(Console.ReadLine());
        
        // número aleatório
        Random geradorRandomico = new Random();
        int numeroMagico = geradorRandomico.Next(1, 101);

        int palpite = -1;

        // do-while
        while (palpite != numeroMagico)
        {
            Console.Write("Qual o seu palpite? ");
            palpite = int.Parse(Console.ReadLine());

            if (numeroMagico > palpite)
            {
                Console.WriteLine("Maior");
            }
            else if (numeroMagico < palpite)
            {
                Console.WriteLine("Menor");
            }
            else
            {
                Console.WriteLine("Você adivinhou!");
            }

        }                            
    }
}
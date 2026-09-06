using System;

class Program
{18
   static void Main(string[] args)
    {
        Console.WriteLine("Olá, seja bem vindo ao sistema.");
        List<int> numeros = new List<int>();
        
        // do-while 
        int numeroUsuario = -1;
        while (numeroUsuario != 0)
        {
            Console.Write("Digite um número (0 para sair): ");
            
            string respostaUsuario = Console.ReadLine();
            numeroUsuario = int.Parse(respostaUsuario);
            
            // Validação do numero 0
            if (numeroUsuario != 0)
            {
                numeros.Add(numeroUsuario);
            }
        }

        // Calcule a soma
        int soma = 0;
        foreach (int numero in numeros)
        {
            soma += numero;
        }

        Console.WriteLine($"A soma é: {soma}");

        //Calcular a média
        float media = ((float)soma) / numeros.Count;
        Console.WriteLine($"A média é: {media}");

        //Encontre o maior
        int maior = numeros[0];

        foreach (int numero in numeros)
        {
            if (numero > maior)
            {
                // se esse número for maior que 'maior', nós encontramos o novo valor para 'maior'!
                maior = numero;
            }
        }

        Console.WriteLine($"O maior valor é: {maior}");
    }
}
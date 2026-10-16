using System;
using System.Collections.Generic;

namespace MonitoramentoExercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            //criando a lista polimorfica de atividades
            List<Atividade> atividades = new List<Atividade>();

            //instanciando cada tipo de atividade
            Corrida corrida1 = new Corrida("03 Nov 2022", 30, 4.8);
            Ciclismo ciclismo1 = new Ciclismo("03 Nov 2022", 45, 20.0);
            Natacao natacao1 = new Natacao("04 Nov 2022", 40, 40);

            //adicionando as atividades na mesma lista
            atividades.Add(corrida1);
            atividades.Add(ciclismo1);
            atividades.Add(natacao1);

            Console.WriteLine("=***** MONITORAMENTO DE EXERCÍCIOS *****=\n");

            //iteração sobre a lista polimorfica(exibir resumos)
            foreach (Atividade atividade in atividades)
            {
                Console.WriteLine(atividade.ObterResumo());
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
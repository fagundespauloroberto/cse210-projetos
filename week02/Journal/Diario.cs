using System;
using System.Collections.Generic; //usamos a biblioteca para reconher a lista...

public class Diario
{
    // privada para garantir o encapsulamento
    private List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        Console.WriteLine("Registros do Diário");

        // Notice the use of the custom data type "Job" in this loop
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }

    }
    public void SalvarNoArquivo(string arquivo)
    {
        
    }

    public void CarregarDoArquivo(string arquivo)
    {
        
    }

}
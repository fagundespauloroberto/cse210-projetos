using System;

class Program
{
    static void Main(string[] args)
    {
        // --- PEDIDO 1 (Cliente nos EUA) ---
        Endereco endereco1 = new Endereco("123 Main Street", "Salt Lake City", "UT", "EUA");
        Cliente cliente1 = new Cliente("John Doe", endereco1);
        Pedido pedido1 = new Pedido(cliente1);

        pedido1.AdicionarProduto(new Produto("Teclado Mecânico", "PROD-001", 89.90m, 1));
        pedido1.AdicionarProduto(new Produto("Mouse Sem Fio", "PROD-002", 25.50m, 2));

        // --- PEDIDO 2 (Cliente Internacional - Brasil) ---
        Endereco endereco2 = new Endereco("Rua Voluntario da Patria, 111", "Xaxim", "SC", "Brasil");
        Cliente cliente2 = new Cliente("Paulo Roberto Fagundes", endereco2);
        Pedido pedido2 = new Pedido(cliente2);

        pedido2.AdicionarProduto(new Produto("Monitor 27 Polegadas", "PROD-003", 299.00m, 1));
        pedido2.AdicionarProduto(new Produto("Suporte Articulado", "PROD-004", 45.00m, 1));
        pedido2.AdicionarProduto(new Produto("Cabo HDMI 2.1", "PROD-005", 12.00m, 3));

        // --- EXIBIÇÃO DO PEDIDO 1 ---
        Console.WriteLine("==================================================");
        Console.WriteLine("                  PEDIDO #1                       ");
        Console.WriteLine("==================================================");
        Console.WriteLine(pedido1.ObterEtiquetaEmbalagem());
        Console.WriteLine(pedido1.ObterEtiquetaEnvio());
        Console.WriteLine($"Preço Total do Pedido:${pedido1.CalcularCustoTotal():F2}\n");

        // --- EXIBIÇÃO DO PEDIDO 2 ---
        Console.WriteLine("==================================================");
        Console.WriteLine("                  PEDIDO #2                       ");
        Console.WriteLine("==================================================");
        Console.WriteLine(pedido2.ObterEtiquetaEmbalagem());
        Console.WriteLine(pedido2.ObterEtiquetaEnvio());
        Console.WriteLine($"Preço Total do Pedido:${pedido2.CalcularCustoTotal():F2}\n");
    }
}

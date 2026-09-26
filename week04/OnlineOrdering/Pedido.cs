using System;
using System.Collections.Generic;
using System.Text;

public class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public decimal CalcularCustoTotal()
    {
        decimal totalProdutos = 0;
        foreach (Produto produto in _produtos)
        {
            totalProdutos += produto.CalcularCustoTotal();
        }

        decimal custoEnvio = _cliente.MoraNosEUA() ? 5.00m : 35.00m;
        return totalProdutos + custoEnvio;
    }

    public string ObterEtiquetaEmbalagem()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("ETIQUETA DE EMBALAGEM:");
        foreach (Produto produto in _produtos)
        {
            sb.AppendLine($"- ID: {produto.ObterIdProduto()} | Produto: {produto.ObterNome()}");
        }
        return sb.ToString();
    }

    public string ObterEtiquetaEnvio()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("ETIQUETA DE ENVIO:");
        sb.AppendLine(_cliente.ObterNome());
        sb.AppendLine(_cliente.ObterEndereco().ObterEnderecoFormatado());
        return sb.ToString();
    }
}

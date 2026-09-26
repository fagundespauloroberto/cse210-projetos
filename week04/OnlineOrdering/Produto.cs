public class Produto
{
    private string _nome;
    private string _idProduto;
    private decimal _preco;
    private int _quantidade;

    public Produto(string nome, string idProduto, decimal preco, int quantidade)
    {
        _nome = nome;
        _idProduto = idProduto;
        _preco = preco;
        _quantidade = quantidade;
    }

    public decimal CalcularCustoTotal()
    {
        return _preco * _quantidade;
    }

    public string ObterNome() => _nome;
    public string ObterIdProduto() => _idProduto;
}
public class Cliente
{
    private string _nome;
    private Endereco _endereco;

    public Cliente(string nome, Endereco endereco)
    {
        _nome = nome;
        _endereco = endereco;
    }

    public bool MoraNosEUA()
    {
        return _endereco.EhEUA();
    }

    public string ObterNome() => _nome;
    public Endereco ObterEndereco() => _endereco;
}
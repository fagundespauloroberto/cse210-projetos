public class Endereco
{
    private string _rua;
    private string _cidade;
    private string _estado;
    private string _pais;

    public Endereco(string rua, string cidade, string estado, string pais)
    {
        _rua = rua;
        _cidade = cidade;
        _estado = estado;
        _pais = pais;
    }

    public bool EhEUA()
    {
        return _pais.Trim().ToUpper() == "EUA" || _pais.Trim().ToUpper() == "USA";
    }

    public string ObterEnderecoFormatado()
    {
        return $"{_rua}\n{_cidade}, {_estado}\n{_pais}";
    }
}
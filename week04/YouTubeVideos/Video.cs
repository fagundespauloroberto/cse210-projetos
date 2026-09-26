using System.Collections.Generic;

public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracaoSegundos;
    private List <Comentario> _comentarios;

    public Video(string titulo, string autor, int duracaoSegundos)
    {
        _titulo = titulo;
        _autor = autor;
        _duracaoSegundos = duracaoSegundos;
        _comentarios = new List<Comentario>();  
    }

    public void AdicionarComentario(string autor, string texto)
    {
        _comentarios.Add(new Comentario(autor, texto));
    }

    public int ObterQuantidadeComentarios()
    {
        return _comentarios.Count;
    }

    public string ObterTitulo() => _titulo;
    public string ObterAutor() => _autor;
    public int ObterDuracao() => _duracaoSegundos;
    public List<Comentario> ObterComentarios() => _comentarios; 
}
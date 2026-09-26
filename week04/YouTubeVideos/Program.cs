using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> listaVideos = new List<Video>();

        // --- VÍDEO 1 ---
        Video video1 = new Video("Minha Primeira Rede Neural (Teoria) - Redes Neurais e Deep Learning 01", "Universo Discreto", 664);
        video1.AdicionarComentario("Carlos Soares", "Vídeo excelente, muito bem explicado!");
        video1.AdicionarComentario("Mariana Luz", "Ajudou muito no meu projeto da faculdade.");
        video1.AdicionarComentario("Felipe Mendes", "Poderia fazer uma parte 2 com PyTorch?");
        listaVideos.Add(video1);

        // --- VÍDEO 2 ---
        Video video2 = new Video("HTML, CSS e JavaScript em 13 MINUTOS", "CursoemVideo Cortes", 780);
        video2.AdicionarComentario("Lucas Andrade", "CARA MUITO BOM , VC É TOP");
        video2.AdicionarComentario("Ana Paula", "Tem que trazer mais assuntos, mas detalhes.");
        video2.AdicionarComentario("Gabriel Souza", "Curto mais objetivo.");
        video2.AdicionarComentario("Renata Lima", "Muito bom o conteudo para iniciar!");
        listaVideos.Add(video2);

        // --- VÍDEO 3 ---
        Video video3 = new Video("Tutorial Delphi para Iniciantes - POO", "Código Certo", 1200);
        video3.AdicionarComentario("Roberto Silva", "Conteúdo de Delphi em 2026 é ouro! Obrigado!");
        video3.AdicionarComentario("Juliana Costa", "Direto ao ponto, parabéns pelo canal.");
        video3.AdicionarComentario("Diego Fernandes", "Muito bom ver os conceitos de POO aplicados.");
        listaVideos.Add(video3);

        // --- EXIBIÇÃO DOS DADOS ---
        Console.WriteLine("==================================================");
        Console.WriteLine("       MONITORAMENTO DE VÍDEOS DO YOUTUBE        ");
        Console.WriteLine("==================================================\n");

        foreach (Video video in listaVideos)
        {
            Console.WriteLine($"Título: {video.ObterTitulo()}");
            Console.WriteLine($"Autor: {video.ObterAutor()}");
            Console.WriteLine($"Duração: {video.ObterDuracao()} segundos");
            Console.WriteLine($"Total de Comentários: {video.ObterQuantidadeComentarios()}");
            Console.WriteLine("Comentários:");

            foreach (Comentario comentario in video.ObterComentarios())
            {
                Console.WriteLine($"  - [{comentario.ObterNomeAutor()}]: {comentario.ObterTexto()}");
            }

            Console.WriteLine("\n--------------------------------------------------\n");
        }
    }
}
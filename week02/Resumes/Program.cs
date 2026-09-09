using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! Projeto da semana 2- Curriculo+Empregos.");
        Emprego emprego1 = new Emprego();
        emprego1._cargo = "Analise e Desenvolvimento de Software";
        emprego1._empresa = "Microsoft";
        emprego1._anoInicio = 2015;
        emprego1._anoFim = 2020;

        Emprego emprego2 = new Emprego();
        emprego2._cargo = "Desenvolvedor de sistemas";
        emprego2._empresa = "Apple";
        emprego2._anoInicio = 2020;
        emprego2._anoFim = 2025;

        Curriculo meuCurriculo = new Curriculo();
        meuCurriculo._nome = "Paulo Fagundes";

        meuCurriculo._empregos.Add(emprego1);
        meuCurriculo._empregos.Add(emprego2);

        meuCurriculo.Exibir();

        meuCurriculo.Mensagem();
    }    

}
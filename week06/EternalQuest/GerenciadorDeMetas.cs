using System;
using System.Collections.Generic;
using System.IO;

namespace QuestDeMetas
{
    public class GerenciadorDeMetas
    {
        private List<Meta> _metas;
        private int _pontos;

        public GerenciadorDeMetas()
        {
            _metas = new List<Meta>();
            _pontos = 0;
        }

        // Loop principal e exibição do Menu
        public void Iniciar()
        {
            bool executando = true;

            while (executando)
            {
                ExibirInfoJogador();
                Console.Clear();
                Console.WriteLine("***************************");
                Console.WriteLine(" Programa de Metas Eternas ");
                Console.WriteLine("***************************");
                Console.WriteLine("  1. Criar Nova Meta       ");
                Console.WriteLine("  2. Listar Metas          ");
                Console.WriteLine("  3. Salvar Metas          ");
                Console.WriteLine("  4. Carregar Metas        ");
                Console.WriteLine("  5. Registrar Evento      ");
                Console.WriteLine("  6. Sair                  ");
                Console.WriteLine("***************************");
                Console.Write("Selecione uma opção no menu (1-6):");

                string opcao = Console.ReadLine()?.Trim();

                switch (opcao)
                {
                    case "1":
                        CriarMeta();
                        break;
                    case "2":
                        ListarDetalhesDasMetas();
                        break;
                    case "3":
                        SalvarMetas();
                        break;
                    case "4":
                        CarregarMetas();
                        break;
                    case "5":
                        RegistrarEvento();
                        break;
                    case "6":
                    case "sair":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.\n");
                        break;
                }
            }
        }

        // Exibe a pontuação atual do usuário
        public void ExibirInfoJogador()
        {
            Console.WriteLine($"\n*** Você tem {_pontos} pontos. ***\n");
        }

        // Exibe apenas os nomes das metas (útil para seleção numérica em menus)
        public void ListarNomesDasMetas()
        {
            Console.WriteLine("Suas metas são:");
            for (int i = 0; i < _metas.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_metas[i].ObterNome()}");
            }
        }

        // Exibe a lista detalhada de cada meta com status de conclusão
        public void ListarDetalhesDasMetas()
        {
            Console.WriteLine("\nSuas metas são:");
            if (_metas.Count == 0)
            {
                Console.WriteLine("  (Nenhuma meta cadastrada ainda)");
                return;
            }

            for (int i = 0; i < _metas.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_metas[i].ObterDetalhesEmTexto()}");
            }
        }

        // Menu para escolher qual tipo de meta instanciar
        public void CriarMeta()
        {
            Console.WriteLine("\nOs tipos de Metas são:");
            Console.WriteLine("  1. Meta Simples");
            Console.WriteLine("  2. Meta Eterna");
            Console.WriteLine("  3. Meta de Lista de Tarefas (Checklist)");
            Console.Write("Qual tipo de meta você gostaria de criar? ");

            string tipo = Console.ReadLine()?.Trim();

            Console.Write("Qual é o nome da sua meta? ");
            string nome = Console.ReadLine();

            Console.Write("Qual é uma breve descrição dela? ");
            string descricao = Console.ReadLine();

            Console.Write("Qual é a quantidade de pontos associada a esta meta? ");
            int.TryParse(Console.ReadLine(), out int pontos);

            switch (tipo)
            {
                case "1":
                    _metas.Add(new MetaSimples(nome, descricao, pontos));
                    break;
                case "2":
                    _metas.Add(new MetaEterna(nome, descricao, pontos));
                    break;
                case "3":
                    Console.Write("Quantas vezes essa meta precisa ser realizada para um bônus? ");
                    int.TryParse(Console.ReadLine(), out int total);

                    Console.Write("Qual é o bônus por realizar essa quantidade de vezes? ");
                    int.TryParse(Console.ReadLine(), out int bonus);

                    _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus));
                    break;
                default:
                    Console.WriteLine("Tipo de meta inválido.");
                    break;
            }
        }

        // Registra o progresso de uma meta selecionada (Polimorfismo na prática)
        public void RegistrarEvento()
        {
            ListarNomesDasMetas();
            Console.Write("Qual meta você realizou? ");

            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= _metas.Count)
            {
                Meta metaSelecionada = _metas[indice - 1];

                // Guarda a pontuação antes do evento
                int pontosAnteriores = _pontos;

                // Executa a regra específica de cada tipo de meta
                metaSelecionada.RegistrarEvento();

                // Atualiza os pontos (metas calculam ou retornam seus ganhos)
                int pontosGanhos = metaSelecionada.ObterPontos();
                _pontos += pontosGanhos;

                Console.WriteLine($"Parabéns! Você ganhou {pontosGanhos} pontos!");
                Console.WriteLine($"Agora você tem {_pontos} pontos.");
            }
            else
            {
                Console.WriteLine("Opção de meta inválida.");
            }
        }

        // Salva a pontuação e a lista de metas em um arquivo texto
        public void SalvarMetas()
        {
            Console.Write("Qual é o nome do arquivo para salvar as metas? ");
            string nomeArquivo = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                writer.WriteLine(_pontos);

                foreach (Meta meta in _metas)
                {
                    writer.WriteLine(meta.ObterRepresentacaoEmTexto());
                }
            }

            Console.WriteLine("Metas salvas com sucesso!");
        }

        // Lê e reconstrói as instâncias de metas a partir de um arquivo texto
        public void CarregarMetas()
        {
            Console.Write("Qual é o nome do arquivo de metas? ");
            string nomeArquivo = Console.ReadLine();

            if (!File.Exists(nomeArquivo))
            {
                Console.WriteLine("Arquivo não encontrado.");
                return;
            }

            string[] linhas = File.ReadAllLines(nomeArquivo);
            if (linhas.Length == 0) return;

            _metas.Clear();
            _pontos = int.Parse(linhas[0]);

            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i];
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] partes = linha.Split(':');
                string tipoMeta = partes[0];
                string[] dados = partes[1].Split(',');

                if (tipoMeta == "MetaSimples")
                {
                    MetaSimples ms = new MetaSimples(dados[0], dados[1], int.Parse(dados[2]));
                    if (bool.Parse(dados[3]))
                    {
                        ms.RegistrarEvento(); // Marca como concluída
                    }
                    _metas.Add(ms);
                }
                else if (tipoMeta == "MetaEterna")
                {
                    _metas.Add(new MetaEterna(dados[0], dados[1], int.Parse(dados[2])));
                }
                else if (tipoMeta == "MetaDeListaDeTarefas")
                {
                    MetaDeListaDeTarefas mlt = new MetaDeListaDeTarefas(
                        dados[0], dados[1], int.Parse(dados[2]), int.Parse(dados[4]), int.Parse(dados[3]));
                    
                    // Ajusta o contador de concluídas já registradas
                    mlt.DefinirConcluidas(int.Parse(dados[5]));
                    _metas.Add(mlt);
                }
            }

            Console.WriteLine("Metas carregadas com sucesso!");
        }
    }
}
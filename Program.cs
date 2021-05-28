using System;
using LAB_1_cadastro_CRUD.classes;
using System.Collections.Generic;

namespace LAB_1_cadastro_CRUD
{
    class Program
    {
       static SerieRepositorio repositorioSeries = new SerieRepositorio(); // instanciação da classe do repositório de séries (essa classe é uma listagem que fica salva na memória durante a execução do programa)
        static void Main(string[] args)
        {
            string opcaoUsuario = menuInicial(); // para definir o valor da variável opcaoUsuario estamos evocando a classe estática menuInicial, a qual retorna um valor do tipo string
            while (opcaoUsuario != "X")
            {
              switch (opcaoUsuario)
              {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
              }
              opcaoUsuario = menuInicial();
            }
       
            Console.WriteLine("Hasta la vista, baby!");
            Console.WriteLine();
        }
    

        // STATIC CLASSES

        private static string menuInicial()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao nosso pequeno acervo de filmes, séries e livros!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar itens");
            Console.WriteLine("2- Inserir novo item");
            Console.WriteLine("3- Atualizar item");
            Console.WriteLine("4- Excluir item");
            Console.WriteLine("5- Visualizar um item");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        

        private static void ListarSeries()
        {
            Console.WriteLine("Listagem dos itens cadastradas:");
            Console.WriteLine("");

            List<Serie> lista = repositorioSeries.Lista(); // chama o método Lista da instância do sérieRepositório e armazna o seu retorno na variável lista

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum item cadastrado.");
                System.Threading.Thread.Sleep(2000); // interrompe a execução por 2 segundos
                return;                
            }

            foreach (Serie serie in lista)
            {
                Console.WriteLine("ID {0} : - {1} {2} {3}", serie.retornaId(), serie.retornaTitulo(), serie.retornaTipoItem(),(serie.retornaExcluido() ? "" : "*INDISPONÍVEL*"));
                
            }
            System.Threading.Thread.Sleep(2000);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir novo item:");
            Console.WriteLine("");
            //usamos o foreach em conjunto com Enum.GetValues e Enum.GetName para gerar uma listagem em tela dos enumeradores de cada gênero
            foreach (int x in Enum.GetValues(typeof(enumeradores.TipoItemEnum)))
            {
                Console.WriteLine("{0}-{1}", x, Enum.GetName(typeof(enumeradores.TipoItemEnum),x));
            }
            Console.Write("Digite o tipo do item entre as opções acima: ");
            int entradaTipo = int.Parse(Console.ReadLine());

            foreach (int x in Enum.GetValues(typeof(enumeradores.GeneroEnum)))
            {
                Console.WriteLine("{0}-{1}", x, Enum.GetName(typeof(enumeradores.GeneroEnum),x));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()); //usa o método system.int.parse que tenta converter uma string em um integer

            Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento: ");
			//abaixo utilizamos o int.tryparse para lidar com casos em que o valor entrado não é um número
            int entradaAno=0;
            bool inteiro = false;
            while(inteiro != true)
            {
                inteiro = int.TryParse(Console.ReadLine(), out entradaAno);
                if(inteiro != true)
                {
                    Console.WriteLine("Por favor digite um ano no formato AAAA (ex.:1999):");
                }
            }
                        
            Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioSeries.ProximoId(),
                                        tipoItem: (enumeradores.TipoItemEnum) entradaTipo,
                                        genero: (enumeradores.GeneroEnum) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );
            
            repositorioSeries.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID do item que deseja atualizar:");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            
            foreach (int x in Enum.GetValues(typeof(enumeradores.TipoItemEnum)))
            {
                Console.WriteLine("{0}-{1}", x, Enum.GetName(typeof(enumeradores.TipoItemEnum),x));
            }
            Console.Write("Digite o tipo do item entre as opções acima: ");
            int entradaTipo = int.Parse(Console.ReadLine());

            foreach (int x in Enum.GetValues(typeof(enumeradores.GeneroEnum)))
            {
                Console.WriteLine("{0}-{1}", x, Enum.GetName(typeof(enumeradores.GeneroEnum),x));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()); //usa o método system.int.parse que tenta converter uma string em um integer

            Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento: ");
			int entradaAno=0;
            bool inteiro = false;
            while(inteiro != true)
            {
                inteiro = int.TryParse(Console.ReadLine(), out entradaAno);
                if(inteiro != true)
                {
                    Console.WriteLine("Por favor digite um ano no formato AAAA (ex.:1999):");
                }
            }

            Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        tipoItem: (enumeradores.TipoItemEnum) entradaTipo,
                                        genero: (enumeradores.GeneroEnum) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );
            
            repositorioSeries.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id do item: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSeries.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id do item: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            Serie serie = repositorioSeries.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
            System.Threading.Thread.Sleep(2000);
        }
    }

}

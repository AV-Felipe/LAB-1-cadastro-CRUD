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
            Console.WriteLine("Bem-vindo ao nosso pequeno acervo de séries e outras coisas supimpas!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        

        private static void ListarSeries()
        {
            Console.WriteLine("Listagem das séries cadastradas:");
            Console.WriteLine("");

            List<Serie> lista = repositorioSeries.Lista(); // chama o método Lista da instância do sérieRepositório e armazna o seu retorno na variável lista

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                System.Threading.Thread.Sleep(2000); // interrompe a execução por 2 segundos
                return;                
            }

            foreach (Serie serie in lista)
            {
                Console.WriteLine("ID {0} : - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (serie.retornaExcluido() ? "" : "*INDISPONÍVEL*"));
                
            }
            System.Threading.Thread.Sleep(2000);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");
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

            Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
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
            Console.WriteLine("Digite o ID da série que deseja atualizar:");
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

            Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
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
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSeries.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            Serie serie = repositorioSeries.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
    }

}

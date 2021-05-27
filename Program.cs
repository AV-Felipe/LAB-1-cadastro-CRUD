using System;

namespace LAB_1_cadastro_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = menuInicial(); // para definir o valor da variável opcaoUsuario estamos evocando a classe estática menuInicial, a qual retorna um valor do tipo string
            while (opcaoUsuario != "X")
            {
              switch (opcaoUsuario)
              {
                case "1":
                    //ListarSeries();
                    break;
                case "2":
                    //InserirSerie();
                    break;
                case "3":
                    //AtualizarSerie();
                    break;
                case "4":
                    //ExcluirSerie();
                    break;
                case "5":
                    //VisualizarSerie();
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
    }

}

using LAB_1_cadastro_CRUD.enumeradores;

namespace LAB_1_cadastro_CRUD.classes
{
    // Iniciamos por declarar uma calasse com nível de acesso public (sem restrições) que herda da classe abstrata entidadeBase (tudo o que nela estiver contido, fica aqui disponível, sem termos que declarar novamente)
    // níveis de acesso: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
    public class Serie : entidadeBase 
    {
        // 

        // PROPRIEDADES EXCLUSIVAS (não herdadas) DA CLASSE SERIE
        
        // O conceito de propriedas é bastante confundido com o de atributos, em c# são distintos
        // sobre o conceito de "properties" ver: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
        // sobre o conceito de "attributes" ver: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/
        private GeneroEnum Genero{get; set;}
        private string Descricao{get; set;}
        private bool Ativo{get; set;}

        // MÉTODOS

        // Aqui definimos as "ações" pelas quais as propriedades definidas acima serão populadas com valores (o método acessor set das propriedades acima definidas que o possuirem)
        // e as ações pelas quais os valores dessas propriedades poderão ser recuperados (o método acessor get)

        // SET - aqui utilizaremos um método para popular todas as propriedades, já que o conjunto das propriedas representa um elemento (é o método construtor, que tem o mesmo nome da classe)
        public Serie (int id, GeneroEnum genero, string titulo, string descricao, int ano, TipoItemEnum tipoItem)
        {
            this.Id = id; // neste statemente estamos definindo o valor da propriedade Id, herdada da classe abstrata, com o valor da variável id, que será passado na execução do método EditarSerie. a keyword "this" serve para desambiguar a expressão, ao marcar qual "Id" se refere a propriedade da instância da classe
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.TipoDeItem = tipoItem;
            this.Ativo = true;
        }

        // SET - aqui criaremos um método para indisponibilizar um item (sua propriedade Ativo passará a ser false)
        public void ExcluirItem ()
        {
            this.Ativo = false;
        }

        //GET - na sequentcia incluiremos os métodos de leitura das propriedades
        // não definimos métodos de leitura para todas as propriedades pois nosso programa só aceesará algumas proriedades individualmente
        // as outras serão apresentadas pela listagem da instância do objeto criado

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Ativo;
		}

        public TipoItemEnum retornaTipoItem()
        {
            return this.TipoDeItem;
        }








    }
}
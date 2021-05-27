using System.Collections.Generic;
using LAB_1_cadastro_CRUD.interfaces;

namespace LAB_1_cadastro_CRUD.classes
{
    // Essa classe será o modelo do repositório dos elementos da classe Serie
    // Essa classe herda da interface InterfaceCRUD<T> devendo conter todos os membros (propriedaes e métodos) dessa
    public class SerieRepositorio : InterfaceCRUD<Serie> // aqui definimos o tipo da entrada do método genérico (substituindo o "T" do <T> pela classe do input passado)
    {
        private List<Serie> listaSerie = new List<Serie>(); // instanciação de um elemento da classe List<Serie> - uma lista de elementos da classe Serie

        public Serie RetornaPorId(int id) // Read
        {
            return listaSerie[id]; // item[valor inteiro] é uma propriedade da classe List<T> onde T é o item; essa propriedade retorna o elemento da posição do índice entre colchetes
            // aqui determinamos que o valor da variável id, que é o input do método, passará o índice para a instância listaSerie da classe List<T> 
        }
        public void Insere(Serie entidade) // Create
        {
            listaSerie.Add(entidade); // add() é um método da classe List<T> que diciona um objeto do tipo T à lista
        }       
        public void Exclui(int id) // Delete
        {
            listaSerie[id].ExcluirItem(); //chama o método ExcluirItem da classe Serie para o item do índice passado pelo input do método
        }        
        public void Atualiza(int id, Serie entidade) // Update
        {
            listaSerie[id] = entidade; //sobrescreve o item com o índice passado
        }
        public int ProximoId() // incrementação do Id do elemento
        {
            return listaSerie.Count; //count é uma propriedade da classe List<T> que retorna o número de elementos da listagem. Esse número se presta para ID, pois o primeiro id é 0, de forma que a contagem é igual a valor do último id+1
        }

        public List<Serie> Lista() // inicializa uma variável do tipo List<Serie> com o nome Lista
        {
            return listaSerie; // retorna a pópria lista que estamos criando
        }

    }
}
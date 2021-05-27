using System.Collections.Generic; // necessário para o uso da classe List<T>

namespace LAB_1_cadastro_CRUD.interfaces
{
    public interface InterfaceCRUD<T> //o T é o tipo genérico passado na implementação da interface
    {
         List<T> Lista(); // List<T> é uma classe genérica de listas de objetos do tipo "T" (passados na instanciação da classe, no nosso caso uma instancia da classe do tipo de item) já provida de diversos métodos para manipulá-los. Ver: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-5.0
        T RetornaPorId(int id); // cRud: Read        
        void Insere(T entidade); // Crud: Create       
        void Exclui(int id); // cruD: Delete        
        void Atualiza(int id, T entidade); // crUd: Update
        int ProximoId(); // incrementação do Id do elemento
    }
}
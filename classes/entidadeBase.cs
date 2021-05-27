namespace LAB_1_cadastro_CRUD.classes
{
    // Aqui criamos a classe abstrata que servirá de base para as demais classes de itens que queiramos controlar em nosso app
    // Essa clase não pode ser instanciada, prestando-se unicamente de modelo para ser herdado por outras classes
    
    public abstract class entidadeBase
    {
        // As propriedades aqui declaradas estaram disponíveis para todas as classes que herdarem desta classe
        // sobre níveis de acesso ver: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
        protected int Id{get; set;}
        protected string Titulo{get; set;}
        protected int Ano{get; set;}
        protected enumeradores.TipoItemEnum TipoDeItem {get; set;}

        // poderiamos ter métodos aqui, porém as propriedas desta classe abstrata são apenas a parte comum das propriedades dos
        // objetos que criaremos, esses, por sua vez, serão instanciados evocando apenas um método construtor, o qual deverá abarcar
        // todas as propriedades (comuns e particulares), por esse motivo não utilizaremos nenhum método aqui.
    }
}
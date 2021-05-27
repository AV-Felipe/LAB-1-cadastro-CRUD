# Digital Innovation One - Prática .NET

## Bootcamp Take Blip

### Projeto Prático 1

Aplictivo CRUD, em linha de comando, para o cadastro de séries (ou filmes, ou livros, etc.) em memória.

Por se tratar de um projeto pedagógico, fez-se uso abundante de comentários, evidenciano detalhes já explícitos no código.

Utilizaremos uma classe abstrata, contendo as informações gerais dos itens que trataremos nos cadastros, a saber:
 - ID
 - Título
 - Ano
 
Da qual derivaremos as classes para cada classe de item do cadastro, cada uma com suas particularidades, por exemplo:
 - Séries precisará de campos para temporada e episódio
 - Livros precisará de campos para edição
 
Utilizaremos uma interface, para padronizar as operações básicas do CRUD no nosso repositório (uma lista de elementos).
 

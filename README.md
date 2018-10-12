# CopaFilmes - Aplicação de entretenimento para competições entre filmes #

CopaFilmes é uma solução desenvolvida em Angular 6 e .NET C# 4.7.



### Solução WEB - Angular 6.1.0 ###
Projeto contendo o front-end para seleção dos filmes que realizarão as batalhas até que um vença:
    https://github.com/MarcioDeAlmeidaRosa/CopaFilmes/tree/master/CopaFilmesWEB
	
Esta solução é dividida em componentes onde cada uma tem sua responsabilidade:
- **Estrutura**
  - components -> Componentes que serão compartilhado em os módulos da aplicação
  - models     -> Define os models da aplicação
  - services   -> Serviços para sustentar a execução da aplicação
  - views	    -> Módulos da aplicação
 
 
### Solução WEB API - .NET Framework 4.7.2 ###
Projeto contendo o back-end para disponibilizar os filmes que farão as batalhas.
    https://github.com/MarcioDeAlmeidaRosa/CopaFilmes/tree/master/CopaFilmesAPI

Esta solução é dividida em componentes onde cada uma tem sua responsabilidade:
- **Estrutura**
  - CopaFilmesAPI         -> Web API para acesso as funcionalidades disponíveis
  - CopaFilmesAPI.Actions -> Projeto responsável por conter as regras de negócio para execução das batalhas
  - CopaFilmesAPI.Core    -> Projeto que da suporte a toda arquitetura, disponibiliza recursos comuns para todos os demais projetos
  - CopaFilmesAPI.DAO     -> Projeto responsável por acesso a dados
  - CopaFilmesAPI.Model   -> Projeto responsável por definição do domínio da API

 
### Instalações necessárias ### 


### Considerações finais ### 

Caso tenha interesse em ajudar no desenvolvendo novas funcionalidades, é só clonar o repositório do código fonte:

    https://github.com/MarcioDeAlmeidaRosa/CopaFilmes.git

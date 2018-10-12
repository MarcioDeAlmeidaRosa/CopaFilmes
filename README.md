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

- **WEB**
  - NodeJS        -> https://nodejs.org/en/download/
  - Angular CLI   -> https://cli.angular.io/
  - Webpack       -> https://webpack.js.org/

- **API**
  - Microsoft.AspNet.Cors -> https://www.nuget.org/packages/Microsoft.AspNet.Cors/5.2.6/ReportAbuse
  - Newtonsoft.Json       -> https://www.nuget.org/packages/Newtonsoft.Json/11.0.2/ReportAbuse
  - FluentValidation      -> https://www.nuget.org/packages/FluentValidation/8.0.100/ReportAbuse
  - RestSharp             -> https://www.nuget.org/packages/RestSharp/106.5.2/ReportAbuse

### Executar aplicações ### 

- **WEB**
  - Verificar os parâmetros da constante app.constants.ts, nele tem o endereço da API para recuperar os dados e a configuração de quantidade de time necessário para a competição, lembrando que a API tem uma trava para não aceitar número impar de time, então pode ser atribuído qualquer valor, exceto impar.
  - Gerar distribuição (desenvolvimento/produção), acesar o repositório web e executar o comando  -> (ng build) caso tenha dúvida, acessar documentação https://github.com/angular/angular-cli/wiki/build
  - Testar distribuição(via browsersync documentação de uso/instalação https://browsersync.io/) após gerar a distribuição, será gerada uma pasta dist/CopaFilmesWEB, acessar a pasta pelo prompt e executar o comando (browser-sync --server) para iniciar a aplicação (http://localhost:3000/partida)
  

  
### Considerações finais ### 

Caso tenha interesse em ajudar no desenvolvendo novas funcionalidades, é só clonar o repositório do código fonte:

    https://github.com/MarcioDeAlmeidaRosa/CopaFilmes.git

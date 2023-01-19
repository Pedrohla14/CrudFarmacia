# API WEB ASP .NET CORE 6 
## Esse projeto se trata de um desafio no qual foi desenvolvido uma API em C#, nele vai conter algumas funcionalidades que se pode usar em uma empresa.
# Como Rodar a API:
## Vai ser preciso ter o SQL SERVER baixado em sua máquina e recomendo baixar o SQL SERVER MANAGEMENT para uma visualização melhor dos dados.
## Após clonar o projeto em sua máquina é necessário configurar o Banco de Dados no Projeto:
### Primeiro Passo:
### No arquivo Program.cs mude o Data Source para a configuração do seu Banco de Dados
![image](https://user-images.githubusercontent.com/94800633/213511040-27c1f9de-9a82-405e-a1d3-fd92eda36dff.png)

### Segundo Passo:
### Rodar o Migrations da api, para que seja criado o DataBase em seu Banco.
### Para rodar o Migrations execute o comando Update-Database no console.

## Agora que o DataBase já foi criado em nosso Banco de Dados, podemos executar o Projeto:

### O Projeto ao ser executado será redirecionado para uma Url do Swagger que poderá usar os endpoints. 
### URL : https://localhost:7093/swagger/index.html 
![image](https://user-images.githubusercontent.com/94800633/213514842-80c7cb15-5d93-433d-bced-cefe58df599e.png)

## A modelagem no Banco de dados foi que uma farmácia tem muitos produtos e um produto pertence à uma farmácia. Segue alguns dados inseridos atráves do swagger.
![image](https://user-images.githubusercontent.com/94800633/213544550-347a2f6d-92b2-448e-a602-76e1b8c9a0c8.png)



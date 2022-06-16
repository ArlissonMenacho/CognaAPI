# Teste Técnico Cogna / Kroton
Projeto desenvolvido em solicitação da empresa Cogna como fruto de avalição técnica

## Dependências

* Necessário ter SQL Server instalado na máquina ou direcionar a um servidor devidamente instalado.
* Microsoft.EntityFrameworkCore 6.0.6
* Microsoft.EntityFrameworkCore.SqlServer 6.0.6
* Microsoft.EntityFrameworkCore.Tools 6.0.6
* Swashbuckle.AspNetCore 6.2.3

## Introdução

O projeto foi configurado a tabela de ToDo e também configurado método seed para popular o sistema para facilitar um teste inicial.

# Documentação

Após clonar o projeto, deve:
* Verificar a conexão do SQL Server caso deseje alterar o local do teste o padrão será localhost.
* Rodar o comando "Update-Database" para criação do banco e população dos dados inicias.

## Executar

E finalmente executar a aplicação:

* Opção 1: Por via comando:
`dotnet run`

* Opção 2: Utilizando a IDE
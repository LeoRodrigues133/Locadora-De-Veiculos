# Locadora De Veiculos 2024

<div align="center">

| <img width="60" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png"> | <img width="60" src="https://miro.medium.com/v2/resize:fit:300/0*cdEEkdP1WAuz-Xkb.png"> | <img width="60" src="https://raw.githubusercontent.com/altmann/FluentResults/master/resources/icons/FluentResults-Icon-64.png"> | <img width="60" src="https://rodrigoesilva.wordpress.com/wp-content/uploads/2011/04/sqlserver_sql_server_2008_logo.png"> |
|:---:|:---:|:---:|:---:|
| .NET Core | ASP.NET Core | FluentResults | Microsoft SQL Server |
||
| <img width="60" src="https://www.infoport.es/wp-content/uploads/2023/09/entity-core.png"> | <img width="60" src="https://api.nuget.org/v3-flatcontainer/dapper/2.1.35/icon"> | <img width="60" src="https://www.lambdatest.com/blog/wp-content/uploads/2021/03/MSTest.png"> | <img width="60" src="https://user-images.githubusercontent.com/25181517/184103699-d1b83c07-2d83-4d99-9a1e-83bd89e08117.png"> |
| EF Core | Dapper | MSTest | Selenium |

</div>

## Projeto
**Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024**

### Arquitetura
- DDD
- N-Camadas

### Stack:
- NET 8.0
- ASP.NET MVC
- Microsoft Identity
- Microsoft SQL Server
- Entity Framework Core
- AutoMapper
- Dapper
- FluentResults
- Selenium

### Inclui:
- Testes de Unidade
- Testes de Integração
- Testes e2e
- Autenticação e Autorização com Microsoft Identity
---

## Detalhes
O sistema foi desenvolvido para simplificar o gerenciamento das operações de uma locadora
de automóveis, abrangendo funcionalidades essenciais como:

Cadastro de Funcionários, Clientes e Veículos: Administradores podem criar usuários para
empresas que utilizam a plataforma, além de gerenciar funcionários e veículos.

Configuração de Aluguéis e Devoluções: Permite o cálculo de preços de aluguéis com base
em fatores como tipo de veículo, plano escolhido e taxas adicionais.

Gestão de Taxas e Serviços: Os clientes podem adicionar taxas e serviços aos aluguéis,
com preços configuráveis por dia ou fixos, que impactam o custo final.

Controle de Devoluções: O sistema registra a devolução dos veículos e aplica multas em
caso de atraso, além de considerar o custo de combustível para o cálculo final.

Autenticação e Autorização: Implementado com Microsoft Identity, garantindo segurança no
gerenciamento de usuários e permissões.

O objetivo central é proporcionar uma gestão eficiente para locadoras, melhorando a
experiência tanto dos funcionários quanto dos clientes.


## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---
## Como Usar

#### Clone o Repositório
```
git clone https://github.com/Kriegerl1/LocadoraDeVeiculos2024.git
```

#### Navegue até a pasta raiz da solução
```
cd LocadoraDeVeiculos2024
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd LocadoraDeVeiculos.WebApp
```

#### Execute o projeto
```
dotnet run
```

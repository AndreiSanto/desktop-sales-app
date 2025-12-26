# Sistema de Vendas – Desktop App (.NET)

## 📌 Visão Geral
Este projeto consiste em um **sistema de vendas desktop**, desenvolvido em **C# (.NET)**, utilizando **WinForms** para interface gráfica, **PostgreSQL** como banco de dados e **RDLC (Microsoft ReportViewer)** para geração de relatórios de vendas.

O sistema permite:
- Cadastro de vendas e itens de venda
- Associação de clientes e produtos
- Geração de relatório de vendas por período
- Visualização de totais e subtotais

---

## 🏗 Arquitetura Adotada

O projeto segue uma **arquitetura em camadas**, inspirada em princípios de **Clean Architecture** e **DDD simplificado**:

src/
- SistemaVendas.Domain -> Entidades e interfaces
- SistemaVendas.Application -> DTOs, Services e regras de aplicação
- SistemaVendas.Infrastructure -> Repositórios e acesso a dados (PostgreSQL)
- SistemaVendas.Forms -> Interface gráfica (WinForms + RDLC)


### Responsabilidade das camadas:
- **Domain**:  
  Contém entidades de negócio (`Venda`, `VendaItem`, `Cliente`, `Produto`) e contratos (`IVendaRepository`,`IProdutoRepository`,`IClienteRepository`).
- **Application**:  
  Contém regras de aplicação, serviços (`VendaAppService`,`ProdutoAppService`,`ClienteAppService`) e DTOs utilizados para comunicação entre camadas.
- **Infra**:  
  Implementa o acesso ao banco de dados utilizando **Npgsql** e SQL puro.
- **Forms (UI)**:  
  Responsável pela interface gráfica e pela exibição de relatórios via **ReportViewer (RDLC)**.

---


## 🗄 Configuração do Banco de Dados

### Banco utilizado
- **PostgreSQL**

### Versão do PostgreSQL
PostgreSQL 15 ou 17

### Script básico de criação das tabelas
O script está em Infrastructure na pasta scripts
Já existe uma string de conexão em appsettings.json

### Como Executar o Projeto
Pré-requisitos

- **.NET 8 

- **PostgreSQL instalado e rodando

- **Visual Studio 2022 ou superior

- **Passos

- **Clone o repositório

- **Crie o banco de dados no PostgreSQL

- **Execute o script de criação das tabelas

- **Ajuste a string de conexão

- **Defina o projeto SistemaVendas.Forms como projeto inicial

- **Execute a aplicação (F5)

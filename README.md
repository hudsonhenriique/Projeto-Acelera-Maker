# Sistema Bancário Maker

## 💻 Sobre o Projeto

O **Sistema Bancário Maker** é uma aplicação de console desenvolvida em **C#** que simula as operações de um banco real.

O sistema foi construído com foco na aplicação de conceitos sólidos de **Programação Orientada a Objetos (POO)**, persistência de dados em banco relacional e automação de testes.

Este projeto compõe meu portfólio prático de desenvolvimento de sistemas, indo além dos requisitos estruturais básicos para incluir arquitetura profissional, banco de dados real e validações de domínio.

---

## ⚙️ Funcionalidades

- **Gestão de Contas:** Criação, leitura, atualização e exclusão (**CRUD**) de contas bancárias.
- **Tipos de Conta:** Suporte para Conta Corrente (com limite de cheque especial) e Conta Poupança (com dia de aniversário).
- **Operações Financeiras:** Saques, depósitos e transferências seguras entre contas.
- **Validações de Domínio:** Bloqueio de saques sem saldo/limite, validação de datas e proteção contra transferências sem fundos.
- **Menu Interativo:** Interface de console à prova de falhas, com tratamento de exceções (`try-catch`) para entradas incorretas do usuário.

---

## 🚀 Tecnologias Utilizadas

- **Linguagem:** C# (.NET)
- **Banco de Dados:** SQLite
- **ORM:** Entity Framework Core (Migrations e auto-criação do banco)
- **Testes:** xUnit (Testes Unitários)

---

## 🏗️ Arquitetura e Boas Práticas

- **Padrão Repository:** Separação clara entre:
  - lógica de negócios (**Models**)
  - controle de fluxo/dados (**Controllers/Repositories**)
  - interface (**Utils/Program**)

- **Tradução Dinâmica:** Código-fonte escrito no padrão global (Inglês), com interface de saída tratada para Português (**UX**).

- **Validação de Domínio:** As regras de negócio estão encapsuladas dentro das próprias classes.

  Exemplo:
  - impossível instanciar uma conta poupança com dia de aniversário inválido (ex: dia 50).

- **Testes Unitários:** Cobertura de testes garantindo consistência matemática e transacional, cobrindo:
  - caminhos de sucesso
  - cenários de falha (**Unhappy Paths**)

---

## 🛠️ Como Executar o Projeto

### Pré-requisitos

- .NET SDK **10.0.203** ou superior instalado

### Passos

#### 1. Clone este repositório

```bash
git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
```

#### 2. Navegue até a pasta do projeto principal

```bash
cd BankAccountSystem
```

#### 3. Execute a aplicação

> O banco de dados SQLite será gerado automaticamente na primeira execução.

```bash
dotnet run
```

---

## ✅ Como Rodar os Testes

Navegue até a pasta de testes e execute o comando abaixo para verificar as validações das regras de negócio:

```bash
cd BankAccountSystem.Tests
dotnet test
```

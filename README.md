# Caitlyn's Ledger

**Caitlyn's Ledger** é uma API inspirada no universo de **Arcane**, permitindo que usuarios criem e gerenciem investigações fictícias. A ideia central é simular o trabalho de uma detetive em Piltover, combinando a tecnologia Hextech e o mistério característico do seriado.


![image](https://github.com/user-attachments/assets/e7c3d2a7-ef64-4b51-bd92-e6e1f81fdfd4)


## Índice
1. [Funcionalidades](#funcionalidades)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Configuração do Projeto](#configuração-do-projeto)
4. [Estrutura de Dados](#estrutura-de-dados)
5. [Endpoints da API](#endpoints-da-api)
6. [Como Executar o Projeto](#como-executar-o-projeto)
7. [Contribuindo](#contribuindo)
8. [Licença](#licença)

---

## Funcionalidades
- **Casos de Investigação**:
  - Criar, listar, atualizar e excluir casos de investigação.
- **Gerenciamento de Pistas**:
  - Relacionar pistas a casos específicos, com descrição e relevância.
- **Gerenciamento de Suspeitos**:
  - Adicionar suspeitos com descrições detalhadas e álibis relacionados aos casos.
- **Documentação da API**:
  - Utiliza o Swagger para explorar e testar os endpoints.
- **Banco de Dados Relacional**:
  - Todas as informações são armazenadas em um banco de dados SQLite.

---

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: ASP.NET Core 8.0
- **Banco de Dados**: SQLite
- **ORM**: Entity Framework Core
- **Documentação da API**: Swagger (Swashbuckle)
- **Controle de Versão**: Git & GitHub

---

## Estrutura de Dados
A API organiza os dados em três principais entidades:

### 1. Case (Caso)
| Campo         | Tipo          | Descrição                           |
|---------------|---------------|---------------------------------------------|
| `Id`          | `int`         | Identificador único do caso.              |
| `Name`        | `string`      | Nome do caso.                              |
| `Description` | `string`      | Descrição detalhada do caso.           |
| `Status`      | `string`      | Status do caso (Aberto/Resolvido).         |
| `Clues`       | `List<Clue>`  | Lista de pistas relacionadas ao caso.     |
| `Suspects`    | `List<Suspect>`| Lista de suspeitos relacionados ao caso. |

### 2. Clue (Pista)
| Campo         | Tipo     | Descrição                                  |
|---------------|----------|----------------------------------------------|
| `Id`          | `int`    | Identificador único da pista.               |
| `Description` | `string` | Descrição da pista.                       |
| `Relevance`   | `string` | Relevância da pista (Alta, Média, Baixa). |
| `CaseId`      | `int`    | Relacionamento com o caso correspondente.    |

### 3. Suspect (Suspeito)
| Campo         | Tipo     | Descrição                                  |
|---------------|----------|----------------------------------------------|
| `Id`          | `int`    | Identificador único do suspeito.            |
| `Name`        | `string` | Nome do suspeito.                           |
| `Alibi`       | `string` | Álibi apresentado pelo suspeito.            |
| `CaseId`      | `int`    | Relacionamento com o caso correspondente.   |

---

## Endpoints da API

### 1. Cases
| Método   | Rota               | Descrição                          |
|-----------|--------------------|-----------------------------------|
| `GET`     | `/api/cases`       | Lista todos os casos.             |
| `GET`     | `/api/cases/{id}`  | Retorna os detalhes de um caso.   |
| `POST`    | `/api/cases`       | Cria um novo caso.                |
| `PUT`     | `/api/cases/{id}`  | Atualiza um caso existente.       |
| `DELETE`  | `/api/cases/{id}`  | Remove um caso.                   |

### 2. Clues
| Método   | Rota               | Descrição                          |
|-----------|--------------------|-----------------------------------|
| `GET`     | `/api/clues`       | Lista todas as pistas.            |
| `GET`     | `/api/clues/{id}`  | Retorna os detalhes de uma pista. |
| `POST`    | `/api/clues`       | Adiciona uma nova pista.          |

### 3. Suspects
| Método   | Rota               | Descrição                          |
|-----------|--------------------|-----------------------------------|
| `GET`     | `/api/suspects`    | Lista todos os suspeitos.         |
| `GET`     | `/api/suspects/{id}`| Retorna os detalhes de um suspeito.|
| `POST`    | `/api/suspects`    | Adiciona um novo suspeito.        |

---

## Como Executar o Projeto

### Pré-requisitos
- Instalar o .NET 8 SDK.
- Opcional: Instalar o SQLite ou uma ferramenta como DB Browser.

### Passos
1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/anadevti/Caitlyn-s-Ledger.git
   cd Caitlyn-s-Ledger
   ```

2. **Restaure as Dependências**:
   ```bash
   dotnet restore
   ```

3. **Configure o Banco de Dados**:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Inicie o Servidor**:
   ```bash
   dotnet run
   ```

5. **Acesse a API**:
   - Swagger: https://localhost:7296/swagger/index.html

---

## Contribuindo
Contribuições são muito bem-vindas! Siga estas etapas:
1. Faça um fork do repositório.
2. Crie um branch para sua feature ou correção:
   ```bash
   git checkout -b minha-feature
   ```
3. Faça suas alterações e commit:
   ```bash
   git commit -m "Minha contribuição"
   ```
4. Envie para a sua branch:
   ```bash
   git push origin minha-feature
   ```
5. Abra um pull request no repositório.

---

## Licença
Este projeto é licenciado sob a licença MIT. Consulte o arquivo `LICENSE` para mais informações.


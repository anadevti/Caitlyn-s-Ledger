# Caitlyn's Ledger

**Caitlyn's Ledger** é uma API inspirada no universo de **Arcane**, permitindo que usuários criem e gerenciem investigações fictícias. A ideia central é simular o trabalho de uma detetive em Piltover, combinando a tecnologia Hextech e o mistério característico do seriado.

![image](https://github.com/user-attachments/assets/e7c3d2a7-ef64-4b51-bd92-e6e1f81fdfd4)

## Índice
1. [Funcionalidades](#funcionalidades)
2. [Arquitetura](#arquitetura)
3. [Tecnologias Utilizadas](#tecnologias-utilizadas)
4. [Estrutura de Dados](#estrutura-de-dados)
5. [Endpoints da API](#endpoints-da-api)
6. [Configuração e Execução](#configuração-e-execução)
7. [Autenticação](#autenticação)
8. [Contribuindo](#contribuindo)
9. [Licença](#licença)

---

## Funcionalidades

### Gestão de Casos de Investigação
- **Criação e Gerenciamento**: Crie, visualize, atualize e encerre casos de investigação.
- **Categorização**: Classifique os casos por status (Aberto, Resolvido, Não Resolvido).
- **Histórico Completo**: Acompanhe a evolução do caso desde sua abertura até a resolução.

### Sistema de Pistas
- **Catalogação de Evidências**: Adicione pistas detalhadas com título, descrição e localização.
- **Datação**: Registre a data de descoberta de cada pista para análise cronológica.
- **Relacionamento**: Associe pistas a casos específicos, construindo uma rede de evidências.

### Rastreamento de Suspeitos
- **Perfis Detalhados**: Crie perfis de suspeitos com nome, descrição e status.
- **Gerenciamento de Status**: Classifique suspeitos como "Suspeito", "Inocente" ou "Indeterminado".
- **Linha do Tempo**: Acompanhe desde quando cada suspeito está sendo investigado.

### Interface e Usabilidade
- **API RESTful Completa**: Acesse todos os recursos através de endpoints bem definidos.
- **Documentação Interativa**: Explore e teste a API diretamente pelo Swagger.
- **Validação de Dados**: Garanta a integridade das informações com validações em todas as entradas.

### Segurança
- **Autenticação OAuth**: Login seguro usando credenciais Google.
- **Autorização**: Controle de acesso baseado em perfis de usuário.
- **Proteção de Dados**: Armazenamento seguro das informações sensíveis.

---

## Arquitetura

O projeto segue os princípios da **Clean Architecture** (Arquitetura Limpa), proporcionando uma separação clara de responsabilidades e facilitando a manutenção, testabilidade e escalabilidade do sistema.

### Camadas da Aplicação

#### 1. Domain (Núcleo)
- **Entidades**: Modelos de domínio como `Case`, `Clue` e `Suspect`.
- **Interfaces do Repositório**: Contratos para acesso a dados independentes de implementação.
- **Regras de Negócio**: Lógica central da aplicação sem dependências externas.

#### 2. Application
- **DTOs (Data Transfer Objects)**: Objetos de transferência de dados entre camadas.
- **Serviços**: Implementação das regras de negócio usando as interfaces do domínio.
- **Mapeamento**: Conversão entre entidades de domínio e DTOs usando AutoMapper.

#### 3. Infrastructure
- **Repositórios**: Implementações concretas dos repositórios definidos no domínio.
- **Contexto de Banco de Dados**: Configuração do Entity Framework Core.
- **Migrações**: Gerenciamento do esquema do banco de dados.
- **Serviços Externos**: Integrações com serviços externos como autenticação OAuth.

#### 4. API
- **Controllers**: Endpoints RESTful que recebem requisições e retornam respostas.
- **Middleware**: Componentes para processamento de requisições como autenticação e log.
- **Configuração**: Inicialização e configuração da aplicação.

### Fluxo de Dados
1. As requisições HTTP chegam aos Controllers na camada API
2. Os Controllers utilizam os Serviços da camada Application
3. Os Serviços aplicam a lógica de negócio e utilizam os Repositórios através de suas interfaces
4. Os Repositórios na camada Infrastructure acessam o banco de dados
5. Os dados retornam pelo mesmo caminho, sendo convertidos em DTOs antes de serem enviados ao cliente

Este padrão arquitetural garante:
- **Inversão de Dependência**: Camadas internas não dependem das externas
- **Separação de Responsabilidades**: Cada componente tem um propósito específico
- **Testabilidade**: Facilidade para criar testes unitários e de integração
- **Manutenibilidade**: Alterações em uma camada não afetam necessariamente as outras

---

## Tecnologias Utilizadas
- **Backend**: ASP.NET Core 8.0
- **Linguagem**: C# 12
- **ORM**: Entity Framework Core 8.0
- **Banco de Dados**: SQLite (desenvolvimento) / SQL Server (produção)
- **Mapeamento de Objetos**: AutoMapper
- **Validação**: FluentValidation
- **Documentação da API**: Swagger / OpenAPI
- **Autenticação**: OAuth 2.0 com Google
- **Containerização**: Docker (preparado para implantação)

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

## Configuração e Execução

### Pré-requisitos
- .NET 8 SDK ou superior
- Git para clonagem do repositório
- Opcional: Visual Studio 2022, JetBrains Rider ou VS Code

### Passos para Execução
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

4. **Configure as Variáveis de Ambiente** (opcional para autenticação Google):
   - Crie um arquivo `appsettings.Development.json` baseado no exemplo fornecido
   - Adicione suas credenciais OAuth do Google

5. **Inicie o Servidor**:
   ```bash
   dotnet run
   ```

6. **Acesse a API**:
   - Documentação Swagger: https://localhost:7296/swagger/index.html
   - Endpoints da API: https://localhost:7296/api/

### Execução com Docker (opcional)
```bash
docker-compose up -d
```

---

## Autenticação

O sistema utiliza autenticação OAuth 2.0 com provedor Google, permitindo:

- **Login Seguro**: Autenticação via conta Google
- **Tokens JWT**: Geração e validação de tokens para acesso à API
- **Sessões**: Gerenciamento de sessões de usuário com timeout configurável

Para configurar a autenticação em ambiente de desenvolvimento:

1. Crie um projeto no Google Cloud Platform
2. Configure as URIs de redirecionamento OAuth
3. Adicione as credenciais ao arquivo `appsettings.Development.json`:
   ```json
   {
     "Authentication": {
       "Google": {
         "ClientId": "seu-client-id",
         "ClientSecret": "seu-client-secret"
       }
     }
   }
   ```

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

Este projeto está licenciado sob a [MIT License](LICENSE).

---

**Desenvolvido com 💙 por [Ana]**

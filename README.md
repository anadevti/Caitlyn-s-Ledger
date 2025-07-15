# Caitlyn's Ledger 🔍

**Caitlyn's Ledger** é uma API inspirada no universo de **Arcane** para gerenciar investigações fictícias. Simule o trabalho de uma detetive em Piltover, organizando casos, pistas e suspeitos.

![image](https://github.com/user-attachments/assets/e7c3d2a7-ef64-4b51-bd92-e6e1f81fdfd4)

## 🚀 Início Rápido

### Pré-requisitos
- .NET 8 SDK
- Git

### Configuração do Ambiente

<details>
<summary>📦 Instalação</summary>

```bash
# Clone o repositório
git clone https://github.com/anadevti/Caitlyn-s-Ledger.git
cd Caitlyn-s-Ledger

# Restaure as dependências
dotnet restore
```
</details>

<details>
<summary>🗄️ Configuração do Banco de Dados</summary>

O projeto usa SQLite por padrão (sem configuração adicional necessária):

```bash
# Crie as migrações (se não existirem)
dotnet ef migrations add InitialCreate

# Aplique as migrações
dotnet ef database update
```

**Arquivo de configuração:** O banco SQLite será criado automaticamente em `CaitlynsLedger.db`
</details>

<details>
<summary>🔐 Autenticação Google (Opcional)</summary>

Para habilitar login com Google:

1. Crie um projeto no [Google Cloud Console](https://console.cloud.google.com/)
2. Configure OAuth 2.0 com redirect URI: `https://localhost:7296/signin-google`
3. Adicione as credenciais em `appsettings.Development.json`:

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
</details>

<details>
<summary>🐳 Docker (Opcional)</summary>

```bash
# Executar com Docker
docker-compose up -d
```
</details>

### Executar a Aplicação

```bash
dotnet run
```

**Acesse:**
- API: https://localhost:7296/api/
- Swagger: https://localhost:7296/swagger

---

## 📋 Funcionalidades

- **Casos:** Crie e gerencie investigações
- **Pistas:** Organize evidências por caso
- **Suspeitos:** Mantenha perfis de investigados
- **Autenticação:** Login seguro com Google
- **API REST:** Endpoints completos e documentados

---

## 🧪 Testes

<details>
<summary>Executar Testes</summary>

```bash
# Todos os testes
dotnet test

# Com cobertura
dotnet test --collect:"XPlat Code Coverage"

# Classe específica
dotnet test --filter "ClassName=CaseServiceTests"
```

**Tecnologias:** xUnit, Moq, FluentAssertions
</details>

---

## 🏗️ Arquitetura

<details>
<summary>Clean Architecture</summary>

```
├── Domain/           # Entidades e regras de negócio
├── Application/      # Serviços e DTOs
├── Infrastructure/   # Repositórios e banco de dados
└── API/             # Controllers e configurações
```

**Fluxo:** Controllers → Services → Repositories → Database
</details>

---

## 📊 Estrutura de Dados

<details>
<summary>Entidades Principais</summary>

### Case (Caso)
- `Id`, `Name`, `Description`, `Status`
- Relacionamentos: `Clues[]`, `Suspects[]`

### Clue (Pista)
- `Id`, `Description`, `Relevance`, `CaseId`

### Suspect (Suspeito)
- `Id`, `Name`, `Alibi`, `CaseId`
</details>

---

## 🔌 API Endpoints

<details>
<summary>Principais Rotas</summary>

### Cases
- `GET /api/cases` - Listar casos
- `GET /api/cases/{id}` - Detalhes do caso
- `POST /api/cases` - Criar caso
- `PUT /api/cases/{id}` - Atualizar caso
- `DELETE /api/cases/{id}` - Deletar caso

### Clues
- `GET /api/clues` - Listar pistas
- `POST /api/clues` - Criar pista

### Suspects
- `GET /api/suspects` - Listar suspeitos
- `POST /api/suspects` - Criar suspeito

**Documentação completa:** Swagger UI
</details>

---

## 🛠️ Tecnologias

<details>
<summary>Stack Técnico</summary>

- **Backend:** ASP.NET Core 8.0
- **Linguagem:** C# 12
- **Banco:** SQLite (dev) / SQL Server (prod)
- **ORM:** Entity Framework Core
- **Mapeamento:** AutoMapper
- **Validação:** FluentValidation
- **Autenticação:** OAuth 2.0 (Google)
- **Testes:** xUnit, Moq, FluentAssertions
- **Documentação:** Swagger/OpenAPI
- **Container:** Docker
</details>

---

## 🤝 Contribuindo

<details>
<summary>Como Contribuir</summary>

1. Fork o projeto
2. Crie uma branch: `git checkout -b minha-feature`
3. Commit suas mudanças: `git commit -m 'Add: nova feature'`
4. Push para a branch: `git push origin minha-feature`
5. Abra um Pull Request

**Padrões:**
- Testes unitários obrigatórios
- Seguir Clean Architecture
- Documentar endpoints no Swagger
</details>

---

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).

---

**Desenvolvido com 💙 por [Ana](https://github.com/anadevti)**

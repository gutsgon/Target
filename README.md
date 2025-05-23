# Resolução das Questões do Teste

Este repositório contém a resolução das questões propostas.

## 📁 Estrutura

- Todos os **códigos em Java** estão localizados na pasta:
  ```
  /test
  ```
  Eles **não utilizam nenhum framework**, apenas precisam do **JDK** para serem executados.

- A **questão 3** foi resolvida utilizando **C# com .NET** para criar uma API.

---

## ✅ Questões Resolvidas

- **Questões 1, 2, 4 e 5**: resolvidas em Java (JDK puro), sem dependências externas.
- **Questão 3**: resolvida com uma **API REST em C# (.NET)**.

---

## ⚙️ Questão 3 - API REST (.NET)

### ▶️ Como executar a aplicação localmente

1. Instale o [.NET SDK](https://dotnet.microsoft.com/download).
2. Navegue até a pasta do projeto da API.
3. Execute o comando:
   ```bash
   dotnet run
   ```

4. Acesse a documentação Swagger:
   ```
   http://localhost:5068/swagger
   ```

---

### 🔐 Autenticação via Swagger

1. No Swagger, vá até o endpoint de **login**.
2. Use as seguintes credenciais:
   - **Usuário:** `admin`
   - **Senha:** `1234`
3. O endpoint retornará um **token JWT**.
4. Clique no botão `Authorize` no Swagger e informe o token no formato:
   ```
   Bearer SEU_TOKEN_AQUI
   ```

---

### 📊 Realizando o Filtro

1. Acesse o endpoint:
   ```
   /api/DiaValor/Relatorio
   ```
2. No corpo da requisição, cole **todo o conteúdo do arquivo `dados.json`** (presente na aplicação).
3. Execute a requisição para obter o relatório com base nos dados enviados.

---

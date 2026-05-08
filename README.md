# 🚀 CRUD MVC - ASP.NET Core C#

Uma aplicação CRUD (Create, Read, Update e Delete) desenvolvida com ASP.NET Core MVC e C#.

Este projeto foi criado com fins de aprendizado, focando em arquitetura MVC, integração com MongoDB e operações CRUD utilizando o driver oficial do MongoDB para .NET.

---

## 📚 Tecnologias Utilizadas

- ASP.NET Core MVC
- C#
- MongoDB
- MongoDB.Driver
- MongoDB Compass
- Bootstrap
- Razor Pages

---

## ✨ Funcionalidades

- ✅ Criar registros
- ✅ Listar dados
- ✅ Atualizar informações
- ✅ Deletar registros
- ✅ Arquitetura MVC
- ✅ Integração com MongoDB

---

## 📁 Estrutura do Projeto

```bash
├── Controllers/
├── Models/
├── Views/
├── Data/
├── wwwroot/
├── appsettings.json
└── Program.cs
```

## ⚙️ Como Executar o Projeto

### Pré-requisitos

Antes de executar o projeto, você precisa ter instalado:

- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 ou VS Code
- MongoDB
- MongoDB Compass

### 📦 Pacotes NuGet Necessários

Instale os seguintes pacotes NuGet no projeto:

- MongoDB.Driver
- MongoDB.Bson

Você pode instalar pelo Gerenciador de Pacotes do Visual Studio ou usando o terminal:

```bash
dotnet add package MongoDB.Driver
dotnet add package MongoDB.Bson
```

---

## 🔧 Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/juninh0-dev/CrudMVC-.NetCore-CSharp.git
```

### 2. Acesse a pasta do projeto

```bash
cd CrudMVC-.NetCore-CSharp
```

### 3. Configure a conexão com o MongoDB

Abra o arquivo `appsettings.json` e configure sua connection string:

```json
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "CrudMVC"
}
```

## 🔧 Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/juninh0-dev/CrudMVC-.NetCore-CSharp.git
```

### 2. Acesse a pasta do projeto

```bash
cd CrudMVC-.NetCore-CSharp
```

### 3. Configure a conexão com o MongoDB

Abra o arquivo `appsettings.json` e configure sua connection string:

```json
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "CrudMVC"
}
```

---

## ▶️ Executando a Aplicação

```bash
dotnet run
```

A aplicação será iniciada localmente.

---

## 👨‍💻 Autor

Feito com 💻 por **Altair**

GitHub: https://github.com/juninh0-dev

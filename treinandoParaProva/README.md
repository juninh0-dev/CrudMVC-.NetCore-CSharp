# Sistema de Gestão de Trabalhos Científicos

Sistema web desenvolvido com ASP.NET Core MVC e MongoDB para gerenciamento interno de submissão e avaliação de trabalhos acadêmicos em um simpósio universitário.

---

# 📚 Sobre o Projeto

A proposta do sistema é permitir que usuários da rede interna da faculdade possam:

- Cadastrar trabalhos científicos
- Informar autores do trabalho
- Avaliar trabalhos submetidos
- Excluir trabalhos
- Visualizar média das avaliações

O sistema utiliza uma única coleção chamada `Trabalhos`, contendo listas embutidas de:

- Autores
- Avaliações

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core MVC
- MongoDB
- C#
- LINQ
- Bootstrap
- Razor Views

---

# 📁 Estrutura do Projeto

```bash
Projeto/
│
├── Controllers/
│   └── TrabalhosController.cs
│
├── Models/
│   ├── Trabalho.cs
│   ├── Autor.cs
│   └── Avaliacao.cs
│
├── ViewModels/
│   └── TrabalhoViewModel.cs
│
├── Views/
│   └── Trabalhos/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       └── Avaliar.cshtml
│
├── Services/
│   └── MongoDBService.cs
│
├── appsettings.json
└── Program.cs
```

---

# 🗂️ Estrutura da Coleção MongoDB

Coleção: `Trabalhos`

Exemplo de documento:

```json
{
  "_id": "ObjectId",
  "titulo": "Inteligência Artificial na Educação",
  "resumo": "Trabalho sobre IA aplicada ao ensino.",
  "areaTematica": "Tecnologia",
  "dataSubmissao": "2026-05-11T00:00:00",
  "autores": [
    {
      "nome": "João",
      "email": "joao@email.com"
    }
  ],
  "avaliacoes": [
    {
      "nota": 5,
      "comentario": "Excelente trabalho",
      "dataAvaliacao": "2026-05-11T00:00:00"
    }
  ]
}
```

---

# 🧱 Models

## Trabalho.cs

```csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Trabalho
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Resumo { get; set; } = string.Empty;

    public string AreaTematica { get; set; } = string.Empty;

    public DateTime DataSubmissao { get; set; }

    public List<Autor> Autores { get; set; } = new();

    public List<Avaliacao> Avaliacoes { get; set; } = new();
}
```

---

## Autor.cs

```csharp
public class Autor
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
```

---

## Avaliacao.cs

```csharp
public class Avaliacao
{
    public int Nota { get; set; }

    public string Comentario { get; set; } = string.Empty;

    public DateTime DataAvaliacao { get; set; }
}
```

---

# 📦 ViewModel Obrigatória

## TrabalhoViewModel.cs

```csharp
public class TrabalhoViewModel
{
    public string Id { get; set; } = string.Empty;

    public string Titulo { get; set; } = string.Empty;

    public string AreaTematica { get; set; } = string.Empty;

    public int QuantidadeAutores { get; set; }

    public double MediaNotas { get; set; }
}
```

---

# ⚙️ Funcionalidades Implementadas

## ✅ Listagem de Trabalhos

A tela principal exibe:

- Título
- Área Temática
- Quantidade de autores
- Média das notas
- Botão Avaliar
- Botão Excluir

A média das avaliações é calculada utilizando LINQ.

Exemplo:

```csharp
MediaNotas = trabalho.Avaliacoes.Any()
    ? trabalho.Avaliacoes.Average(a => a.Nota)
    : 0
```

---

## ✅ Cadastro de Trabalhos

O formulário permite cadastrar:

- Título
- Resumo
- Área Temática
- 1 ou 2 autores

Validações:

- Título obrigatório
- Resumo obrigatório
- Pelo menos 1 autor
- Máximo 2 autores

---

## ✅ Avaliação de Trabalhos

A tela de avaliação apresenta:

### Informações somente leitura

- Título
- Resumo

### Campos do formulário

- Nota (1 a 5)
- Comentário

---

# 🔄 Atualização das Avaliações

A avaliação é salva utilizando ReplaceOneAsync.

Fluxo:

1. Busca o documento completo
2. Adiciona nova avaliação na lista
3. Substitui documento atualizado

Exemplo:

```csharp
var trabalho = await _trabalhos
    .Find(x => x.Id == id)
    .FirstOrDefaultAsync();

trabalho.Avaliacoes.Add(new Avaliacao
{
    Nota = avaliacao.Nota,
    Comentario = avaliacao.Comentario,
    DataAvaliacao = DateTime.Now
});

await _trabalhos.ReplaceOneAsync(
    x => x.Id == id,
    trabalho
);
```

---

# 🖥️ Configuração do MongoDB

## appsettings.json

```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "FaculdadeDB",
    "CollectionName": "Trabalhos"
  }
}
```

---

# ▶️ Como Executar o Projeto

## 1. Clonar o repositório

```bash
git clone https://github.com/seuusuario/projeto.git
```

---

## 2. Restaurar pacotes

```bash
dotnet restore
```

---

## 3. Executar o MongoDB

Verifique se o MongoDB está ativo na máquina.

---

## 4. Rodar o projeto

```bash
dotnet run
```

---

# 📌 Regras de Negócio

- Não existe autenticação/login
- Qualquer usuário pode cadastrar e avaliar trabalhos
- Cada trabalho deve possuir:
  - mínimo de 1 autor
  - máximo de 2 autores
- Nota da avaliação:
  - mínimo 1
  - máximo 5

---

# 📊 Exemplo de Tela Principal

| Título | Área | Autores | Média | Ações |
|---|---|---|---|---|
| IA na Educação | Tecnologia | 2 | 4.5 | Avaliar / Excluir |

---

# 🧠 Conceitos Utilizados

- ASP.NET Core MVC
- MongoDB Embedded Documents
- LINQ
- ViewModel
- CRUD
- ReplaceOneAsync
- Razor Pages
- Validação de Formulários

---

# 👨‍💻 Autor

Projeto desenvolvido para fins acadêmicos na disciplina de Desenvolvimento Web com ASP.NET Core MVC e MongoDB.
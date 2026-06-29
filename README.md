# 📋 Tarefator - Um Projeto Educativo em C# e .NET

> **Um gerenciador de tarefas simples, construído com foco educativo para demonstrar como trabalhar com IA no desenvolvimento e na melhoria de código legado.**

## 🎯 Propósito do Projeto

O **Tarefator** foi desenvolvido com **simplicidade e clareza** como principais objetivos. Este projeto serve como:

✅ **Base educativa** para alunos aprender como funciona o desenvolvimento com IA  
✅ **Referência prática** de como melhorar código legado sem estar presente no desenvolvimento inicial  
✅ **Material para entender** testes, novas funcionalidades e arquitetura de software  
✅ **Exemplo real** de uma aplicação C# simples e funcional  

## 🚀 O que é o Tarefator?

O Tarefator é um **gerenciador de tarefas por linha de comando (CLI)** que permite:

- ✏️ **Adicionar** novas tarefas
- 📝 **Listar** todas as tarefas
- ✅ **Marcar** tarefas como concluídas
- 🗑️ **Remover** tarefas
- 🚪 **Sair** da aplicação

## 📦 Stack Tecnológico

- **Linguagem**: C# 14.0
- **Framework**: .NET 10
- **IDE**: Visual Studio Community 2026
- **Padrão**: Console Application

## 🛠️ Como Usar

### Pré-requisitos

- .NET 10 SDK ou superior instalado
- Visual Studio Community 2026 ou qualquer editor compatível com C#

### Instalação e Execução

```bash
# Clone ou baixe o repositório
cd tarefator

# Restaure as dependências
dotnet restore

# Execute o projeto
dotnet run
```

Após isso, você verá um menu interativo:

```
╔════════════════════════════════════╗
║       Bem-vindo ao Tarefator!      ║
╚════════════════════════════════════╝

Escolha uma opção:
1. Adicionar Tarefa
2. Listar Tarefas
3. Concluir Tarefa
4. Remover Tarefa
5. Sair

Escolha uma opção:
```

## 📁 Estrutura do Projeto

```
Tarefator/
├── Program.cs              # Ponto de entrada da aplicação
├── Services/
│   └── TarefaService.cs   # Lógica de negócio para gerenciar tarefas
├── UI/
│   └── MenuHelper.cs      # Interface de usuário e menus
├── Models/
│   └── Tarefa.cs          # Modelo de dados (sugestão)
└── Tests/
	└── TarefatorTests/    # Testes unitários (para implementar)
```

## 🎓 Como Este Projeto Ajuda na Aprendizagem

Este é o material educativo do prof. **Marco Antonio Angelo**, desenvolvido para demonstrar na prática como trabalhar com IA no desenvolvimento de software.

### 1. **Aprender a Trabalhar com IA no Desenvolvimento**

Este projeto foi desenvolvido **com a ajuda de IA**, mostrando como:

- ✨ Usar prompts efetivos para gerar código
- 🔄 Iterar sobre sugestões de IA
- 🎯 Manter o foco em requisitos claros
- 📝 Documentar decisões arquiteturais

**Como usar**: Leia o código, entenda a lógica e tente fazer pequenas mudanças com a ajuda de uma IA!

### 2. **Melhorar Código Legado**

Mesmo não tendo participado do desenvolvimento inicial, você pode:

- 🔍 Entender a lógica do `TarefaService`
- 🐛 Identificar possíveis melhorias
- ➕ Adicionar novos recursos
- 🧪 Implementar testes para garantir qualidade

**Desafio**: Tente refatorar o `MenuHelper` para usar um padrão mais robusto!

### 3. **Implementar Testes**

Adicionar testes é essencial para a qualidade do código:

```csharp
// Exemplo de teste com xUnit
[Fact]
public void AdicionarTarefa_DeveAdicionarComSucesso()
{
	// Arrange
	var service = new TarefaService();

	// Act
	service.AdicionarTarefa("Estudar C#");

	// Assert
	Assert.Single(service.ObterTodas());
}
```

**Como começar**:
1. Crie um projeto de testes (`dotnet new xunit -n Tarefator.Tests`)
2. Adicione referência ao projeto principal
3. Implemente testes para cada método do `TarefaService`

### 4. **Adicionar Novos Funcionamentos**

Algumas ideias para estender o projeto:

- 📅 **Datas de vencimento** para tarefas
- 🏷️ **Categorias/Tags** para organizar tarefas
- 💾 **Persistência em arquivo** (JSON/CSV)
- 🔍 **Buscar tarefas** por palavra-chave
- 📊 **Estatísticas** (tarefas concluídas, pendentes, etc.)
- 🌙 **Temas de cor** no menu
- ⏰ **Prioridades** para tarefas

**Como começar**:
1. Add um novo método ao `TarefaService`
2. Atualize o `MenuHelper` para exibir a opção
3. Teste a implementação
4. Documente a mudança

### 5. **Construir Desenhos de Arquitetura**

Visualizar a arquitetura é importante:

#### Diagrama de Fluxo

```
┌─────────────┐
│ Program.cs  │
└──────┬──────┘
	   │
	   ├─→ MenuHelper (UI/Interação)
	   │       │
	   │       └─→ TarefaService (Lógica)
	   │
	   └─→ Console.ReadLine()
```

#### Diagrama de Camadas

```
┌─────────────────────────────────┐
│  Presentation Layer             │
│  (MenuHelper, Program.cs)       │
├─────────────────────────────────┤
│  Business Layer                 │
│  (TarefaService)                │
├─────────────────────────────────┤
│  Data Layer                     │
│  (Models - Tarefa)              │
└─────────────────────────────────┘
```

#### Diagrama de Objetos (PlantUML)

```
@startuml
class Program {
	Main()
}

class MenuHelper {
	ExibirMenu()
	AdicionarTarefa()
	ListarTarefas()
	ConcluirTarefa()
	RemoverTarefa()
}

class TarefaService {
	AdicionarTarefa()
	ListarTarefas()
	ConcluirTarefa()
	RemoverTarefa()
}

class Tarefa {
	Id
	Titulo
	Descricao
	Concluida
	DataCricacao
}

Program --> MenuHelper
MenuHelper --> TarefaService
TarefaService --> Tarefa
@enduml
```

## 📚 Próximos Passos Sugeridos

### Iniciante
- [ ] Execute o projeto e entenda o fluxo
- [ ] Leia e compreenda cada método
- [ ] Tente adicionar uma nova opção no menu

### Intermediário
- [ ] Implemente testes unitários
- [ ] Refatore o código para usar padrões como MVC
- [ ] Adicione persistência em arquivo

### Avançado
- [ ] Crie uma API REST para o Tarefator
- [ ] Implemente usando Entity Framework
- [ ] Adicione um banco de dados real (SQL Server, PostgreSQL)
- [ ] Containerize com Docker
- [ ] Faça deploy na nuvem (Azure, AWS)

## 🤝 Como Contribuir

1. **Faça um Fork** do projeto
2. **Crie uma branch** para sua feature (`git checkout -b feature/melhoria`)
3. **Commit suas mudanças** (`git commit -m 'Adiciona nova feature'`)
4. **Push para a branch** (`git push origin feature/melhoria`)
5. **Abra um Pull Request**

### Ideias de Contribuição

- 🐛 Correção de bugs
- 🎨 Melhorias na UI/UX
- 📖 Documentação melhorada
- 🧪 Novos testes
- ✨ Novas funcionalidades
- 🚀 Otimizações de performance

## ⌨️ Atalhos do GitHub Copilot

Aprenda a usar o Copilot de forma eficiente em sua IDE favorita!

### Visual Studio Code

| Ação | Atalho |
|------|--------|
| Aceitar sugestão completa | `Tab` |
| Aceitar sugestão por palavra | `Ctrl + →` (Ctrl + Seta Direita) |
| Ver próxima sugestão | `Alt + ]` |
| Abrir Copilot Chat | `Ctrl + Shift + I` (inline) |
| Descartar sugestão | `Esc` |

### Visual Studio 2026

| Ação | Atalho |
|------|--------|
| Aceitar sugestão completa | `Tab` |
| Aceitar sugestão por palavra | `Ctrl + →` (Ctrl + Seta Direita) |
| Descartar sugestão | `Esc` |

### 💡 Dicas de Uso

- **Prompt rápido**: Use `Ctrl + Shift + I` (VS Code) para fazer perguntas ao Copilot sem interromper o fluxo
- **Múltiplas sugestões**: Quando o Copilot oferece sugestões, use `Alt + ]` para navegar entre todas
- **Aceitar parcial**: Se uma sugestão é quase perfeita, use `Ctrl + →` para aceitar palavra por palavra e parar quando necessário
- **Combine com Chat**: Use o Chat para entender a lógica, depois deixe o Copilot gerar o código

---

## 📖 Recursos para Aprender

### Microsoft Learn
- [C# Fundamentals](https://learn.microsoft.com/pt-br/training/modules/csharp-statements/)
- [.NET Documentation](https://learn.microsoft.com/pt-br/dotnet/)

### Padrões e Boas Práticas
- [Clean Code - Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [Design Patterns - Gang of Four](https://refactoring.guru/design-patterns)
- [SOLID Principles](https://www.digitalocean.com/community/conceptual_articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design)

### Testes
- [xUnit Documentation](https://xunit.net/)
- [Moq - Mocking Library](https://github.com/moq/moq4)

### IA e Desenvolvimento
- [GitHub Copilot](https://github.com/features/copilot)
- [OpenAI Cookbook](https://github.com/openai/openai-cookbook)

## 💡 Dicas de Desenvolvimento com IA

1. **Seja específico**: Descreva exatamente o que você quer
2. **Forneça contexto**: Mostre o código existente
3. **Itere**: A IA pode errar; revise e refine os prompts
4. **Aprenda**: Entenda por que a IA sugeriu aquela solução
5. **Documente**: Sempre documente as decisões tomadas

Exemplo de bom prompt:
```
Implemente um método em TarefaService que retorna a quantidade de tarefas concluídas.
O método deve ser testável e seguir o padrão de código já existente.
```

## 📝 Licença

Este projeto é licenciado sob a [MIT License](LICENSE) - sinta-se livre para usar, modificar e compartilhar!

## 👨‍🏫 Sobre o Projeto e Mentoria

Este projeto foi desenvolvido como **material educativo** com o objetivo de ensinar alunos sobre desenvolvimento em C# e .NET, trabalhando com IA e melhorando código legado.

### Instrutor
**Marco Antonio Angelo** é o mentor responsável por este projeto educativo.

- 📧 Email: [marco.angelo.blu@gmail.com](mailto:marco.angelo.blu@gmail.com)
- 💼 LinkedIn: [Marco Antonio Angelo](https://www.linkedin.com/in/marco-antonio-angelo-14882912a/)

Se tiver dúvidas sobre o projeto ou quiser conectar-se com o instrutor, sinta-se livre para entrar em contato! 🤝

## 🙏 Agradecimentos

- Desenvolvido com foco educativo pelo prof. Marco Antonio Angelo
- Graças a comunidade C# e .NET por ferramentas incríveis
- Inspirado em boas práticas de desenvolvimento
- Dedicado a todos os alunos que querem aprender com IA

---

**Desenvolvido com ❤️ para aprender e ensinar**

*Quer melhorar este README? Abra uma issue ou PR! 🚀*

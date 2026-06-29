using Tarefator.Services;

namespace Tarefator.UI;

public class MenuHelper
{
    private readonly TarefaService _service;

    public MenuHelper(TarefaService service)
    {
        _service = service;
    }

    public void ExibirBemVindo()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║     BEM-VINDO À LISTA DE TAREFAS   ║");
        Console.WriteLine("╚════════════════════════════════════╝\n");
    }

    public void ExibirMenu()
    {
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║            MENU PRINCIPAL          ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.WriteLine("║  1 - Adicionar Tarefa              ║");
        Console.WriteLine("║  2 - Listar Tarefas                ║");
        Console.WriteLine("║  3 - Marcar como Concluída         ║");
        Console.WriteLine("║  4 - Remover Tarefa                ║");
        Console.WriteLine("║  5 - Sair                          ║");
        Console.WriteLine("╚════════════════════════════════════╝");
    }

    public void AdicionarTarefa()
    {
        Console.Write("\n📝 Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine() ?? "";

        try
        {
            _service.Adicionar(descricao);
            Console.WriteLine("✅ Tarefa adicionada com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"❌ {ex.Message}");
        }
    }

    public void ListarTarefas()
    {
        Console.Clear();
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║        LISTA DE TAREFAS            ║");
        Console.WriteLine("╚════════════════════════════════════╝\n");

        var tarefas = _service.ObterTodas();

        if (tarefas.Count == 0)
        {
            Console.WriteLine("📭 Nenhuma tarefa cadastrada.\n");
            return;
        }

        foreach (var tarefa in tarefas)
        {
            string status = tarefa.Concluida ? "✓" : "○";
            string descricao = tarefa.Concluida ? $"~~{tarefa.Descricao}~~" : tarefa.Descricao;

            Console.WriteLine($"[{status}] {tarefa.Id} - {descricao}");
            Console.WriteLine($"    Criada em: {tarefa.DataCriacao:dd/MM/yyyy HH:mm}\n");
        }

        ExibirEstatisticas();
    }

    public void ConcluirTarefa()
    {
        ListarTarefas();

        if (_service.ObterTotal() == 0) return;

        Console.Write("Digite o ID da tarefa a marcar como concluída: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_service.Concluir(id))
                Console.WriteLine("✅ Tarefa marcada como concluída!");
            else
                Console.WriteLine("❌ Tarefa não encontrada!");
        }
        else
        {
            Console.WriteLine("❌ ID inválido!");
        }
    }

    public void RemoverTarefa()
    {
        ListarTarefas();

        if (_service.ObterTotal() == 0) return;

        Console.Write("Digite o ID da tarefa a remover: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_service.Remover(id))
                Console.WriteLine("✅ Tarefa removida com sucesso!");
            else
                Console.WriteLine("❌ Tarefa não encontrada!");
        }
        else
        {
            Console.WriteLine("❌ ID inválido!");
        }
    }

    private void ExibirEstatisticas()
    {
        int total = _service.ObterTotal();
        int concluidas = _service.ObterConcluidas();
        int pendentes = _service.ObterPendentes();

        Console.WriteLine($"📊 Total: {total} | ✓ Concluídas: {concluidas} | ○ Pendentes: {pendentes}\n");
    }

    public void PausarExecucao()
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }
}

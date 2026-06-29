using Tarefator.Models;

namespace Tarefator.Services;

public class TarefaService
{
    private readonly List<Tarefa> _tarefas = new();

    public void Adicionar(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição não pode estar vazia!");

        var novaTarefa = new Tarefa
        {
            Id = _tarefas.Count > 0 ? _tarefas.Max(t => t.Id) + 1 : 1,
            Descricao = descricao,
            Concluida = false,
            DataCriacao = DateTime.Now
        };

        _tarefas.Add(novaTarefa);
    }

    public List<Tarefa> ObterTodas()
    {
        return _tarefas.OrderByDescending(t => !t.Concluida)
                       .ThenByDescending(t => t.DataCriacao)
                       .ToList();
    }

    public bool Concluir(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
            return false;

        tarefa.Concluida = true;
        return true;
    }

    public bool Remover(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
            return false;

        _tarefas.Remove(tarefa);
        return true;
    }

    public int ObterTotal() => _tarefas.Count;
    public int ObterConcluidas() => _tarefas.Count(t => t.Concluida);
    public int ObterPendentes() => _tarefas.Count(t => !t.Concluida);
}

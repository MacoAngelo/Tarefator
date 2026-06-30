using System.Text.Json;
using Tarefator.Models;

namespace Tarefator.Services;

public class TarefaService
{
    private readonly List<Tarefa> _tarefas = new();
    private static readonly object _fileLock = new();

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
        tarefa.DataConclusao = DateTime.Now;

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

    /*
     * TODO: Gera método para edição de tarefas, permitindo alterar a descrição de uma tarefa existente.
     * Regras: Deve receber o ID da tarefa e a nova descrição. Se a tarefa não existir, deve contornar sem estourar exceção. Se a descrição for inválida (vazia ou nula), deve lançar uma exceção.
     * Retorno: true se a edição for bem-sucedida, false caso contrário.
     */
    public bool Editar(int id, string novaDescricao)
    {
        if (string.IsNullOrWhiteSpace(novaDescricao))
            throw new ArgumentException("Descrição não pode estar vazia!");
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
            return false;
        tarefa.Descricao = novaDescricao;
        return true;
    }

    /// <summary>
    /// Registra os dados de tarefas existentes em um arquivo JSON.
    /// Regra 01: O arquivo deve ser salvo no diretório do aplicativo com o nome "tarefas.json".
    /// Regra 02: Se o arquivo já existir, ele deve ser sobrescrito.
    /// Regra 03: O método deve estar preparado para lidar com multi threading, 
    /// garantindo que múltiplas chamadas ao método não corrompam o arquivo.
    /// </summary>
    public void RegistrarDados()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "tarefas.json");
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_tarefas, options);

        lock (_fileLock)
        {
            var tempPath = path + ".tmp";
            File.WriteAllText(tempPath, json);

            if (File.Exists(path))
            {
                // Substitui o arquivo existente de forma atômica quando possível
                File.Replace(tempPath, path, null);
            }
            else
            {
                File.Move(tempPath, path);
            }
        }
    }

    public int ObterTotal() => _tarefas.Count;
    public int ObterConcluidas() => _tarefas.Count(t => t.Concluida);
    public int ObterPendentes() => _tarefas.Count(t => !t.Concluida);
}

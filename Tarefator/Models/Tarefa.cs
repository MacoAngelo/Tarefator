namespace Tarefator.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; } = "";
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
}

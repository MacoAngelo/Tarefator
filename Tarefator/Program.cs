using Tarefator.Services;
using Tarefator.UI;

var tarefaService = new TarefaService();
var menuHelper = new MenuHelper(tarefaService);

menuHelper.ExibirBemVindo();

bool executando = true;

while (executando)
{
    menuHelper.ExibirMenu();
    Console.Write("\nEscolha uma opção: ");
    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            menuHelper.AdicionarTarefa();
            break;
        case "2":
            menuHelper.ListarTarefas();
            break;
        case "3":
            menuHelper.ConcluirTarefa();
            break;
        case "4":
            menuHelper.RemoverTarefa();
            break;
        case "5":
            executando = false;
            Console.WriteLine("\n👋 Até logo!");
            break;
        default:
            Console.WriteLine("❌ Opção inválida. Tente novamente.");
            break;
    }

    if (executando && opcao != "2")
    {
        menuHelper.PausarExecucao();
    }
}

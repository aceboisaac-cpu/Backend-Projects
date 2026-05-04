using TaskTracker.Cli.Services;
using TaskTracker.Cli.Storage;

var store = new TaskFileStore();
var service = new TaskService(store);

if (args.Length == 0)
{
    ShowHelp();
    return;
}

var command = args[0].ToLowerInvariant();

switch (command)
{
    case "add":
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: add \"descripcion\"");
            return;
        }

        var description = args[1];
        var created = service.Add(description);
        Console.WriteLine($"✅ Task added successfully (ID: {created.Id})");
        break;

    case "list":
        string? status = args.Length >= 2 ? args[1] : null;
        var tasks = service.List(status);

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"[{task.Id}] {task.Description} | {task.Status} | created: {task.CreatedAt:u} | updated: {task.UpdatedAt:u}");
        }
        break;

    default:
        Console.WriteLine($"Comando desconocido: {command}");
        ShowHelp();
        break;
}

static void ShowHelp()
{
    Console.WriteLine("Task Tracker CLI");
    Console.WriteLine("Comandos:");
    Console.WriteLine("  add \"descripcion\"");
    Console.WriteLine("  list");
    Console.WriteLine("  list todo");
    Console.WriteLine("  list in-progress");
    Console.WriteLine("  list done");
}

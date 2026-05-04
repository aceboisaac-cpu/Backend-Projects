using TaskTracker.Cli.Models;
using TaskTracker.Cli.Storage;

namespace TaskTracker.Cli.Services;

public class TaskService
{
    private readonly TaskFileStore _store;

    public TaskService(TaskFileStore store)
    {
        _store = store;
    }

    public TaskItem Add(string description)
    {
        var tasks = _store.Load();
        var nextId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
        var now = DateTime.UtcNow;

        var task = new TaskItem
        {
            Id = nextId,
            Description = description,
            Status = "todo",
            CreatedAt = now,
            UpdatedAt = now
        };

        tasks.Add(task);
        _store.Save(tasks);
        return task;
    }

    public List<TaskItem> List(string? status = null)
    {
        var tasks = _store.Load();

        if (string.IsNullOrWhiteSpace(status))
            return tasks;

        return tasks
            .Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

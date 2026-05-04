# Task Tracker CLI (C#)

Proyecto de consola en C# para gestionar tareas, basado en:
https://roadmap.sh/projects/task-tracker

## 🚀 Features actuales

- Agregar tareas
- Listar todas las tareas
- Listar tareas por estado (`todo`, `in-progress`, `done`)
- Persistencia en archivo JSON local (`tasks.json`)

## 🧱 Estructura del proyecto

```text
01-task-tracker/
├── TaskTracker.sln
└── TaskTracker.Cli/
    ├── Models/
    │   └── TaskItem.cs
    ├── Services/
    │   └── TaskService.cs
    ├── Storage/
    │   └── TaskFileStore.cs
    └── Program.cs
```

## ⚙️ Requisitos

- .NET SDK 8 o superior

Verificar versión:

```bash
dotnet --version
```

## ▶️ Cómo ejecutar

Desde la carpeta `TaskTracker.Cli`:

```bash
dotnet run -- add "Aprender C# CLI"
dotnet run -- list
dotnet run -- list todo
```

## 🧪 Comandos disponibles

```bash
add "descripcion"
list
list todo
list in-progress
list done
```

## 📁 Persistencia

Las tareas se guardan en `tasks.json` dentro de `TaskTracker.Cli`.

Cada tarea tiene:

- `id`
- `description`
- `status`
- `createdAt`
- `updatedAt`





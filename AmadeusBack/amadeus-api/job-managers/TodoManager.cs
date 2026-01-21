using System;
using amadeus_api.database;
using amadeus_api.database.models;
using log4net;

namespace amadeus_api.job_managers;

public class TodoManager(AmaContext context) : AmaManager(context)
{
    private static readonly ILog log = LogManager.GetLogger(typeof(TodoManager));

    public List<TodoTask> FetchTodosForUser(long userId)
    {
        log.Info("Fetching todos for user with ID: " + userId);
        var todos = _context.Todos.Where(t => t.OwnerId == userId && t.Status != TodoTaskStatus.DELETED).ToList();
        log.Info("Fetched " + todos.Count + " todos for user with ID: " + userId);
        return todos;
    }

    public TodoTask CreateTodoForUser(long userId, string name, string? description, DateTime? dueDate)
    {
        log.Info("Creating new todo for user with ID: " + userId);
        var todo = new TodoTask
        {
            OwnerId = userId,
            Name = name,
            Description = description,
            DueDate = dueDate,
            Status = TodoTaskStatus.TODO
        };
        todo.MarkCreated(userId);
        _context.Todos.Add(todo);
        _context.SaveChanges();
        log.Info("Created new todo with ID: " + todo.Id + " for user with ID: " + userId);
        return todo;
    }

    public TodoTask NextMyTodoState(long todoId, long loggedUserId)
    {
        log.Info("Updating NextState for todo with ID: " + todoId + " for user with ID: " + loggedUserId);
        var todo = _context.Todos.Find(todoId) ?? throw new Exception($"Todo with ID {todoId} does not exist.");
        if (todo.OwnerId != loggedUserId) throw new Exception($"Todo with ID {todoId} does not belong to user with ID {loggedUserId}.");
        switch (todo.Status)
        {
            case TodoTaskStatus.TODO:
                todo.Status = TodoTaskStatus.IN_PROGRESS;
                break;
            case TodoTaskStatus.IN_PROGRESS:
                todo.Status = TodoTaskStatus.DONE;
                break;
        }
        todo.MarkUpdated(loggedUserId);
        _context.SaveChanges();
        log.Info("Updated todo with ID: " + todoId + " for user with ID: " + loggedUserId);
        return todo;
    }

    public void DeleteMyTodo(long todoId, long loggedUserId)
    {
        log.Info("Deleting todo with ID: " + todoId + " for user with ID: " + loggedUserId);
        var todo = _context.Todos.Find(todoId) ?? throw new Exception($"Todo with ID {todoId} does not exist.");
        if (todo.OwnerId != loggedUserId) throw new Exception($"Todo with ID {todoId} does not belong to user with ID {loggedUserId}.");
        todo.MarkDeleted(loggedUserId);
        _context.SaveChanges();
        log.Info("Deleted todo with ID: " + todoId + " for user with ID: " + loggedUserId);
    }
}

using System;
using amadeus_api.job_managers;
using amadeus_api.job_models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amadeus_api.job_controllers;

[Authorize]
public class TodoController(TodoManager manager) : AmaController
{
    protected TodoManager _manager = manager;

    [HttpGet]
    [Route("api/users/{userId}/todos")]
    public IActionResult FetchTodosForUser(long userId)
    {
        var todos = _manager.FetchTodosForUser(userId).Select(t => t.ToDTO()).ToList();
        return Ok(todos);
    }

    [HttpPost]
    [Route("api/users/{userId}/todos")]
    public IActionResult CreateTodoForUser([FromRoute] long userId, [FromBody] RequestCreateTodoTask request)
    {
        var todo = _manager.CreateTodoForUser(userId, request.Name, request.Description, request.DueDate);
        return Ok(todo.ToDTO());
    }

    [HttpGet]
    [Route("api/me/todos")]
    public IActionResult FetchMyTodos()
    {
        var todos = _manager.FetchTodosForUser(_loggedUserId).Select(t => t.ToDTO()).ToList();
        return Ok(todos);
    }

    [HttpPost]
    [Route("api/me/todos")]
    public IActionResult CreateMyTodo([FromBody] RequestCreateTodoTask request)
    {
        var todo = _manager.CreateTodoForUser(_loggedUserId, request.Name, request.Description, request.DueDate);
        return Ok(todo.ToDTO());
    }

    [HttpDelete]
    [Route("api/me/todos/{id}")]
    public IActionResult DeleteMyTodo([FromRoute] long id)
    {
        _manager.DeleteMyTodo(id, _loggedUserId);
        return NoContent();
    }

    [HttpPost]
    [Route("api/me/todos/{id}/next-state")]
    public IActionResult NextMyTodoState([FromRoute] long id)
    {
        var todo = _manager.NextMyTodoState(id, _loggedUserId);
        return Ok(todo.ToDTO());
    }
}

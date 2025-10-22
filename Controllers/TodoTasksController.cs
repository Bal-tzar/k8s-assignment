using Microsoft.AspNetCore.Mvc;
using KubernetesAssignment.Models;
using KubernetesAssignment.Services;

namespace KubernetesAssignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTasksController : ControllerBase
{
    private readonly TasksService _tasksService;

    public TodoTasksController(TasksService tasksService) =>
        _tasksService = tasksService;

    [HttpGet]
    public async Task<List<TodoItem>> Get() =>
        await _tasksService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<TodoItem>> Get(string id)
    {
        var todo = await _tasksService.GetAsync(id);
        if (todo is null) return NotFound();
        return todo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TodoItem newTodo)
    {
        await _tasksService.CreateAsync(newTodo);
        return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, TodoItem updatedTodo)
    {
        var todo = await _tasksService.GetAsync(id);
        if (todo is null) return NotFound();
        updatedTodo.Id = todo.Id;
        await _tasksService.UpdateAsync(id, updatedTodo);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var todo = await _tasksService.GetAsync(id);
        if (todo is null) return NotFound();
        await _tasksService.RemoveAsync(id);
        return NoContent();
    }
}

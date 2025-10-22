namespace KubernetesAssignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTasksController : ControllerBase
{
    private readonly TasksService _tasksService;

    public TodoTasksController(TasksService tasksService) =>
        _tasksService = tasksService;

    [HttpGet]
    public async Task<List<Tasks>> Get() =>
        await _taskService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Tasks>> Get(string id)
    {
        var tasks = await _tasksService.GetAsync(id);

        if (tasks is null)
        {
            return NotFound();
        }

        return tasks;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Tasks newTasks)
    {
        await _booksService.CreateAsync(newTasks);

        return CreatedAtAction(nameof(Get), new { id = newTasks.Id }, newTasks);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Tasks updatedTasks)
    {
        var tasks = await _tasksService.GetAsync(id);

        if (tasks is null)
        {
            return NotFound();
        }

        updatedTasks.Id = tasks.Id;

        await _tasksService.UpdateAsync(id, updatedTasks);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var tasks = await _tasksService.GetAsync(id);

        if (tasks is null)
        {
            return NotFound();
        }

        await _tasksService.RemoveAsync(id);

        return NoContent();
    }
}

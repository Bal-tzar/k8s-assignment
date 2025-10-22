using MongoDB.Driver;
using Microsoft.Extensions.Options;
using KubernetesAssignment.Models;

namespace KubernetesAssignment.Services;

public class TasksService
{
    private readonly IMongoCollection<TodoItem> _todoTasks;

    public TasksService(IOptions<TodoListDBSettings> todoListDBSettings)
    {
        var mongoClient = new MongoClient(todoListDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(todoListDBSettings.Value.DatabaseName);

        _todoTasks = mongoDatabase.GetCollection<TodoItem>(todoListDBSettings.Value.TaskNames);
    }

    public async Task<List<TodoItem>> GetAsync() =>
        await _todoTasks.Find(_ => true).ToListAsync();

    public async Task<TodoItem?> GetAsync(string id) =>
        await _todoTasks.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TodoItem newTodo) =>
        await _todoTasks.InsertOneAsync(newTodo);

    public async Task UpdateAsync(string id, TodoItem updatedTodo) =>
        await _todoTasks.ReplaceOneAsync(x => x.Id == id, updatedTodo);

    public async Task RemoveAsync(string id) =>
        await _todoTasks.DeleteOneAsync(x => x.Id == id);
}
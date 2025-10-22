namespace KubernetesAssignment.Services;

public class TasksService
{
    private readonly IMongoCollection<Tasks> _todoTasks;

    public TasksService(
        IOptions<TodoListDBSettings> todoListDBSettings)
        {
            var mongoClient = new MongoClient(
                todoListDBSettings.Value.ConnectionString);
            
            var mongoDatabase = mongoCliecnt.GetDatabase(
                todoListDBSettings.Value.DatabaseName);

            _todoTasks = mongoDatabase.GetCollection<Tasks>(
                todoListDBSettings.Value.TaskNames);           
        }

    public async Task<List<Tasks>> GetAsync() =>
        await _todoTasks.Find(_ => true).ToListAsync();
    
    public async Task<Tasks?> GetAsync(string id) =>
        await _todoTasks.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task CreateAsync(Tasks newTasks) =>
        await _todoTasks.InsertOneAsync(newTasks);
    
    public async Task UpdateAsync(string id, Tasks updatedTasks) =>
        await _todoTasks.ReplaceOneAsync(x => x.Id == id, updatedTasks);
    
    public async Task RemoveAsync(string id) => 
        await _todoTasks.DeleteOneAsync(x => x.Id == id);
    
}
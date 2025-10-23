namespace KubernetesAssignment.Models;

    public class TodoListDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TaskNames { get; set; } = null!;
    }

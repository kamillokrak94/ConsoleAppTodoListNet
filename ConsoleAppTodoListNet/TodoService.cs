namespace ConsoleAppTodoListNet
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public interface ITodoService
    {
        void AddTodo(string description);
        List<Todo> GetAllTodos();
        bool RemoveTodo(int id);
        void ClearTodos();
    }

    public class TodoService : ITodoService
    {
        private readonly List<Todo> _todos = [];
        private int _nextId = 1;

        public void AddTodo(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.", nameof(description));

            _todos.Add(new Todo
            {
                Id = _nextId++,
                Description = description
            });
        }

        public List<Todo> GetAllTodos()
        {
            // Return a copy to prevent external modification
            return new List<Todo>(_todos);
        }

        public bool RemoveTodo(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
                return true;
            }
            return false;
        }

        public void ClearTodos()
        {
            _todos.Clear();
        }
    }
}
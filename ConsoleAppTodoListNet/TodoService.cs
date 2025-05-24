using ConsoleAppTodoListNet.Models;
namespace ConsoleAppTodoListNet
{
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
            try
            {
                if (string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Description cannot be empty.", nameof(description));

                _todos.Add(new Todo
                {
                    Id = _nextId++,
                    Description = description
                });
            }
            catch (ArgumentException ex)
            {
                
                throw;
            }
        }

        public List<Todo> GetAllTodos()
        {
            
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
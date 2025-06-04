using ConsoleAppTodoListNet.Models;
namespace ConsoleAppTodoListNet.Services
{
    public interface ITodoService
    {
        bool AddTodo(string? description, out string message);
        List<Todo> GetAllTodos();
        bool RemoveTodo(int id, out string m);
        void ClearTodos();
    }

    public class TodoService : ITodoService
    {
        private readonly List<Todo> _todos = [];
        private int _nextId = 1;

        public bool AddTodo(string? description, out string message)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                message = Messages.DescriptionEmpty;
                return false;
            }

            _todos.Add(new Todo
            {
                Id = _nextId++,
                Description = description
            });
            message = Messages.ItemAdded;
            return true;
        }
           

        public List<Todo> GetAllTodos()
        {

            return new List<Todo>(_todos);
        }

        public bool RemoveTodo(int id, out string message)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
                message = Messages.ItemDeleted;
                return true;
            }
            message = Messages.ItemNotFound;
            return false;
        }

        public void ClearTodos()
        {
            _todos.Clear();
        }
    }
}
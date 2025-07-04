using ConsoleAppTodoListNet.Models;
namespace ConsoleAppTodoListNet.Services
{
    public interface ITodoService
    {
        string AddTodo(string? description);
        List<Todo> GetAllTodos();
        string RemoveTodo(int id);
        string UpdateTodo(int id, string? newDescription);
        void ClearTodos();
    }

    public class TodoService : ITodoService
    {
        private readonly List<Todo> _todos = [];
        private int _nextId = 1;

        public string AddTodo(string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return Messages.DescriptionEmpty;
            }

            _todos.Add(new Todo
            {
                Id = _nextId++,
                Description = description
            });
            return Messages.ItemAdded;
        }

        public List<Todo> GetAllTodos()
        {
            return new List<Todo>(_todos);
        }

        public string RemoveTodo(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
                return Messages.ItemDeleted;
            }
            return Messages.ItemNotFound;
        }
        public string UpdateTodo(int id, string? newDescription)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return "Item not found.";

            if (string.IsNullOrWhiteSpace(newDescription))
                return "Description cannot be empty.";

            todo.Description = newDescription;
            return "Item updated successfully.";
        }
        public void ClearTodos()
        {
            _todos.Clear();
        }
    }
}
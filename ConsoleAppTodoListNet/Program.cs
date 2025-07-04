using ConsoleAppTodoListNet.Services;
public enum MenuOption
{
    Add = 1,
    View,
    Delete,
    Clear,
    Update,
    Exit
}

namespace ConsoleAppTodoListNet
{
    public class Program
    {
      public static void Main(string[] args)
{
    ITodoService service = new TodoService();

    while (true)
    {
        CreateHeader();
        var input = Console.ReadLine() ?? string.Empty;

        if (!int.TryParse(input, out int optionValue) ||
            !Enum.IsDefined(typeof(MenuOption), optionValue))
        {
            Console.WriteLine($"{Messages.InvalidChoice}");
            continue;
        }

        var choice = (MenuOption)optionValue;

        switch (choice)
        {
            case MenuOption.Add:
                AddTodoItem(service);
                break;
            case MenuOption.View:
                ViewTodoList(service);
                break;
            case MenuOption.Delete:
                DeleteTodoItem(service);
                break;
            case MenuOption.Clear:
                Console.Clear();
                break;
                    case MenuOption.Update:
                        UpdateTodoItem(service);
                        break;
                    case MenuOption.Exit:
                Console.WriteLine($"{Messages.ExitingApp}");
                break;
            default:
                Console.WriteLine($"{Messages.InvalidChoice}");
                break;
        }

        if (choice == MenuOption.Exit)
        {
            break;
        }
    }

    Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
    Console.ReadKey();
}
        private static void CreateHeader()
        {
            Console.WriteLine("==== TODO LIST ====");
            string[] menuOptions =
            {
        "1. Add item",
        "2. View items",
        "3. Delete item",
        "4. Clear console",
        "5. Update item",
        "6. Exit"
    };

            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
            Console.Write("Enter your choice: ");
        }
        private static void AddTodoItem(ITodoService service)
        {
            Console.Write($"{Environment.NewLine}Enter a new TODO item: ");
            var description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description))
            {
                string message = service.AddTodo(description);
                Console.WriteLine($"{message}");
            }
            else
            {
                Console.WriteLine("Description cannot be empty.");
            }
        }

        private static void ViewTodoList(ITodoService service)
        {
            var todos = service.GetAllTodos();
            Console.WriteLine($"{Environment.NewLine}==== TODO LIST ====");
            if (todos.Count == 0)
            {
                Console.WriteLine($"{Messages.ItemNotFound}");
            }
            else
            {
                foreach (var todo in todos)
                {
                    Console.WriteLine($"{todo.Id}. {todo.Description}");
                }
            }
        }
        private static void UpdateTodoItem(ITodoService service)
        {
            ViewTodoList(service);
            Console.Write($"{Environment.NewLine}Enter the ID of the item to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter the new description: ");
                var newDescription = Console.ReadLine();
                string message = service.UpdateTodo(id, newDescription);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"{Messages.InvalidId}");
            }
        }
        private static void DeleteTodoItem(ITodoService service)
        {
            ViewTodoList(service);
            Console.Write($"{Environment.NewLine}Enter the ID of the item to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                string message = service.RemoveTodo(id); 
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"{Messages.InvalidId}");
            }
        }

    }
}
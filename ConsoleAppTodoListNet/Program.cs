using ConsoleAppTodoListNet.Services;

namespace ConsoleAppTodoListNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ITodoService service = new TodoService();


            string choice;

            while (true)
            {
                CreateHeader();
                choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        AddTodoItem(service);
                        break;
                    case "2":
                        ViewTodoList(service);
                        break;
                    case "3":
                        DeleteTodoItem(service);
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        Console.WriteLine($"{Messages.ExitingApp}");
                        break;
                    default:
                        Console.WriteLine($"{Messages.InvalidChoice}");
                        break;
                }

                if (choice == "5")
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
        "5. Exit"
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
                if (service.AddTodo(description, out string message))
                {
                    Console.WriteLine($"{message}");
                }
                else
                {
                    Console.WriteLine($"Failed to add item: {message}");
                }
            }
            else
            {
                service.AddTodo(description, out string message);
                Console.WriteLine(message);
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
        private static void DeleteTodoItem(ITodoService service)
        {
            ViewTodoList(service);
            Console.Write($"{Environment.NewLine}Enter the ID of the item to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (service.RemoveTodo(id, out string message))
                {
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine($"{Messages.InvalidId}");
            }
        }
    }
}
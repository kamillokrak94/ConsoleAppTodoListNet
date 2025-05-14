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
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (choice == "5")
                {
                    break;
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        private static void CreateHeader()
        {
            Console.WriteLine("==== TODO LIST ====");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. View items");
            Console.WriteLine("3. Delete item");
            Console.WriteLine("4. Clear console");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }
        private static void AddTodoItem(ITodoService service)
        {
            Console.Write("\nEnter a new TODO item: ");
            var description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description))
            {
                service.AddTodo(description);
                Console.WriteLine("Item added successfully.");
            }
            else
            {
                Console.WriteLine("Description cannot be empty.");
            }
        }

        private static void ViewTodoList(ITodoService service)
        {
            var todos = service.GetAllTodos();
            Console.WriteLine("\n==== TODO LIST ====");
            if (todos.Count == 0)
            {
                Console.WriteLine("No items found.");
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
            Console.Write("\nEnter the ID of the item to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (service.RemoveTodo(id))
                {
                    Console.WriteLine("Item deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
    }
}
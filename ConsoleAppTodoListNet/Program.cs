namespace ConsoleAppTodoListNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> todoList = new List<string>();
            string choice;

            do
            {
                CreateHeader();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTodoItem(todoList);
                        break;
                    case "2":
                        ViewTodoList(todoList);
                        break;
                    case "3":
                        DeleteTodoItem(todoList);
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
            } while (choice != "5");

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
        private static void AddTodoItem(List<string> todoList)
        {
            Console.Write("\nEnter a new TODO item: ");

            Console.WriteLine("Item added successfully.");

        }

        private static void ViewTodoList(List<string> todoList)
        {
            Console.WriteLine("\n==== TODO LIST ====");

        }

        private static void DeleteTodoItem(List<string> todoList)
        {
            ViewTodoList(todoList);

            Console.WriteLine("Item deleted successfully.");


        }

    }
}

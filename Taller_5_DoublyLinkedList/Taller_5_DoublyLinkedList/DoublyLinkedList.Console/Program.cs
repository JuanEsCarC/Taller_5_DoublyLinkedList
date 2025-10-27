
using DoublyLinkedList.Core;

var list = new DoublyLinkedList<string>();
var opc = string.Empty;


do
{
    opc = Menu();
    switch (opc)
    {
        case "0":
            Console.WriteLine("Exiting...");
            break;
        case "1":
            Console.Write("Enter the value to insert: ");
            var valueAdd = Console.ReadLine()!;
            if (valueAdd != null)
            {
                list.InsertSorted(valueAdd);
            }
            Console.WriteLine($"Inserted {valueAdd} at the list.");
            break;
        case "2":
            Console.WriteLine("Forward list:");
            Console.WriteLine(list.GetForward());
            Console.WriteLine();
            break;
        case "3":
            Console.WriteLine("Backward list:");
            Console.WriteLine(list.GetBackward());
            Console.WriteLine();
            break;
        case "4":
            list.SortDescending();
            Console.WriteLine("the list was sorted in descending order: ");
            Console.WriteLine(list.GetForward());
            Console.WriteLine();
            break;
        case "5":
            Console.WriteLine(list.ShowModa());
            break;
        case "6":
            list.SortAscending();
            Console.WriteLine(list.ShowGraph());
            break;
        case "7":
            Console.Write("Enter the value to validate: ");
            var valueValidate = Console.ReadLine()!;
            Console.WriteLine($"Inserted {valueValidate} to validate.");
            if (valueValidate != null)
            {
                string result = list.Exists(valueValidate);
                Console.WriteLine($"The value inserted to validate {result}");
            }
            else
                Console.WriteLine("The value inserted to validate is null.");
            break;
        case "8":
            Console.Write("Enter the value to delete: ");
            var valueDelete = Console.ReadLine()!;
            Console.WriteLine($"Inserted {valueDelete} to delete.");
            if (valueDelete != null)
            {
                list.DeleteConcurrency(valueDelete);
                Console.WriteLine($"The value was deleted");
            }
            break;
        case "9":
            list.DeleteAllConcurrency();
            Console.WriteLine("All Concurrency was deleted, the list is empty.");
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

} while (opc != "0");

string Menu()
{
    Console.WriteLine();
    Console.WriteLine("Option Menu");
    Console.WriteLine();
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show list forward");
    Console.WriteLine("3. Show list backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show moda(s)");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Delete a concurrency");
    Console.WriteLine("9. Delete all concurrency");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
    Console.Write("Enter your option: ");
    return Console.ReadLine()!;
}

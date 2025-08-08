using System;

namespace Warehouse_Inventory_Management_System
{
    class Program
    {
        static void Main()
        {
            var manager = new WareHouseManager();
            manager.SeedData();

            Console.WriteLine("\n--- Grocery Items ---");
            manager.PrintAllItems(manager.GetGroceryRepo());

            Console.WriteLine("\n--- Electronic Items ---");
            manager.PrintAllItems(manager.GetElectronicRepo());

            Console.WriteLine("\n--- Simulating Errors ---");

            try
            {
                manager.GetElectronicRepo().AddItem(new ElectronicItem(1, "Camera", 4, "Canon", 18));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }

            try
            {
                manager.GetGroceryRepo().RemoveItem(999);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }

            try
            {
                manager.GetElectronicRepo().UpdateQuantity(2, -10);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }

            try
            {
                manager.IncreaseStock(manager.GetGroceryRepo(), 1, -5);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }
            Console.WriteLine("\n--- Final Grocery Items ---");
            manager.PrintAllItems(manager.GetGroceryRepo());

            Console.WriteLine("\n--- Final Electronic Items ---");
            manager.PrintAllItems(manager.GetElectronicRepo());

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

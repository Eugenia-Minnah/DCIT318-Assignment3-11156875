using System;

namespace Inventory_Records
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "inventory.json";

            InventoryApp app = new InventoryApp(filePath);

            app.SeedSampleData();
            app.SaveData();

            Console.WriteLine("\n--- New Session ---\n");
            InventoryApp newApp = new InventoryApp(filePath);
            newApp.LoadData();
            newApp.PrintAllItems();
        }
    }
}
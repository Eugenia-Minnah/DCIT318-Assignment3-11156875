using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Records
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 12, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Mouse", 22, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Keyboard", 7, DateTime.Now));
            _logger.Add(new InventoryItem(4, "Monitor", 10, DateTime.Now));
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    public class WareHouseManager
    {
        private readonly InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
        private readonly InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

        public void SeedData()
        {
            // Electronics
            try { _electronics.AddItem(new ElectronicItem(1, "TV", 5, "Samsung", 24)); } catch { }
            try { _electronics.AddItem(new ElectronicItem(2, "Laptop", 3, "Hp", 12)); } catch { }
            try { _electronics.AddItem(new ElectronicItem(3, "Headphones", 10, "JBL", 6)); } catch { }

            // Groceries
            try { _groceries.AddItem(new GroceryItem(1, "Rice", 50, DateTime.Now.AddMonths(12))); } catch { }
            try { _groceries.AddItem(new GroceryItem(2, "Milk", 30, DateTime.Now.AddDays(10))); } catch { }
            try { _groceries.AddItem(new GroceryItem(3, "Eggs", 200, DateTime.Now.AddDays(21))); } catch { }
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                if (quantity <= 0)
                    throw new InvalidQuantityException("Quantity to increase must be positive.");

                var item = repo.GetItemById(id); 
                int newQty = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQty);
                Console.WriteLine($"Increased stock. ID:{id} New Quantity:{newQty}");
            }
            catch (DuplicateItemException ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with ID {id} removed.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public InventoryRepository<ElectronicItem> GetElectronicRepo() => _electronics;
        public InventoryRepository<GroceryItem> GetGroceryRepo() => _groceries;
    }
}

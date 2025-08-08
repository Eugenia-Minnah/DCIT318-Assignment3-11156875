using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    public class ElectronicItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public string Brand { get; }
        public int WarrantyMonths { get; }

        public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Brand = brand;
            WarrantyMonths = warrantyMonths;
        }

        public override string ToString()
            => $"ID:{Id} Name:{Name} Qty:{Quantity} Brand:{Brand} Warranty:{WarrantyMonths}mo";
    }
}
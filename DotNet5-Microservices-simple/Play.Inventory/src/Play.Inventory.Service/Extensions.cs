using Play.Inventory.Service.Dtos;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service
{
    public static class Extensions
    {
        public static InventoryItemDto AsDto(this InventoryItem Item, string name, string description)
        {
            return new InventoryItemDto(Item.CatalogItemId, name, description, Item.Quantity, Item.AcquiredDate);
        }
    }
}
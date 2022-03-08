using Play.Inventory.Service.Dtos;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service
{
    public static class Extensions
    {
        public static InventoryItemDto AsDto(this InventoryItem Item)
        {
            return new InventoryItemDto(Item.CatalogItemId, Item.Quantity, Item.AcquiredDate);
        }
    }
}
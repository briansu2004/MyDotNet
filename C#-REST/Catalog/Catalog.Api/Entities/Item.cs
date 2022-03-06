using System;

namespace Catalog.Api.Entities
{
    // Record Types
    // use for immutable objects
    public class Item
    {
        // init only; no set
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
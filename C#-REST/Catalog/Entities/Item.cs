using System;

namespace Catalog.Entities
{
    // Record Types
    // use for immutable objects
    public record Item
    {
        // init only; no set
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

    }
}
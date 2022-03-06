using System;

namespace Catalog.Api.Entities
{
    // Record Types
    // use for immutable objects
    public record ItemRecord
    {
        // init only; no set
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}
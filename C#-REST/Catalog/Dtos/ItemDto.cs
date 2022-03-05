
using System;

namespace Catalog.Dtos
{
    public record ItemDto
    {
        // init only; no set
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}
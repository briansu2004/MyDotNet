

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);

        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync(Item item);

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
    }
}
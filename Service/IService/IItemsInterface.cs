using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Models;

namespace ecommerce.Service.IService
{
    internal interface IItemsInterface
    {

        Task<SuccessMessage> AddItemAsync(AddItem item);
        Task<SuccessMessage> UpdateItemAsync(Item item);
        Task<SuccessMessage> DeleteItemAsync(string id);
        Task<SuccessMessage> GetItemAsync(string id);
        Task<List<Item>> GetAllItemsAsync();




    }
}
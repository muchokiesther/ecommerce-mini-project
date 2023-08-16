using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ecommerce.Models;
using ecommerce.Service.IService;
using Newtonsoft.Json;

namespace ecommerce.Service
{
    internal class ItemService : IItemsInterface

    {
        private readonly HttpClient _httpClient;
        private readonly string _url = " http://localhost:3000/Items";
        public ItemService()
        {
            _httpClient = new HttpClient();

        }
        public async Task<SuccessMessage> AddItemAsync(AddItem item)
        {

            var content = JsonConvert.SerializeObject(item);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_url, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                return new SuccessMessage { Message = "Item added Successfully" };
            }
            throw new Exception("Item not added ");


        }

          public async Task<SuccessMessage> DeleteItemAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(_url + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                return new SuccessMessage { Message = "Item deleted Successfully" };
            }
            throw new Exception("Item not deleted ");

        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
           var response = await _httpClient.GetAsync(_url);
            var items = JsonConvert.DeserializeObject<List<Item>>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                return items;
            }

            throw new Exception("Cant Get items");
        }

      
        public async Task<Item> GetItemAsync(string id)
        {
            var response = await _httpClient.GetAsync(_url + "/" + id);
            var item = JsonConvert.DeserializeObject<Item>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return item;
            }
            throw new Exception("Item not found");
        }

          public async Task<SuccessMessage> UpdateItemAsync(Item item)
        {
            var content = JsonConvert.SerializeObject(item);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(_url + "/" + item.Id, bodyContent);

            if (response.IsSuccessStatusCode)
            {
                return new SuccessMessage { Message = "Item Updated Successfully" };
            }
            else
            {
                throw new Exception("Updating an Item failed");
            }
        }

    }
}


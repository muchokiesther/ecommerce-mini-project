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
        //purpose ids to communicate with a service
          private readonly HttpClient _httpClient;
      private readonly string _url = " http://localhost:3000/Items"; 
          public ItemService()
          {
            _httpClient = new HttpClient();
           
          }
        public async Task<SuccessMessage> AddItemAsync(AddItem item)
        {

var content = JsonConvert.SerializeObject(item);
var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
var response = await _httpClient.PostAsync(_url,bodyContent);
if(response.IsSuccessStatusCode){
    return new SuccessMessage {Message= "Item added Successfully"};
    }
    throw new Exception("Item not added "); 
 

        }

        public Task<SuccessMessage> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SuccessMessage> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessMessage> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Helpers;
using ecommerce.Service;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class ItemsController
    {
        private readonly ItemService itemService = new ItemService();

        public static void Init()
        {
            Console.WriteLine("Welcome to The Great Shop");
            Console.WriteLine("1. Add an Item");
            Console.WriteLine("2. View Items");
            Console.WriteLine("3. Update an Item");
            Console.WriteLine("4. Delete an Item");
            var input = Console.ReadLine();
            var validateResults = Validation.Validate(new List<string> { input });
            if (!validateResults)
            {
                ItemsController.Init();
            }
            else
            {
                var itemsController = new ItemsController();
                itemsController.MenuRedirectAsync(input).Wait();
            }
        }

        public async Task MenuRedirectAsync(string Id)
        {
            switch (Id)
            {
                case "1":
                    await AddnewItem();
                    break;
                case "2":
                    await ViewItems();
                    break;
                case "3":
                    await UpdateItem();
                    break;
                case "4":
                    await DeleteItem();
                    break;
                default:
                    // await ItemsController.Init();
                    break;
            }
        }

        public async Task AddnewItem()
        {
            Console.WriteLine("Enter Item Name:");
            var itemName = Console.ReadLine();

            Console.WriteLine("Enter Item Description:");
            var itemDescription = Console.ReadLine();

            Console.WriteLine("Enter Item Price:");
            var itemPrice = Console.ReadLine();

            var newItem = new AddItem
            {
                ItemName = itemName,
                Description = itemDescription,
                Price = itemPrice
            };

            try
            {
                var res = await itemService.AddItemAsync(newItem);
                Console.WriteLine(res.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ViewItems()
        {
            try
            {
                var items = await itemService.GetAllItemsAsync();
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Id}. {item.ItemName}");
                }

                Console.WriteLine("View One of the Above Items");
                var id = Console.ReadLine();
                await ViewOneItem(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ViewOneItem(string id)
        {
            try
            {
                var res = await itemService.GetItemAsync(id);
                Console.WriteLine($"Name: {res.ItemName}");
                Console.WriteLine($"Description: {res.Description}");
                Console.WriteLine($"Price: {res.Price}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateItem()
        {
            await ViewItems();
            Console.WriteLine("Enter the Id of the Item you want to update:");
            var id = Console.ReadLine();

            Console.WriteLine("Enter Item Name:");
            var itemName = Console.ReadLine();

            Console.WriteLine("Enter Item Description:");
            var itemDescription = Console.ReadLine();

            Console.WriteLine("Enter Item Price:");
            var itemPrice = Console.ReadLine();

            var updatedItem = new Item
            {
                Id = id,
                ItemName = itemName,
                Description = itemDescription,
                Price = itemPrice
            };

            try
            {
                var res = await itemService.UpdateItemAsync(updatedItem);
                Console.WriteLine(res.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteItem()
        {
            await ViewItems();
            Console.WriteLine("Enter the Id of the Item you want to delete:");
            var id = Console.ReadLine();

            try
            {
                var res = await itemService.DeleteItemAsync(id);
                Console.WriteLine(res.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

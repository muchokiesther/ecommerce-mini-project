
using ecommerce.Controllers;

class Program
{
    public  async  static Task Main(string[] args)
    {
        await ItemsController.Init();
    }
}
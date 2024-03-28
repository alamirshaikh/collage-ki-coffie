using collage_ki_coffie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using collage_ki_coffie.Backend;

namespace collage_ki_coffie.Controllers
{
    [Authorize]
    public class Coffie : Controller
    {

        private readonly MainEngine _main;

        public Coffie(MainEngine Main)
        {
            _main = Main;
            
        }
        public IActionResult Buycoffie()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CoffieAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CoffieAdd(Coffies Model)
        {
            try
            {

            Coffies coffie = new Coffies()
                {
                    CoffeeName = Model.CoffeeName,
                    Description = Model.Description,
                    Price = Model.Price
               
                    
                };


             
                await _main.Add<Coffies>(coffie, "AddCoffeeItem");

            return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { success = false });   
            }
             

        }


    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace collage_ki_coffie.Controllers
{
    [Authorize]
    public class Coffie : Controller
    {

        public IActionResult Buycoffie()
        {
            return View();
        }



    }
}

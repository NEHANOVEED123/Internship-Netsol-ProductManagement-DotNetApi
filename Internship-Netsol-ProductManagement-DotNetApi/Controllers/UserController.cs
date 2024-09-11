using Microsoft.AspNetCore.Mvc;

namespace Internship_Netsol_ProductManagement_DotNetApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

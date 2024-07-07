using Microsoft.AspNetCore.Mvc;

namespace BookManagerApp.Controllers
{
    public class LibraryViewModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TestWebApplication.Areas.TestArea.Controllers
{
    [Area("TestArea")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

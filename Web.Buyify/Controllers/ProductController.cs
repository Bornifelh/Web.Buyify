using Microsoft.AspNetCore.Mvc;

namespace Web.Buyify.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Articles.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }


    }


}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Buyify.Models;

namespace Web.Buyify.Pages
{
    public class ArticlesDisponiblesModel : PageModel
    {
        private readonly AppDbContext _context;
        public ArticlesDisponiblesModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Article>? Articles { get; set; }

        public void OnGet()
        {
            try
            {
                Articles = _context?.Articles.ToList();
            }
            catch (Exception ex)
            {
                _ = new Exception(ex.Message);
            }

        }
    }
}

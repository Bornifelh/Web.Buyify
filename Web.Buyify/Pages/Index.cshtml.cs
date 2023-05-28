using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Buyify.Models;

namespace Web.Buyify.Pages
{
    public class IndexModel : PageModel
    {   
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context; 
        }

        public List<Article>? Articles { get; set; }
        public List<CategoryMag>? CategoryMag { get;set; }

        public void OnGet()
        {
            try
            {
                 Articles = _context?.Articles.ToList();
                 CategoryMag = _context?.CategoryMag.ToList();
            }
            catch (Exception ex) 
            {
                _ = new Exception(ex.Message);
            }
            
        }
    }
}
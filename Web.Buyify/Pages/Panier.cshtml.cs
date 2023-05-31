using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Buyify.Pages
{
    
    public class PanierModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }

       
        public void OnGet()
        {
        }
    }
}

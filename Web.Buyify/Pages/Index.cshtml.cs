﻿using Microsoft.AspNetCore.Mvc;
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
            Articles = _context?.Articles.ToList();
          CategoryMag = _context?.CategoryMag.ToList();            
        }

        public IActionResult NewsletterDialog()
        {
            return PartialView("NewsletterDialog");
        }

        private IActionResult PartialView(string v)
        {
            throw new NotImplementedException();
        }
    }
}
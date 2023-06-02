using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Buyify;
using Web.Buyify.Models;

namespace Web.Buyify.Controllers
{
    public class UserCustomersController : Controller
    {
        private readonly AppDbContext _context;

        public UserCustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserCustomers
        public async Task<IActionResult> Index()
        {
              return _context.UsersCustomers != null ? 
                          View(await _context.UsersCustomers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.UsersCustomers'  is null.");
        }

        // GET: UserCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsersCustomers == null)
            {
                return NotFound();
            }

            var userCustomer = await _context.UsersCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCustomer == null)
            {
                return NotFound();
            }

            return View(userCustomer);
        }

        // GET: UserCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Utilisateur,Pass,Nom,Mail,Phone,Adresse,Ville,Province,Nationalite")] UserCustomer userCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCustomer);
        }

        // GET: UserCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsersCustomers == null)
            {
                return NotFound();
            }

            var userCustomer = await _context.UsersCustomers.FindAsync(id);
            if (userCustomer == null)
            {
                return NotFound();
            }
            return View(userCustomer);
        }

        // POST: UserCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Utilisateur,Pass,Nom,Mail,Phone,Adresse,Ville,Province,Nationalite")] UserCustomer userCustomer)
        {
            if (id != userCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCustomerExists(userCustomer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userCustomer);
        }

        // GET: UserCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsersCustomers == null)
            {
                return NotFound();
            }

            var userCustomer = await _context.UsersCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCustomer == null)
            {
                return NotFound();
            }

            return View(userCustomer);
        }

        // POST: UserCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsersCustomers == null)
            {
                return Problem("Entity set 'AppDbContext.UsersCustomers'  is null.");
            }
            var userCustomer = await _context.UsersCustomers.FindAsync(id);
            if (userCustomer != null)
            {
                _context.UsersCustomers.Remove(userCustomer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCustomerExists(int id)
        {
          return (_context.UsersCustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

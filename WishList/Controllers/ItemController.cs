using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            return View("Index", new List<Item>());
        }
        
        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        
        // POST
        [HttpPost]
        public IActionResult Create(Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        // DELETE
        public IActionResult Delete(int Id)
        {
            var Item = _context.Items.FirstOrDefault(e => e.Id == Id);

            _context.Items.Remove(Item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

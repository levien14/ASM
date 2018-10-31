using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC.Models;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["Create"] = "Create Success";
            return Redirect("Index");
        }

        public IActionResult Edit(long id)
        {
            var checke = _context.Products.Find(id);
            if (checke == null)
            {
                return NotFound();
            }
            return View(checke);
        }

        public IActionResult Update(Product product)
        {
            var checke = _context.Products.Find(product.id);
            if (checke == null)
            {
                return NotFound();
            }

            checke.name = product.name;
            checke.price = product.price;
            _context.Products.Update(checke);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Delete(Product product)
        {
            var del = _context.Products.Find(product.id);
            if (del == null)
            {
                return NotFound();
            }

            _context.Products.Remove(del);
            _context.SaveChanges();
            return Redirect("Index");

        }
    }
}
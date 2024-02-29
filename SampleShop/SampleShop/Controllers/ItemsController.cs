using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleShop.Data;
using SampleShop.Models;
namespace SampleShop.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objlist = _db.Items;
            return View(objlist);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Item target = _db.Items.SingleOrDefault(d => d.Id == id);
            ViewBag.isInCart = false;

            Byte[] info;
            HttpContext.Session.TryGetValue("cart", out info);
            if (!(info is null))
            {
                var originalList = Enumerable.Range(0, info.Length / 4)
                             .Select(i => BitConverter.ToInt32(info, i * 4))
                             .ToList();
                if (originalList.Contains(id))
                    ViewBag.isInCart = true;
            }
            return View(target);
        }


        public IActionResult AddToCart(int id)
        {
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                Byte[] info;
                HttpContext.Session.TryGetValue("cart", out info);
                if (!(info is null))
                {
                    var originalList = Enumerable.Range(0, info.Length / 4)
                                 .Select(i => BitConverter.ToInt32(info, i * 4))
                                 .ToList();
                    originalList.Add(id);
                    byte[] bytes = originalList.SelectMany(BitConverter.GetBytes).ToArray();
                    HttpContext.Session.Set("cart", bytes);
                    return RedirectToAction("Detail", new { id = id });
                }
            }
            byte[] intBytes = BitConverter.GetBytes(id);
            HttpContext.Session.Set("cart", intBytes);
            HttpContext.Session.TryGetValue("cart", out intBytes);
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult cart()
        {
            Byte[] info;
            HttpContext.Session.TryGetValue("cart", out info);
            if (!(info is null)) {
                var originalList = Enumerable.Range(0, info.Length / 4)
                             .Select(i => BitConverter.ToInt32(info, i * 4))
                             .ToList();
                IEnumerable<Item> cartList = _db.Items.Where(d => originalList.Contains(d.Id));
                return View(cartList);
            }
            IEnumerable<Item> empty = _db.Items.Where(d => false);
            return View(empty);
        }

        public IActionResult RemoveFromCartInCart(int id)
        {
            Byte[] info;
            HttpContext.Session.TryGetValue("cart", out info);
            if (!(info is null))
            {
                var originalList = Enumerable.Range(0, info.Length / 4)
                             .Select(i => BitConverter.ToInt32(info, i * 4))
                             .ToList();
                originalList.Remove(id);
                byte[] bytes = originalList.SelectMany(BitConverter.GetBytes).ToArray();
                HttpContext.Session.Set("cart", bytes);
            }
            return RedirectToAction("cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            Byte[] info;
            HttpContext.Session.TryGetValue("cart", out info);
            if (!(info is null))
            {
                var originalList = Enumerable.Range(0, info.Length / 4)
                             .Select(i => BitConverter.ToInt32(info, i * 4))
                             .ToList();
                originalList.Remove(id);
                byte[] bytes = originalList.SelectMany(BitConverter.GetBytes).ToArray();
                HttpContext.Session.Set("cart", bytes);
            }
            return RedirectToAction("Detail",new {id=id });
        }
    }

}

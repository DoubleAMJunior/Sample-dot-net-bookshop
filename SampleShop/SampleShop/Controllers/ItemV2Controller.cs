using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleShop.Data;
using SampleShop.Models;
using SampleShop.ServiceAndMiddleware;

namespace SampleShop.Controllers
{
    public class ItemV2Controller : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserManager userManager;

        public ItemV2Controller(ApplicationDbContext db,IUserManager um)
        {
            _db = db;
            userManager = um;
        }

        public IActionResult Index()
        {
            
            IEnumerable<ItemV2> objlist = _db.ItemsV2;
            ViewBag.manager = false;
            if (userManager.isSigned())
            {
                if (userManager.getUser().Manager)
                {
                    ViewBag.manager = true;
                }
            }
            return View(objlist);
        }

        public IActionResult Add()
        {
            if (userManager.isSigned()) 
            {
                if (userManager.getUser().Manager)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(ItemV2 obj)
        {
            if (!userManager.isSigned())
                return RedirectToAction("Index");
            
            if (!userManager.getUser().Manager)
                return RedirectToAction("Index");
            
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files["ImageData"];
                BinaryReader reader = new BinaryReader(file.OpenReadStream());
                Byte[] data = reader.ReadBytes((int)file.Length);
                obj.img = data;

                _db.ItemsV2.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            ItemV2 target = _db.ItemsV2.SingleOrDefault(d => d.Id == id);
            ViewBag.img = File(target.img, "image/*");

            if (userManager.isSigned())
            {
                ViewBag.isInCart = false;
                User cu = userManager.getUser();
                string[] idString = cu.CartItemIds.Split(" ");
                string ID = id.ToString();
                for (int i = 0; i < idString.Length; i++)
                {
                    if (ID.Equals(idString[i]))
                    {
                        ViewBag.isInCart = true;
                    }
                }
            }
            else
            {
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
            }

            return View(target);
        }

        public ActionResult GetImage(int id)
        {
            var q = from temp in _db.ItemsV2 where temp.Id == id select temp.img;
            byte[] cover = q.First();

            if (cover != null)
            {
                return File(cover, "image/*");
            }
            return null;
        }

        public IActionResult AddToCart(int id)
        {
            if (userManager.isSigned())
            {
                User cu = userManager.getUser();
                cu.CartItemIds += " " + id;
                _db.Users.Update(cu);
                _db.SaveChanges();
            }
            else
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
            }
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult cart()
        {
            ViewBag.signed = false;
            if (userManager.isSigned())
            {
                ViewBag.signed = true;
                User cu = userManager.getUser();
                string[] idString=cu.CartItemIds.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (idString.Equals(""))
                {
                    IEnumerable<ItemV2> emptyList = _db.ItemsV2.Where(d => false);
                    return View(emptyList);
                }
                else
                {
                    int[] id = Array.ConvertAll(idString, s => int.Parse(s));
                    IEnumerable<ItemV2> items = _db.ItemsV2.Where(d => Array.Exists(id, e => e == d.Id));
                    return View(items); 
                }
            }
            Byte[] info;
            HttpContext.Session.TryGetValue("cart", out info);
            if (!(info is null))
            {
                var originalList = Enumerable.Range(0, info.Length / 4)
                             .Select(i => BitConverter.ToInt32(info, i * 4))
                             .ToList();
                IEnumerable<ItemV2> cartList = _db.ItemsV2.Where(d => originalList.Contains(d.Id));
                return View(cartList);
            }
            IEnumerable<ItemV2> empty = _db.ItemsV2.Where(d => false);
            return View(empty);
        }

        public IActionResult RemoveFromCartInCart(int id)
        {
            if (userManager.isSigned())
            {
                User cu = userManager.getUser();
                string[] idString = cu.CartItemIds.Split(" ");
                string ID = id.ToString();
                for (int i = 0; i < idString.Length; i++)
                {
                    if (ID.Equals(idString[i]))
                    {
                        idString[i] = "";
                        break;
                    }
                }
                cu.CartItemIds = String.Join(" ", idString);
                _db.Users.Update(cu);
                _db.SaveChanges();
            }
            else
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
            }
            return RedirectToAction("cart");
        }
        public IActionResult RemoveFromCart(int id)
        {
            if (userManager.isSigned())
            {
                User cu = userManager.getUser();
                string[] idString = cu.CartItemIds.Split(" ");
                string ID = id.ToString();
                for (int i = 0; i < idString.Length; i++)
                {
                    if (ID.Equals(idString[i]))
                    {
                        idString[i] = "";
                        break;
                    }
                }
                cu.CartItemIds = String.Join(" ", idString);
                _db.Users.Update(cu);
                _db.SaveChanges();
            }
            else
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
            }
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult Purchase()
        {
            if (userManager.isSigned())
            {
                User cu = userManager.getUser();
                string[] idString = cu.CartItemIds.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (!idString.Equals("")) 
                {
                    int[] id = Array.ConvertAll(idString, s => int.Parse(s));
                    IEnumerable<ItemV2> items = _db.ItemsV2.Where(d => Array.Exists(id, e => e == d.Id));
                    foreach (var item in items)
                    {
                        item.NumAvailable--;
                        if (item.NumAvailable <= 0)
                        {
                            _db.ItemsV2.Remove(item);
                        }
                        else
                        {
                            _db.ItemsV2.Update(item);
                        }
                        
                    }
                }
                cu.CartItemIds = "";
                _db.Users.Update(cu);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}

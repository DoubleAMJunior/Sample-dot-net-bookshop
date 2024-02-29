using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleShop.Models;
using SampleShop.Data;

namespace SampleShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }
            
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User credentials)
        {
            User target = _db.Users.SingleOrDefault(d => d.UserName.Equals(credentials.UserName));
            if (target is null)
                return View();
            if (target.pass.Equals(credentials.pass))
            {
                String currentCart = getSessionCart();
                if (target.CartItemIds.Equals(""))
                {
                    target.CartItemIds = currentCart;
                }
                else
                {
                    target.CartItemIds += " " + currentCart;
                }
                _db.Users.Update(target);
                _db.SaveChanges();
                HttpContext.Response.Cookies.Append("user_id", target.Id.ToString());
                return RedirectToAction( "Index","ItemV2");
            }
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                newUser.CartItemIds = getSessionCart();
                _db.Users.Add(newUser);
                _db.SaveChanges();
                HttpContext.Response.Cookies.Append("user_id", newUser.Id.ToString());
                return RedirectToAction( "Index","ItemV2");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("user_id");
            return RedirectToAction("Index", "ItemV2");
        }

        [NonAction]
        private String getSessionCart()
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
                    String result = String.Join(" ", originalList);
                    return result;
                }
            }
            return "";
        }
    }
}

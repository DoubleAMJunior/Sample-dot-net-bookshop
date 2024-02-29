using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcTraining.Models;
using System.ComponentModel.DataAnnotations;
using DataManager.Data;
using System.Reflection;

namespace MvcTraining.Controllers
{
    public class StartController : Controller
    {
        private AppDbContext _context;
        private AutoMapper.Mapper mapper;
        private AutoMapper.Mapper reverseMapper;
        private AutoMapper.Mapper mapperDUser;

        public StartController(AppDbContext context) {
            _context = context;
            var mapConfig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<User, DataManager.Entities.User>().BeforeMap((src, dest) => {
                dest.addresses = new List<DataManager.Entities.Address>();
                dest.addresses.Add(new DataManager.Entities.Address(src.address1));
                dest.addresses.Add(new DataManager.Entities.Address(src.address2));
            }));

            var reverseCofig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DataManager.Entities.User,User>().BeforeMap((src, dest) => {
               // DataManager.Entities.Address[] list = src.addresses.ToArray();
                //dest.address1 = list[0].address;
                //dest.address2 = list[1].address;
            }));
            var duserMapperCongif = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DataManager.Entities.User, DataManager.Entities.User>());
            mapper = new AutoMapper.Mapper(mapConfig);
            reverseMapper = new AutoMapper.Mapper(reverseCofig);
            mapperDUser = new AutoMapper.Mapper(duserMapperCongif);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(User user)
        {
            var context = new ValidationContext(user);
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(user, context, validationResult, true)) {

                DataManager.Entities.User DUser = mapper.Map<DataManager.Entities.User>(user);
                DataManager.Entities.User found = _context.Users.FirstOrDefault<DataManager.Entities.User>(s => s.email == DUser.email);
                if (found is null)
                {
                    _context.Add(DUser);
                }
                else
                {
                    PropertyInfo[] properties = typeof(DataManager.Entities.User).GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        if (p.GetValue(DUser) != p.GetValue(found))
                        {
                            p.SetValue(found, p.GetValue(DUser));
                        }
                    }
                }
                _context.SaveChanges();
                return "user" + DUser.firstName + DUser.lastName + " Created";
            }
            return String.Join(",", validationResult.Select(r => r.ErrorMessage));
        }

        public IActionResult update()
        {
            return View();
        }

        [HttpPost]
        public string update(User user)
        {
            var context = new ValidationContext(user);
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(user, context, validationResult, true))
            {

                DataManager.Entities.User DUser = mapper.Map<DataManager.Entities.User>(user);
                _context.Entry(DUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "user" + DUser.firstName + DUser.lastName + " Created";
            }
            return String.Join(",", validationResult.Select(r => r.ErrorMessage));
        }

        public IActionResult SpreadSheat()
        {
            List<DataManager.Entities.User> dbEntities= _context.Users.Where(t=> t.email!="").ToList();
            List<User> dbObjects= new List<User>();
            foreach (var entity in dbEntities)
            {
                User u = reverseMapper.Map<User>(entity);
                dbObjects.Add(u);
            }
            return View(dbObjects);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult SpreadSheat(ICollection<User> usersList)
        {
            List<DataManager.Entities.User> uiUsers = new List<DataManager.Entities.User>();
            foreach (User u in usersList)
            {
                if (u.email!=null) {
                    uiUsers.Add(mapper.Map<DataManager.Entities.User>(u));
                }
            }

            List<DataManager.Entities.User> dbUsers=_context.Users.ToList<DataManager.Entities.User>();

            var d = dbUsers.Except(uiUsers).ToList();
            _context.Users.RemoveRange(d);
            var e = uiUsers.Except(dbUsers).ToList();
            _context.Users.AddRange(e);
            dbUsers.Join(uiUsers,d=> d.email,u=> u.email,(o,u)=>new {o,u }).ToList().ForEach(i=> { mapperDUser.Map<DataManager.Entities.User, DataManager.Entities.User>(i.u,i.o); });

            _context.SaveChanges();
            return RedirectToAction("SpreadSheat");
        }

        [HttpPost]
        public IActionResult addRow(List<User> userList)
        {
            userList.Add(new Models.User());
            return View("SpreadSheat",userList);
        }
    }
}
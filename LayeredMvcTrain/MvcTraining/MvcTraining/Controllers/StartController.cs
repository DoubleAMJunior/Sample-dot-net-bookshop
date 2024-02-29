using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq.Expressions;

namespace MvcTraining.Controllers
{
    public class StartController : Controller
    {
        private ApplicationServices.ServiceInterface.IUserModelDbActions _dbOperator;
        private ApplicationServices.ServiceInterface.IUserMapper _mapper;
        private DataManager.Data.AppDbContext Context;
        public StartController(ApplicationServices.ServiceInterface.IUserModelDbActions dbActions,ApplicationServices.ServiceInterface.IUserMapper m, DataManager.Data.AppDbContext Context)
        {
            _dbOperator = dbActions;
            _mapper = m;
            this.Context = Context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ApplicationServices.Models.User user)
        {
            var context = new ValidationContext(user);
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(user, context, validationResult, true))
            {

                _dbOperator.addOrInsertUser(user);
                return RedirectToAction("SpreadSheat");
            }
            return View("Index");
        }

        public IActionResult update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult update(ApplicationServices.Models.User user)
        {
            var context = new ValidationContext(user);
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(user, context, validationResult, true))
            {

                _dbOperator.addOrInsertUser(user);
                return RedirectToAction("SpreadSheat");
            }
            return View("update");
        }

        public IActionResult SpreadSheat()
        {
            List < ApplicationServices.Models.User> dbObjects = _dbOperator.getUserEntity(t => t.Email != "").ToList();
            return View(dbObjects);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult SpreadSheat(ICollection<ApplicationServices.Models.User> usersList)
        {
            _dbOperator.RemoveMissing(usersList);
            _dbOperator.Insertnew(usersList);
            _dbOperator.bulkUpdate(usersList);
            return RedirectToAction("SpreadSheat");
        }

        [HttpPost]
        public IActionResult addRow(List<ApplicationServices.Models.User> userList)
        {
            userList.Add(new ApplicationServices.Models.User());
            return View("SpreadSheat", userList);
        }
        
        public IActionResult Search()
        {
            return View(new ApplicationServices.Models.GenericSearchModel<ApplicationServices.Models.UserSearchModel, ApplicationServices.Models.UserResultModel>());
        }
        [HttpPost]
        public IActionResult Search(ApplicationServices.Models.GenericSearchModel<ApplicationServices.Models.UserSearchModel, ApplicationServices.Models.UserResultModel> searchObj)
        {
            if (ModelState.IsValid)
            {
                if (searchObj.searchModel.name != null)
                {
                    List<String> s = searchObj.searchModel.name.Split(" ").ToList();
                   



                   /* ParameterExpression Input = Expression.Parameter(typeof(Core.Entities.User), "Input");
                    ParameterExpression res = Expression.Parameter(typeof(bool), "res");
                  //  ParameterExpression invokertn = Expression.Parameter(typeof(bool));
                    List<ParameterExpression> head = new List<ParameterExpression>();
                    head.Add(res);
                  //  head.Add(invokertn);
                    
                    List<Expression> body=new List<Expression>();

                   // ParameterExpression s0 = Expression.Parameter(typeof(string), "s0");
                   // head.Add(s0);
                    //Expression assignS0 = Expression.Assign(s0, Expression.Constant(s[0],typeof(string)));


                    Expression line1 =Expression.Assign(res, Expression.Constant(true));
                    //Expression line2 = Expression.Invoke(CheckContain,Input,s0);
                    //Expression invokeAssign = Expression.Assign(invokertn, line2);
                   // Expression line3 = Expression.MakeBinary(ExpressionType.AndAlso,invokertn, res);
                    //Expression line4 = Expression.Assign(res, line3);

                    LabelTarget returnTarget = Expression.Label(typeof(bool),"ReturnLabelTarget");
                    GotoExpression returnLine = Expression.Return(returnTarget, res,typeof(bool));
                    LabelExpression labelExpression = Expression.Label(returnTarget, Expression.Constant(false, typeof(bool)));

                    //body.Add(assignS0);
                    body.Add(line1);
                    //body.Add(invokeAssign);
                   // body.Add(line4);
                    body.Add(returnLine);
                    body.Add(labelExpression);
                    BlockExpression block = Expression.Block(
                            head,
                            body
                        );

                    *//*  Expression<Func<Core.Entities.User, bool>> expF = (u) => s.All(e=> (u.firstName + " " + u.lastName).Contains(e));
                      var results= Context.Users.Where(expF).ToList();*//*
                    string blockString = block.ToString();
                    Core.Entities.User CoreUser = new Core.Entities.User();
                    CoreUser.firstName = "Ali";
                    CoreUser.lastName = "Abbasi";*/
                    var selector = makeExpresion(s);
                    string selectortext = selector.ToString();
                    var results = Context.Users.Where(selector);
                    var resultList = results.ToList();

                    // e=>(u.firstName + " " + u.lastName).Contains(e));
                    /* Expression<Func<IEnumerable<string>,bool>> andaggeragate = (l) => BinaryExpression.And(checkSearch)
                     Expression<Func >*/

                    //Context.Users.Where(checkSearch).ToList();

                    //var searchResult = _dbOperator.getUserEntity(checkSearch.Compile());
                    // List<ApplicationServices.Models.User> results = searchResult.ToList();
                    /*searchResult = searchResult.Where(u => {
                        if (searchObj.searchModel.startBD == null)
                            return true;
                        var searchList = searchObj.searchModel.startBD.Split("/");
                        if (searchList.Length != 3)
                        {
                            return true;
                        }
                        var dbList = u.BirthDate.Split("/");
                        for (int i = 0; i < 3; i++)
                        {
                            if (Int32.Parse(searchList[i]) < Int32.Parse(dbList[i]))
                            {
                                return true;
                            }
                            else if (Int32.Parse(searchList[i]) > Int32.Parse(dbList[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }).ToList();
                    searchResult = searchResult.Where(u => {
                        if (searchObj.searchModel.endBD == null)
                            return true;
                        var searchList = searchObj.searchModel.endBD.Split("/");
                        if (searchList.Length != 3)
                        {
                            return true;
                        }
                        var dbList = u.BirthDate.Split("/");
                        for (int i = 0; i < 3; i++)
                        {
                            if (Int32.Parse(searchList[i]) < Int32.Parse(dbList[i]))
                            {
                                return false;
                            }
                            else if (Int32.Parse(searchList[i]) > Int32.Parse(dbList[i]))
                            {
                                return true;
                            }
                        }
                        return true;
                    }).ToList();*/
                    searchObj.resultModel = new List<ApplicationServices.Models.UserResultModel>();
                    foreach (Core.Entities.User u in results)
                    {
                        var modelUser = _mapper.MapEntityToUser(u);
                        searchObj.resultModel.Add(_mapper.mapUserToSearchModel(modelUser));
                    }
                }

            }
            return View(searchObj);
        }

        private Expression<Func<Core.Entities.User, bool>> makeExpresion(List<String> splited) 
        {
            ParameterExpression input = Expression.Parameter(typeof(Core.Entities.User));
            Expression<Func<Core.Entities.User, String, bool>> CheckContain = (u, p) => (u.firstName + " " + u.lastName).Contains(p);

            BinaryExpression res = null;
            foreach (String part in splited)
            {
                Expression newPart = Expression.Invoke(CheckContain,input,Expression.Constant(part,typeof(string)));
                res = res == null ? Expression.And(Expression.Constant(true,typeof(bool)) ,newPart) : Expression.AndAlso(res,newPart);
            }
            return Expression.Lambda<Func<Core.Entities.User, bool>>(res,new List<ParameterExpression>() { input });
        }
    }
}

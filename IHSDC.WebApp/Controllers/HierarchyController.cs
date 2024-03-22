using IHSDC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    public class HierarchyController : Controller
    {
        // GET: Hierarchy
        public ActionResult Index()
        {
            try
            { 
                using(var db = new ApplicationDbContext())
                {
                    //Nitesh 10-02-2023
                    if (Session["UserIntId"] != null)
                    {
                        ViewBag.Root = db.Users.FirstOrDefault(p => p.Superior == null).UserName;
                        if (db.Users.Count() == 1) return HttpNotFound("No user exists in hierarchy. Nothing to display!");

                        var users = db.Users.ToList().OrderBy(u => u.IntId);
                        var FullHierarchyList = new List<FullHierarchyView>();
                        foreach (var user in users)
                        {
                            var HierarchyList = UHierarchy.GetHierarchy(user);
                            foreach (var item in HierarchyList)
                            {
                                if (user.IntId != item.IntId)
                                {
                                    FullHierarchyList.Add(
                                        new FullHierarchyView
                                        {
                                            UserId = user.IntId,
                                            ChildId = item.IntId
                                        });
                                }
                                else
                                {
                                    FullHierarchyList.Add(
                                        new FullHierarchyView
                                        {
                                            UserId = user.IntId,
                                            ChildId = 0
                                        });
                                }
                            }
                        }
                        return View(FullHierarchyList);
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }

                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
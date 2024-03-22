using IHSDC.Common.Models;
using IHSDC.WebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    public class RolesController : BaseController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var rolesList = new List<RoleViewModel>();
            foreach (var role in _db.Roles)
            {
                var roleModel = new RoleViewModel()
                {
                    RoleName = role.Name,
                    Description = role.Description
                };
                rolesList.Add(roleModel);
            }
            return View(rolesList);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Create([Bind(Include = "RoleName, Description")]RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(model.RoleName, model.Description);
                ApplicationRoleManager _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
                var roleExisits = await _roleManager.RoleExistsAsync(model.RoleName);
                if (roleExisits)
                {
                    Warning(string.Format("Role <b>{0}</b> already exists.", model.RoleName), true);
                    return View();
                }
                else
                {
                    var idResult = _roleManager.Create(new ApplicationRole(model.RoleName, model.Description));
                    //_db.CreateRole(_roleManager, model.RoleName, model.Description);
                    Success(string.Format("Role <b>{0}</b> was successfully added.", model.RoleName), true);
                    return RedirectToAction("Index", "Roles");
                }
            }
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            // It's actually the Role.Name tucked into the id param:
            var role = _db.Roles.First(r => r.Name == id);
            var roleModel = new EditRoleViewModel(role);
            return View(roleModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include =
            "RoleName,OriginalRoleName,Description")] EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _db.Roles.First(r => r.Name == model.OriginalRoleName);
                role.Name = model.RoleName;
                role.Description = model.Description;
                _db.Entry(role).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(id == "Administrator")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Administrator Role Cannot Be Deleted!");
            }
            if (id == "User")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User Role Cannot Be Deleted!");
            }
            if (id == "NoSubordinates")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "NoSubordinates Role Cannot Be Deleted!");
            }
            var role = _db.Roles.First(r => r.Name == id);
            var model = new RoleViewModel(role);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            //var role = _db.Roles.First(r => r.Name == id);
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));

            var role = _db.Roles.First(r => r.Name == id);
            var roleUsers = _db.Users.Where(u => u.UserRoles.Any(r => r.RoleId == role.Id));
            foreach(var user in roleUsers)
            {
                userManager.RemoveFromRole(user.Id, role.Name);
            }

            _db.Roles.Remove(role);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //TODO: Add or Remove Roles to Users
    }
}
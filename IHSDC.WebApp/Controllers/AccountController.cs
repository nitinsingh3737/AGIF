using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using IHSDC.WebApp.Models;
using System.Data.Entity;
using System.Net;
using System.Collections.Generic;

namespace IHSDC.WebApp.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public AccountController()
        {
            System.Web.Helpers.AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        //GET: /Account
        [Authorize]
        public ActionResult Hierarchy()
        {
            var CurrentUser = UserManager.FindById(User.Identity.GetUserId());
            if (User.IsInRole("Administrator"))
                Information("You have <strong>Administrative Previleges</strong>, please make changes carefully!", true);
            return View(UHierarchy.GetHierarchyUsers(CurrentUser).OrderBy(u => u.IntId));
        }

        // Edit current user
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CurrentUser = _db.Users.FirstOrDefault(i => i.UserName == User.Identity.Name);
            var EditUser = _db.Users.FirstOrDefault(i => i.Id == id);
            if (EditUser == null) return HttpNotFound("No such user exists. Edit User Failed!");
            if (EditUser == CurrentUser) return Redirect("~/Manage/Index");
            if (EditUser.Superior == CurrentUser)
            {
                ViewBag.EditUsername = EditUser.UserName;
                return View(new EditUserViewModel(EditUser));
            }
            Danger(string.Format("You are not authorised to edit this user. The <strong>{0}</strong> is not your immediate subordinate.", EditUser.UserName), true);
            return RedirectToAction("Hierarchy");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = _db.Users.FirstOrDefault(i => i.UserName == User.Identity.Name);
                var EditUser = _db.Users.FirstOrDefault(i => i.UserName == model.Username);
                if (EditUser.Superior == CurrentUser)
                {
                    EditUser.EstablishmentFull = model.EstablishmentFull;
                    EditUser.EstablishmentAbbreviation = model.EstablishmentAbbreviation;
                    EditUser.Appointment = model.Appointment;
                    EditUser.Rank = model.Rank;
                    EditUser.PersonnelNumber = model.Number;
                    EditUser.FullName = model.FullName;
                    EditUser.PhoneNumber = model.ASCON;
                }
                _db.Entry(EditUser).State = EntityState.Modified;
                _db.SaveChanges();
                Success("User editted successfully", true);
                return RedirectToAction("Hierarchy");
            }
            Warning("Please correct the errors", true);
            return View(model);
        }


        // GET & POST: Delete current user
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CurrentUser = _db.Users.FirstOrDefault(i => i.UserName == User.Identity.Name);
            var DeleteUser = _db.Users.FirstOrDefault(i => i.Id == id);
            var AdminRoleId = _db.Roles.FirstOrDefault(n => n.Name == "Administrator");
            foreach(var role in DeleteUser.Roles)
            {
                if (role.RoleId == AdminRoleId.Id) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Administrator cannot be deleted.");
            }
            if (DeleteUser == null)
                return HttpNotFound("No such user exists. Delete User Failed!");
            if (DeleteUser == CurrentUser) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You cannot delete yourself.");
            var model = new DeletetUserViewModel(DeleteUser);
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CurrentUser = _db.Users.FirstOrDefault(i => i.UserName == User.Identity.Name);
            var DeleteUser = _db.Users.FirstOrDefault(i => i.Id == id);
            var AdminRoleId = _db.Roles.FirstOrDefault(n => n.Name == "Administrator");
            foreach (var role in DeleteUser.Roles)
            {
                if (role.RoleId == AdminRoleId.Id) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Administrator cannot be deleted.");
            }
            if (DeleteUser == null)
                return HttpNotFound("No such user exists. Delete User Failed!");
            if (DeleteUser == CurrentUser) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You cannot delete yourself.");

            var Superior = DeleteUser.Superior;
            var Subordinates = DeleteUser.Subordinates;
            foreach(var Subordinate in Subordinates)
            {
                Subordinate.Superior = Superior;
            }

            //TODO: Update Hierarchy and Full Hierarchy on account delete and adding superior check reoccurence of _db.SavChanges()

            _db.Users.Remove(DeleteUser);
            _db.SaveChanges();

            return RedirectToAction("Hierarchy");
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }



        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Information("You are required to login in order to continue, please login with credentials provided by your superior HQ.", true);
                    return View(model);
                }

                var loggedinUser = await UserManager.FindAsync(model.Username, model.Password);
                if (loggedinUser != null)
                {
                    // change the security stamp only on correct username/password
                    await UserManager.UpdateSecurityStampAsync(loggedinUser.Id);
                }

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: true);
                switch (result)
                {
                    case SignInStatus.Success:
                        Session["UserIntId"] = _db.Users.FirstOrDefault(i => i.UserName == model.Username).IntId;
                        Session["Username"] = model.Username;

                        LogSignin(User.Identity.Name, _db.Users.FirstOrDefault(i => i.UserName == model.Username).IntId.ToString(), Session.SessionID);
                        LogVisit();
                        return RedirectToAction("Index", "Home");
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        Danger("Invalid login attempt.", true);
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //string ret = ex.Message.ToString();
                if(Session["UserIntId"]!=null)
                return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Login", "Account");
                //return View("Error");
            }
        }

        ////
        //// GET: /Account/VerifyCode
        //[AllowAnonymous]
        //public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        //{
        //    // Require that the user has already logged in via username/password or external login
        //    if (!await SignInManager.HasBeenVerifiedAsync())
        //    {
        //        return View("Error");
        //    }
        //    return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        ////
        //// POST: /Account/VerifyCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // The following code protects for brute force attacks against the two factor codes. 
        //    // If a user enters incorrect codes for a specified amount of time then the user account 
        //    // will be locked out for a specified amount of time. 
        //    // You can configure the account lockout settings in IdentityConfig
        //    var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(model.ReturnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.Failure:
        //        default:
        //            ModelState.AddModelError("", "Invalid code.");
        //            return View(model);
        //    }
        //}

        //
        // GET: /Account/Add
        [Authorize]
        public ActionResult Add()
        {
            var AllRoles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).Where(n => n.Name != "Administrator").ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = AllRoles;
            return View();
        }
                
        //
        // POST: /Account/Add
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var CurrentUser = UserManager.FindById(User.Identity.GetUserId());
                    var NewUser = new ApplicationUser
                    {
                        UserName = model.Username.ToLower(),
                        Email = string.Format("{0}@{1}", model.Username.ToLower(), "admin"),
                        EmailConfirmed = true,
                        Rank = model.Rank,
                        PersonnelNumber = model.Number,
                        FullName = model.FullName,
                        EstablishmentFull = model.EstablishmentFull,
                        EstablishmentAbbreviation = model.EstablishmentAbbreviation,
                        CreatedByIntId = CurrentUser.IntId,
                        CreatedOn = DateTime.Now,
                        Superior = CurrentUser,
                        PhoneNumber = model.ASCON
                    };

                    var result = await UserManager.CreateAsync(NewUser, model.Password);
                    if (result.Succeeded)
                    {
                        //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        try
                        {
                            foreach (var role in model.Roles)
                            {
                                UserManager.AddToRole(NewUser.Id, role);
                                UserManager.AddToRole(NewUser.Id, "User");
                            }
                        }
                        catch (Exception)
                        {
                            UserManager.AddToRole(NewUser.Id, "User");
                        }

                        // Make IVR Call on phone provided << Phase 2

                        using (var db = new ApplicationDbContext())
                        {
                            db.Hierarchy.Add(new Hierarchy
                            {
                                UserId = NewUser.Superior.IntId,
                                ChildId = NewUser.IntId
                            });
                            db.SaveChanges();
                        }
                        //Update full hierarchy
                        UHierarchy.UpdateHierarchyTable();
                        Success(string.Format("<b>{0}</b> was successfully added.", NewUser.UserName), true);
                        return RedirectToAction("Hierarchy", "Account");
                    }
                    AddErrors(result);
                }
                catch (Exception)
                {
                    var AllRoles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).Where(n => n.Name != "Administrator").ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                    ViewBag.Roles = AllRoles;
                }

            }
            else
            {
                {
                    var AllRoles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).Where(n => n.Name != "Administrator" && n.Name != "User").ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                    ViewBag.Roles = AllRoles;
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // Add Superior
        [Authorize(Roles = "Administrator")]
        public ActionResult AddSuperior()
        {
            var AllSuperiorLessUsers = (new ApplicationDbContext())
                .Users
                .Where(s => s.Superior == null)
                .ToList()
                .Select(
                rr => new SelectListItem { Value = rr.Id, Text = rr.UserName }).ToList();
            ViewBag.SuperiorLessUsers = AllSuperiorLessUsers;
            var AllRoles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).Where(n => n.Name != "Administrator" && n.Name != "NoSubordinates").ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = AllRoles;
            return View();
        }


        //TODO: Add superior & update subordinates
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSuperior(AddSuperiorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var NewUser = new ApplicationUser
                {
                    UserName = model.Username.ToLower(),
                    Email = string.Format("{0}@{1}", model.Username.ToLower(), "admin"),
                    EmailConfirmed = true,
                    Rank = model.Rank,
                    PersonnelNumber = model.Number,
                    FullName = model.FullName,
                    EstablishmentFull = model.EstablishmentFull,
                    EstablishmentAbbreviation = model.EstablishmentAbbreviation,
                    CreatedByIntId = UserManager.FindById(User.Identity.GetUserId()).IntId,
                    CreatedOn = DateTime.Now,
                    PhoneNumber = model.ASCON
                };

                var result = await UserManager.CreateAsync(NewUser, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    try
                    {
                        foreach (var role in model.Roles)
                        {
                            UserManager.AddToRole(NewUser.Id, role);
                            UserManager.AddToRole(NewUser.Id, "User");
                        }
                    }
                    catch (Exception)
                    {
                        UserManager.AddToRole(NewUser.Id, "User");
                    }

                    // Make IVR Call on phone provided << Phase 2

                    var SubordinateUser = UserManager.FindById(model.SubordinateId);
                    var EditUser = _db.Users.FirstOrDefault(i => i.UserName == NewUser.UserName);

                    if (SubordinateUser != null)
                    {
                        _db.Hierarchy.Add(new Hierarchy
                        {
                            UserId = NewUser.Superior.IntId,
                            ChildId = SubordinateUser.IntId
                        });
                        SubordinateUser.Superior = EditUser;
                    }
                    _db.Entry(SubordinateUser).State = EntityState.Modified;
                    _db.Entry(EditUser).State = EntityState.Modified;
                    _db.SaveChanges();

                    Success(string.Format("<strong>{0}</b> as superior to <strong>{1}</strong> was successfully added.", NewUser.UserName, SubordinateUser.UserName), true);
                    return RedirectToAction("Hierarchy", "Account");
                }
                AddErrors(result);
            }
            else
            {
                {
                    var AllSuperiorLessUsers = (new ApplicationDbContext())
                .Users
                .Where(s => s.Superior == null)
                .ToList()
                .Select(
                rr => new SelectListItem { Value = rr.Id, Text = rr.UserName }).ToList();
                    ViewBag.SuperiorLessUsers = AllSuperiorLessUsers;
                    var AllRoles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).Where(n => n.Name != "Administrator" && n.Name != "NoSubordinates").ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                    ViewBag.Roles = AllRoles;
                }
            }
            return View(model);
        }

        //TODO: Generate HTO Request

        //TODO: Approve HTO Request


        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        ////
        //// GET: /Account/ResetPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ResetPasswordConfirmation()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    // Request a redirect to the external login provider
        //    return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}

        ////
        //// GET: /Account/SendCode
        //[AllowAnonymous]
        //public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        //{
        //    var userId = await SignInManager.GetVerifiedUserIdAsync();
        //    if (userId == null)
        //    {
        //        return View("Error");
        //    }
        //    var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
        //    var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
        //    return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        ////
        //// POST: /Account/SendCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SendCode(SendCodeViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Generate the token and send it
        //    if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        //}

        ////
        //// GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    // Sign in the user with this external login provider if the user already has a login
        //    var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(returnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
        //        case SignInStatus.Failure:
        //        default:
        //            // If the user does not have an account, then prompt the user to create an account
        //            ViewBag.ReturnUrl = returnUrl;
        //            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
        //            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        //    }
        //}

        ////
        //// POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index", "Manage");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            return View("ExternalLoginFailure");
        //        }
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //            if (result.Succeeded)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            
            using (var db = new ApplicationDbContext())
            {
                var CurrentVisit = db.Visits.FirstOrDefault(s => s.SessionId == Session.SessionID.ToString());
                if (CurrentVisit != null)
                {
                    CurrentVisit.End = DateTime.Now;
                    db.Entry(CurrentVisit).State = EntityState.Modified;
                }
                var CurrentLogin = db.Logins.FirstOrDefault(u => u.Username == User.Identity.Name && u.SessionId == Session.SessionID);
                if (CurrentLogin != null)
                {
                    CurrentLogin.LoggedOutAt = DateTime.Now;
                    CurrentLogin.IsLoggedIn = false;
                   
                    db.Entry(CurrentLogin).State = EntityState.Modified;
                    foreach (var l in db.Logins.Where(u => u.Username == User.Identity.Name))
                    {
                        db.Entry(l).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                Session.Abandon();
                 Session.Clear();

 //if (Request.Cookies["ASP.NET_SessionId"] != null)
 //{
 //    var cookie = new HttpCookie("ASP.NET_SessionId");
 //    cookie.Expires = DateTime.Now.AddDays(-1); // Set the expiration date to the past to remove it
 //    Response.Cookies.Add(cookie);
 //}
 //HttpContext.Session.Clear();
 ////Session.SessionID
 //string newSessionId = Session.SessionID;
            }
            return RedirectToAction("Index", "Home");
        }

        ////
        //// GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        //public ActionResult ExternalLoginFailure()
        //{
        //    return View();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_userManager != null)
        //        {
        //            _userManager.Dispose();
        //            _userManager = null;
        //        }

        //        if (_signInManager != null)
        //        {
        //            _signInManager.Dispose();
        //            _signInManager = null;
        //        }
        //    }

        //    base.Dispose(disposing);
        //}

        #region Helpers
        //*Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
              // System.Web.Helpers.AntiForgery.Validate(HttpContext.CurrentHandler) == false;

               System.Web.Helpers.AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}

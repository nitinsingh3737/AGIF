﻿using DocumentFormat.OpenXml.Wordprocessing;
using IHSDC.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Web;

[assembly: OwinStartupAttribute(typeof(IHSDC.WebApp.Startup))]
namespace IHSDC.WebApp
{
    public partial class Startup
    {
       


        public void Configuration(IAppBuilder app)
        {

            //*app.Response.Headers.Add("X-Frame-Options", "DENY");

            

           

            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //Enable the application to use a cookie to store information for the
            //signed in user and to use a cookie to temporarily store information

            //about a user logging in with a third party login provider

            //Configure the sign in cookie

           app.UseCookieAuthentication(new CookieAuthenticationOptions
           {
               
               AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
               LoginPath = new PathString("/Account/Login"),
               Provider = new CookieAuthenticationProvider
               {
                   // Enables the application to validate the security stamp when the user 
                   // logs in. This is a security feature which is used when you 
                   // change a password or add an external login to your account.  
                   OnValidateIdentity = Microsoft.AspNet.Identity.Owin.SecurityStampValidator
                       .OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                       validateInterval: TimeSpan.FromMinutes(30),
                       regenerateIdentity: (manager, user)
                       => user.GenerateUserIdentityAsync(manager))
               }
           });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when 
            // they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(
                DefaultAuthenticationTypes.TwoFactorCookie,
                TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such 
            // as phone or email. Once you check this option, your second step of 
            // verification during the login process will be remembered on the device where 
            // you logged in from. This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(
                DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.Use(async (context, next) =>
            {

                context.Response.Headers.Append("X-Frame-Options", "DENY");
                await next();
            });


            ConfigureAuth(app);
        }
    }
}

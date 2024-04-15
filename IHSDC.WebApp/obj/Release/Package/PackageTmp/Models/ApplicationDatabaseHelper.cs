using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHSDC.WebApp.Models
{
    public static class ApplicationDatabaseHelper
    {
        public static void Initialize()
        {
            System.Data.Entity.Database.SetInitializer(new ApplicationDbContext.ApplicationDbInitializer());
            using (var db = new ApplicationDbContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
}
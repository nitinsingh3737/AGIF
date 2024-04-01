using IHSDC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IHSDC.WebApp
{

        public class DBConnection : DbContext
        {
            public DBConnection() : base("IHSDCDBDBContext")
            {

            } 
       
       
        public virtual DbSet<CarPcModel> carPcModel { get; set; }
        public virtual DbSet<certModel> certModel { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DBConnection>(null);
            base.OnModelCreating(modelBuilder);
        }

        public IList<certModel> yearList(string type)
        {
            var data = GetDataInList<certModel>("sp_select_year @certType='"+type+"'").ToList();
            return data;

        }

        public IList<Rank> rankList()
            {
                var data = GetDataInList<Rank>("sp_select_rank").ToList();
                return data;

            }

            public bool updateApplication(CarPcModel model)
            {
                var data = GetDataInList<object>("update CarPcModels set ApplicationForm='" + model.ApplicationForm + "' where Application_Id='" + model.Application_Id + "'  SELECT CAST(1 AS BIT) AS IsSuccess,'Added Successfully' AS Msg,'s' as MsgStatus,'' as MidMsg;").ToList();
                return true;

            }


            public IList<CarPcModel> getApplicationDetailById(string id)
            {
                var data = GetDataInList<CarPcModel>("select * from CarPcModels where Army_No='" + id + "'").ToList();
                return data;

            }

            public IList<CarPcModel> getApplication()
            {
                var data = GetDataInList<CarPcModel>("select * from CarPcModels").ToList();

                return data;

            }


        

        public IList<Unit> unitList()
            {
                var data = GetDataInList<Unit>("sp_select_Unit").ToList();
                return data;

            }


        public bool insertcert(certModel model)
        {
            try
            {
                var data = GetDataInList<CarPcModel>("certinsert @certType='" + model.certType + "',@year='" + model.year + "'").ToList();
                return true;
            }
            catch
            {
                return false;
            }

        }

        #region  for connection DB 
        public List<T> GetDataInList<T>(String Query)
            {
                try
                {
                    IList<T> sqlList = this.Database.SqlQuery<T>(Query).ToList();
                    return sqlList.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            #endregion




        }


    
}
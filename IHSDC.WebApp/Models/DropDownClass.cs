
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Models
{
    public class DropDownClass
    {
        public SelectList LoadRanks1 ()
        {
            DBConnection con = new DBConnection();
            Rank model = new Rank();
            return new SelectList(con.rankList(), "rank", "rank");
        }

        public List<SelectListItem> LoadRanks()
        {
            DBConnection con = new DBConnection();
            // Assuming RankList is a list of Rank objects with properties ID and Name
            var RankList = con.rankList();

            // Create a list of SelectListItem objects from RankList
            List<SelectListItem> items = RankList.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(), // Assuming ID is an integer
                Text = r.rank
            }).ToList();

            return items;

        }


        public SelectList loadYear(string type)
        {
            DBConnection con = new DBConnection();
            certModel model = new certModel();
            return new SelectList(con.yearList(type).Distinct(), "year", "year");
        }
        public SelectList LoadUnits()
        {
            DBConnection con = new DBConnection();
            Unit model = new Unit();
            return new SelectList(con.unitList(), "unitName", "unitName");
        }

        //public SelectList CDA_PAO_LoadUnits(string unitName)
        //{
        //    DBConnection con = new DBConnection();
        //    Unit model = new Unit();
        //    return new SelectList(con.CDA_PAOList(unitName), "unitName", "unitName");
        //}

        public SelectList LoadAppType()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="Car",Value="2"}
                ,new SelectListItem{Text="Two Wheeler Application",Value="7"}
            }, "Value", "Text");
        }

        //public SelectList LoadFrequency()
        //{
        //    try
        //    {
        //        using (var con = new DBConnection())
        //        {
        //            var loan = con.LoanFrequency.ToList(); // Convert to list
        //            return new SelectList(loan, "Id", "Frequency");
        //            // Change "Id" and "Name" to the actual properties you want to display
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //    return new SelectList(new List<object>());
        //}


        public SelectList LoadLoanType()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="New Car",Value="5"},
                new SelectListItem{Text="Old Car",Value="6"},
                 new SelectListItem{Text="EV",Value="7"}
                //new SelectListItem{Text="Inward Transfer",Value="8"}
                
            }, "Value", "Text");
        }

        public SelectList LoadPreType()
        {
            return new SelectList(new SelectListItem[]{
                  new SelectListItem{Text="No",Value="NO"},
                new SelectListItem{Text="HBA",Value="HBA"},
                new SelectListItem{Text="PCA",Value="PCA"},
                 new SelectListItem{Text="CA",Value="CA"}

            }, "Value", "Text");
        }
    }
}
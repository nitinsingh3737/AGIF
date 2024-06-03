
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
            var RankList = con.rankList();
            List<SelectListItem> items = RankList.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
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
        public SelectList LoadUnitAddress()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="c/o 56 APO",Value="c/o 56 APO"},
                new SelectListItem{Text="c/o 99 APO",Value="c/o 99 APO"}
            }, "Value", "Text");
        }

        public SelectList LoadExtentionOfService()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="YES",Value="YES"},
                new SelectListItem{Text="NO",Value="NO"}
            }, "Value", "Text");
        }

        public SelectList LoadAppType()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="Car",Value="2"}
                ,new SelectListItem{Text="Two Wheeler Application",Value="7"}
            }, "Value", "Text");
        }

        public SelectList LoadLoanType()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="New Car",Value="5"},
                new SelectListItem{Text="Old Car",Value="6"},
                 new SelectListItem{Text="EV",Value="7"}
                
            }, "Value", "Text");
        }
        public SelectList LoadFrequencyType ()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="1st Time",Value="1st Time"},
                new SelectListItem{Text="2nd Time",Value="2nd Time"}

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
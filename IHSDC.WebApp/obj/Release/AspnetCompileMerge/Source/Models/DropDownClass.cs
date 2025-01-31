﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Models
{
    public class DropDownClass
    {
        public SelectList LoadRanks()
        {
            DBConnection con = new DBConnection();
            Rank model = new Rank();
            return new SelectList(con.rankList(), "rank", "rank");
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

        public SelectList LoadAppType()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="Car/Two Wheeler",Value="2"},
                new SelectListItem{Text="Computer",Value="3"}
            }, "Value", "Text");
        }
        public SelectList LoadLoanType()
        {
            return new SelectList(new SelectListItem[]{
                new SelectListItem{Text="NewCar",Value="5"},
                new SelectListItem{Text="OldCar",Value="6"},
                new SelectListItem{Text="Inward Transfer",Value="8"},
                new SelectListItem{Text="Two Wheeler",Value="7"}
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHSDC.WebApp.Models
{
    public class Claim
    {
        [Key]
        public int  Application_Id { get; set; }

        [Display(Name = "Army No")]
        public string Army_No { get; set; }
        public string  Rank  { get; set; }
        public string  Name  { get; set; }

        [Display(Name = "Regt/Corps")]
        public string Regt_Corps  { get; set; }

        [Display(Name = "Present Unit")]
        public string Unit  { get; set; }

        [Display(Name = "Date of Commission/Enrolment")]
        public string Enrollment_Date { get; set; }


        [Display(Name="Date of Birth")]
        public string Date_Of_Birth { get; set; }

        [Display(Name = "Total service in Army(In Year & Months)")]
        public int Year_Of_Service { get; set; }

        [Display(Name = "E-mail ID")]
        public string Email_Id { get; set; }

       
        [Display(Name="Aadhar No")]
        public string  Adhar_No { get; set; }

        [Display(Name = "PAN No")]
        public string Pan_No {get; set; }

        [Display(Name = "Mob No")]
        public string Mobile_No { get; set; }

        [Display(Name ="Purpose of withdrawal")]
        public string Purpose_of_withdrawal { get; set; }

        [Display(Name = "House Building Advance")]
        public string House_Building_Advance_Loan  { get; set; }

        [Display(Name = "Conveyance Advance")]
        public string Conveyance_Advance_Loan { get; set; }

        [Display(Name = "Computer Advance")]
        public string Computer_Advance_Loan  { get; set; }

        [Display(Name = "House Building Date of Loan taken")]
        public string House_Building_Date_of_Loan_taken  { get; set; }

        [Display(Name = "House Building Duration of Loan")]
        public string House_Building_Duration_of_Loan { get; set; }

        [Display(Name = "House Building Amount Taken")]
        public string House_Building_Amount_Taken  { get; set; }


        [Display(Name = "Conveyance Date of Loan taken")]
        public string Conveyance_Date_of_Loan_taken { get; set; }

        [Display(Name = "Conveyance Duration of Loan")]
        public string Conveyance_Duration_of_Loan { get; set; }

        [Display(Name = "Conveyance Amount Taken")]
        public string Conveyance_Amount_Taken  { get; set; }

        [Display(Name = "Computer Date of Loan taken")]
        public string Computer_Date_of_Loan_taken  { get; set; }

        [Display(Name = "Computer Duration of Loan")]
        public string Computer_Duration_of_Loan  { get; set; }

        [Display(Name = "Computer Amount Taken")]
        public string Computer_Amount_Taken  { get; set; }

        [Display(Name = "Amount of withdrawal required")]
        public int  Amount_of_withdrawal { get;set; }

        [Display(Name = "Name of child")]
        public string  Name_of_Child  { get; set; } 

         [Display(Name = "date of Birth")]
        public string  date_of_Birth_Child  { get; set; }

        [Display(Name = "DO Part-II No")]
        public string  DO_Part_II_No { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                     ApplyFormatInEditMode = true)]
        public DateTime? DateTimeUpdated { get; set; }
       

        [Display(Name = "DO Part-II Date")]
        public string DO_Part_II_Date  { get; set; }

        [Display(Name = "DO Part-II No(attach attested copy)")]    
        public string Attach_Part_II_Order {get; set; }

        [Display(Name = "Presently studying in")]
        public string Presently_studying  { get; set; }

        [Display(Name = "Course for wich withdrawal required")]
        public string Course  { get; set; }

        [Display(Name = "Name of College/institution where studying")]
        public string College_Name  { get; set; }

        [Display(Name = "Name of College(attach Bonafide cert/admission letter)")]
        public string  Attach_College_doc  { get; set; }

        [Display(Name = "Total Expenditure")]
        public string  Total_Expenditure_Amount  { get; set; }

        [Display(Name = "Attach a cert from college/institution duly attested by unit")]
        public string Attach_Expenditure_doc   { get; set; }

        [Display(Name = "Age of Ward")]
        public string Age { get; set; }

        [Display(Name = "Date of Marriage")]
        public string Date_of_Mairrage {get; set; }

        [Display(Name = "Att invitation card")]
        public string  Attach_Mairrage_doc { get; set; }

        //---
        [Display(Name = "Address of property intended to make renovation/repair")]
        public string Address {get; set;}

        [Display(Name = "Name of property holder(s)")]
        public string Name_of_Property_holder { get; set; }

        [Display(Name = "Estimated cost of expenditure")]
        public string Estimated_Cost_of_Expenditure {get; set; }

        [Display(Name = "expenditure(attach details)")]
        public string Attach_document_Expenditure_doc { get; set; }

        [Display(Name = "Date of Retirement")]
        public string Date_of_Retirement {get; set; }

        [Display(Name = "No of withdrawal")]
        public string No_of_withdrawal { get; set; }

        [Display(Name = "Reason for first withdrawal")]
        public string Reason_for_first_withdrawal { get; set; }

        [Display(Name = "Amount Paid")]
        public string Amount_Paid {get; set; }

        [Display(Name = "Date of withdrawal")]
        public string Date_of_withdrawal { get; set; }


        [Display(Name = "Name of the Bank(Salary Account only)")]
        public string Name_of_Bank { get; set; }

        [Display(Name = "Attach latest salary statement")]
        public string Attach_Bank_Pay_Slip { get; set; }

        [Display(Name = "Branch Name")]
        public string Branch_Name { get; set; }

        [Display(Name = "Account No")]
        public string  Account_No { get; set; }

        [Display(Name = "Account No(attach cancelled cheque/pass book Copy clearly visible with acct No and IFSC Code)")]
        public string Attach_Cancel_Check_Passbook  { get; set; }

        [Display(Name = "IFSC Code(In case of transferred account present branch IFSC should be mentioned")]
        public string IFSC_Code { get; set; }

        [Display(Name = "Bank Address(with Pin Code No")] 
        public string Bank_Address { get; set; }

        [Display(Name = "Contact No of Bank")]
        public string Contact_No_of_Bank  { get; set; }

    }
}
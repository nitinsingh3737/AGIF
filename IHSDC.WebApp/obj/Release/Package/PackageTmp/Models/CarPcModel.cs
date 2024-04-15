using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IHSDC.WebApp.Models
{
    public class CarPcModel
    {
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (DateTime.Parse(Date_Of_Birth) > DateTime.Parse(Enrollment_Date))
        //    {
        //        yield return
        //          new ValidationResult(errorMessage: "Enrollment Date must be greater than Date Of Birth",
        //                               memberNames: new[] { "Enrollment_Date" });
        //    }
        //}

        //public CarPcModel()
        //{
        //    this.DateTimeUpdated = DateTimeUpdated.ToString("");
        //}

        // public IList<CarPcModel> carPcModel { get; set; }
        [Key]
        //public int Application_Id { get; set; }
        public int Application_Id { get; set; }

        [Required]
        [Display(Name ="Application Type")]
        public string ApplicationType { get; set; }

        [Required]
        //[StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 12)]
        //[RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public string AadharNo { get; set; }
        //[StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Required]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string PANNo { get; set; }

        [Display(Name ="Car Loan Type")]
        public string CarLoanType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                      ApplyFormatInEditMode = true)]
        public DateTime? DateTimeUpdated { get; set; }
        //[StringLength(50)]
        //[RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]

        [Display(Name = "Name of Applicant")]
        public string Loanee_Name { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Army_No { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Old_Army_No { get; set; }


        [StringLength(50)]
        [Display (Name ="Rank & Trade")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Rank { get; set; }
        [StringLength(50)]
        [Display(Name ="Regt/Corps")]
        public string Regt_Corps { get; set; }

        [StringLength(50)]
        [Display(Name ="Present_Unit")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Unit { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string CDA_PAO { get; set; }

        public string Date_Of_Birth {
            get;
            set;
        }
       
       
        [Display(Name = "Enrollment_Date")]
        public string  Enrollment_Date { get; set; }
       
       
        public string Promotion_Date { get; set; }
       
      
        public string  Retirement_Date { get; set; }
      
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Year_Of_Service { get; set; }
    
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Residual_Service { get; set; }
    
        [Required]
        public string  Salary_Slip_Month_Year { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string CDA_Account_No { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Basic_Salary { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Rank_Grade_Pay { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? DSOP_AFPP { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? MSP { get; set; }
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? AGIF { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? NPA_X_Pay { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Income_Tax_Monthly { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Tech_Pay { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Rev_IT { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? TPTL_Pay { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? PLI { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? DA { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? MISC { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? MISC_Pay { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Total { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Salary_After_Deduction { get; set; }
        [StringLength(50)]
        [Display (Name ="Dealer Name and Address")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Dealer_Name { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Vehicle_Name { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Vehicle_Make { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        [Display (Name ="Cost of Veh Ex Showroom")]
        public int? Total_Cost { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Amount_Applied_For_Loan { get; set; }

        //[RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? No_Of_EMI_Applied { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Inst_No1_Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                      ApplyFormatInEditMode = true)]
        public DateTime?  Inst_No1_Date { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Inst_No2_Amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                      ApplyFormatInEditMode = true)]
        public DateTime?  Inst_No2_Date { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Inst_No3_Amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                      ApplyFormatInEditMode = true)]
        public DateTime?  Inst_No3_Date { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Inst_No4_Amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                      ApplyFormatInEditMode = true)]
        public DateTime?  Inst_No4_Date { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Inst_No5_Amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                      ApplyFormatInEditMode = true)]
        public DateTime?  Inst_No5_Date { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Pers_Address_Line1 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Pers_Address_Line2 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Pers_Address_Line3 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Pers_Address_Line4 { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Pin_Code { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Site_Address_Line1 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Site_Address_Line2 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Site_Address_Line3 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Site_Address_Line4 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Site_City { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Site_Pin { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Payee_Account_No { get; set; }
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string IFSC_Code { get; set; }
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Mobile_No { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter valid email address")]
        public string E_Mail_Id { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Payable_In_Favour_Of { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Dispatch_Type { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string City_Branch_Code_Search { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Payable_To { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Dispatch_Address_Line1 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Dispatch_Address_Line2 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Dispatch_Address_Line3 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Dispatch_Address_Line4 { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Previous_Loan_Source { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Previous_Loan_Purpose { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? Amount { get; set; }

        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only numbers")]
        public int? EMI { get; set; }
        [StringLength(50)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string Previous_Loan_Is_Paid { get; set; }

        public string Status { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }
        public string ApplicationForm { get; set; }
        public string PaySlip { get; set; }
        public string Quotation { get; set; }
        public string CancelledCheque { get; set; }
        public string DrivingLicence { get; set; }

        //ajay 03-04-24
        public string Next_Fmn_Hq {get; set;}
        public string Unit_Pin { get; set; }
        public string Unit_Address { get; set; }
        public string Extension_of_Service_in_Present_Rank {get; set;}
        public string Veh_Type { get; set; }
        public string Amt_Eligible_for_loan { get; set; }

        public string EMI_Eligible_for_loan { get; set; }

        public string FileUpload  { get; set; }


    }
}
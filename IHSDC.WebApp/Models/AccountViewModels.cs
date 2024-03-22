using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IHSDC.WebApp.Models
{
    public class HandingTakingOverListViewModel
    {
        public string Username { get; set; }
        public DateTime RequestDate { get; set; }
        [Required]
        [Display(Name = "Handining Over By")]
        public ApptDetails HandedOverBy { get; set; }
        [Required]
        [Display(Name = "Taking Over By")]
        public ApptDetails TakenOverBy { get; set; }
        public string Reason { get; set; }
        public string ApproveAction { get; set; }
    }

    public class UserHandingTakingOverViewModel
    {
        public DateTime RequestDate { get; set; }
        [Required]
        [Display(Name = "Taking Over By")]
        public ApptDetails TakenOverBy { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
    }

    public class ApptDetailsViewModel
    {
        [Required]
        [Display(Name = "Service Number")]
        public string ServiceNumber { get; set; }
        [Required]
        public string Rank { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Appointment { get; set; }
    }

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Unit/ Formation/ Directorate")]
        public string EstablishmentFull { get; set; }

        [Required]
        [Display(Name = "Establishment Abbreviation")]
        public string EstablishmentAbbreviation { get; set; }

        [Required]
        public string Appointment { get; set; }

        [Required]
        [Display(Name = "Personnel Number")]
        public string Number { get; set; }

        [Required]
        public string Rank { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed")]
        [Display(Name = "ASCON Number")]
        public string ASCON { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public string[] Roles { get; set; }
    }

    public class AddSuperiorViewModel
    {
        [Required]
        [Display(Name = "Select Subordinate")]
        public string SubordinateId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Unit/ Formation/ Directorate")]
        public string EstablishmentFull { get; set; }

        [Required]
        [Display(Name = "Establishment Abbreviation")]
        public string EstablishmentAbbreviation { get; set; }

        [Required]
        public string Appointment { get; set; }

        [Required]
        [Display(Name = "Personnel Number")]
        public string Number { get; set; }

        [Required]
        public string Rank { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed")]
        [Display(Name = "ASCON Number")]
        public string ASCON { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public string[] Roles { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class EditUserViewModel
    {
        public string Username { get; set; }
        
        [Display(Name = "Unit/ Formation/ Directorate")]
        public string EstablishmentFull { get; set; }

        [Required]
        [Display(Name = "Establishment Abbreviation")]
        public string EstablishmentAbbreviation { get; set; }

        [Required]
        public string Appointment { get; set; }

        [Required]
        [Display(Name = "Personnel Number")]
        public string Number { get; set; }

        [Required]
        public string Rank { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed in ASCON Telephone field")]
        [Display(Name = "ASCON Number")]
        public string ASCON { get; set; }
        

        public EditUserViewModel() { }
        public EditUserViewModel(ApplicationUser user)
        {
            this.Username = user.UserName;
            this.EstablishmentFull = user.EstablishmentFull;
            this.EstablishmentAbbreviation = user.EstablishmentAbbreviation;
            this.Appointment = user.Appointment;
            this.Number = user.PersonnelNumber;
            this.Rank = user.Rank;
            this.FullName = user.FullName;
            this.ASCON = user.PhoneNumber;
        }
    }

    public class DeletetUserViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Unit/ Formation/ Directorate")]
        public string EstablishmentFull { get; set; }

        [Required]
        [Display(Name = "Establishment Abbreviation")]
        public string EstablishmentAbbreviation { get; set; }

        [Required]
        public string Appointment { get; set; }

        [Required]
        [Display(Name = "Personnel Number")]
        public string Number { get; set; }

        [Required]
        public string Rank { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string SuperiorEstablishment { get; set; }
        public IEnumerable<string> SubordinateEstablishments { get; set; }
        
        public DeletetUserViewModel() { }
        public DeletetUserViewModel(ApplicationUser user)
        {
            this.Username = user.UserName;
            this.EstablishmentFull = user.EstablishmentFull;
            this.EstablishmentAbbreviation = user.EstablishmentAbbreviation;
            this.Appointment = user.Appointment;
            this.Number = user.PersonnelNumber;
            this.Rank = user.Rank;
            this.FullName = user.FullName;
            this.SuperiorEstablishment = this.GetSuperior(user);
            this.SubordinateEstablishments = this.GetSubordinateUsernames(user.Subordinates);
        }

        private string GetSuperior(ApplicationUser user)
        {
            return string.IsNullOrEmpty(user.EstablishmentFull) ? "Superuser" : user.Superior.EstablishmentFull.ToString();
        }

        private IEnumerable<string> GetSubordinateUsernames(ICollection<ApplicationUser> subordinates)
        {
            var returnStr = new List<string>();
            if (subordinates.Count < 1)
            {
                returnStr.Add("No Subordinates");
                return returnStr;
            }
            foreach(var subordinate in subordinates)
            {
                returnStr.Add(subordinate.EstablishmentFull);
            }
            return returnStr;
        }
    }
}

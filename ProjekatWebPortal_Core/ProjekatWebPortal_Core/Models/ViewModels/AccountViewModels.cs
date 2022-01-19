using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
/*using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;*/
using ProjekatWebPortal_Core.Models;


namespace ProjekatWebPortal_Core.Models
{
    //public class ExternalLoginConfirmationViewModel
    //{
    //    [Required]
    //    [Display(Name = "Email")]
    //    public string Email { get; set; }
    //}

    //public class ExternalLoginListViewModel
    //{
    //    public string ReturnUrl { get; set; }
    //}

    //public class SendCodeViewModel
    //{
    //    public string SelectedProvider { get; set; }
    //    public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    //    public string ReturnUrl { get; set; }
    //    public bool RememberMe { get; set; }
    //}

    //public class VerifyCodeViewModel
    //{
    //    [Required]
    //    public string Provider { get; set; }

    //    [Required]
    //    [Display(Name = "Code")]
    //    public string Code { get; set; }
    //    public string ReturnUrl { get; set; }

    //    [Display(Name = "Remember this browser?")]
    //    public bool RememberBrowser { get; set; }

    //    public bool RememberMe { get; set; }
    //}

    //public class ForgotViewModel
    //{
    //    [Required]
    //    [Display(Name = "Email")]
    //    public string Email { get; set; }
    //}

    //public class LoginViewModel
    //{
        
    //    [Display(Name = "Korisnicko ime")]
    //    [Required(ErrorMessage ="Morate uneti korisnicko ime!")]
    //    public string Username { get; set; }

    //    [Required(ErrorMessage ="Morate uneti sifru!")]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [Display(Name = "zapamti me?")]
    //    public bool RememberMe { get; set; }
    //}

    public class RegisterViewModel
    {
        //public IEnumerable<SmerModel> Smerovi { get; set; }
       // public IEnumerable<IdentityRole> Uloge { get; set; }
        public IEnumerable<SkolaModel> Skole { get; set; }

      /*  public IEnumerable<StrucnaSpremaModel> StrucneSpreme { get; set; }

        public List<SmerModel> SmeroviPoSkolama { get; set; }
        public int SelektovanaSkola { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        public int skolaId { get; set; }
        public int smerId { get; set; }

        public int? GodinaUpisa { get; set; }
        public string SelektovanaSS { get; set; }
        public int selektovaniSmer { get; set; }
        public string selektovanaUloga { get; set; }

        [Required(ErrorMessage ="Morate uneti email!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Morate uneti ime!")]
        
        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate uneti prezime!")]
        public string Prezime { get; set; }
        */

        
        
    }

    //public class izmenikorisnikaviewmodel
    //{
    //    public applicationuser korisnik {get; set;}

    //    public ienumerable<smermodel> smerovi { get; set; }
    //    public ienumerable<identityrole> uloge { get; set; }
    //    public ienumerable<skolamodel> skole { get; set; }
    //    public ienumerable<strucnaspremamodel> strucnespreme { get; set; }

    //}
    //public class detaljikorisnikaviewmodel
    //{
    //    public applicationuser korisnik { get; set; }

    //    public string selektovanismer { get; set; }
        
    //    public string selektovanaskola { get; set; }
        

    //}


    //public class resetpasswordviewmodel
    //{
    //    [required]
    //    [emailaddress]
    //    [display(name = "vaš email")]
    //    public string email { get; set; }

    //    [required]
    //    [stringlength(100, errormessage = "the {0} must be at least {2} characters long.", minimumlength = 6)]
    //    [datatype(datatype.password)]
    //    [display(name = "nova lozinka")]
    //    public string password { get; set; }

    //    [datatype(datatype.password)]
    //    [display(name = "potvrda nove lozinke")]
    //    [compare("password", errormessage = "ponudjene sifre se ne podudaraju.")]
    //    public string confirmpassword { get; set; }

    //    public string code { get; set; }
    //}

    //public class forgotpasswordviewmodel
    //{
    //    [required]
    //    [emailaddress]
    //    [display(name = "email")]
    //    public string email { get; set; }
    //}
}

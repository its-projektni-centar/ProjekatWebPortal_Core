using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatWebPortal_Core.Controllers
{
    public class SkolaController : Controller
    {
        private UsersMaterijalDbContext _usersMaterijalContext;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public SkolaController(UsersMaterijalDbContext umdbc, SignInManager<AspNetUserCustom> signInManager, UserManager<AspNetUserCustom> usman)
        {
            _usersMaterijalContext = umdbc;
            _userManager = usman;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult> SkolaPrikaz()
        {
            if (User.IsInRole("SuperAdministrator") || User.IsInRole("GlobalniUrednik"))
            {
                List<SkolaModel> skole = _usersMaterijalContext.Skola.ToList();
                return View(skole);
            }
            int skolaId = ( await vratiSkolu(User.Identity.Name)).IdSkole;
            return RedirectToAction("SmeroviPrikaz", "Smer", new { id = skolaId });
        }


        public async Task<SkolaModel> vratiSkolu(string username)
        {

            AspNetUserCustom user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return null;
            SkolaModel s = _usersMaterijalContext.Skola.AsQueryable().Where(p => p.IdSkole == user.SkolaId).FirstOrDefault();
            return s;
        }
    }
}
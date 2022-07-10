using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.Models;
using ProjekatWebPortal_Core.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjekatWebPortal_Core.Controllers
{
    public class OrganizacijaController : Controller
    {

        private UsersMaterijalDbContext _usersMaterijalContext;
        private readonly SignInManager<AspNetUserCustom> _signInManager;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public OrganizacijaController(UsersMaterijalDbContext umdbc, SignInManager<AspNetUserCustom> signInManager, UserManager<AspNetUserCustom> usman)
        {
            _usersMaterijalContext = umdbc;
            _signInManager = signInManager;
            _userManager = usman;
        }

        // GET: Organizacija
        [Authorize(Roles = "LokalniUrednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult kalendarNastave()
        {
            return View();
        }

        [Authorize(Roles = "LokalniUrednik,Profesor,Ucenik,SuperAdministrator,Administrator")]
        [HttpGet]
        public ViewResult planNastave()
        {
            List<SmerModel> model = _usersMaterijalContext.Smer.ToList();
            if (model.Count() > 0)
            {
                var myviewmodel = new SmerViewModel();

                myviewmodel.smerovi = model;

                return View(myviewmodel);
            }
            else
            {
                ViewBag.Poruka = "Trenutno nema nikakvih smerova!";
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "LokalniUrednik")]
        public ActionResult dodavanjeNastave()
        {
            List<SmerModel> model = _usersMaterijalContext.Smer.ToList();
            if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }

            if (model.Count > 0)
            {
                var myviewmodel = new SmerViewModel();
                myviewmodel.smerovi = model;

                return View(myviewmodel);
            }
            else
            {
                return NotFound("Nešto nije u redu!");
            }
        }

        [HttpPost]
        [Authorize(Roles = "LokalniUrednik")]
        public ActionResult UploadPlan(string tip, IFormFile file, SmerViewModel model)
        {
            int smerId = model.smeroviModel.smerId;
            SmerModel modelsmer = _usersMaterijalContext.Smer.Find(smerId);

            if (tip.Equals("its"))
            {

                _usersMaterijalContext.Smer.Attach(modelsmer);

                modelsmer.fajlIts = new byte[file.Length];
                file.OpenReadStream().Read(modelsmer.fajlIts, 0, (int)(file.Length));
                modelsmer.fileMimeTypeIts = file.ContentType;
                modelsmer.nazivFajlIts = Path.GetFileName(file.FileName);

                _usersMaterijalContext.SaveChanges();
                
                TempData["SuccMsg"] = "Uspešno dodat plan nastave";
                return RedirectToAction("dodavanjeNastave", "Organizacija");
            }
            else if (tip.Equals("ns"))
            {

                _usersMaterijalContext.Smer.Attach(modelsmer);

                    modelsmer.fajlNs = new byte[file.Length];
                    file.OpenReadStream().Read(modelsmer.fajlNs, 0, (int)(file.Length));
                    modelsmer.fileMimeTypeNs = file.ContentType;
                    modelsmer.nazivFajlNs = Path.GetFileName(file.FileName);

                _usersMaterijalContext.SaveChanges();
                
                TempData["SuccMsg"] = "Uspešno dodat plan nastave";
                return RedirectToAction("dodavanjeNastave", "Organizacija");
            }
            else if (tip.Equals("ms"))
            {

                _usersMaterijalContext.Smer.Attach(modelsmer);

                    modelsmer.fajlMs = new byte[file.Length];
                    file.OpenReadStream().Read(modelsmer.fajlMs, 0, (int)(file.Length));
                    modelsmer.fileMimeTypeMs = file.ContentType;
                    modelsmer.nazivFajlMs = Path.GetFileName(file.FileName);

                _usersMaterijalContext.SaveChanges();
                

                TempData["SuccMsg"] = "Uspešno dodat plan nastave";
                return RedirectToAction("dodavanjeNastave", "Organizacija");
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult SkidanjePlana(int id, string type)
        {
            SmerModel model = _usersMaterijalContext.Smer.Find(id);
            if (type.Equals("iths"))
            {
                return File(model.fajlIts, model.fileMimeTypeIts, model.nazivFajlIts);
            }
            else if (type.Equals("ns"))
            {
                return File(model.fajlNs, model.fileMimeTypeNs, model.nazivFajlNs);
            }
            else if (type.Equals("ms"))
            {
                return File(model.fajlMs, model.fileMimeTypeMs, model.nazivFajlMs);
            }
            return NotFound();
        }

        [Authorize(Roles = "LokalniUrednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult rasporedCasova()
        {
            return View();
        }
    }
}
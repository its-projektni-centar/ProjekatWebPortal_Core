using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.Models;
using ProjekatWebPortal_Core.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjekatWebPortal_Core.Controllers
{
    /// <summary>
    /// Predmet Kontroler
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class PredmetController : Controller
    {
        private UsersMaterijalDbContext _usersMaterijalContext;

        private readonly UserManager<AspNetUserCustom> _userManager;

        public PredmetController(UsersMaterijalDbContext umdbc, SignInManager<AspNetUserCustom> signInManager, UserManager<AspNetUserCustom> usman)
        {
            _usersMaterijalContext = umdbc;
            _userManager = usman;
        }

        // GET: Predmet
        /// <summary>
        /// Index akcija
        /// </summary>
        /// <returns>IndexView</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vraca stranicu sa formom za dodavanje predmeta
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        //public async Task<ActionResult> DodajPredmet()
        //{
        //    DodajPremetViewModel viewModel = new DodajPremetViewModel();
        //    viewModel.tip = 1;
        //    viewModel.skole = context.skole.ToList();
        //    var smerIds = context.smeroviPoSkolama.Where(x => x.skolaId == context.skole.FirstOrDefault().IdSkole).Select(x => x.smerId).ToList();

        //    if (!this.User.IsInRole("SuperAdministrator"))
        //    {
        //        SkolaModel sk = await ApplicationUser.vratiSkoluModel(User.Identity.Name);
        //        if (sk.IdSkole != 0)
        //        {
        //            viewModel.skolaId = sk.IdSkole;
        //            smerIds = context.smeroviPoSkolama.Where(x => x.skolaId == viewModel.skolaId).Select(x => x.smerId).ToList();
        //        }
        //    }
        //    viewModel.smerovi = context.smerovi.Where(x => smerIds.Contains(x.smerId)).ToList();
        //    return View("DodajPredmet", viewModel);
        //}

        //public JsonResult GetSmerovi(int skolaID)
        //{
        //    var smerIds = context.smeroviPoSkolama.Where(x => x.skolaId == skolaID).Select(x => x.smerId).ToList();
        //    var viewModel = context.smerovi.Where(x => smerIds.Contains(x.smerId)).ToList();

        //    return Json(viewModel, JsonRequestBehavior.AllowGet);
        //}

        ///// <summary>
        ///// Dodaje predmet u bazu i dodaje smerove na kojima je predmet u tabelu PredmetPoSmeru
        ///// </summary>
        ///// <param name="viewModel">The view model.</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        //public ActionResult DodajPredmet(DodajPremetViewModel viewModel)
        //{
        //    try
        //    {
        //        viewModel.predmet.tipId = 1;

        //        context.Add<PredmetModel>(viewModel.predmet);

        //        foreach (int n in viewModel.smerIds)
        //        {
        //            context.Add<PredmetPoSmeru>(new PredmetPoSmeru
        //            {
        //                predmetId = viewModel.predmet.predmetId,
        //                smerId = n
        //                //smerId = viewModel.smer.smerId
        //            });
        //        }

        //        context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return RedirectToAction("DodajPredmet", "Predmet");
        //}

        ///// <summary>
        ///// Menja Predmet u bazi
        ///// </summary>
        ///// <param name="smerId">The smer identifier.</param>
        ///// <param name="smeroviId">Lista smerova na kojima je predmet.</param>
        ///// <param name="predmetNaziv">Novi naziv predmeta.</param>
        ///// <param name="predmetOpis">Novi opis predmeta.</param>
        ///// <param name="predmetId">Id predmeta koji treba promeniti.</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik, GlobalniUrednik")]
        //public ActionResult Edit(int smerId, DodajPremetViewModel viewmodel, string predmetNaziv, string predmetOpis, int predmetId, int Razred)
        //{
        //    context = new MaterijalContext();

        //    PredmetModel predmetPromenjenji = context.predmeti.FirstOrDefault(m => m.predmetId == predmetId);
        //    int tipID = context.predmeti.Where(m => m.predmetId == predmetId).Select(m => m.tipId).First();

        //    string tip = context.tipPredmeta.Where(m => m.tipId == tipID).Select(m => m.tipNaziv).First();
        //    List<int> smeroviIdIzBaze = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).Select(m => m.smerId).ToList();

        //    if (predmetPromenjenji == null)
        //    {
        //        return new HttpNotFoundResult("Nije nadjen ni jedan predmet u bazi sa datim ID-om");
        //    }
        //    predmetPromenjenji.predmetNaziv = predmetNaziv;
        //    predmetPromenjenji.predmetOpis = predmetOpis;
        //    predmetPromenjenji.Razred = Razred;

        //    var predmetiPoSmeruZaBrisanje = context.predmetiPoSmeru.Where(pps => pps.predmetId == predmetId);
        //    foreach (PredmetPoSmeru pps in predmetiPoSmeruZaBrisanje)
        //    {
        //        context.Delete(pps);
        //    }

        //    context.SaveChanges();

        //    foreach (int smerZaUbacivanje in viewmodel.smerIds)
        //    {
        //        PredmetPoSmeru ZAUBACIVANJE = new PredmetPoSmeru();

        //        ZAUBACIVANJE.predmetId = predmetId;
        //        ZAUBACIVANJE.smerId = smerZaUbacivanje;

        //        context.Add(ZAUBACIVANJE);
        //    }

        //    context.SaveChanges();

        //    string smernaziv = context.smerovi.FirstOrDefault(x => x.smerId == smerId).smerNaziv;

        //    return RedirectToAction("PredmetiPrikaz", new { smer = smernaziv, razred = Razred, tip });
        //}

        ///// <summary>
        ///// Vratis the smerove.
        ///// </summary>
        ///// <param name="id">Id predmeta.</param>
        ///// <returns>Json sa smerovima</returns>
        //[HttpGet]
        //public ActionResult VratiSmerove(int id)
        //{
        //    context = new MaterijalContext();

        //    List<int> smeroviId = context.predmetiPoSmeru.Where(m => m.predmetId == id).Select(m => m.smerId).ToList();

        //    List<int> smeroviModel = new List<int>();

        //    foreach (int smerId in smeroviId)
        //    {
        //        int smer = context.smerovi.Where(m => m.smerId == smerId).Select(m => m.smerId).Single();
        //        smeroviModel.Add(smer);
        //    }

        //    return Json(smeroviModel, JsonRequestBehavior.AllowGet);
        //}

        ////GET: /Predmet/PredmetiPrikaz
        ///// <summary>
        ///// Prikazuje predmete na odredjenom smeru
        ///// </summary>
        ///// <param name="Smer">Naziv smera za koji zelimo da prikazemo predmete.</param>
        ///// <returns></returns>
        [HttpGet]
        public ActionResult PredmetiPrikaz(int Smer, int razred)
        {
            List<SmerModel> smerovi = _usersMaterijalContext.Smer.ToList();
            //return Content(smerovi.Count().ToString());
            int smerId = Smer;

            int razredPOM = razred;
            //try
            //{
            //    smerId = context.smerovi.FirstOrDefault(x => x.smerNaziv == Smer).smerId;
            //}
            //catch
            //{
            //    return View("FileNotFound");
            //}

            if (smerId != 0)
            {
            }
            var predPoSmer = _usersMaterijalContext.predmetiPoSmeru.Where(x => x.smerId == smerId).Select(x => x.predmetId);
            List<PredmetModel> predmeti = _usersMaterijalContext.predmeti.Where(x => predPoSmer.Contains(x.predmetId) && x.Razred == razredPOM).ToList();
            
            PredmetPoSmeruViewModel predmetiPoSmeru = new PredmetPoSmeruViewModel
            {
                predmeti = predmeti,
                smerovi = smerovi,
                smerId = smerId
            };
            predmetiPoSmeru.viewModel = new DodajPremetViewModel();
            predmetiPoSmeru.viewModel.tip = 1;
            predmetiPoSmeru.viewModel.skole = _usersMaterijalContext.Skola.ToList();
            var smerIds = _usersMaterijalContext.smeroviPoSkolama.Where(x => x.skolaId == _usersMaterijalContext.Skola.FirstOrDefault().IdSkole).Select(x => x.smerId).ToList();
            predmetiPoSmeru.viewModel.smerovi = _usersMaterijalContext.Smer.Where(x => smerIds.Contains(x.smerId)).ToList();
            
            return View("PredmetiPrikaz", predmetiPoSmeru);
        }
    }
}
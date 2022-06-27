using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.Models;
using ProjekatWebPortal_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Controllers
{
    /// <summary>
    /// Materijal kontroler
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class MaterijalController : Controller
    {
        private UsersMaterijalDbContext _usersMaterijalContext;
        private readonly SignInManager<AspNetUserCustom> _signInManager;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public MaterijalController(UsersMaterijalDbContext umdbc, SignInManager<AspNetUserCustom> signInManager, UserManager<AspNetUserCustom> usman)
        {
            _usersMaterijalContext = umdbc;
            _signInManager = signInManager;
            _userManager = usman;
        }

        

        // GET: Materijal
        /// <summary>
        /// Index akcija
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        //TESTIRATI KAD MLADJA PROSLEDI EKSTENZIJU I ID TIPA!!!
        //VIDETI KAKO CE DA SE HENDLUJE SAMA NAMENA MATERIJALA I POJAVLJIVANJE NA STRANANMA
        //

        /// <summary>
        /// Prikaz materijala sa sortiranjem
        /// </summary>
        /// <param name="sort">String po kome se sortiraju materijali.</param>
        /// <param name="formati">Lista formata za prikaz.</param>
        /// <param name="tipovi">Lista tipova materijala za prikaz.</param>
        /// <param name="number">The number.</param>
        /// <param name="id">Id modula za koji su materijali, ako je id = null, predpostavlja se da je dati materijal za profesore</param>
        /// <returns>Parcijalni pregled karticw</returns>
        [HttpGet]
        public async Task<ActionResult> MaterijaliPrikaz(string sort, List<string> formati, List<int> tipovi, int number = 0, int? id = null)
        {
            List<OsiromaseniMaterijali> materijali;

            MaterijaliNaprednaPretragaViewModel vm;
            int namenaID = 1;
            if (id == null)
            {
                if (User.IsInRole("Ucenik"))
                {
                    return new StatusCodeResult(403);
                }
                namenaID = 2;
            }
            if (this.User.IsInRole("Ucenik"))
            {
                int? smer = await VratiSmerId(this.User.Identity.Name);

                
                if (smer != null)
                {
                    ModulModel mod = _usersMaterijalContext.moduli.FirstOrDefault(x => x.modulId == id);
                    PredmetPoSmeru pos = _usersMaterijalContext.predmetiPoSmeru.FirstOrDefault(x => x.predmetId == mod.predmetId && x.smerId == smer);

                    if (pos == null)
                    {
                        return new StatusCodeResult(403);
                    }
                }
            }



            materijali = _usersMaterijalContext.naprednaPretraga(formati, tipovi, id, namenaID).ToList();

            //string contcat = "";

            //foreach (var item in tipovi)
            //{
            //    contcat += item.ToString();
            //}

            return Content(materijali.Count.ToString());
            /*
            if (sort == "opadajuce")
            {
                materijali = context.naprednaPretraga(formati, tipovi, id, namenaID).ToList();
                materijali.Reverse();

                vm = new MaterijaliNaprednaPretragaViewModel
                {
                    osiromaseniMaterijali = materijali,
                    naprednaPretragaSelektovani = "",
                    tipoviMaterijala = umdbc.tipMaterijala.ToList()
                };

                return PartialView("_Kartice", vm);
            }
            else if (sort == "rastuce")
            {
                materijali = context.naprednaPretraga(formati, tipovi, id, namenaID).ToList();

                vm = new MaterijaliNaprednaPretragaViewModel
                {
                    osiromaseniMaterijali = materijali,
                    naprednaPretragaSelektovani = "",
                    tipoviMaterijala = context.tipMaterijala.ToList()
                };
                return PartialView("_Kartice", vm);
            }

            vm = new MaterijaliNaprednaPretragaViewModel
            {
                osiromaseniMaterijali = materijali,
                naprednaPretragaSelektovani = "",
                tipoviMaterijala = context.tipMaterijala.ToList()
            };

            if (sort != null && tipovi.Count != 0)
            {
                return View("_Kartice", vm);
            }

            return View("MaterijaliPrikaz", vm);*/
        }

        //public JsonResult GetSmerovi(int skolaID)
        //{
        //    MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
        //    {
        //        tipoviMaterijala = context.tipMaterijala.ToList(),
        //        nameneMaterijala = context.nameneMaterijala.ToList(),
        //        skole = context.skole.ToList(),
        //        Smerovi = context.smerovi.ToList(),
        //        Predmeti = context.predmeti.ToList(),
        //        Moduli = context.moduli.ToList()
        //    };

        //    var smeroviPoSkoli = context.smeroviPoSkolama.Where(x => x.skolaId == skolaID).Select(x => x.smerId).ToList();
        //    viewModel.SmeroviPoSkolama = context.smerovi.Where(x => smeroviPoSkoli.Contains(x.smerId)).ToList();

        //    if (viewModel.SmeroviPoSkolama.Count > 0)
        //    {
        //        int id = viewModel.SmeroviPoSkolama.FirstOrDefault().smerId;

        //        var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == id).Select(c => c.predmetId).ToList();
        //        viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)).ToList();

        //        int idP = viewModel.PredmetPoSmeru.FirstOrDefault().predmetId;

        //        viewModel.ModulPoPredmetu = context.moduli.Where(x => x.predmetId == idP).ToList();

        //        if (viewModel.ModulPoPredmetu.Count() < 1)
        //        {
        //            viewModel.ModulPoPredmetu = new List<ModulModel>();
        //        }

        //        var res = new { smerovi = viewModel.SmeroviPoSkolama, predmeti = viewModel.PredmetPoSmeru, moduli = viewModel.ModulPoPredmetu };

        //        return Json(res, JsonRequestBehavior.AllowGet);
        //    }
        //    viewModel.ModulPoPredmetu = new List<ModulModel>();
        //    viewModel.PredmetPoSmeru = new List<PredmetModel>();
        //    var result = new { smerovi = viewModel.SmeroviPoSkolama, predmeti = viewModel.PredmetPoSmeru, moduli = viewModel.ModulPoPredmetu };

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetPredmeti(int smerID)
        //{
        //    MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
        //    {
        //        tipoviMaterijala = context.tipMaterijala.ToList(),
        //        nameneMaterijala = context.nameneMaterijala.ToList(),
        //        skole = context.skole.ToList(),
        //        Smerovi = context.smerovi.ToList(),
        //        Predmeti = context.predmeti.ToList(),
        //        Moduli = context.moduli.ToList()
        //    };

        //    var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == smerID).Select(c => c.predmetId).ToList();
        //    viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)).ToList();

        //    if (viewModel.PredmetPoSmeru.Count < 1)
        //    {
        //        viewModel.PredmetPoSmeru = new List<PredmetModel>();
        //        viewModel.ModulPoPredmetu = new List<ModulModel>();

        //        var result = new { predmeti = viewModel.PredmetPoSmeru, moduli = viewModel.ModulPoPredmetu };

        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }

        //    int idP = viewModel.PredmetPoSmeru.FirstOrDefault().predmetId;

        //    viewModel.ModulPoPredmetu = context.moduli.Where(x => x.predmetId == idP).ToList();

        //    if (viewModel.ModulPoPredmetu.Count() < 1)
        //    {
        //        viewModel.ModulPoPredmetu = new List<ModulModel>();
        //    }

        //    var res = new { predmeti = viewModel.PredmetPoSmeru, moduli = viewModel.ModulPoPredmetu };

        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetModuli(int modulID)
        //{
        //    MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
        //    {
        //        tipoviMaterijala = context.tipMaterijala.ToList(),
        //        nameneMaterijala = context.nameneMaterijala.ToList(),
        //        skole = context.skole.ToList(),
        //        Smerovi = context.smerovi.ToList(),
        //        Predmeti = context.predmeti.ToList(),
        //        Moduli = context.moduli.ToList()
        //    };

        //    viewModel.ModulPoPredmetu = context.moduli.Where(x => x.predmetId == modulID).ToList();

        //    if (viewModel.ModulPoPredmetu.Count() < 1)
        //    {
        //        viewModel.ModulPoPredmetu = new List<ModulModel>();
        //    }

        //    var res = new { moduli = viewModel.ModulPoPredmetu };

        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}

        ////kod ove akcije treba dodati punjenje tabele namena materijala
        ///// <summary>
        ///// Vraca view na kome je forma za dodavanje predmeta
        ///// </summary>
        ///// <param name="smerId">Id smera za koji je predmet koji se dodaje.</param>
        ///// <returns></returns>
        //[HttpGet]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik,Profesor")]
        //public async Task<ActionResult> UploadMaterijal()
        //{
        //    context = new MaterijalContext();

        //    MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
        //    {
        //        tipoviMaterijala = context.tipMaterijala.ToList(),
        //        nameneMaterijala = context.nameneMaterijala.ToList(),
        //        skole = context.skole.ToList(),
        //        Smerovi = context.smerovi.ToList(),
        //        Predmeti = context.predmeti.ToList(),
        //        Moduli = context.moduli.ToList()
        //    };

        //    try
        //    {
        //        var skId = viewModel.skole.ToList()[0].IdSkole;
        //        if (!this.User.IsInRole("SuperAdministrator"))
        //        {
        //            SkolaModel sk = await ApplicationUser.vratiSkoluModel(User.Identity.Name);
        //            if (sk.IdSkole > 0)
        //            {
        //                skId = sk.IdSkole;
        //            }
        //        }
        //        var smeroviPoSkoli = context.smeroviPoSkolama.Where(x => x.skolaId == skId).Select(x => x.smerId).ToList();
        //        viewModel.SmeroviPoSkolama = context.smerovi.Where(x => smeroviPoSkoli.Contains(x.smerId)).ToList();
        //        int id = viewModel.SmeroviPoSkolama.First().smerId;
        //        var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == id).Select(c => c.predmetId).ToList();
        //        viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)).ToList();

        //        int idP = viewModel.PredmetPoSmeru.FirstOrDefault().predmetId;

        //        viewModel.ModulPoPredmetu = context.moduli.Where(x => x.predmetId == idP).ToList();

        //        if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }

        //        return View("UploadMaterijal", viewModel);
        //    }
        //    catch (ArgumentOutOfRangeException) { return new HttpNotFoundResult("Nema unetih smerova"); }
        //}

        ////kod ove akcije treba dodati punjenje tabele namena materijala
        ///// <summary>
        ///// Dodaje materijal u bazu
        ///// </summary>
        ///// <param name="materijal">Materijal model.</param>
        ///// <param name="file">Uploadovani fajl.</param>
        ///// <param name="predmet">Predmet za koji je materijal.</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik,Profesor")]
        //public ActionResult UploadMaterijal(MaterijalModel materijal, HttpPostedFileBase file, int modulId, string idUser, string odobreno)
        //{
        //    // PredmetModel predmet = new PredmetModel();
        //    //materijal.modulId = modulId;

        //    context = new MaterijalContext();

        //    if (materijal.namenaMaterijalaId != 2)
        //    {
        //        context.Add<MaterijalPoModulu>(new MaterijalPoModulu
        //        {
        //            modulId = modulId,
        //            materijalId = materijal.materijalId
        //        });
        //    }
        //    if (idUser != null)
        //    {
        //        materijal.idUser = idUser;
        //    }
        //    if (odobreno != null)
        //    {
        //        materijal.odobreno = odobreno;
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (file != null)
        //        {
        //            string nazivFajla = Path.GetFileName(file.FileName);

        //            materijal.datumMaterijali = DateTime.Now;
        //            materijal.fileMimeType = file.ContentType;
        //            materijal.materijalFile = new byte[file.ContentLength];
        //            file.InputStream.Read(materijal.materijalFile, 0, file.ContentLength);
        //            materijal.materijalNaziv = nazivFajla;
        //            materijal.materijalEkstenzija = Path.GetExtension(nazivFajla);
        //            materijal.materijalOpis = materijal.materijalOpis;
        //            materijal.materijalNaslov = materijal.materijalNaslov;
        //            materijal.Obrisan = false;

        //            context.Add<MaterijalModel>(materijal);
        //            context.SaveChanges();
        //        }

        //        TempData["SuccMsg"] = "Uspešno ste postavili materijal!";
        //        //ViewBag.Message = "Uspešno ste postavili materijal!";
        //        return RedirectToAction("UploadMaterijal", "Materijal");
        //        // return View("UploadMaterijal", ViewModel);
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Postavljanje materijala nije uspelo!";
        //        //TempData["ErrorMsg"] = "Postavljanje materijala nije uspelo!";
        //        return RedirectToAction("UploadMaterijal", "Materijal");

        //        // return View("UploadMaterijal", ViewModel);
        //    }
        //}

        //[HttpGet]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        //public ActionResult MaterijaliCekanje()
        //{
        //    MaterijaliNaprednaPretragaViewModel materijal = new MaterijaliNaprednaPretragaViewModel();

        //    List<OsiromaseniMaterijali> listaMaterijalaCekanje = context.nacekanju().ToList();
        //    materijal.osiromaseniMaterijali = listaMaterijalaCekanje;

        //    if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }

        //    return View(materijal);
        //}

        //[HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        //public ActionResult ObrazlozenjeMaterijal(string obrazlozenje, int id)
        //{
        //    MaterijalModel model = new MaterijalModel() { materijalId = id, obrazlozenje = obrazlozenje, odobreno = "false" };
        //    using (MaterijalContext db = new MaterijalContext())
        //    {
        //        db.materijali.Attach(model);
        //        db.Entry(model).Property(x => x.obrazlozenje).IsModified = true;
        //        db.Entry(model).Property(x => x.odobreno).IsModified = true;
        //        db.SaveChanges();
        //    }
        //    TempData["SuccMsg"] = "Uspesno uneseno";

        //    return RedirectToAction("MaterijaliCekanje");
        //}

        //[HttpGet]
        //[Authorize(Roles = "SuperAdministrator,Profesor")]
        //public ActionResult UrednikOdgovor()
        //{
        //    MaterijalContext materijalContext = new MaterijalContext();
        //    UrednikOdgovorViewModel urednik = new UrednikOdgovorViewModel();
        //    var idUser = User.Identity.GetUserId();

        //    var odgovor = materijalContext.materijali.Where(x => x.odobreno.Equals("false") && x.obrazlozenje != null && x.idUser == idUser).Select(x => new UrednikOdgovorViewModel { MaterijalOpis = x.materijalOpis, MaterijalNaslov = x.materijalNaslov, Obrazlozenje = x.obrazlozenje, datum = x.datumMaterijali }).ToList();

        //    return View(odgovor);
        //}

        ///*[HttpPost]
        //[Authorize(Roles ="Profesor")]
        //public ActionResult UploadMaterijalProfesor(MaterijalProfesorModel materijalProfesor,HttpPostedFileBase file,PredmetPoSmeru predmet)
        //{
        //    materijalProfesor.predmetId = predmet.predmetId;
        //    context = new MaterijalContext();
        //    if (materijalProfesor.namenaMaterijalaId == 2)
        //    {
        //        materijalProfesor.predmetId = null;
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (file != null)
        //        {
        //            string nazivFajla = Path.GetFileName(file.FileName);

        //            materijalProfesor.fileMimeType = file.ContentType;
        //            materijalProfesor.materijalFile = new byte[file.ContentLength];
        //            file.InputStream.Read(materijalProfesor.materijalFile, 0, file.ContentLength);
        //            materijalProfesor.materijalNaziv = nazivFajla;
        //            materijalProfesor.materijalEkstenzija = Path.GetExtension(nazivFajla);
        //            materijalProfesor.materijalOpis = materijalProfesor.materijalOpis;
        //            materijalProfesor.materijalNaslov = materijalProfesor.materijalNaslov;

        //            context.Add<MaterijalProfesorModel>(materijalProfesor);
        //            context.SaveChanges();
        //        }
        //        ViewBag.Message = "Uspešno ste postavili materijal!";

        //        return RedirectToAction("UploadMaterijal", "Materijal");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Postavljanje materijala nije uspelo!";
        //        return RedirectToAction("UploadMaterijal", "Materijal");
        //    }
        //}*/

        ///// <summary>
        ///// Skida selektovani materijal
        ///// </summary>
        ///// <param name="id">Id materijala za download.</param>
        ///// <returns></returns>
        //public FileContentResult DownloadMaterijal(int id)
        //{
        //    MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
        //    if (materijal != null)
        //    {
        //        return File(materijal.materijalFile, materijal.fileMimeType, materijal.materijalNaziv);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public ActionResult Delete(int id)
        //{
        //    MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
        //    if (materijal == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View("Delete", materijal);
        //}

        ///// <summary>
        ///// Brise materijal
        ///// </summary>
        ///// <param name="id">Id materijala za brisanje</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik,GlobalniUrednik")]
        ////[ActionName("Delete")]
        ////[Route("UploadMaterijal/DeleteConfirmed/{id:int}")]
        //public ActionResult DeleteConfirmed(int id, int? modulId)
        //{
        //    if (modulId != null)
        //    {
        //        try
        //        {
        //            MaterijalPoModulu matPoMod = context.materijalPoModulu.Where(x => x.materijalId == id && x.modulId == modulId).FirstOrDefault();
        //            context.Delete<MaterijalPoModulu>(matPoMod);
        //            context.SaveChanges();
        //        }
        //        catch (Exception) { }
        //    }
        //    List<MaterijalPoModulu> lista = context.materijalPoModulu.Where(x => x.materijalId == id).ToList();
        //    if (lista.Count == 0)
        //    {
        //        MaterijalModel temp = context.pronadjiMaterijalPoId(id);
        //        temp.Obrisan = true;
        //        context.SaveChanges();
        //    }

        //    return RedirectToAction("MaterijaliPrikaz");
        //}

        ////public ActionResult SortirajPoTipuMaterijala(int id)
        ////{
        ////    context = new MaterijalContext();
        ////    List<MaterijalModel> model = context.materijali.Where(m => m.tipMaterijalId == id).ToList();

        ////    return View("MaterijaliPrikaz", model);

        ////}

        ///// <summary>
        ///// Filtrira materijal po formatu i tipu materijala.
        ///// </summary>
        ///// <param name="ekstenzija">Zeljena ekstenzija po kojoj se filtrira.</param>
        ///// <param name="id">Id tipa materijala po kome se filtrira.</param>
        ///// <param name="materijali">Lista materijala za filtriranje.</param>
        //public void FiltrirajPoFormatuMaterijala(string ekstenzija, int id, ref List<MaterijalModel> materijali) //Refaktorisati naziv akcije kasnije jer se ffiltrira i tip materijala ne samo format
        //{
        //    materijali = context.materijali.Where(m => m.materijalEkstenzija == ekstenzija && m.tipMaterijalId == id).ToList();//scuffed
        //}

        //// IF SCUFFED IN MATERIJALCONTEXT THIS.UNCOMMENT

        ////public List<MaterijalModel> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds)
        ////{
        ////    List<MaterijalModel> materijali = new List<MaterijalModel>();
        ////    foreach(MaterijalModel m in context.materijali)
        ////    {
        ////        if (ekstenzije.Contains(m.materijalEkstenzija) && tipoviMaterijalaIds.Contains(m.tipMaterijalId))
        ////            materijali.Add(m);

        ////    }
        ////    return materijali;
        //}

        public async Task<int?> VratiSmerId(string username)
        {
            AspNetUserCustom user = _userManager.Users.Where(x => x.UserName == username).FirstOrDefault();
            if (user == null)
                return null;
            int? smer = _usersMaterijalContext.Smer.Where(x => x.smerId == user.SmerId).FirstOrDefault()?.smerId;
            return smer;

        }

        


        IQueryable<OsiromaseniMaterijali> poModulu(int? modulId)
        {
            IQueryable<OsiromaseniMaterijali> materijali;

            materijali = from mat in _usersMaterijalContext.materijali
                         select new OsiromaseniMaterijali
                         {
                             namenaID = mat.namenaMaterijalaId,
                             materijalId = mat.materijalId,
                             ekstenzija = mat.materijalEkstenzija,
                             materijalNaslov = mat.materijalNaslov,
                             materijalOpis = mat.materijalOpis,
                             tipMaterijalaId = mat.tipMaterijalId
                         };

            if (modulId != null)
            {
                materijali = from mat in _usersMaterijalContext.materijali
                             join matPoMod in _usersMaterijalContext.materijalPoModulu
                             on mat.materijalId equals matPoMod.materijalId
                             where matPoMod.modulId == modulId
                             select new OsiromaseniMaterijali
                             {
                                 namenaID = mat.namenaMaterijalaId,
                                 materijalId = mat.materijalId,
                                 ekstenzija = mat.materijalEkstenzija,
                                 materijalNaslov = mat.materijalNaslov,
                                 materijalOpis = mat.materijalOpis,
                                 tipMaterijalaId = mat.tipMaterijalId,
                                 modulId = modulId
                             };
            }

            return materijali;
        }

        public IQueryable<OsiromaseniMaterijali> poNameni(int namenaID, IQueryable<OsiromaseniMaterijali> materijali)
        {
            materijali = materijali.Where(m => m.namenaID == namenaID).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaID,
                materijalId = m.materijalId,
                ekstenzija = m.ekstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalaId,
                modulId = m.modulId
            });

            return materijali;
        }
    }
}
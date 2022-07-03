﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.Models;
using ProjekatWebPortal_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ProjekatWebPortal_Core.Controllers
{
    public class GlobalniController : Controller
    {
        // private IMaterijalContext context;
        private UsersMaterijalDbContext _usersMaterijalContext;

        public GlobalniController(UsersMaterijalDbContext umdbc)
        {
            _usersMaterijalContext = umdbc;
        }

        //GET: /Predmet/PredmetiPrikaz
        /// <summary>
        /// Prikazuje predmete na odredjenom smeru
        /// </summary>
        /// <param name="Smer">Naziv smera za koji zelimo da prikazemo predmete.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult PredmetiPrikaz()
        {
            List<PredmetModel> model = _usersMaterijalContext.predmeti.Where(x => x.tipId == 2).ToList();

            PredmetPoSmeruViewModel predmetiPoSmeru = new PredmetPoSmeruViewModel
            {
                predmeti = model
            };

            return View("PredmetiPrikaz", predmetiPoSmeru);
        }

        /// <summary>
        /// Vraca stranicu sa formom za dodavanje globalnog predmeta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,GlobalniUrednik")]
        public ActionResult DodajPredmet()
        {
            DodajPremetViewModel viewModel = new DodajPremetViewModel();
            viewModel.tipoviPredmeta = _usersMaterijalContext.tipPredmeta.ToList();

            return View("DodajPredmet", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator, GlobalniUrednik")]
        public ActionResult DodajPredmet(DodajPremetViewModel viewModel)
        {

            try
            {
                if (User.IsInRole("GlobalniUrednik"))
                {
                    viewModel.predmet.tipId = 2;
                }
                else
                {
                    int id = viewModel.tipIds.FirstOrDefault();
                    viewModel.predmet.tipId = id;
                }

                _usersMaterijalContext.Add<PredmetModel>(viewModel.predmet);

                _usersMaterijalContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("PredmetiPrikaz", "Globalni");
        }

        [HttpPost]
        public ActionResult EditPredmet(string predmetNaziv, string predmetOpis, int predmetId)
        {

            PredmetModel predmet = _usersMaterijalContext.predmeti.Where(x => x.predmetId == predmetId).Single();

            predmet.predmetNaziv = predmetNaziv;
            predmet.predmetOpis = predmetOpis;

            try
            {
                _usersMaterijalContext.SaveChanges();
            }
            catch
            {
                return new StatusCodeResult(403);
            }

            return RedirectToAction("PredmetiPrikaz", new { razred = 0, tip = "globalni" });
        }

        /// <summary>
        //GET: /Modul/ModulPrikaz
        /// <returns></returns>
        /// </summary>
        /// Prikazuje module na odredjenom predmetu
        /// <param name="id">ID predmeta za koji zelimo da prikazemo module.</param>
        public ActionResult ModuliPrikaz(int id)
        {
            List<ModulModel> moduli;
            ViewBag.predmetId = id;
            try
            {
                int pID = _usersMaterijalContext.predmeti.Where(x => x.predmetId == id).FirstOrDefault().predmetId;
                if (pID != 0)
                {
                    moduli = _usersMaterijalContext.moduli.Where(x => x.predmetId == pID).ToList();
                    return View(moduli);
                }
            }
            catch { }
            return View("FileNotFound");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator, GlobalniUrednik")]
        public ActionResult DodajModul(int? predmetId)
        {
            DodajModulViewModel viewModel = new DodajModulViewModel()
            {
                Predmeti = _usersMaterijalContext.predmeti.Where(x => x.tipId == 2)
            };

            viewModel.predmetId = predmetId;

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator, GlobalniUrednik")]
        public ActionResult DodajModul(DodajModulViewModel m)
        {

            if (m.modul.predmetId != null)
            {
                m.predmetId = m.modul.predmetId;
            }
            else if (m.predmetId != null)
            {
                m.modul.predmetId = m.predmetId;
            }

            try
            {
                _usersMaterijalContext.Add<ModulModel>(m.modul);
                _usersMaterijalContext.SaveChanges();
            }
            catch
            {
                return  new StatusCodeResult(403);
            }

            return RedirectToAction("ModuliPrikaz", "Globalni", new { id = m.modul.predmetId });
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator, GlobalniUrednik")]
        public ActionResult EditModul(int id)
        {
            ModulModel modul = _usersMaterijalContext.moduli.Where(x => x.modulId == id).Single();

            DodajModulViewModel viewModel = new DodajModulViewModel()
            {
                Predmeti = _usersMaterijalContext.predmeti.Where(x => x.tipId == 2)
            };
            viewModel.predmetId = modul.predmetId;
            viewModel.modul = modul;

            return View("EditModul", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator, GlobalniUrednik")]
        public ActionResult EditModul(DodajModulViewModel m)
        {
            if (m.modul.predmetId != null)
            {
                m.predmetId = m.modul.predmetId;
            }
            else if (m.predmetId != null)
            {
                m.modul.predmetId = m.predmetId;
            }
            ModulModel editovan = m.modul;
            ModulModel modul;
            try
            {
                modul = _usersMaterijalContext.moduli.Where(x => x.modulId == editovan.modulId).Single();

                modul.modulNaziv = editovan.modulNaziv;
                modul.modulOpis = editovan.modulOpis;
                modul.predmetId = editovan.predmetId;
                _usersMaterijalContext.SaveChanges();
            }
            catch
            {
                return new StatusCodeResult(403);
            }
            return RedirectToAction("ModuliPrikaz", new { id = editovan.predmetId });
        }

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
        public ActionResult MaterijaliPrikaz(string sort, List<string> formati, List<int> tipovi, int number = 0, int? id = null)
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
            materijali = _usersMaterijalContext.naprednaPretraga(formati, tipovi, id, namenaID).ToList();

            if (sort == "opadajuce")
            {
                materijali = _usersMaterijalContext.naprednaPretraga(formati, tipovi, id, namenaID).ToList();
                materijali.Reverse();

                vm = new MaterijaliNaprednaPretragaViewModel
                {
                    osiromaseniMaterijali = materijali,
                    naprednaPretragaSelektovani = "",
                    tipoviMaterijala = _usersMaterijalContext.tipMaterijala.ToList()
                };

                return PartialView("_Kartice", vm);
            }
            else if (sort == "rastuce")
            {
                materijali = _usersMaterijalContext.naprednaPretraga(formati, tipovi, id, namenaID).ToList();

                vm = new MaterijaliNaprednaPretragaViewModel
                {
                    osiromaseniMaterijali = materijali,
                    naprednaPretragaSelektovani = "",
                    tipoviMaterijala = _usersMaterijalContext.tipMaterijala.ToList()
                };
                return PartialView("_Kartice", vm);
            }

            vm = new MaterijaliNaprednaPretragaViewModel
            {
                osiromaseniMaterijali = materijali,
                naprednaPretragaSelektovani = "",
                tipoviMaterijala = _usersMaterijalContext.tipMaterijala.ToList()
            };

            if (sort != null && tipovi.Count != 0)
            {
                return View("_Kartice", vm);
            }

            return View("MaterijaliPrikaz", vm);
        }
    }
}
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.Models;
using ProjekatWebPortal_Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ProjekatWebPortal_Core.Controllers
{
    public class VestiController : Controller
    {
        private readonly VestiDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; //Koristi se za ucitavanje xml fajla

        //Dependecy injection za DbContext bazu
        public VestiController(VestiDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //TEST ZA PATH
        public IActionResult Index(string fileId, string ekstenzija)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            path = Path.Combine(webRootPath, "Content/Konfiguracija/", "MojaKonfiguracija.xml");
            return Content(path);
        }

        private VestModel VratiGlavnuVest()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            path = Path.Combine(webRootPath, "Content/Konfiguracija/", "MojaKonfiguracija.xml");

            XDocument xmlFajl = null;
            try
            {
                //xmlFajl = XDocument.Load(Server.MapPath("~/Content/Konfiguracija/MojaKonfiguracija.xml")); - UKINITO.
                xmlFajl = XDocument.Load(path); // Ucitaj XML fajl
            }
            catch (FileNotFoundException)
            {
                xmlFajl = new XDocument(new XElement("konfigurcija", new XElement("glavnaVest", new List<XAttribute> { new XAttribute("idGlavne", 0), new XAttribute("datumIsteka", 0) })));
                xmlFajl.Save(path);
            }

            int ID;
            DateTime datum;
            var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
            try
            {
                ID = (int)Konfiguracija.Attribute("idGlavne");
                datum = (DateTime)Konfiguracija.Attribute("datumIsteka");
            }
            catch
            {
                return _context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
            }
            if (DateTime.Today.Date <= datum.Date)
            {
                VestModel Vest = _context.Vesti.FirstOrDefault(m => m.Id == ID);
                if (Vest != null)
                    return Vest;
                else
                    return _context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
            }
            else
            {
                return _context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
            }
        }

        private void SnimiGlavnuVest(int ID, DateTime DatDo)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            path = Path.Combine(webRootPath, "Content/Konfiguracija/", "MojaKonfiguracija.xml");

            XDocument xmlFajl = XDocument.Load(path);
            var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
            Konfiguracija.Attribute("datumIsteka").SetValue(DatDo.ToShortDateString());
            Konfiguracija.Attribute("idGlavne").SetValue(ID.ToString());
            xmlFajl.Save(path);
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")] - IDENTITY
        public IActionResult NovaVest()
        {
            DodajVestViewModel vm = new DodajVestViewModel();
            return View(vm);
        }



        /*Instead of HttpFileBase, you've to use IFormFile from Microsoft.AspNetCore.Http (install NuGet package if you haven't.)*/
        //[ValidateInput(false)] - MVC old
        [HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")] - IDENTITY
        public IActionResult SnimiVest(IFormFile Fajl, DodajVestViewModel vm) //HttpPostedFileBase ?
        {
            VestModel Vest = new VestModel();
            TeloVestiModel Telo = new TeloVestiModel();
            Vest.Naslov = vm.Naslov;

            Vest.KratakOpis = vm.KratakOpis;
            if (Fajl != null)
            {
                string ekstenzija = Fajl.FileName.Remove(0, Fajl.FileName.LastIndexOf('.'));
                string fileId = Guid.NewGuid().ToString().Replace("-", "");

                string webRootPath = _webHostEnvironment.WebRootPath;
                string contentRootPath = _webHostEnvironment.ContentRootPath;
                string path = "";
                path = Path.Combine(webRootPath, "/Content/Uploads/Thumbnails/", fileId + ekstenzija);
                string pathzaserver = "/Content/Uploads/Thumbnails/" + fileId + ekstenzija;

                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(path, FileMode.Append))
                {

                    Fajl.CopyTo(fileStream);
                }

                //Fajl.Write(path);
                Vest.Thumbnail = pathzaserver;
            }
            _context.Vesti.Add(Vest);
            _context.SaveChanges();
            Telo.TeloVesti = vm.Vest;
            Telo.VestId = Vest.Id;
            _context.TeloVesti.Add(Telo);
            _context.SaveChanges();
            return RedirectToAction("PrikazVesti", "Vesti");
        }

        [HttpGet]
        public IActionResult PrikazVesti()
        {
            VestModel GlavnaVest = VratiGlavnuVest();

            return View(GlavnaVest);
        }

        [HttpGet]
        public ActionResult PosaljiVesti(int pageindex, int pagesize, int idGlavne)
        {
            List<VestModel> vesti = _context.Vesti.OrderByDescending(m => m.DatumPostavljanja).Where(m => m.Id != idGlavne).Skip(pageindex * pagesize).Take(pagesize).ToList();
            return Json(vesti.ToList(), new Newtonsoft.Json.JsonSerializerSettings()); //pre: JsonRequestBehavior.AllowGet
        }

        [HttpGet]
        public ActionResult PretragaPoNaslovu(string kveri)
        {
            List<VestModel> RezultatPretrage = _context.Vesti.Where(x => x.Naslov.ToLower().Contains(kveri.ToLower())).Take(10).ToList();
            return Json(RezultatPretrage, new Newtonsoft.Json.JsonSerializerSettings()); //pre: JsonRequestBehavior.AllowGet
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public IActionResult BrisanjeVesti(int Id, bool glavna = false)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            path = Path.Combine(webRootPath, "Content/Konfiguracija/", "MojaKonfiguracija.xml");

            VestModel ZaBrisanje = _context.Vesti.FirstOrDefault(x => x.Id == Id);
            if (glavna)
            {
                XDocument xmlFajl = XDocument.Load(path);
                var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
                Konfiguracija.Attribute("datumIsteka").SetValue("");
                Konfiguracija.Attribute("idGlavne").SetValue("");
                xmlFajl.Save(path);
            }
            if (ZaBrisanje != null)
            {
                string pathThumbnail = "";
                pathThumbnail = Path.Combine(ZaBrisanje.Thumbnail);
                string Thumbnail = pathThumbnail;
                if (System.IO.File.Exists(Thumbnail))
                {
                    System.IO.File.Delete(Thumbnail);
                }
                TeloVestiModel telo = _context.TeloVesti.FirstOrDefault(x => x.VestId == Id);
                if (telo != null)
                    _context.TeloVesti.Remove(telo);
                _context.Vesti.Remove(ZaBrisanje);

                _context.SaveChanges();
            }
            return RedirectToAction("PrikazVesti");
        }

        public IActionResult PrikaziVest(string Naslov, string Datum)
        {
            Naslov = HttpUtility.UrlDecode(Naslov);
            Datum = HttpUtility.UrlDecode(Datum);
            string datum;
            try
            {
                datum = Convert.ToDateTime(Datum).ToShortDateString();
            }
            catch
            {
                return NotFound("Na zalost vest koju trazite nije nadjena");
            }
            List<VestModel> VestiZaPrikaz = _context.Vesti.Where(x => x.Naslov == Naslov).ToList();
            if (VestiZaPrikaz == null)
            {

                return NotFound("Na zalost vest koju trazite nije nadjena"); /*new HttpNotFoundResult("Na zalost vest koju trazite nije nadjena");*/
            }

            for (int i = 0; i < VestiZaPrikaz.Count; i++)
            {
                if (VestiZaPrikaz[i].DatumPostavljanja.ToShortDateString() == datum)
                {
                    int id = VestiZaPrikaz[i].Id;
                    PrikazVestiViewModel vm = new PrikazVestiViewModel
                    {
                        Naslov = VestiZaPrikaz[i].Naslov,
                        KratakOpis = VestiZaPrikaz[i].KratakOpis,
                        DatumPostavljanja = Convert.ToDateTime(datum),
                        TeloVesti = _context.TeloVesti.FirstOrDefault(x => x.VestId == id).TeloVesti
                    };
                    return View(vm);
                }
            }
            return NotFound("Na zalost vest koju trazite nije nadjena");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //[Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public ActionResult PostaviGlavnuVest(DateTime datum, string naslov, DateTime novDatum)
        {
            if (datum != null && naslov != null && novDatum != null)
            {
                int id;
                List<VestModel> Vesti = _context.Vesti.Where(x => x.Naslov == naslov).ToList();
                if (Vesti == null)
                {
                    return NotFound("Na zalost vest koju trazite nije nadjena");
                }
                for (int i = 0; i < Vesti.Count; i++)
                {
                    if (Vesti[i].DatumPostavljanja.ToShortDateString() == datum.ToShortDateString())
                    {
                        id = Vesti[i].Id;
                        SnimiGlavnuVest(id, novDatum);
                        return RedirectToAction("PrikazVesti", "Vesti");
                    }
                }

                return NotFound("Vest nije mogla biti postavljena kao glavna, pokusajte ponovo, ako se ova greska i dalje pojavljuje, kontaktirajte administratora");
            }
            else return NotFound("Vest nije mogla biti postavljena kao glavna, pokusajte ponovo, ako se ova greska i dalje pojavljuje, kontaktirajte administratora");
        }
    }
}

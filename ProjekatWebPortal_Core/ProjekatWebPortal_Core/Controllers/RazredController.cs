using Microsoft.AspNetCore.Mvc;

namespace ProjekatWebPortal_Core.Controllers
{
    public class RazredController : Controller
    {
        // GET: Godina
        public ActionResult RazrediPrikaz(int id)
        {
            if (id == 0) // ako je smer null
            {
                return RedirectToAction("SmeroviPrikaz", "Smer");
            }
            
            //object smer = HttpUtility.UrlDecode(id);

            return View("RazrediPrikaz", id);
        }
    }
}
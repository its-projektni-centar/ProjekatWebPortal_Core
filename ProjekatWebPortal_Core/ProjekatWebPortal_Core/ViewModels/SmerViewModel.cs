using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjekatWebPortal_Core.Models;

namespace ProjekatWebPortal_Core.ViewModels
{
    public class SmerViewModel
    {
        public IEnumerable<SmerModel> smerovi { get; set; }
        public SmerModel smeroviModel { get; set; }
    }
}
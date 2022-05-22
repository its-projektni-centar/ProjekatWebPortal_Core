using System;

namespace ProjekatWebPortal_Core.Models.ViewModels
{
    public class PrikazVestiViewModel
    {
        public string Naslov { get; set; }
        public string KratakOpis { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public string TeloVesti { get; set; }
    }
}

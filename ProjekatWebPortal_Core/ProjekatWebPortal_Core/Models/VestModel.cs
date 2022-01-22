using System;
using System.ComponentModel.DataAnnotations;

namespace ProjekatWebPortal_Core.Models
{
    public class VestModel
    {
        public VestModel()
        {
            DatumPostavljanja = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Thumbnail { get; set; }
        public string KratakOpis { get; set; }
        public DateTime DatumPostavljanja { get; set; }
    }
}

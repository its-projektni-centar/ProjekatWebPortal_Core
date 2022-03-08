using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatWebPortal_Core.Models
{
    public class GlobalniZahteviModel
    {
        [Key]
        public int zahtevId { get; set; }

        public DateTime zahtevDatum { get; set; }
        public string zahtevObrazlozenje { get; set; }
        public bool ZaGlobalnog { get; set; }

        [ForeignKey("MaterijalModel")]
        public int materijalId { get; set; }

        public MaterijalModel MaterijalModel { get; set; }

        public int? predlozeniModul { get; set; }
    }
}

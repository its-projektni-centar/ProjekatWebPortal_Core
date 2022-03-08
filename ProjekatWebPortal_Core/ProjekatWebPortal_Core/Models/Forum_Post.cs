using Projekat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatWebPortal_Core.Models
{
    [Table("Forum_Posts")]
    public class Forum_Post
    {
        [Key]
        public int Id_post { get; set; }

        [Required(ErrorMessage = "polje je obavezno")]
        [StringLength(50)]
        public string posttitle { get; set; }

        [Required(ErrorMessage = "polje je obavezno")]
        public string postmessage { get; set; }

        public DateTime posteddate { get; set; }

        [Required]
        [StringLength(10)]
        public string approved { get; set; }

        public string imgTema { get; set; }
        public AspNetUserCustom aspNetUser { get; set; }

        [Required]
        [ForeignKey("aspNetUserCustom")]
        public string Id { get; set; }

    }
}

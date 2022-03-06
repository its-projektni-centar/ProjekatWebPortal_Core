namespace Projekat.Models
{
    using Microsoft.AspNetCore.Identity;
    using ProjekatWebPortal_Core.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //--using System.Data.Entity.Spatial;

    public class AspNetUserCustom : IdentityUser
    {

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public byte[] Slika { get; set; }

        public int? SkolaId { get; set; }

        public int? GodinaUpisa { get; set; }

        public int? SmerId { get; set; }

        public string Uloga { get; set; }

        public virtual ICollection<Forum_Post> Forum_Post { get; set; }
        
    }
}

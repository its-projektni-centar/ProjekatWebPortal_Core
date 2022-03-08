﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatWebPortal_Core.Models
{
    public class MaterijalProfesorModel
    {
        [Key]
        public int materijalId { get; set; }
        [DisplayName("Materijal")]
        [MaxLength]
        public byte[] materijalFile { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string fileMimeType { get; set; }

        public string materijalOpis { get; set; }

        public string materijalEkstenzija { get; set; }

        public string materijalNaziv { get; set; }

        public string materijalNaslov { get; set; }

        public int? predmetId { get; set; }
        //  [ForeignKey("TipMaterijalModel")]
        public int tipMaterijalId { get; set; }
        // [ForeignKey("NamenaMaterijalModel")]
        public int namenaMaterijalaId { get; set; }

        public string odobreno { get; set; }

        public string obrazlozenje { get; set; }
        public NamenaMaterijalaModel namenaMaterijalaModel { get; set; }
        public TipMaterijalModel TipMaterijalModel { get; set; }
        public PredmetModel PredmetModel { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatWebPortal_Core.Models
{
    public class PredmetPoSmeru
    {
        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        [Key, ForeignKey("PredmetModel"), Column(Order = 0)]
        public int predmetId { get; set; }

        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        [Key, ForeignKey("SmerModel"), Column(Order = 1)]
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the predmet model.
        /// </summary>
        /// <value>
        /// The predmet model.
        /// </value>
        public PredmetModel PredmetModel { get; set; }
        /// <summary>
        /// Gets or sets the smer model.
        /// </summary>
        /// <value>
        /// The smer model.
        /// </value>
        public SmerModel SmerModel { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjekatWebPortal_Core.Models;
using ProjekatWebPortal_Core.ViewModels;

namespace ProjekatWebPortal_Core.ViewModels
{
    /// <summary>
    /// materijali napredna pretraga view model
    /// </summary>
    public class MaterijaliNaprednaPretragaViewModel
    {

        /// <summary>
        /// Gets or sets the osiromaseni materijali.
        /// </summary>
        /// <value>
        /// The osiromaseni materijali.
        /// </value>
        public List<ViewModels.OsiromaseniMaterijali> osiromaseniMaterijali { get; set; }

        /// <summary>
        /// Gets or sets the tipovi materijala.
        /// </summary>
        /// <value>
        /// The tipovi materijala.
        /// </value>
        public IEnumerable<TipMaterijalModel> tipoviMaterijala { get; set; }

        /// <summary>
        /// Gets or sets the tip materijala.
        /// </summary>
        /// <value>
        /// The tip materijala.
        /// </value>
        public TipMaterijalModel tipMaterijala { get; set; }

        /// <summary>
        /// Gets or sets the materijal.
        /// </summary>
        /// <value>
        /// The materijal.
        /// </value>
        public MaterijalModel materijal { get; set; }

        /// <summary>
        /// Gets or sets the napredna pretraga selektovani.
        /// </summary>
        /// <value>
        /// The napredna pretraga selektovani.
        /// </value>
        public string naprednaPretragaSelektovani { get; set; }
    }
}
﻿using ProjekatWebPortal_Core.Models;
using System.Collections.Generic;

namespace ProjekatWebPortal_Core.ViewModels
{
    /// <summary>
    /// materijal upload view model
    /// </summary>
    public class MaterijalUploadViewModel
    {
        /// <summary>
        /// Gets or sets the materijal.
        /// </summary>
        /// <value>
        /// The materijal.
        /// </value>
        public MaterijalModel Materijal { get; set; }

        public List<SkolaModel> skole { get; set; }

        public int skolaId { get; set; }

        public List<SmerModel> SmeroviPoSkolama { get; set; }

        public MaterijalProfesorModel MaterijalProfesor { get; set; }

        /// <summary>
        /// Gets or sets the predmeti.
        /// </summary>
        /// <value>
        /// The predmeti.
        /// </value>
        public IEnumerable<PredmetModel> Predmeti { get; set; }

        /// <summary>
        /// Gets or sets the tipovi materijala.
        /// </summary>
        /// <value>
        /// The tipovi materijala.
        /// </value>
        public IEnumerable<TipMaterijalModel> tipoviMaterijala { get; set; }

        /// <summary>
        /// Gets or sets the namene materijala.
        /// </summary>
        /// <value>
        /// The namene materijala.
        /// </value>
        public IEnumerable<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<SmerModel> Smerovi { get; set; }

        /// <summary>
        /// Gets or sets the predmet po smeru.
        /// </summary>
        /// <value>
        /// The predmet po smeru.
        /// </value>
        public List<PredmetModel> PredmetPoSmeru { get; set; }

        /// <summary>
        /// Gets or sets the moduli.
        /// </summary>
        /// <value>
        /// The moduli.
        /// </value>
        public IEnumerable<ModulModel> Moduli { get; set; }

        /// <summary>
        /// Gets or sets the modul po premdetu.
        /// </summary>
        /// <value>
        /// The modul po predmetu.
        /// </value>
        public List<ModulModel> ModulPoPredmetu { get; set; }

        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        public int predmetId { get; set; }

        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        public int modulId { get; set; }
    }
}
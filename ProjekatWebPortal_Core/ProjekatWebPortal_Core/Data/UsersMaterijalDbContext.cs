﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjekatWebPortal_Core.Models;
using Projekat.Models;
using System.Threading.Tasks;
using System.Linq;
using ProjekatWebPortal_Core.ViewModels;

namespace ProjekatWebPortal_Core.Data
{
    public class UsersMaterijalDbContext : IdentityDbContext<AspNetUserCustom>
    {
        public UsersMaterijalDbContext(DbContextOptions<UsersMaterijalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<SmerPoSkoli>().HasKey(table => new {
                table.skolaId,
                table.smerId
            });

            builder.Entity<PredmetPoSmeru>().HasKey(table => new {
                table.predmetId,
                table.smerId
            });

            builder.Entity<MaterijalPoModulu>().HasKey(table => new {
                table.materijalId,
                table.modulId
            });

            //builder.HasDbFunction(
            //    typeof(UsersMaterijalDbContext).GetMethod(nameof(VratiSmer), new[] { typeof(string) })).
            //    .HasTranslation(
            //        args =>
            //        {
                        
            //        }
            //    )

         
         }

        //METODE
        //public async Task<SmerModel> VratiSmer(string username) // await?
        //   => throw new NotSupportedException();

        public IQueryable<OsiromaseniMaterijali> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds, int? modulId, int namenaID)//Dodati parametre
        {
            //IMaterijalContext context = new MaterijalContext();
            // && (a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId)
            if (namenaID == 2)
            {
                IQueryable<OsiromaseniMaterijali> materijali2;

                materijali2 = from mat in this.materijali
                              where mat.namenaMaterijalaId == 2
                              select new OsiromaseniMaterijali
                              {
                                  namenaID = mat.namenaMaterijalaId,
                                  materijalId = mat.materijalId,
                                  ekstenzija = mat.materijalEkstenzija,
                                  materijalNaslov = mat.materijalNaslov,
                                  materijalOpis = mat.materijalOpis,
                                  tipMaterijalaId = mat.tipMaterijalId
                              };

                return materijali2;
            }

            var queriable = poModulu(modulId);
            queriable = poNameni(namenaID, queriable);

            Console.WriteLine(ekstenzije.Count);
            Console.WriteLine(tipoviMaterijalaIds.Count);


            //if (ekstenzije != null && tipoviMaterijalaIds != null) //////////////////////////////////////////EXCEPTION
            if (ekstenzije.Count > 0 && tipoviMaterijalaIds.Count > 0)
            {
                queriable = queriable.
                   Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

                queriable = queriable.
                    Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));

                Console.WriteLine("naprednaPretraga 1");


                return queriable;
            }
 //           else if (ekstenzije == null && tipoviMaterijalaIds != null)
            else if (ekstenzije.Count == 0 && tipoviMaterijalaIds.Count > 0)

            {
                queriable = queriable.
                Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));

                Console.WriteLine("naprednaPretraga 2");

                return queriable;
            }
            // else if (ekstenzije != null && tipoviMaterijalaIds == null)
            else if (ekstenzije.Count > 0 && tipoviMaterijalaIds.Count == 0)
            {
                queriable = queriable.
                Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

                Console.WriteLine("naprednaPretraga 3");


                return queriable;
            }
            else
            {
                Console.WriteLine("naprednaPretraga 4");

                return queriable;
            }
        }

            IQueryable<OsiromaseniMaterijali> poModulu(int? modulId) // OK
        {
            // TEST MODUL@!

            IQueryable<OsiromaseniMaterijali> materijali;

            materijali = from mat in this.materijali
                         select new OsiromaseniMaterijali
                         {
                             namenaID = mat.namenaMaterijalaId,
                             materijalId = mat.materijalId,
                             ekstenzija = mat.materijalId.ToString(), 
                             materijalNaslov = mat.materijalNaslov,
                             materijalOpis = mat.materijalOpis,
                             tipMaterijalaId = mat.tipMaterijalId
                         };

            if (modulId != null)
            {
                materijali = from mat in this.materijali
                             join matPoMod in materijalPoModulu
                             on mat.materijalId equals matPoMod.materijalId
                             where matPoMod.modulId == modulId
                             select new OsiromaseniMaterijali
                             {
                                 namenaID = mat.namenaMaterijalaId,
                                 materijalId = mat.materijalId,
                                 ekstenzija = mat.materijalEkstenzija,
                                 materijalNaslov = mat.materijalNaslov,
                                 materijalOpis = mat.materijalOpis,
                                 tipMaterijalaId = mat.tipMaterijalId,
                                 modulId = modulId
                             };
            }

            return materijali;
        }

        public IQueryable<OsiromaseniMaterijali> poNameni(int namenaID, IQueryable<OsiromaseniMaterijali> materijali)
        {
            materijali = materijali.Where(m => m.namenaID == namenaID).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaID,
                materijalId = m.materijalId,
                ekstenzija = m.ekstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalaId,
                modulId = m.modulId
            });

            return materijali;
        }

        public bool PostojiGlobalni(int? materijalId)
        {
            var globalPredmeti = this.predmeti.Where(x => x.tipId == 2).Select(x => x.predmetId).ToList();
            var globalModuli = this.moduli.Where(x => globalPredmeti.Contains((int)x.predmetId)).Select(x => x.modulId).ToList();

            List<MaterijalPoModulu> materijalPoModulus = this.materijalPoModulu.Where(x => x.materijalId == materijalId && globalModuli.Contains(x.modulId)).ToList();

            if (materijalPoModulus.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool PostojiGlobalniZahtev(int? materijalId)
        {
            var zahtevi = this.globalniZahtevi.Where(x => x.materijalId == materijalId).ToList();
            if (zahtevi.Count > 0)
            {
                return true;
            }
            return false;
        }

        // TABELE
        public DbSet<MaterijalModel> materijali { get; set; }

        public DbSet<TipMaterijalModel> tipMaterijala { get; set; }

        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        public DbSet<MaterijalPoModulu> materijalPoModulu { get; set; }

        public DbSet<ModulModel> moduli { get; set; }

        public DbSet<PredmetModel> predmeti { get; set; }

        public DbSet<TipPredmetaModel> tipPredmeta { get; set; }

        public DbSet<PredmetPoSmeru> predmetiPoSmeru { get; set; }

        public DbSet<SmerModel> Smer { get; set; }

        public DbSet<SmerPoSkoli> smeroviPoSkolama { get; set; }

        public DbSet<SkolaModel> Skola { get; set; }

        public DbSet<GlobalniZahteviModel> globalniZahtevi { get; set; }

        public DbSet<Forum_Post> Forum { get; set; }

        public DbSet<Forum_Message> Message { get; set; }

        public DbSet<MaterijalProfesorModel> Profesormaterijali { get; set; }


        
    }
}

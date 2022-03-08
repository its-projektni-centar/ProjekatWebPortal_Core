using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjekatWebPortal_Core.Models;
using Projekat.Models;

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
        }


        public DbSet<SkolaModel> Skola { get; set; }

        public DbSet<SmerModel> Smer { get; set; }

        public DbSet<SmerPoSkoli> smeroviPoSkolama { get; set; }

        public DbSet<TipMaterijalModel> tipMaterijala { get; set; }

        
        public DbSet<TipPredmetaModel> tipPredmeta { get; set; }

        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        public DbSet<PredmetModel> predmeti { get; set; }

        public DbSet<PredmetPoSmeru> predmetiPoSmeru { get; set; }

        public DbSet<GlobalniZahteviModel> globalniZahtevi { get; set; }


        public DbSet<MaterijalModel> materijali { get; set; }

        public DbSet<ModulModel> moduli { get; set; }

        public DbSet<MaterijalPoModulu> materijalPoModulu { get; set; }

        public DbSet<MaterijalProfesorModel> Profesormaterijali { get; set; }

        public DbSet<Forum_Post> Forum { get; set; }

        public DbSet<Forum_Message> Message { get; set; }



    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjekatWebPortal_Core.Models;

namespace ProjekatWebPortal_Core.Data
{
    public class UsersMaterijalDbContext : IdentityDbContext
    {
        public UsersMaterijalDbContext(DbContextOptions<UsersMaterijalDbContext> options)
            : base(options)
        {
        }


    }
}

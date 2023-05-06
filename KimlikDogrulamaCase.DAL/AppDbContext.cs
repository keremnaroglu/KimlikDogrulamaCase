using KimlikDogrulamaCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimlikDogrulamaCase.DAL
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= DESKTOP-SRVROOJ\SQLSERVER2019 ; Database= KimlikDogrulamaDb; Trusted_Connection= True;");
        }

        public DbSet<User> Users { get; set; }
    }
}

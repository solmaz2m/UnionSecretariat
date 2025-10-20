using System.Collections.Generic;
using UnionSecretariat.Models;
using Microsoft.EntityFrameworkCore;


namespace UnionSecretariat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Letter> Letters { get; set; }
        public DbSet<LettersImages> LettersImages { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }

    }
}

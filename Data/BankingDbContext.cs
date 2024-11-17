using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banking.Model;
using Microsoft.EntityFrameworkCore;

namespace banking.Data
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) //passing the value to the DbContext constructor
        {

        }

        public DbSet<BankAccount> BankAccounts { get; set; }

    }
}


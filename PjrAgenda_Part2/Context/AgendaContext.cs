using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PjrAgenda_Part2.Models;

namespace PjrAgenda_Part2.Context
{
    internal class AgendaContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Telephone> Telephones { get; set; }
    }
}

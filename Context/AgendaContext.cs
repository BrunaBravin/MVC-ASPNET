using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_ASPNET.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
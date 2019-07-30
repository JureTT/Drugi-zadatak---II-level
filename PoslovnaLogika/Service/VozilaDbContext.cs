using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    public class VozilaDbContext : DbContext
    {
        public DbSet<VoziloMarka> VoziloMarke { get; set; }
        public DbSet<VoziloModel> VoziloModeli { get; set; }
    }
}

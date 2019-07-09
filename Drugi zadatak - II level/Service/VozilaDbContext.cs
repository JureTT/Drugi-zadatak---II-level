using Drugi_zadatak___II_level.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Drugi_zadatak___II_level.Service
{
    public class VozilaDbContext:DbContext
    {
        public DbSet<VoziloMarka> VoziloMarke { get; set; }
        public DbSet<VoziloModel> VoziloModeli { get; set; }
    }
}
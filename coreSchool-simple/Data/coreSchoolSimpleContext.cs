using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace coreSchoolSimple.Models
{
    public class coreSchoolSimpleContext : DbContext
    {
        public coreSchoolSimpleContext (DbContextOptions<coreSchoolSimpleContext> options)
            : base(options)
        {
        }

        public DbSet<coreSchoolSimple.Models.Turma> Turma { get; set; }
        public DbSet<coreSchoolSimple.Models.Professor> Professor { get; set; }
        public DbSet<coreSchoolSimple.Models.Aluno> Aluno { get; set; }
    }
}

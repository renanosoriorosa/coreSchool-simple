using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Models.ViewModels
{
    public class AlunoViewModel
    {
        public Aluno Aluno { get; set; }
        public ICollection<Professor> Professores { get; set; }
        public ICollection<Turma> Turmas { get; set; }
    }
}

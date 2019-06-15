using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Curso { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma()
        {
        }

        public Turma(int id, int numero, string curso)
        {
            Id = id;
            Numero = numero;
            Curso = curso;
        }
    }
}

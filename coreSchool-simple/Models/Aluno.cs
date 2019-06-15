using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public double Nota { get; set; }

        public Turma Turma { get; set; }
        public int TurmaId { get; set; }

        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        public Aluno()
        {

        }

        public Aluno(int id, string nome, DateTime dataNasc, double nota, Turma turma, Professor professor)
        {
            Id = id;
            Nome = nome;
            DataNasc = dataNasc;
            Nota = nota;
            Turma = turma;
            Professor = professor;
        }
    }
}

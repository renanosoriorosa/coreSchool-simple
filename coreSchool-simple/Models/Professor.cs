using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Professor()
        {
        }

        public Professor(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}

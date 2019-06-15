using coreSchoolSimple.Models;
using coreSchoolSimple.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Services
{
    public class AlunosService
    {
        private readonly coreSchoolSimpleContext _context;

        public AlunosService(coreSchoolSimpleContext context)
        {
            _context = context;
        }

        // encontra todos
        public async Task<List<Aluno>> FindAllAsync()
        {
            return await _context.Aluno.ToListAsync();
        }

        // cria um novo
        public async Task InsertAsync(Aluno obj)
        {
            _context.Aluno.Add(obj);
            await _context.SaveChangesAsync();
        }

        // encontra pelo ID
        public async Task<Aluno> FindByIdAsync(int id)
        {
            return await _context.Aluno
                .Include(x => x.Turma)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = _context.Aluno.FindAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não é possivel deletar o Aluno, Aluno já está vinculado");
            }
        }

        public async Task UpdateAsync(Aluno obj)
        {
            bool hasAny = await _context.Aluno.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new BdConcurrencyException(e.Message);
            }
        }
    }
}

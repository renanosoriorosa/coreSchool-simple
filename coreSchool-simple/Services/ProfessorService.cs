using coreSchoolSimple.Models;
using coreSchoolSimple.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Services
{
    public class ProfessorService
    {
        private readonly coreSchoolSimpleContext _context;

        public ProfessorService(coreSchoolSimpleContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> FindAllAsync()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor> FindByIdAsync(int id)
        {
            return await _context.Professor.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task InsertAsync(Professor obj)
        {
            _context.Professor.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Professor.FindAsync(id);
                _context.Professor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw new IntegrityException("Não é possivel deletar o Professor, " +
                    "Professor já está vinculado");

            }
        }

        public async Task UpdateAsync(Professor obj)
        {
            bool hasAny = await _context.Professor.AnyAsync(x => x.Id == obj.Id);
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

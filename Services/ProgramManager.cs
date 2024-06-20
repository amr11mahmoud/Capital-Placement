using CapitalPlacement.DataBase;
using CapitalPlacement.Models.Programs;
using CapitalPlacement.Services.Interface;
using CapitalPlacement.Shared;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacement.Services
{
    public class ProgramManager : IProgramManager
    {
        CapitalDbContext _context;

        public ProgramManager(CapitalDbContext capitalDbContext)
        {
            _context = capitalDbContext;
        }

        public async Task<int> AddProgram(CapitalProgram program)
        {

            await _context.Programs.AddAsync(program);

            return await _context.SaveChangesAsync();
        }

        public async Task<Result<bool>> DeleteProgram(Guid id)
        {
            var getProgramResult = await GetProgram(id);

            if (getProgramResult.IsFailure)
            {
                return Result.Failure<bool>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            _context.Programs.Remove(getProgramResult.Value);
            await _context.SaveChangesAsync();
            
            return Result.Success(true);
        }

        public async Task<List<CapitalProgram>> GetAllPrograms()
        {
            var programs = await _context.Programs.ToListAsync();

            return programs;
        }

        public async Task<Result<CapitalProgram>> GetProgram(Guid id)
        {
            CapitalProgram? program = await _context.Programs.FirstOrDefaultAsync(p => p.Id == id);

            if (program == null)
            {
                return Result.Failure<CapitalProgram>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            return Result.Success(program);
        }
    }
}

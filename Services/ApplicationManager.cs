using CapitalPlacement.DataBase;
using CapitalPlacement.Models.Applications;
using CapitalPlacement.Services.Interface;
using CapitalPlacement.Shared;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacement.Services
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly CapitalDbContext _context;

        public ApplicationManager(CapitalDbContext capitalDbContext)
        {
            _context = capitalDbContext;
        }

        public async Task<int> AddApplication(Guid capitalProgramId, Application application)
        {
            application.CapitalProgramId = capitalProgramId;

            await _context.Applications.AddAsync(application);
            return await _context.SaveChangesAsync();
        }

        public async Task<Result<Application>> GetApplication(Guid id)
        {
            Application? application = await _context.Applications.FirstOrDefaultAsync(p => p.Id == id);

            if (application == null)
            {
                return Result.Failure<Application>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            return Result.Success(application);
        }

        public async Task<List<Application>> GetAllApplications(Guid capitalProgramId)
        {
            var applications = await _context.Applications
                .Where(a=> a.CapitalProgramId == capitalProgramId)
                .ToListAsync();

            return applications;
        }

        public async Task<Result<bool>> DeleteApplication(Guid id)
        {
            var getApplicationResult = await GetApplication(id);

            if (getApplicationResult.IsFailure)
            {
                return Result.Failure<bool>(Error.Errors.Applications.ApplicationNotFound());
            }

            _context.Applications.Remove(getApplicationResult.Value);
            await _context.SaveChangesAsync();

            return Result.Success(true);
        }
    }
}

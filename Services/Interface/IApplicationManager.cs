using CapitalPlacement.Models.Applications;
using CapitalPlacement.Shared;

namespace CapitalPlacement.Services.Interface
{
    public interface IApplicationManager
    {
        Task<int> AddApplication(Guid capitalProgramId, Application application);
        Task<Result<Application>> GetApplication(Guid id);
        Task<List<Application>> GetAllApplications(Guid capitalProgramId);
        Task<Result<bool>> DeleteApplication(Guid id);
    }
}

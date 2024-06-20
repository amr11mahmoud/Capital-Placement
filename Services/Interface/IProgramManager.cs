using CapitalPlacement.Models.Programs;
using CapitalPlacement.Shared;

namespace CapitalPlacement.Services.Interface
{
    public interface IProgramManager
    {
        Task<int> AddProgram(CapitalProgram program);
        Task<Result<CapitalProgram>> GetProgram(Guid id);
        Task<List<CapitalProgram>> GetAllPrograms();
        Task<Result<bool>> DeleteProgram(Guid id);
    }
}

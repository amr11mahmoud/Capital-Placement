using CapitalPlacement.Models.Programs;
using CapitalPlacement.Models.Candidates;

namespace CapitalPlacement.Models.Applications
{
    public class Application:Entity
    {
        public Guid CapitalProgramId { get; set; }
        public Candidate PersonalInformation { get; set; }
        public CapitalProgram Program { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

using CapitalPlacement.Models.Applications;
using CapitalPlacement.Models.Questions;

namespace CapitalPlacement.Models.Programs
{
    public class CapitalProgram:Entity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }

        public IEnumerable<Question> CustomQuestions { get; set; }
    }
}

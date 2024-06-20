using CapitalPlacement.Dtos.Questions;

namespace CapitalPlacement.Dtos.Programs
{
    public class ReadProgramDto:BaseProgramDto
    {
        public Guid Id { get; set; }
        public IList<ReadQuestionDto> CustomQuestions { get; set; }
    }
}

using CapitalPlacement.Dtos.Questions;

namespace CapitalPlacement.Dtos.Programs
{
    public class CreateProgramDto: BaseProgramDto
    {
        public IList<CreateQuestionDto> CustomQuestions { get; set; }
    }
}

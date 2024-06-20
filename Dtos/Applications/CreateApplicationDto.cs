namespace CapitalPlacement.Dtos.Applications
{
    public class CreateApplicationDto:BaseApplicationDto
    {
        public List<AnswerDto> Answers { get; set; }
    }
}

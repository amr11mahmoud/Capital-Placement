namespace CapitalPlacement.Dtos.Applications
{
    public class ReadApplicationDto:BaseApplicationDto
    {
        public List<AnswerDto> Answers { get; set; }
        public Guid Id { get; set; }
    }
}

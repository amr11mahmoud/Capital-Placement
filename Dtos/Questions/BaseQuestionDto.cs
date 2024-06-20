using CapitalPlacement.Enums;

namespace CapitalPlacement.Dtos.Questions
{
    public class BaseQuestionDto
    {
        public QuestionType Type { get; set; }
        public string Title { get; set; }
        public List<string>? Options { get; set; }
        public byte? MaxChoiceAllowed { get; set; }
        public bool? EnableOtherOption { get; set; }
    }
}

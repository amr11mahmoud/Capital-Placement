using CapitalPlacement.Enums;

namespace CapitalPlacement.Models.Applications
{
    public class Answer:Entity
    {
        public Guid QuestionId { get; set; }
        public string Value { get; set; }
    }
}

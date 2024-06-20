using CapitalPlacement.Enums;
using Newtonsoft.Json;

namespace CapitalPlacement.Models.Questions
{
    public class Question : Entity
    {
        public Guid CapitalProgramId { get; set; }
        public QuestionType Type { get; set; }
        public string Title { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Options { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte MaxChoiceAllowed { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool EnableOtherOption { get; set; }
    }
}

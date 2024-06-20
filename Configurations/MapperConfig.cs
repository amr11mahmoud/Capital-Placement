using AutoMapper;
using CapitalPlacement.Dtos.Applications;
using CapitalPlacement.Dtos.Programs;
using CapitalPlacement.Dtos.Questions;
using CapitalPlacement.Models.Applications;
using CapitalPlacement.Models.Candidates;
using CapitalPlacement.Models.Programs;
using CapitalPlacement.Models.Questions;

namespace CapitalPlacement.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CapitalProgram, CreateProgramDto>().ReverseMap();
            CreateMap<CapitalProgram, ReadProgramDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Question, ReadQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Application, CreateApplicationDto>().ReverseMap();
            CreateMap<Application, ReadApplicationDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using CapitalPlacement.Dtos.Programs;
using CapitalPlacement.Dtos.Questions;
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
        }
    }
}

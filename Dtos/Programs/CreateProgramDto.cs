﻿using CapitalPlacement.Dtos.Questions;

namespace CapitalPlacement.Dtos.Programs
{
    public class CreateProgramDto: BaseProgramDto
    {
        public IEnumerable<CreateQuestionDto> CustomQuestions { get; set; }
    }
}

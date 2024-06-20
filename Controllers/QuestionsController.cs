using AutoMapper;
using CapitalPlacement.Dtos.Questions;
using CapitalPlacement.Models.Questions;
using CapitalPlacement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Controllers
{
    [Route("api/Programs/{programId}/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IProgramManager _programManager;
        private readonly IMapper _mapper;

        public QuestionsController(IProgramManager programManager, IMapper mapper)
        {
            _programManager = programManager;
            _mapper = mapper;
        }

        // DELETE api/programs/<QuestionsController>/50fbb05b-c473-4f0f-309a-08dc911def49
        [HttpDelete("{questionId}")]
        public async Task<IActionResult> Delete(Guid programId, Guid questionId)
        {
            var result = await _programManager.DeleteProgramQuestion(programId, questionId);

            if (result.IsFailure)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok();
        }

        // PUT api/programs/50fbb05b-c473-4f0f-309a-08dc911def49/<QuestionsController>/50fbb05b-c473-4f0f-309a-08dc911def49
        [HttpPut("{questionId}")]
        public async Task<IActionResult> Put(Guid programId, Guid questionId, [FromBody] UpdateQuestionDto request)
        {
            var result = await _programManager.UpdateProgramQuestion(programId, _mapper.Map<Question>(request));

            if (result.IsFailure)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok();
        }
    }
}
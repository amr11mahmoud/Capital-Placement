using AutoMapper;
using CapitalPlacement.Dtos.Programs;
using CapitalPlacement.Models.Programs;
using CapitalPlacement.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CapitalPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramManager _programManager;
        private readonly IMapper _mapper;
        
        public ProgramsController(IProgramManager programManager, IMapper mapper)
        {
            _programManager = programManager;
            _mapper = mapper;
        }

        // GET: api/<ProgramsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CapitalProgram> programs = await _programManager.GetAllPrograms();

            return Ok(_mapper.Map<List<ReadProgramDto>>(programs));
        }

        // GET api/<ProgramsController>/50fbb05b-c473-4f0f-309a-08dc911def49
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _programManager.GetProgram(id);
            
            if (result.IsFailure)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok(_mapper.Map<ReadProgramDto>(result.Value));
        }

        // POST api/<ProgramsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProgramDto request)
        {
            await _programManager.AddProgram(_mapper.Map<CapitalProgram>(request));

            return Created();
        }

        // PUT api/<ProgramsController>/50fbb05b-c473-4f0f-309a-08dc911def49
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ProgramsController>/50fbb05b-c473-4f0f-309a-08dc911def49
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _programManager.DeleteProgram(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok();
        }
    }
}

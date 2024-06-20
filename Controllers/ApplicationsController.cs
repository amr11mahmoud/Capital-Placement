using AutoMapper;
using CapitalPlacement.Dtos.Applications;
using CapitalPlacement.Models.Applications;
using CapitalPlacement.Services;
using CapitalPlacement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Controllers
{
    [Route("api/Programs/{capitalProgramId}/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationManager _applicationManager;
        private readonly IMapper _mapper;
        public ApplicationsController(IApplicationManager applicationManager, IMapper mapper)
        {
            _applicationManager = applicationManager;
            _mapper = mapper;
        }

        // GET: api/<ApplicationsController>
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid capitalProgramId)
        {
            var result = await _applicationManager.GetAllApplications(capitalProgramId);

            return Ok(_mapper.Map<List<ReadApplicationDto>>(result));
        }

        // GET api/<ApplicationsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _applicationManager.GetApplication(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok(_mapper.Map<ReadApplicationDto>(result.Value));
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid capitalProgramId, [FromBody] CreateApplicationDto request)
        {
            await _applicationManager.AddApplication(capitalProgramId, _mapper.Map<Application>(request));

            return Created();
        }

        // PUT api/<ApplicationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ApplicationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _applicationManager.DeleteApplication(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok();
        }
    }
}

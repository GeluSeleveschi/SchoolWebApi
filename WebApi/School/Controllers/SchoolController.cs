using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SchoolController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetSchools()
        {
            try
            {
                var claims = User.Claims;

                var schools = _repository.School.GetAllSchools(trackChanges: false);

                var companiesDto = _mapper.Map<IEnumerable<SchoolDto>>(schools);

                return Ok(companiesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSchools)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

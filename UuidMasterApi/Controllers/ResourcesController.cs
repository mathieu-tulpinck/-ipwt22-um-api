using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UuidMasterApi;
using UuidMasterApi.Models;

namespace UuidMaster.Api.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourcesController : ControllerBase
    {
        private readonly UuidMasterApiDbContext _context;
        private readonly IMapper _mapper;

        public ResourcesController(UuidMasterApiDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResources()
        {
            var resourceEntities = await _context.Resources.ToListAsync();
            var resourceDtos = _mapper.Map<IEnumerable<ResourceDto>>(resourceEntities);
            return Ok(resourceDtos);
        }
    }
}
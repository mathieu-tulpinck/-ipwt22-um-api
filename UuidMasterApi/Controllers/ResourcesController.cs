using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UuidMasterApi.Entities;
using UuidMasterApi.Enums;
using UuidMasterApi.Models;

namespace UuidMasterApi.Controllers
{
    [ApiController]
    [Route("resources")]
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

        [HttpGet("{uuid}", Name ="GetResource")]
        public async Task<ActionResult<ResourceDto>> GetResource(Guid uuid) 
        {
            var resourceEntity = await _context.Resources.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if (resourceEntity == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ResourceDto>(resourceEntity));
        }

        [HttpGet("search")]
        public async Task<ActionResult<ResourceDto>> GetResource([Required(ErrorMessage = "source field is required.")] string source, [Required(ErrorMessage = "entityType field is required.")] string entityType, [Required(ErrorMessage = "sourceEntityId field is required.")] int sourceEntityId)
        {
            var resourceEntity = await _context.Resources
                .Where(r => r.Source == Enum.Parse<Source>(source))
                .Where(r => r.EntityType == entityType)
                .Where(r => r.SourceEntityId == sourceEntityId)
                .FirstOrDefaultAsync();
            if (resourceEntity == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ResourceDto>(resourceEntity));
        }

        [HttpPost]
        public async Task<ActionResult<ResourceDto>> CreateResource(ResourceCreateDto resourceCreateDto) 
        {
            var resourceEntity = _mapper.Map<Resource>(resourceCreateDto); // Assigns uuid to entity.
            _context.Resources.Add(resourceEntity);
            await _context.SaveChangesAsync();
            var resourceDto = _mapper.Map<ResourceDto>(resourceEntity);

            return CreatedAtRoute("GetResource",
                new {
                    uuid = resourceEntity.Uuid,
                }, 
                resourceDto
            );
        }

        [HttpPatch("{uuid}")]
        public async Task<ActionResult> PatchResource(Guid uuid, JsonPatchDocument<ResourceUpdateDto> patchDocument)
        {
            var resourceEntity = await _context.Resources.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if (resourceEntity == null) {
                return NotFound();
            }
            var resourcePatchDto = _mapper.Map<ResourceUpdateDto>(resourceEntity);

            patchDocument.ApplyTo(resourcePatchDto, ModelState);
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(resourcePatchDto)) {
                return BadRequest(ModelState);
            }

            _mapper.Map(resourcePatchDto, resourceEntity);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete action not yet implemented.
    }
}
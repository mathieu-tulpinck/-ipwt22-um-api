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
            var resourceEntities = await _context.Resources
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ResourceDto>>(resourceEntities));
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<ResourceDto>> GetResources(Guid uuid) 
        {
            var resourceEntities = await _context.Resources
                .Where(r => r.Uuid == uuid.ToString())
                .ToListAsync();
            if (!resourceEntities.Any()) {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ResourceDto>>(resourceEntities));
        }

        [HttpGet("{uuid}/{source}", Name ="GetResource")]
        public async Task<ActionResult<ResourceDto>> GetResource(Guid uuid, Source source) 
        {
            var resourceEntity = await _context.Resources
                .Where(r => r.Uuid == uuid.ToString())
                .Where(r => r.Source == source)    
                .FirstOrDefaultAsync();
            if (resourceEntity == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ResourceDto>(resourceEntity));
        }

        [HttpGet("search")]
        public async Task<ActionResult<ResourceDto>> GetResource([Required(ErrorMessage = "source field is required.")] Source source, [Required(ErrorMessage = "entityType field is required.")] EntityType entityType, [Required(ErrorMessage = "sourceEntityId field is required."), MaxLength(254)] string sourceEntityId)
        {
            var resourceEntity = await _context.Resources
                .Where(r => r.Source == source)
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
            var resourceEntityToCreate = _mapper.Map<Resource>(resourceCreateDto); // Assigns uuid to entity.
            _context.Resources.Add(resourceEntityToCreate);
            await _context.SaveChangesAsync();
            var resourceDto = _mapper.Map<ResourceDto>(resourceEntityToCreate);

            return CreatedAtRoute("GetResource",
                new {
                    uuid = resourceEntityToCreate.Uuid,
                    source = resourceEntityToCreate.Source
                }, 
                resourceDto
            );
        }

        [HttpPost("{uuid}")]
        public async Task<ActionResult<ResourceDto>> CreateResource(Guid uuid, ResourceCreateDto resourceCreateDto) 
        {
            var resourceEntities = await _context.Resources
                .Where(r => r.Uuid == uuid.ToString())
                .ToListAsync();
            if (!resourceEntities.Any()) {
                return NotFound();
            }

            var resourceCreateDtoWithUuid = new ResourceCreateDtoWithUuid(uuid, resourceCreateDto);
            var resourceEntityToCreate = _mapper.Map<Resource>(resourceCreateDtoWithUuid);
            _context.Resources.Add(resourceEntityToCreate);
            await _context.SaveChangesAsync();
            var resourceDto = _mapper.Map<ResourceDto>(resourceEntityToCreate);

            return CreatedAtRoute("GetResource",
                new {
                    uuid = resourceEntityToCreate.Uuid,
                    source = resourceEntityToCreate.Source
                }, 
                resourceDto
            );
        }

        [HttpPatch("{uuid}/{source}")]
        public async Task<ActionResult> PatchResource(Guid uuid, Source source, JsonPatchDocument<ResourceUpdateDto> patchDocument)
        {
            var resourceEntity = await _context.Resources
                .Where(r => r.Uuid == uuid.ToString())
                .Where(r => r.Source == source)
                .FirstOrDefaultAsync();
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

//         // Delete action not yet implemented.
    }
}
using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID(Guid id)
        {
            var walk = await _walkRepository.GetByID(id);

            if (walk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDTO>(walk));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            var walkDomain = await _walkRepository.Create(_mapper.Map<Walk>(addWalkRequestDTO));

            if (walkDomain == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByID), new { id = walkDomain.Id }, _mapper.Map<WalkDTO>(walkDomain));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            return Ok(_mapper.Map<List<WalkDTO>>(await _walkRepository.GetAll(
                filterOn, filterQuery, // Filter
                sortBy, isAscending ?? true, // Sort
                pageNumber, pageSize))); // Pagination
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {            
            var walkDomain = _mapper.Map<Walk>(updateWalkRequestDTO);

            walkDomain = await _walkRepository.Update(id, walkDomain);

            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDTO>(walkDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.Delete(id);
            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDTO>(walkDomain));
        }

    }
}

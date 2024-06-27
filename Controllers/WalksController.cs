using AutoMapper;
using FirstRestfulAPI.CustomActionFilter;
using FirstRestfulAPI.Model.Domain;
using FirstRestfulAPI.Model.DTO;
using FirstRestfulAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace FirstRestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
            //map this dto to domain model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //map domain model to dto
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
           
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 1000)
        {
          var walksDomainModel = await walkRepository.GetAsync(filterOn, filterQuery, sortBy, isAscending ?? true, PageNumber, PageSize);
            
          return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));    
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.GetByIDAsync(id);

            if(walksDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walksDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
      
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                if(walkDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<Walk>(walkDomainModel));
         
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));

        }
    
    }
}

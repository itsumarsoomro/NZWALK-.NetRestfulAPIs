using AutoMapper;
using FirstRestfulAPI.CustomActionFilter;
using FirstRestfulAPI.Data;
using FirstRestfulAPI.Model.Domain;
using FirstRestfulAPI.Model.DTO;
using FirstRestfulAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FirstRestfulAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase 
    {
        // It's part of the Entity Framework Core, which is an ORM (Object-Relational Mapper) for interacting with the database.
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        //db context constructor injection - ctor short form for contructor
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepositor, 
            IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepositor;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{code}")]
        [Authorize(Roles = "Reader")]
        public IActionResult GetRegionByCode([FromRoute] string code)
        {
            //find method only works with Primary key
            // var region =  dbContext.Regions.Find(id);

            var region = dbContext.Regions.FirstOrDefault(y => y.Code == code);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        [HttpGet]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> GetALLTEST2()
        {
           
            

               // logger.LogInformation("Get All Region Action Method Was Invoked");

                var regions = await regionRepository.GetAllAsync();
                

                //mapping domain models to dto
                var regionsDto = mapper.Map<List<RegionDto>>(regions);

                 //logger.LogInformation($"Get All Region Action request Was Finished with data: {JsonSerializer.Serialize(regions)}");

                //throw new Exception("This is a custom exception");

                return Ok(regionsDto);
         
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionByID([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetRegionByID(id);

            var regionDto = mapper.Map<RegionDto>(regionDomain);


            if (regionDomain != null)
            {
                return Ok(regionDto);
            }

            return BadRequest("Not Found");
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> PostALLTEST2([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                //map or convert dto to domain model
                var regionDomain = mapper.Map<Region>(addRegionRequestDto);

                regionDomain = await regionRepository.PostALLTEST2(regionDomain);

                //map model back to dto
                var regionsDto = mapper.Map<RegionDto>(regionDomain);


                return CreatedAtAction(nameof(GetRegionByID), new { id = regionsDto.id }, regionsDto);
                // return CreatedAtAction(nameof(GetRegionByID), new { id = regionsDto.id }, RegionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // Update the region // PUT HTTP verb / id
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
                //map dto to comain modal
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                // Retrieve the region by ID
                regionDomainModel = await regionRepository.Update(id, regionDomainModel);

                // Check if the region exists
                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                // Convert domain model to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                // Return the updated region
                return Ok(regionDto);
          
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {

            var regionDomain = await regionRepository.DeleteRegionByID(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
    }
}

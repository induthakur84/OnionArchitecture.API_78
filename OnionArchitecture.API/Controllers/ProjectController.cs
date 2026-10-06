using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Data.Services.IServices;
using OnionArchitecture.DTO;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult>Create(ProjectCreateDto projectCreateDto)
        {
            var result= await _projectService.Create(projectCreateDto); 
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var result= await _projectService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var result= await _projectService.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProjectUpdateDto projectUpdateDto)
        {
            var result= await _projectService.Update(projectUpdateDto);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result=await _projectService.Delete(Id);
            return Ok(result);
        }
    }
}

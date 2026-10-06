using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Data.Services.IServices;
using OnionArchitecture.Domain;
using OnionArchitecture.DTO;

namespace OnionArchitecture.Data.Services
{

    //Encapsulation
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProjectService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ProjectResponseDto> Create(ProjectCreateDto projectCreateDto)
        {

            //projectcreate dto to project
            var project = new Project
            {
                Name = projectCreateDto.Name,
                Description = projectCreateDto.Description,
                Author = projectCreateDto.Author,
            };
            _applicationDbContext.Add(project);

            await _applicationDbContext.SaveChangesAsync();


            //Product domain to pronjectresponsedto

            return new ProjectResponseDto
            {
                Description = project.Description,
                Author = project.Author,
            };
        }

        public async Task<bool> Delete(int id)
        {
            var project =await _applicationDbContext.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }

            _applicationDbContext.Projects.Remove(project);

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjectResponseDto>> GetAll()
        {
            return await _applicationDbContext.Projects.Select(p=> new ProjectResponseDto
            { 
                Description= p.Description,
                Author = p.Author,
            }).ToListAsync();  
        }

        public async Task<ProjectResponseDto> GetById(int id)
        {
            var project = await _applicationDbContext.Projects.FindAsync(id);
            if(project == null)
            {
                return null;
            }

            return new ProjectResponseDto
            {
                Description = project.Description,
                Author = project.Author,
            };
        }

        public async Task<ProjectResponseDto> Update(ProjectUpdateDto projectUpdateDto)
        {
           var project= await _applicationDbContext.Projects.FindAsync(projectUpdateDto.Id);
            if (project == null)
            {
                return null;
            }
            project.Name = projectUpdateDto.Name;
            project.Description = projectUpdateDto.Description;
            project.Author = projectUpdateDto.Author;

            await _applicationDbContext.SaveChangesAsync();

            return new ProjectResponseDto
            {
                Description = projectUpdateDto.Description,
                Author = projectUpdateDto.Author,
            };
        }
    }
}

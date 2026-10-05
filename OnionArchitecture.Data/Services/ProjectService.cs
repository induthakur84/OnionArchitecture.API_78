using OnionArchitecture.Data.Services.IServices;
using OnionArchitecture.DTO;

namespace OnionArchitecture.Data.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _applicationDbContext;
         
        public ProjectService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<ProjectResponseDto> Create(ProjectCreateDto projectCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectResponseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectResponseDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectResponseDto> Update(ProjectUpdateDto projectUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}

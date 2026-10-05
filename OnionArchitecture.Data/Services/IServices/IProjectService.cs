using OnionArchitecture.DTO;

namespace OnionArchitecture.Data.Services.IServices
{
    public  interface IProjectService
    {
        Task<ProjectResponseDto>Create(ProjectCreateDto projectCreateDto);
        Task<ProjectResponseDto> Update(ProjectUpdateDto projectUpdateDto);

        Task<List<ProjectResponseDto>> GetAll();

        Task<bool> Delete(int id);

        Task<ProjectResponseDto> GetById(int id);
    }
}

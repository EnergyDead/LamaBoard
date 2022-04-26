using Application.Mappings;
using Domain.Entities;

namespace Application.Dto;

public class ProjectDto : IMapFrom<Domain.Entities.Projects>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<BoardBriefDto> BoardBriefDtos { get; } = new();
    public Users Creater { get; set; }
}

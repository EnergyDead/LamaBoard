using Application.Mappings;

namespace Application.Projects.Queries;

public class ProjectBriefDto : IMapFrom<Domain.Entities.Projects>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

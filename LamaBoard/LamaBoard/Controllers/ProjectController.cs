using Application.Boards.Queries.GetTasks;
using Application.Models;
using Application.Projects.Commands;
using Application.Projects.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LamaBoard.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class ProjectController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProjectBriefDto>>> GetProjectsWithPagination( [FromQuery] GetProjectsWithPaginationQuery query )
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProjectCommand command)
    {
        return await Mediator.Send( command );
    }

    [HttpGet( "{id}" )]
    public string Get( int id )
    {
        return "value";
    }

    // POST api/<ProjectController>
    [HttpPost]
    public void Post( [FromBody] string value )
    {
    }

    // PUT api/<ProjectController>/5
    [HttpPut( "{id}" )]
    public void Put( int id, [FromBody] string value )
    {
    }

    // DELETE api/<ProjectController>/5
    [HttpDelete( "{id}" )]
    public void Delete( int id )
    {
    }
}

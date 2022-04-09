using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LamaBoard.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class ProjectController
{
    [HttpGet]
    public async Task<ActionResult<ProjectBriefDto>> GetProjectsWithPagination()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(ProjectDto command)
    {
        throw new NotImplementedException();
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

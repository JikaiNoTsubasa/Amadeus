using System;
using System.Net;
using amadeus_api.job_managers;
using amadeus_api.job_models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amadeus_api.job_controllers;

[Authorize]
public class ProjectController(ProjectManager manager) : AmaController
{
    protected ProjectManager _manager = manager;

    [HttpGet]
    [Route("api/projects")]
    public IActionResult GetAllProjects()
    {
        var projects = _manager.FetchAllProjects().Select(p => p.ToDTO()).ToList();
        return StatusCode(200, projects);
    }

    [HttpGet]
    [Route("api/me/projects")]
    public IActionResult GetMyProjects()
    {
        var projects = _manager.FetchMyProjects(_loggedUserId).Select(p => p.ToDTO()).ToList();
        return StatusCode(200, projects);
    }

    [HttpPost]
    [Route("api/projects")]
    public IActionResult CreateProject([FromBody] RequestCreateProject model)
    {
        var project = _manager.CreateProject(model.Name, model.OwnerId ?? _loggedUserId, _loggedUserId, model.CustomerId, model.Description).ToDTO();
        return StatusCode(201, project);
    }

    [HttpDelete]
    [Route("api/projects/{projectId:long}")]
    public IActionResult DeleteProject([FromRoute] long projectId)
    {
        _manager.DeleteProject(projectId, _loggedUserId);
        return StatusCode(HttpStatusCode.NoContent.GetHashCode());
    }

    [HttpPost]
    [Route("api/projects/{id:long}/phases")]
    public IActionResult CreateProjectPhase([FromRoute] long id, [FromBody] RequestCreateProjectPhase model)
    {
        var phase = _manager.CreateProjectPhase(id, model.Name, _loggedUserId).ToDTO();
        return StatusCode(201, phase);
    }
}

using System;
using amadeus_api.database;
using amadeus_api.database.models;
using log4net;
using Microsoft.EntityFrameworkCore;

namespace amadeus_api.job_managers;

public class ProjectManager(AmaContext context) : AmaManager(context)
{
    private static readonly ILog log = LogManager.GetLogger(typeof(ProjectManager));

    public List<Project> FetchAllProjects()
    {
        return [.. _context.Projects.Include(p => p.Owner).Include(p => p.Customer)];
    }

    public List<Project> FetchMyProjects(long userId)
    {
        return [.. _context.Projects.Include(p => p.Owner).Include(p => p.Customer).Where(p => p.OwnerId == userId)];
    }

    public Project CreateProject(string name, long ownerId, long loggedUserId, long? customerId = null, string? description = null)
    {
        log.Info($"Creating new project: Name={name}, OwnerId={ownerId}, CustomerId={customerId}");
        // fetch owner to ensure it exists
        var owner = _context.Users.Find(ownerId) ?? throw new Exception($"Owner with ID {ownerId} does not exist.");
        var project = new Project
        {
            Name = name,
            Owner = owner,
            CustomerId = customerId,
            Description = description
        };
        project.MarkCreated(loggedUserId);

        _context.Projects.Add(project);
        _context.SaveChanges();
        log.Info($"Project created successfully with ID: {project.Id}");

        return project;
    }

    public void DeleteProject(long projectId, long loggedUserId)
    {
        log.Info($"Deleting project with ID: {projectId}");
        var project = _context.Projects.Find(projectId) ?? throw new Exception($"Project with ID {projectId} does not exist.");
        project.MarkDeleted(loggedUserId);
        _context.SaveChanges();
        log.Info($"Project with ID: {projectId} deleted successfully.");
    }
}

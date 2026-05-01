using System;
using amadeus_api.database.models;

namespace amadeus_api.job_models;

public static class DTOHelper
{
    #region Project
    public static ResponseProject ToDTO(this Project model)
    {
        var prj = new ResponseProject
        {
            Status = model.Status,
            Code = model.Code,
            Description = model.Description,
            Summary = model.Summary,
            Owner = model.Owner.ToDTOEmbedded(),
            Customer = model.Customer?.ToDTOEmbedded(),
            PhasesCount = model.Phases?.Count,
            TasksCount = model.Tasks?.Count
        };
        prj.FeedEntityInfo(model);
        return prj;
    }
    #endregion

    #region Phase
    public static ResponseProjectPhase ToDTO(this ProjectPhase model)
    {
        var phase = new ResponseProjectPhase();
        phase.FeedEntityInfo(model);
        return phase;
    }
    #endregion

    #region User
    public static ResponseUserEmbedded ToDTOEmbedded(this User model)
    {
        return new ResponseUserEmbedded
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
            Avatar = model.Avatar
        };
    }
    #endregion

    #region Customer
    public static ResponseCustomerEmbedded ToDTOEmbedded(this Customer model)
    {
        return new ResponseCustomerEmbedded
        {
            Description = model.Description,
            ContactName = model.ContactName,
            ContactPhone = model.ContactPhone,
            ContactEmail = model.ContactEmail
        };
    }
    #endregion

    #region TodoTask
    public static ResponseTodoTask ToDTO(this TodoTask model)
    {
        var todo = new ResponseTodoTask
        {
            Description = model.Description,
            DueDate = model.DueDate,
            Status = model.Status
        };
        todo.FeedEntityInfo(model);
        return todo;
    }
    #endregion
}
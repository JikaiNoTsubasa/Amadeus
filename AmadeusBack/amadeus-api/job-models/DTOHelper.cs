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
            Description = model.Description,
            Owner = model.Owner.ToDTOEmbedded(),
            Customer = model.Customer?.ToDTOEmbedded()
        };
        prj.FeedEntityInfo(model);
        return prj;
    }
    #endregion

    #region User
    public static ResponseUserEmbedded ToDTOEmbedded(this User model)
    {
        return new ResponseUserEmbedded
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email
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
}
using System;
using amadeus_api.database;

namespace amadeus_api.job_managers;

public class AmaManager (AmaContext dbContext)
{
    protected AmaContext _context = dbContext;
}

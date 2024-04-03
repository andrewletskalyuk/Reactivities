using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //api/Activities
        public async Task<ActionResult<IReadOnlyCollection<Activity>>> GetActitities()
        {
            return await _context.Activities.ToArrayAsync();    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityAsync(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}
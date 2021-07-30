using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.DTOs;
using back_end.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        
        public ActorController(ApplicationDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        [HttpGet]         
        public async Task<ActionResult<List<ActorDTO>>> All()
        {
            // var qry = this.repository.AllGenres();
             var actors = await context.Actors.ToListAsync();
             if (actors == null) {
                return NotFound();
            }
            var result= mapper.Map<List<ActorDTO>>(actors);
            return result;
        }
    }
}
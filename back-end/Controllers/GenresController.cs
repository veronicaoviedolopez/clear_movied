using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.DTOs;
using back_end.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        
        public GenresController(ApplicationDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        [HttpGet]         
        public async Task<ActionResult<List<GenreDTO>>> All()
        {
            // var qry = this.repository.AllGenres();
             var genres = await context.Genres.ToListAsync();
             if (genres == null) {
                return NotFound();
            }
            var result= mapper.Map<List<GenreDTO>>(genres);
            return result;
        }
    }
}
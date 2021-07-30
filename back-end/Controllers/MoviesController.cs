using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Utilities;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context,
            IMapper _mapper)
        {
            this.context = context;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> Get()
        {
            var res = await this.context.Movies
                        .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
                        .Include(x => x.MoviesActors).ThenInclude(x => x.Actor).ToListAsync();
            var result= this.mapper.Map<List<MovieDTO>>(res);
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var pelicula = await context.Movies
                .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MoviesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula == null) { return NotFound(); }

            var dto = mapper.Map<MovieDTO>(pelicula);
            dto.Actors = dto.Actors.OrderBy(x => x.Name).ToList();
            return dto;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<MovieDTO>>> Filter([FromQuery] MovieFilterDTO moviefilterDTO)
        {
            var moviesQueryable = context.Movies.AsQueryable();
            

            if (!string.IsNullOrEmpty(moviefilterDTO.Title))
            {
                moviesQueryable = moviesQueryable.Where(x => x.Title.Contains(moviefilterDTO.Title));
            }

             if (moviefilterDTO.ActorId != 0)
            {
                moviesQueryable = moviesQueryable
                    .Where(x => x.MoviesActors.Select(y => y.ActorId)
                    .Contains(moviefilterDTO.ActorId));
            }

            if (moviefilterDTO.GenreId != 0)
            {
                moviesQueryable = moviesQueryable
                    .Where(x => x.MoviesGenres.Select(y => y.GenreId)
                    .Contains(moviefilterDTO.GenreId));
            }

            await HttpContext.InsertarParametrosPaginacionEnCabecera(moviesQueryable);

            var peliculas = await moviesQueryable                   
            .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
            .Include(x => x.MoviesActors).ThenInclude(x => x.Actor).ToListAsync();
            return mapper.Map<List<MovieDTO>>(peliculas);
        }
    }
}
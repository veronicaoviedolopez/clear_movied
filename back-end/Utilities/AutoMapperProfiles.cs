using System.Collections.Generic;
using back_end.Controllers.Entities;
using back_end.DTOs;
using NetTopologySuite.Geometries;

namespace back_end.Utilities
{
    public class AutoMapperProfiles: AutoMapper.Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<Actor, ActorDTO>();
            CreateMap<Movie, MovieDTO>()
              .ForMember(x => x.Genres, options => options.MapFrom(MapearPeliculasGeneros))
                .ForMember(x => x.Actors, options => options.MapFrom(MapearPeliculasActores));
        }

        private List<MovieActorDTO> MapearPeliculasActores(Movie movie, MovieDTO movieDTO)
        {
            var resultado = new List<MovieActorDTO>();

            if (movie.MoviesActors != null)
            {
                foreach (var x in movie.MoviesActors)
                {
                    resultado.Add(new MovieActorDTO()
                    {
                        Id = x.ActorId,
                        Name = x.Actor.Name,
                        Photo = x.Actor.Photo,
                        Character = x.Character
                    });
                }
            }

            return resultado;
        }

        private List<GenreDTO> MapearPeliculasGeneros(Movie movie, MovieDTO movieDTO)
        {
            var resultado = new List<GenreDTO>();

            if (movie.MoviesGenres != null)
            {
                foreach (var genero in movie.MoviesGenres)
                {
                    resultado.Add(new GenreDTO() { Id = genero.GenreId, Name = genero.Genre.Name });
                }
            }

            return resultado;
        }

    }
}
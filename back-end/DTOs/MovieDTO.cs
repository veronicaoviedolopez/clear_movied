using System;
using System.Collections.Generic;


namespace back_end.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Trailer { get; set; }
        public bool inCinema { get; set; }
        public System.DateTime releaseDate { get; set; }
        public string Poster { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<MovieActorDTO> Actors { get; set; }
    }
}
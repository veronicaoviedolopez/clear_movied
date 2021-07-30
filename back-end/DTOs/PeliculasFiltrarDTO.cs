using back_end.DTOs;

namespace back_end.Controllers
{
 public class MovieFilterDTO
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int ActorId { get; set; }
    }}
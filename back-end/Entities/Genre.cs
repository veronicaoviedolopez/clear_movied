using System.ComponentModel.DataAnnotations;
namespace back_end.Controllers.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Property '{0}' is required")]
        [StringLength(50)]
        public string Name { get; set;}
    }
}
using System.ComponentModel.DataAnnotations;
namespace back_end.Controllers.Entities

{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } 
        public string Biography { get; set; }
        public string Photo { get; set; }
    }
}
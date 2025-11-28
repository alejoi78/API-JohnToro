using System.ComponentModel.DataAnnotations;

namespace API_JohnToro.DAL.Models
{
    public class Movie:AuditBase
    {
        [Required]
        [Display(Name = "Nombre de la pelicula")]
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Clasification { get; set; }
    }
}

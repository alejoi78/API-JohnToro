using System.ComponentModel.DataAnnotations;

namespace API_JohnToro.DAL.Models.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        public int Duration { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "La clasificacion de la pelicula es obligatoria.")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres es de 10.")]
        public string Clasification { get; set; }
    }
}

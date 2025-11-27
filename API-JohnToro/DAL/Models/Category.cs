using System.ComponentModel.DataAnnotations;

namespace API_JohnToro.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]
        [Display(Name="Nombre de la categoria")]
        public string Name { get; set; }
    }
}

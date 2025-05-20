using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_TallerAPI.DAL.ENTITIES
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] // para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "el campo {0} debe tener máximo {1} caracteres.")] // longitud
        [Required(ErrorMessage = "Este campo es obligatorio.")] // campo requerido
        public string Name { get; set; }

    }
}

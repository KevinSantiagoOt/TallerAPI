using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_TallerAPI.DAL.ENTITIES
{
    public class AuditBase
    {
        [Key] //PK
        [Required] // Este campo es obligatorio
        public virtual Guid Id { get; set; } // PK de todas las tablas

        public virtual DateTime? CreatedDate { get; set; } // guardar todo registro nuevo con su fecha

        public virtual DateTime? ModifiedDate { get; set; } // guardar todo registro que se modifico con su fecha
    }
}

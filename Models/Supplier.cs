using System.ComponentModel.DataAnnotations;

namespace Proyecto1_web.Models
{
    public class Supplier
    {
        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Digite su cédula jurídica")]
        public string Legal_Doc { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Digite la descripción")]
        public string Supplier_Description { get; set; }
    }
}

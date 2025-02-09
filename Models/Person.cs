using System.ComponentModel.DataAnnotations;

namespace Proyecto1_web.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Digite el dato requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$", ErrorMessage = "Formato requerido 0#-####-####")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Digite su nombre y apellidos")]
        public string Name { get; set; }



        [RegularExpression("^\\d{4}$", ErrorMessage = "Ingrese solo su año de nacimiento")]
        [Range(minimum: 1900, maximum: 2003, ErrorMessage = "Debe ser mayor de edad y estar vivo")]
        public int Year_Age { get; set; }




        [Required(ErrorMessage = "Digite el dato requerido")]
        [RegularExpression("^(\\d{4}-\\d{4})$", ErrorMessage = "Formato requerido ####-####")]
        public string Phone { get; set; }




        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Digite su profesión")]
        public string Profession { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        //[RegularExpression("^[^@]+@[^@]+.[a-zA-z][2,4]$", ErrorMessage = "Ingrese un correo válido")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Ingrese un correo válido")]
        
        public string email { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Combo_Recom { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Digite su contrase")]
        public string Password { get; set; }


        public string Rol { get; set; }


    }
}

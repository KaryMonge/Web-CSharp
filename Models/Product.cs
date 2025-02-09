using System.ComponentModel.DataAnnotations;

namespace Proyecto1_web.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Product_Id { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Digite su profesión")]
        public string Product_Descrition { get; set; }



        [RegularExpression("^d{4}$", ErrorMessage = "Ingrese solo el año de ingreso")]
        [Required(ErrorMessage = "Digite el dato requerido")]
        [Range(minimum: 1900, maximum: 2022, ErrorMessage = "Ingrese un dato válido")]
        public int Year_in { get; set; }

        


        [Required(ErrorMessage = "Digite el dato requerido")]
        [Range(0, 1000, ErrorMessage = "Precio 0 > 10 000 000")]
        public float Price { get; set; }


        [Required(ErrorMessage = "Digite el dato requerido")]
        [Range(0, 100, ErrorMessage = "Porcentaje de 0 a 100")]
        public int Utility { get; set; }


    }
}

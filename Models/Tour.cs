using System.ComponentModel.DataAnnotations;

namespace Proyecto1_web.Models
{
    public class Tour
    {




        //[Required(ErrorMessage = "Digite el dato requerido")]
        //[StringLength(15, MinimumLength = 10, ErrorMessage = "Digite la ID del tour")]
        public string Tour_Id { get; set; }


        




        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Digite la descripción")]
        public string Tour_Description { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Tour_Image { get; set; }





        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Week_list { get; set; }


    }
}

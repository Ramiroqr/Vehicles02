using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles02.API.Data.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        public string Descripcion { get; set; }
    }
}

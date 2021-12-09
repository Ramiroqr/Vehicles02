using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicles02.API.Data.Entities;

namespace Vehicles02.API.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Vehiculo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de Vehiculo.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int VehicleTypeId { get; set; }

        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una marca.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int BrandId { get; set; }

        public IEnumerable<SelectListItem> BrandTypes { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1900, 3000, ErrorMessage = "Valor de modelo no valido")]
        public int Model { get; set; }

        [Display(Name = "Placa")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de plaza incorrecto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener {1}caracteres.")]
        public string Plaque { get; set; }

        [Display(Name = "Linea")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Line { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Color { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }

        public ICollection<VehiclePhoto> VehiclePhotos { get; set; }

    }
}

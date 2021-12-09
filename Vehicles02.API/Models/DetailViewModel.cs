using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicles02.API.Data.Entities;

namespace Vehicles02.API.Models
{
    public class DetailViewModel 
    {
        public int Id { get; set; }

        [Display(Name = "Precio mano de obra")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal LaborPrice { get; set; }

        [Display(Name = "Precio de repuestos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal SparePartsPrice { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public int HistoryId { get; set; }

        [Display(Name = "Procedimiento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes Seleccionar un procedimiento.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ProcedureId { get; set; }

        public IEnumerable<SelectListItem> Procedures { get; set; }
    }
}

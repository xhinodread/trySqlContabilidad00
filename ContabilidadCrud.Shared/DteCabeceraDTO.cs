using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContabilidadCrud.Shared
{
	public class DteCabeceraDTO
	{
		public long IdDteCabecera { get; set; }

		[Required]
		[Range(1, long.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
		public int IdTipoDte { get; set; }

		[Required]
		[Range(1, long.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
		public long IdEmpresa { get; set; }

		[Required]
		[Range(1, long.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
		public long Folio { get; set; }
		public DateTime FechaEmision { get; set; }

	}
}

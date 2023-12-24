namespace trySqlContabilidad00.Models
{
	public partial class DteCabecera
	{

		public long IdDteCabecera { get; set; }
		public int IdTipoDte { get; set; }
		public long IdEmpresa { get; set; }
		public long Folio { get; set; }
		public DateTime FechaEmision { get; set; }

		
	}
}

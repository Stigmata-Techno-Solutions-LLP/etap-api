using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class ComponentDetails
	{
		public int Id { get; set; }
		public int? ProjectStructureId { get; set; }
		public string CompId { get; set; }
		public int? CompTypeId { get; set; }
		public string DrawingNo { get; set; }
		public int? ComponentNo { get; set; }
		public bool? IsGroup { get; set; }
		public decimal? Leng { get; set; }
		public decimal? Breath { get; set; }
		public decimal? Height { get; set; }
		public decimal? Thickness { get; set; }
		public decimal? Width { get; set; }
		public string MakeType { get; set; }
		public bool? IsTag { get; set; }
		public string QrCode { get; set; }
		public bool? IsDelete { get; set; }
		public bool? IsActive { get; set; }
		public string CompStatus { get; set; }
	}
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
namespace ETapManagement.ViewModel.Dto
{

	public class AddSurplus
	{
		public int SiteReqId { get; set; }
		public int StructureId { get; set; }		
		public DateTime SurplusDate { get; set; }		

	}
	public class SurplusDetails
	{
		public int Id{get;set;}
		public int SiteReqId { get; set; }
		public string isAction { get; set; }
		public string StructureTypeName { get; set; }

		public int StructureId { get; set; }
		public string StructureName { get; set; }
		
		public DateTime SurplusDate { get; set; }

		public string Status { get; set; }

		public string StatusInternal { get; set; }

	}

	  public class SiteDeclarationDetailsPayload {
        public commonEnum.Rolename role_name { get; set; }
        public int? role_hierarchy { get; set; }

    }

    public class WorkFlowSurplusDeclPayload {
        [Required]
        public int decl_id {get;set;}
        [Required]
        public commonEnum.WorkFlowMode mode { get; set; }
        
        public commonEnum.Rolename role_name { get; set; }
        public string role_hierarchy { get; set; }

    }
}
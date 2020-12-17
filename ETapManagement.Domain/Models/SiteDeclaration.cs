﻿using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteDeclaration
    {
        public SiteDeclaration()
        {
            SitedeclStatusHistory = new HashSet<SitedeclStatusHistory>();
        }

        public int Id { get; set; }
        public int? SitereqId { get; set; }
        public int? StructId { get; set; }
        public DateTime SurplusFromdate { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Notes { get; set; }
        public int? RoleId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public virtual SiteRequirement Sitereq { get; set; }
        public virtual Structures Struct { get; set; }
        public virtual ICollection<SitedeclStatusHistory> SitedeclStatusHistory { get; set; }
    }
}
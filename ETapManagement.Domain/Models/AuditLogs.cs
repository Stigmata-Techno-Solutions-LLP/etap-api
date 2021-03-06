﻿using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class AuditLogs
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

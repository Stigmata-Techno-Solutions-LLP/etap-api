using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class Users {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? IcId { get; set; }
        public int? BuId { get; set; }
        public string PsNo { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual BusinessUnit Bu { get; set; }
        public virtual IndependentCompany Ic { get; set; }
        public virtual Project Project { get; set; }
        public virtual Roles Role { get; set; }
    }
}
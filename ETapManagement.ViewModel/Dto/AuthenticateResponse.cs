using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ETapManagement.ViewModel.Dto {
    public class AuthenticateResponse {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
                public int? VendorId { get; set; }

        public string RoleName { get; set; }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int ProjectId {get;set;}
        public int IndependentCompanyId {get;set;}
        public int BusinessUnitId {get;set;}
        public string ProjectCode {get;set;}
        public string ProjectName {get;set;}

    }

    public class RefreshToken {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }

    public class RefreshResponse {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
        public bool IsAPIValid { get; set; }
    }
}
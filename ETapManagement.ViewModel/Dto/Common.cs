using System;
namespace ETapManagement.ViewModel.Dto {
    public class ResponseMessage {
        public string Message { get; set; }
    }

    public class ResponseMessageForgotPassword {
        public string Message { get; set; }
        public bool IsValid { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
    }
}
﻿namespace PhoneBook.API.EndPoints.UserEndPoints
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string? Message { get; set; }
    }
}

namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class GetContactDetailsResponse
    {
        public System.Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}

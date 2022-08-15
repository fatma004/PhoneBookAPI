namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class CreateContactRequest
    {
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}

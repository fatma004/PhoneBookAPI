using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhoneBook.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserId { get; set; }

        [JsonIgnore, ForeignKey("UserId")]
        public SeUser User { get; set; }
    }
}

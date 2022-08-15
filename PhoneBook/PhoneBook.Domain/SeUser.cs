using Microsoft.AspNetCore.Identity;

namespace PhoneBook.Domain
{
    public class SeUser : IdentityUser
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public virtual ICollection<Contact>? Contacts { get; set; }

    }
}

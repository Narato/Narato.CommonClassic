using System.ComponentModel.DataAnnotations;

namespace Narato.Common.Tests.Stubs
{
    public class Contact
    {
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [StringLength(256)]
        public string EmailAddress { get; set; }
        [Range(0, 20)]
        public int PreferedNumber { get; set; }
    }
}

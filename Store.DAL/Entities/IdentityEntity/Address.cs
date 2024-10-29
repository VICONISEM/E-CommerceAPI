using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities.IdentityEntity
{
    public class Address
    {
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public int AppUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
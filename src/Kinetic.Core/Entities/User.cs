using Microsoft.AspNetCore.Identity;

namespace Kinetic.Core.Entities
{
    public class User {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string IdentityId { get; set; }

        public ICollection<Space.Space> Spaces { get; } = new List<Space.Space>();
        public ICollection<Space.SpaceUser> SpaceUsers { get; } = new List<Space.SpaceUser>();
    }
}

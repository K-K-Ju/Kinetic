namespace Kinetic.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ViewName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        
        public ICollection<Space.Space> Spaces { get; } = new List<Space.Space>();
    }
}

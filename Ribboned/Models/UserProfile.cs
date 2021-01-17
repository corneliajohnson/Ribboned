namespace Ribboned.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName {get; set;}
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string FirebaseUserId { get; set; }
    }
}

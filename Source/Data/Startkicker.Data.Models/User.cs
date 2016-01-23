namespace PayItForward.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    public class User : IdentityUser
    {
        private ICollection<Donation> donations;

        private ICollection<Story> stories;

        private ICollection<Comment> comments;

        public User()
        {
            this.donations = new HashSet<Donation>();
            this.stories = new HashSet<Story>();
            this.comments = new HashSet<Comment>();
        }

        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Range(0, int.MaxValue)]
        [Column(TypeName = "Money")]
        public int AvailableMoneyAmount { get; set; }

        public virtual ICollection<Story> Stories
        {
            get
            {
                return this.stories;
            }

            set
            {
                this.stories = value;
            }
        }

        public virtual ICollection<Donation> Donations
        {
            get
            {
                return this.donations;
            }

            set
            {
                this.donations = value;
            }
        }
        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}

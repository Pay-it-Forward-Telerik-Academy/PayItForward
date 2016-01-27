namespace PayItForward.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using PayItForward.Data.Models;

    public class PayItForwardDbContext : IdentityDbContext<User>, IPayItForwardDbContext
    {
        public PayItForwardDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Story> Stories { get; set; }

        public virtual IDbSet<Donation> Donations { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static PayItForwardDbContext Create()
        {
            return new PayItForwardDbContext();
        }
    }
}

namespace PayItForward.Data.Models
{
    using System;
    using System.Collections.Generic;


    public class Story
    {
        private ICollection<Donation> donations;

        private ICollection<Comment> comments;

        private ICollection<Like> likes;

        public Story()
        {
            this.comments = new HashSet<Comment>();
            this.donations = new HashSet<Donation>();
            this.likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double CollectedAmount { get; set; }

        public double GoalAmount { get; set; }

        public DateTime PostDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsRemoved { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsClosed { get; set; }

        public bool IsAccept { get; set; }

        public string DocumentUrl { get; set; }

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

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }

            set
            {
                this.likes = value;
            }
        }
    }
}
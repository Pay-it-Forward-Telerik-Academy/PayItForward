namespace PayItForward.Data.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int StoryId { get; set; }

        public virtual Story Story { get; set; }

        public int Ammount { get; set; }

        public string Country { get; set; }
    }
}
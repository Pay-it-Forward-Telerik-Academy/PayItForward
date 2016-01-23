namespace PayItForward.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public bool IsRemoved { get; set; }

        public string Context { get; set; }

        public int StoryId { get; set; }

        public virtual Story Story { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}

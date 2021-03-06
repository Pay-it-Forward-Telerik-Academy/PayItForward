﻿namespace PayItForward.Data.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int StoryId { get; set; }

        public virtual Story Story { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}

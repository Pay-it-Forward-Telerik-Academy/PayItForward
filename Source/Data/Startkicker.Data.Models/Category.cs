namespace PayItForward.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<Story> stories;

        public Category()
        {
            this.stories = new HashSet<Story>();
        }

        public int Id { get; set; }

        public bool IsRemoved { get; set; }

        public string Name { get; set; }

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
    }
}
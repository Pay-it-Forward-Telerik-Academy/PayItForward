using PayItForward.Data.Models;
using PayItForward.Data.Repositories;
using PayItForward.Services.Data.Contracts;


namespace PayItForward.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentRepo;


        public CommentsService(IRepository<Comment> commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public int Add(string userId, int storyId, string comment)
        {
            var commentToAdd = new Comment
            {
                Context = comment,
                StoryId = storyId,
                UserId = userId,
                IsRemoved = false

            };
            this.commentRepo.Add(commentToAdd);
            this.commentRepo.SaveChanges();
            return commentToAdd.Id;
        }
    }
}

using PayItForward.Data.Models;
using PayItForward.Data.Repositories;
using PayItForward.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PayItForward.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentRepo;

        private readonly IRepository<Story> storyRepo;


        public CommentsService(IRepository<Comment> commentRepo, IRepository<Story> storyRepo)
        {
            this.commentRepo = commentRepo;
            this.storyRepo = storyRepo;
        }

        public int Add(string userId, int storyId, string comment)
        {
            var commentToAdd = new Comment
            {
                Context = comment,
                StoryId = storyId,
                UserId = userId,
                IsRemoved = false,
                CreatedOn = DateTime.Now

            };
            this.commentRepo.Add(commentToAdd);
            this.commentRepo.SaveChanges();
            return commentToAdd.Id;
        }

        public IEnumerable<Comment> GetAllByStoryIdOrderedByDate(int storyId)
        {
            var story = this.storyRepo.GetById(storyId);
            return story.Comments.OrderBy(x => x.CreatedOn);

        }
    }
}

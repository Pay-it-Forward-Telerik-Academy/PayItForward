using PayItForward.Data.Models;
using PayItForward.Data.Repositories;
using PayItForward.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayItForward.Services.Data
{
    public class LikesService : ILikesService
    {
        private readonly IRepository<Like> likeRepo;


        public LikesService(IRepository<Like> likeRepo)
        {
            this.likeRepo = likeRepo;
        }

        public bool AddLike(int storyId, string userId)
        {
            var isLikeInvalid = likeRepo.All().Any(x => x.UserId == userId && x.StoryId == storyId);
            if (isLikeInvalid)
            {
                return false;
            }
            else
            {
                var likeToAdd = new Like
                {
                    StoryId = storyId,
                    UserId = userId
                };
                likeRepo.Add(likeToAdd);
                likeRepo.SaveChanges();
            }
            return true;
        }
    }
}

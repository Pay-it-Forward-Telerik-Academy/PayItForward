using PayItForward.Data.Models;
using System.Collections.Generic;

namespace PayItForward.Services.Data.Contracts
{
    public interface ICommentsService
    {
        int Add(string userId, int storyId, string comment);

        IEnumerable<Comment> GetAllByStoryIdOrderedByDate(int storyId);
    }
}

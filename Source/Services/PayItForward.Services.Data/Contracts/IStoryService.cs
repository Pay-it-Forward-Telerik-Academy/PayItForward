namespace PayItForward.Services.Data.Contracts
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Net.Mime;

    using PayItForward.Data.Models;

    public interface IStoryService
    {
        Story GetById(int id);

        IQueryable<Story> GetNotApproved();

        IQueryable<Story> GetAll();

        IQueryable<Story> GetByCategory(string categoryName);

        int Add(string title, string description, int goalMoney, int estimatedDays, int categoryId, string userId, string imageUrl, string documentUrl);

        int AddMoney(int storyId, int amount, string userId);

        void Update(Story story);

        void Remove(Story story);

        void RemoveById(int id);

        void Save();

        int Count();
    }
}

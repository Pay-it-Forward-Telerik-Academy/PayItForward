namespace Startkicker.Services.Data.Contracts
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Net.Mime;

    using PayItForward.Data.Models;

    public interface IStoryService
    {
        IQueryable<Story> GetById(int id);

        IQueryable<Story> GetAll();

        IQueryable<Story> GetByCategory(string categoryName);

        int Add(string title, string description, int goalMoney, int estimatedDays, int categoryId, int userId, string imageUrl);

        int AddMoney(int storyId, int amount, int userId);

        void Update(Story story);

        void Remove(Story story);

        void RemoveById(int id);
    }
}

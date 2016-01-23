namespace PayItForward.Services.Data.Contracts
{
    using PayItForward.Data.Models;
    using System.Linq;

    public interface IDonationService
    {
        IQueryable<Donation> GetById(int id);

        IQueryable<Donation> GetAll();

        IQueryable<Donation> GetByStory(string storyName);

        int Add(string userId, int storyId, int Ammount, string Country);
    }
}

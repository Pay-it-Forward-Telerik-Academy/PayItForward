namespace PayItForward.Services.Data
{
    using System;
    using System.Linq;
    using PayItForward.Data.Models;
    using PayItForward.Services.Data.Contracts;
    using PayItForward.Data.Repositories;
    public class DonationService : IDonationService
    {
        private readonly IRepository<Donation> donationRepo;
        private readonly IRepository<Story> storyRepo;
        private readonly IRepository<User> usersRepo;

        public DonationService(IRepository<Donation> donationRepo, IRepository<User> usersRepo, IRepository<Story> storyRepo)
        {
            this.donationRepo = donationRepo;
            this.usersRepo = usersRepo;
            this.storyRepo = storyRepo;
        }

        public int Add(string userId, int storyId, int Ammount, string Country)
        {
            var donationToAdd = new Donation
            {
                UserId = userId,
                StoryId = storyId,
                Country = Country,
                Ammount = Ammount
            };

            this.donationRepo.Add(donationToAdd);
            this.donationRepo.SaveChanges();
            var storyToDonate = this.storyRepo.GetById(storyId);
            storyToDonate.CollectedAmount += Ammount;
            this.storyRepo.SaveChanges();

            return donationToAdd.Id;
        }

        public IQueryable<Donation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Donation> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Donation> GetByStory(string storyName)
        {
            throw new NotImplementedException();
        }
        
    }
}

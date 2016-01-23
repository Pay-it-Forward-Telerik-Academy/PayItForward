namespace PayItForward.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PayItForward.Data.Models;
    using PayItForward.Data.Repositories;

    using PayItForward.Services.Data.Contracts;

    public class StoryService : IStoryService
    {
        private readonly IRepository<Story> storyRepo;
        private readonly IRepository<User> usersRepo;

        public StoryService(IRepository<Story> storyRepo, IRepository<User> usersRepo)
        {
            this.storyRepo = storyRepo;
            this.usersRepo = usersRepo;
        }

        public Story GetById(int id)
        {
            return this.storyRepo.GetById(id);
        }

        public IQueryable<Story> GetByCategory(string categoryName)
        {
            return
                this.storyRepo.All()
                    .Where(x => (!x.IsRemoved) && x.Category.Name == categoryName)
                    .OrderByDescending(c => c.Title);

        }

        public IQueryable<Story> GetAll()
        {
            return this.storyRepo.All().Where(x => (!x.IsRemoved)).ToList().AsQueryable();

        }


        public int Add(string title, string description, int goalAmount, int estimatedDays, int categoryId, string userId, string imageUrl, string documentsUrl)
        {
            var storyToAdd = new Story
            {
                ExpirationDate = DateTime.Now.AddDays(estimatedDays),
                Title = title,
                Description = description,
                GoalAmount = goalAmount,
                CategoryId = categoryId,
                UserId = userId,
                ImageUrl = imageUrl,
                IsRemoved = false,
                IsClosed = false,
                CollectedAmount = 0,
                DocumentUrl = documentsUrl,
                IsAccept = false,
                PostDate = DateTime.Now
            };

            this.storyRepo.Add(storyToAdd);
            this.storyRepo.SaveChanges();

            return storyToAdd.Id;
        }

        public void Update(Story project)
        {
            this.storyRepo.Update(project);
            this.storyRepo.SaveChanges();
        }

        public void Remove(Story project)
        {
            project.IsRemoved = true;
            this.storyRepo.Update(project);
            this.storyRepo.SaveChanges();
        }

        public void RemoveById(int id)
        {
            Story projectToRemove = this.storyRepo.GetById(id);
            projectToRemove.IsRemoved = true;
            this.storyRepo.Update(projectToRemove);
            this.storyRepo.SaveChanges();
        }

        public int AddMoney(int storyId, int amount, string userId)
        {
            User user = this.usersRepo.GetById(userId);

            if (user == null)
            {
                throw new UnauthorizedAccessException("User could not be found!");
            }

            if ((user.AvailableMoneyAmount - amount) <= 0)
            {
                throw new UnauthorizedAccessException("User have no enough money to proceed this opertion!");
            }

            Story storyToUpdate = this.storyRepo.GetById(storyId);

            if (storyToUpdate == null)
            {
                throw new ArgumentOutOfRangeException("Could not find the project. Make sure the ID is correct!");
            }

            if (storyToUpdate.UserId == userId)
            {
                throw new UnauthorizedAccessException("User could not fund own project!");
            }

            storyToUpdate.CollectedAmount += amount;
            this.storyRepo.Update(storyToUpdate);

            user.AvailableMoneyAmount -= amount;
            this.usersRepo.Update(user);

            this.storyRepo.SaveChanges();
            this.usersRepo.SaveChanges();

            return 1;
        }

        public void Save()
        {
            this.storyRepo.SaveChanges();
        }

        public IQueryable<Story> GetNotApproved()
        {
            return this.storyRepo.All()
                .Where(x => !x.IsAccept && !x.IsRemoved)
                .ToList()
                .AsQueryable();
        }
    }
}

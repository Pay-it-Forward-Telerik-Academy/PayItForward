namespace PayItForward.Services.Data
{
    using System;
    using System.Linq;

    using PayItForward.Data.Models;
    using PayItForward.Data.Repositories;

    using PayItForward.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> usersRepo;

        public UsersService(IRepository<User> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        public IQueryable<User> All()
        {
           return this.usersRepo.All().OrderBy(u => u.Id);
        }

        public int Count()
        {
           return this.usersRepo.All().Count();
        }

        public void Delete(string id)
        {
            this.usersRepo.Delete(id);
            this.usersRepo.SaveChanges();
        }

        public User GetById(string id)
        {
            return this.usersRepo.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return this.usersRepo.All().FirstOrDefault(x => x.UserName == userName);
        }

        public void Update()
        {
            this.usersRepo.SaveChanges();
        }
    }
}
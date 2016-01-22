namespace PayItForward.Services.Data
{
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

        public User GetById(string id)
        {
            return this.usersRepo.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return this.usersRepo.All().FirstOrDefault(x => x.UserName == userName);
        }
    }
}
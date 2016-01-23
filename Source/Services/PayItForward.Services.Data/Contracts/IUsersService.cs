namespace PayItForward.Services.Data.Contracts
{
    using PayItForward.Data.Models;
    using System.Linq;
    public interface IUsersService
    {
        IQueryable<User> All();

        User GetById(string id);

        User GetByUserName(string userName);

        void Update();

        void Delete(string id);
    }
}

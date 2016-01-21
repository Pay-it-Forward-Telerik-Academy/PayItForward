namespace Startkicker.Services.Data.Contracts
{
    using PayItForward.Data.Models;

    public interface IUsersService
    {
        User GetById(string id);

        User GetByUserName(string userName);
    }
}

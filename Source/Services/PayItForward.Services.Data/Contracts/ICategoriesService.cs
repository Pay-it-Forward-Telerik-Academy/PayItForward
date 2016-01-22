namespace PayItForward.Services.Data.Contracts
{
    using System.Linq;

    using PayItForward.Data.Models;

    public interface ICategoriesService
    {
        int Add(string categoryName);

        IQueryable<Category> GetPage(int page = 1, int pageSize = 10);

        IQueryable<Category> GetById(int id);

        IQueryable<Category> GetAll();

        void Remove(int id);

        int Update(Category category);
    }
}
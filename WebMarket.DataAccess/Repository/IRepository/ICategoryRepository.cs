using WebMarket.Models;

namespace WebMarket.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        

    }
}

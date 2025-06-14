using BusinessObjects;
using DataAccessObjects;

namespace Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}

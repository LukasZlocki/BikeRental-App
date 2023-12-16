using BikeRental.Models.Models;

namespace BikeRental.Services.Resource_Service
{
    public interface ICategoryService
    {
       public List<Category> GetAllCategories();
       public Category GetCategoryById(int id);
    }
}

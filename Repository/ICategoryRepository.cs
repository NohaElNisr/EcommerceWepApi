using SouqAPI.Model;
using System.Collections.Generic;

namespace SouqAPI.Repository
{
    public interface ICategoryRepository
{
        int Delete(int id);
        List<Category> GetAll();
        List<Category> GetBycatID(int catid);
        Category GetById(int id);
        Category GetByName(string Name);
        int Insert(Category cat);
        int Update(int id, Category cat);
    }
}

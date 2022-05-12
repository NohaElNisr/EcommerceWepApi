using SouqAPI.Model;
using System.Collections.Generic;

namespace SouqAPI.Repository
{
    public class CategoryRepository:ICategoryRepository
{
        private readonly SouqEntity context;

        public CategoryRepository(SouqEntity context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetBycatID(int catid)
        {
            throw new System.NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category GetByName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(Category cat)
        {
            throw new System.NotImplementedException();
        }

        public int Update(int id, Category cat)
        {
            throw new System.NotImplementedException();
        }
    }
}

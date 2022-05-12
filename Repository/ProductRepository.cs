using SouqAPI.Model;
using System.Collections.Generic;

namespace SouqAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SouqEntity context;

        public ProductRepository(SouqEntity context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product GetByName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetByproID(int pro)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(Product pro)
        {
            throw new System.NotImplementedException();
        }

        public int Update(int id, Product pro)
        {
            throw new System.NotImplementedException();
        }
    }
}

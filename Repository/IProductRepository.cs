using System.Collections.Generic;
using SouqAPI.Model;

namespace SouqAPI.Repository
{
    public interface IProductRepository
{
        int Delete(int id);
        List<Product> GetAll();
        List<Product> GetByproID(int pro);
        Product GetById(int id);
        Product GetByName(string Name);
        int Insert(Product pro);
        int Update(int id, Product pro);
    }
}

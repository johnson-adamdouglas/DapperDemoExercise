using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public interface IProductRepository //This is a completely abstract class which can only contain abstract methods and properties with empty bodies
        //To access these methods, this interface must be implemented by another class.
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct( int productID, string name, double price, int categoryID, int onSale, int stockLevel);

        public void UpdateProduct(int productID, string name, double price, int categoryID, int onSale, int stockLevel);

        public void DeleteProduct(int productID);
    }

}

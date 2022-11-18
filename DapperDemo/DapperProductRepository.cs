using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperDemo
{
    public class DapperProductRepository : IProductRepository // All dapper methods are held here.
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(int productID, string name, double price, int categoryID, int onSale, int stockLevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS (ProductID, Name, Price, CategoryID, OnSale, StockLevel) " +
                "VALUES (@productID, @productName, @price, @categoryID, @onSale, @stockLevel);",
             new { 
                 productID = productID,
                 productName = name, 
                 price = price, 
                 categoryID = categoryID,
                 onSale = onSale,
                 stockLevel = stockLevel
             });
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle("SELECT * FROM PRODUCTS WHERE ProductID = id;",
                new { id = id });
        }

        public void UpdateProduct(int productID, string name, double price, int categoryID, int onSale, int stockLevel)
        {
            _connection.Execute("UPDATE PRODUCTS SET " +
                "Name = @name," +
                "Price = @price," +
                "CategoryID = @categoryID," +
                "OnSale = @onSale," +
                "StockLevel = stockLevel" +
                "Where ProductID = @id;",
                new {
                    id = productID,
                    name = name, 
                    price = price, 
                    categoryID = categoryID, 
                    onSale = onSale, 
                    stockLevel = stockLevel
                });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM PRODUCTS WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @productID;",
                new { productID = productID });
        }
     

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

      
    }
}

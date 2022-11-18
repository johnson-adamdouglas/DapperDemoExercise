using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            #region Department
            //var repo = new DapperDepartmentRepository(conn);

            //var depts = repo.GetAllDepartments();

            //foreach (var dept in depts)
            //{
            //    Console.WriteLine(dept.Name);
            //}
            //Console.WriteLine("Enter a new department name");
            //var newDept = Console.ReadLine();
            //repo.InsertDepartment(newDept);
            //Console.WriteLine();
            //depts = repo.GetAllDepartments();
            //foreach (var dept in depts)
            //{
            //    Console.WriteLine(dept.Name);
            //}
            #endregion

            #region Products
            var productRepo = new DapperProductRepository(conn);
            var products = productRepo.GetAllProducts();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Name);
            //    Console.WriteLine(product.ProductID);
            //    Console.WriteLine(product.Price);
            //    Console.WriteLine(product.CategoryID);
            //    Console.WriteLine(product.OnSale);
            //    Console.WriteLine(product.StockLevel);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            //bool toCreate = false;
            //do
            //{
            //    Console.WriteLine("Would you like to create a new product?");
            //    if (Console.ReadLine().ToLower() == "yes")
            //    {
            //        toCreate = true;
            //        Console.WriteLine("Enter a new product ID");
            //        var productID = int.Parse(Console.ReadLine());
            //        Console.WriteLine("Enter a new product name");
            //        var newProductName = Console.ReadLine();
            //        Console.WriteLine("What is the price");
            //        var price = double.Parse(Console.ReadLine());
            //        Console.WriteLine("What is the category ID?");
            //        var categoryID = int.Parse(Console.ReadLine());
            //        Console.WriteLine("What is the on-sale code?");
            //        var onSale = int.Parse(Console.ReadLine());
            //        Console.WriteLine("What is the stock level?");
            //        var stockLevel = int.Parse(Console.ReadLine());

            //        productRepo.CreateProduct(productID, newProductName, price, categoryID, onSale, stockLevel);
            //    }
            //} while (toCreate == true);

            //Console.WriteLine();
            //products = productRepo.GetAllProducts();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductID);
            //    Console.WriteLine(product.Name);
            //    Console.WriteLine(product.Price);
            //    Console.WriteLine(product.CategoryID);
            //    Console.WriteLine(product.OnSale);
            //    Console.WriteLine(product.StockLevel);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion

            #region Update
            Console.WriteLine("What product ID would you like to update?");
            var updateProductID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new product name?");
            var updateName = Console.ReadLine();

            Console.WriteLine("What is the new price?");
            var updatePrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the new category ID?");
            var updateCatID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new on-sale code?");
            var updateOnSale = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new stock level?");
            var updateStockLevel = int.Parse(Console.ReadLine());

            productRepo.UpdateProduct(updateProductID, updateName, updatePrice, updateCatID, updateOnSale, updateStockLevel);

            #endregion

            #region delete
            //Console.WriteLine("What product ID would you like to delete?");
            //var deleteID = int.Parse(Console.ReadLine());
            //productRepo.DeleteProduct(deleteID);
            //Console.WriteLine("Product Deleted");


            #endregion
        }
    }
}
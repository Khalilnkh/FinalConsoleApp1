using ConsoleTables;
using MarketConsoleApp.Data.Enums;
using MarketConsoleApp.Data.Models;
using MarketConsoleApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsoleApp.Services.Concrete
{
    public class MenuService
    {
        private static IMarketService marketService = new MarketService();

        public static void AddProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine()!;
                ValidateMyString(name);

                static void ValidateMyString(string s)
                {
                    if (s.All(char.IsDigit))
                    {
                        Console.WriteLine("The product can not be consist of only numbers or digits");
                        throw new FormatException();
                    }
                }

                Console.WriteLine("Enter product's price:");
                decimal price = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter products's department:");
                Department department = (Department)Enum.Parse(typeof(Department), Console.ReadLine()!);

                Console.WriteLine("Enter products's quantity :");
                int quantity = int.Parse(Console.ReadLine()!);

                int id = marketService.AddProduct(name, price, department, quantity);

                Console.WriteLine($"Product with ID:{id} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Please enter new id of product");
                int id = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter product's new name:");
                string name = Console.ReadLine()!;
                ValidateMyString(name);
                static void ValidateMyString(string s)

                {
                    if (s.All(char.IsDigit))
                    {
                        Console.WriteLine("The product can not be consist of only numbers or digits");
                        throw new FormatException();

                    }
                }
                Console.WriteLine("Enter product's new price:");
                decimal price = decimal.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter products's new department:");
                Department department = (Department)Enum.Parse(typeof(Department), Console.ReadLine()!);
                Console.WriteLine("Enter products's new quantity :");
                int quantity = int.Parse(Console.ReadLine()!);
                marketService.UpdateProduct(id, name, price, department, quantity);

                Console.WriteLine($"Product with ID {id} was updated");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }
        }

        public static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Please enter Id of product");
                int id = int.Parse(Console.ReadLine()!);

                marketService.DeleteProduct(id);
                Console.WriteLine($"Product with ID:{id} was deleted!");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Eror {ex.Message}");
            }

        }

        public static void ShowProducts()
        {
            try
            {
                var table = new ConsoleTable("ID", "Name", "Price", "Department", "Quantity");

                foreach (var product in marketService.GetProducts())
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Department, product.Quantity);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        public static void ShowCategories()
        {
            try
            {
                var table = new ConsoleTable("Id", "Department");

                foreach (var product in marketService.GetProducts())
                {
                    table.AddRow(product.Id, product.Department);
                }

                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");

            }
        }

        public static void GetProductsByCategory()
        {
            try
            {
                Console.WriteLine("List of available products:");
                ShowCategories();
                Console.WriteLine("Please enter category of  product");
                Department department = (Department)Enum.Parse(typeof(Department), Console.ReadLine()!);

                var table = new ConsoleTable("ID", "Name", "Price", "Department", "Quantity");

                foreach (var product in marketService.GetProductsByCategory(department))
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Department, product.Quantity);
                }
                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }




        }

        public static void GetProductsByPriceRange()
        {
            try
            {
                Console.WriteLine("Please Add minimum price of product");
                int minPrice = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Please Add maximum price of product");
                int maxPrice = int.Parse(Console.ReadLine()!);

                var table = new ConsoleTable("ID", "Name", "Price", "Department", "Quantity");

                foreach (var product in marketService.GetProductsByPriceRange(minPrice, maxPrice))
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Department, product.Quantity);
                }
                table.Write();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }


        }

        public static void GetProductsByName()
        {
            try
            {
                Console.WriteLine("Please Add product name ");
                string name = Console.ReadLine()!;
                ValidateMyString(name);
                static void ValidateMyString(string s)
                {
                    if (s.All(char.IsDigit))
                    {
                        Console.WriteLine("The product can not be consist of only numbers or digits");
                        throw new FormatException();

                    }
                }
                var table = new ConsoleTable("ID", "Name", "Price", "Department", "Quantity");

                foreach (var product in marketService.GetProductsByGivenName(name))
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Department, product.Quantity);
                }
                table.Write();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }


        }

        public static void DeleteSale()
        {


            try
            {
                Console.WriteLine("Please enter Id of sale");
                int id = int.Parse(Console.ReadLine()!);

                marketService.DeleteSale(id);
                Console.WriteLine($"Product with ID:{id} was deleted!");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Eror {ex.Message}");
            }


        }

        public static void ShowSales()
        {
            try
            {
                var table = new ConsoleTable("ID", "Ammount", "Date", "SalesItem", "Product");

                foreach (var sale in marketService.GetSales())
                {
                    table.AddRow(sale.Id,sale.Amount,sale.Date,sale.SaleItem,sale.Product.Name,sale.Product.Department,sale.Product.Quantity,sale.Product.Quantity);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        //public static void AddSales()
        //{

        //    try
        //    {
        //        Console.WriteLine("Enter products's ID:");
        //        int productId = int.Parse(Console.ReadLine()!);

        //        Console.WriteLine("Enter SaleItem's ID:");
        //        int saleItemId = int.Parse(Console.ReadLine()!);

        //        Console.WriteLine("Enter Sale's date (dd/MM/yyyy - HH:mm):");
        //        var date = DateTime.ParseExact(Console.ReadLine()!, "(dd/MM/yyyy - HH:mm)", null);

        //        Console.WriteLine("Enter amount of sale:");
        //        int amount = int.Parse(Console.ReadLine()!);

        //        var table = new ConsoleTable("ID", "Amount", "Date", "SalesItem", "Product");

        //        foreach (var sales in marketService.AddSales(amount,date,saleItemId,productId));
        //        {
        //            //table.AddRow(, product.Name, product.Price, product.Department, product.Quantity);
        //        }
        //        table.Write();

        //        var id = marketService.AddSales(amount, date, saleItemId, productId);

        //        Console.WriteLine($"Sale with ID:{id} was created!");
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"Error: {ex.Message}");
        //    }


        //}

    }
}

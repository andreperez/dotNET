using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace edX.DataApp.Lab.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ContosoContext context = new ContosoContext())
            {
                Console.WriteLine("Connection Successful");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"{"Product",10}\t{"Price",10}\t{"Cost",10}\t{"Profit",10}");

                Console.WriteLine("------------------------------------------------------------");

                // Questão 1
                /*
                var produtoTmp = context.Products
                    .FirstOrDefault(p => p.ProductNumber == "SH-W890-M");

                Console.WriteLine($"{produtoTmp.ProductNumber,10}\t{produtoTmp.ListPrice,10:C}\t{produtoTmp.StandardCost,10:C}\t{(produtoTmp.ListPrice - produtoTmp.StandardCost),10:C}");
                */

                // Questão 2                
                /*
                var models = new List<string>()
                {
                    "FR-R92R-44",
                    "BK-R93R-48",
                    "BK-R89B-52",
                    "BK-M68B-46",
                    "BK-T44U-46"
                };

                var products = context.Products
                    .Where(p => (p.ListPrice - p.StandardCost) > 1000m
                    && models.Contains(p.ProductNumber))
                    .ToList();
                */

                // Questão 3
                /*
                var produtoTmp = context.Products
                    .FirstOrDefault(p => p.ProductNumber == "FR-M21B-40");

                Console.WriteLine($"{produtoTmp.ProductNumber,10}\t{produtoTmp.ListPrice,10:C}\t{produtoTmp.StandardCost,10:C}\t{(produtoTmp.ListPrice - produtoTmp.StandardCost),10:C}");
                */

                var products = context.Products;

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductNumber,10}\t{product.ListPrice,10:C}\t{product.StandardCost,10:C}\t{(product.ListPrice - product.StandardCost),10:C}");
                }

                Console.WriteLine("------------------------------------------------------------");

                System.Console.WriteLine("Application has completed execution. Press any key to exit.");

                System.Console.ReadKey();
            }
        }
    }
}

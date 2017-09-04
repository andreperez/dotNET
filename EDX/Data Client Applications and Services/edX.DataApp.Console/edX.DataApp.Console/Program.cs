using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace edX.DataApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }

        static async Task RunAsync()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                System.Console.WriteLine("Connection Successful");

                //await new DataAdapter().RunLogic(connection);
                //await new DataReader().RunLogic();

                //IEnumerable<Customer> customers = await new GenericQuery().RunLogic(connection);

                //foreach (Customer customer in customers)
                //{
                //    System.Console.WriteLine($"[{customer.Id:000}]\t{customer.Company}\t{customer.Email}");
                //}
            }
        }
    }
}

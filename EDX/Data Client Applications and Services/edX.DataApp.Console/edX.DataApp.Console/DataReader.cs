using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Console
{
    /*
    While DataSets are very powerful, there are some scenarios where they are not the ideal solution for retrieving data in your data source:

    Simple Result Reads: Your application may need only to read the results of a query once and cache the data locally. DataSets maintain an open connection to the data source.
    
    Remote Services: Remote databases, application tiers or XML/JSON services may not have the capability to maintain an open connection. Your application will need the ability to create ad-hoc queries that disconnect after they are complete.
        
    Data Shaping: Many user interface applications need the ability to enumerate the results of a query and then bind them to user interface components. While UI binding can occur with DataSets and DataTables, the binding is far more restrictive and less flexible than binding to custom classes with the application's source code.
        
    The DataReader classes in ADO.NET allow you to perform queries in a forward-only, read-only manner. These queries can free the connection as quickly as possible so that other applications can access your database in a performant manner. The DataReader classes are ideal for scenarios where you need to read and use the results of a query in a detached manner.
    */

    public class DataReader
    {

        public async Task RunLogic()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                System.Console.WriteLine("Connection Successful");
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT FirstName, LastName FROM Customers";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader.GetString(1);
                    int id = reader.GetFieldValue<int>(0);
                    int lastNameOrdinalValue = reader.GetOrdinal("LastName");
                    string lastName = reader.GetFieldValue<string>(lastNameOrdinalValue);
                    string companyNameType = reader.GetFieldType(3).AssemblyQualifiedName;

                    System.Console.WriteLine($"{firstName} {lastName}");
                }
            }
        }
    }
}

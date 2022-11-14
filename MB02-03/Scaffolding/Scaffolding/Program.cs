using System.Data.SqlClient;

namespace Scafffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // To import data with scaffolding:
            //      Scaffold-DbContext 'Server=LAPTOP-9L41U7GC\SQLSERVER_EB;Database=Northwind;Trusted_Connection=True;Encrypt=False;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
        }
    }
}

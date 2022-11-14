using System.Data.SqlClient;
namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter filter-criteria: ");
            string filterValue = Console.ReadLine();

            try
            {
                using SqlConnection conn = new SqlConnection(
                    "Server=LAPTOP-9L41U7GC\\SQLSERVER_EB;Database=Northwind;Trusted_Connection=True;"
                    );
                conn.Open();

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT c.ContactName, c.CompanyName,
                                        IsNull((select sum(CONVERT(money,UnitPrice*Quantity*(1-Discount)/100)) 
                                        FROM [dbo].[Order Details] od
                                        INNER JOIN [dbo].[Order] o ON od.OrderID = o.OrderID
                                        WHERE o.CustomerID = c.CustomerID), 0
                                        ) AS Sale
                                    FROM [dbo].[Customers] c
                                    WHERE ContactName LIKE @filterCriteria OR CompanyName LIKE @filterCriteria;";
                cmd.Parameters.AddWithValue("@filterCriteria", $"%{filterValue}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string str = reader.GetString(0);
                    Console.WriteLine(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Test1()
        {
            Console.Write("Enter Filter-Criteria: ");
            var filter = Console.ReadLine();
            try
            {
                // using C#8: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations
                // using var conn = new SqlConnection("Server=LAPTOP-9L41U7GC\\SQLSERVER_EB;Database=Northwind;Trusted_Connection=True;");
                using var conn = new SqlConnection("Server=LAPTOP-9L41U7GC\\SQLSERVER_EB;Database=Northwind;Trusted_Connection=True;");
                conn.Open();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    select a.CompanyName, a.ContactName, 
                           IsNull((select sum(CONVERT(money,UnitPrice*Quantity*(1-Discount)/100)) from [dbo].[Order Details] x inner join [dbo].[Orders] y on x.OrderID = y.OrderID where y.CustomerID = a.CustomerID),0) as Sales 
                       from [dbo].[Customers] a
                       where CompanyName like @para or ContactName like @para";



                cmd.Parameters.AddWithValue("@para", $"%{filter}%"); // "%" + filter + "%"
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(0).PadRight(20).Substring(0, 20)} | {reader.GetString(1).PadRight(20).Substring(0, 20)} | {reader.GetDecimal(2):N2}");
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
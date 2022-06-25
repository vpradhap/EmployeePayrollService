using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        //Declaring connection string for connecting with the database
        public static string connectionString = "data source = .; database = Employee_Payroll_DB; integrated security = true";

        //SqlConnection represents a connection to the SQL server database
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetEmployees()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                //SQL query to retrieve all data from the table employee_payroll
                string query = @"select * from Employee_Payroll";

                //Executing the query
                SqlCommand cmd = new SqlCommand(query, connection);

                //Opens the database connection with property settings specified
                connection.Open();

                //SqlDataReader for reading the stream of rows from an SQL server database
                //ExecuteReader sends cmd text to connection and builds an SQL SqlDataReader
                SqlDataReader reader = cmd.ExecuteReader();

                //Checking if reader contains one or more rows
                if (reader.HasRows)
                {
                    //Console.WriteLine("id name salary joiningdate gender phone_no address department basic_pay deductions taxable_pay income_tax net_pay");
                    //Reading next record
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["id"] + "  " + reader["name"] + "\t" + reader["salary"] + "  " + reader["joining_date"] + "  " + reader["gender"] + "  " + reader["phone_no"] + "  " + reader["address"] + "  " + reader["department"] + "  " + reader["basic_pay"] + "  " + reader["deductions"] + "  " + reader["taxable_pay"] + "  " + reader["income_tax"] + "  " + reader["net_pay"]);
                    }
                }
                else
                {
                    Console.WriteLine("No records");
                }
               // reader.Close();
                //connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //Closes the connection to the database
                connection.Close();
            }
        }
    }
}

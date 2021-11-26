using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLogic;

namespace DataLogic
{
    public class EmployeeDAL
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EFE3AH;Initial Catalog=PPM;Integrated Security =True");
        public void Insert()
        {

            con.Open();

            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                Console.Write("Enter the Employee Id: ");
                int eid = Convert.ToInt32(Console.ReadLine());
                employeeModel.empolyeeId = eid;

                Console.Write("Enter the emplyee first name: ");
                string fname = Console.ReadLine();
                employeeModel.firstName = fname;

                Console.Write("Enter the emplyee last name: ");
                string lname = Console.ReadLine();
                employeeModel.lastName = lname;

                Console.Write("Enter the emplyee email Id: ");
                string email = Console.ReadLine();
                employeeModel.emailID = email;

                Console.Write("Enter the emplyee phone number: ");
                string phone = Console.ReadLine();
                employeeModel.phoneNo = phone;

                Console.Write("Enter the emplyee address: ");
                string addrss = Console.ReadLine();
                employeeModel.address = addrss;
                string command = string.Format("Insert into Employee_Data(EmployeeId,FirstName,LastName,Email,PhoneNo,Address) values(" + employeeModel.empolyeeId + ",'" + employeeModel.firstName + "','" + employeeModel.lastName + "','" + employeeModel.emailID + "','" + employeeModel.phoneNo + "','" + employeeModel.address + "');");
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Console.WriteLine("EmployeeId already Exist");

                }
                else throw;
            }



            con.Close();
        }
        public void Select()
        {

            con.Open();

            string query = "select * from Employee_Data";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    Console.WriteLine("{0}   {1}  {2}  {3}  {4}  {5}", rdr["EmployeeId"], rdr["FirstName"], rdr["LastName"], rdr["Email"], rdr["PhoneNo"], rdr["Address"]);
                }
            }

            con.Close();
        }
        public void Delete(int id)
        {

            con.Open();
            string query = string.Format("DELETE from Employee_Data where EmployeeId = " + id + ";");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.ReadKey();


            con.Close();
        }
    }
}

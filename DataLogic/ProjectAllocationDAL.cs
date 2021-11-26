using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLogic;

namespace DataLogic
{
    public class ProjectAllocationDAL
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EFE3AH;Initial Catalog=PPM;Integrated Security =True");
        public void Insert()
        {
            con.Open();
            Console.WriteLine("Enter Employee Id:");
            int empid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Role Id:");
            int rid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Project Id:");
            int pid = int.Parse(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("Select FirstName from Employee_Data where EmployeeId = " + empid + ";", con);
            string fname = (string)cmd.ExecuteScalar();
            SqlCommand cmd1 = new SqlCommand("Select ProjectName from Project_Data where ProjectId =  " + pid + ";", con);
            string pname = (string)cmd1.ExecuteScalar();
            SqlCommand cmd2 = new SqlCommand("Select RoleName from Role_Data where RoleId = " + rid + ";", con);
            string rname = (string)cmd2.ExecuteScalar();
            SqlCommand cmd3 = new SqlCommand("Select Email from Employee_Data where EmployeeId = " + empid + ";", con);
            string email = (string)cmd3.ExecuteScalar();
            Console.WriteLine("Enter Employee Project Detail Id:");
            int ppid = int.Parse(Console.ReadLine());
            string command = string.Format("Insert into ProjectAllocation_Data(Employee_Id, Role_Id,Project_Id,Employee_Name,Project_Name,Role_Name,Email ,PDID)" +
                " values(" + empid + "," + rid + "," + pid + ",'" + fname + "','" + pname + "','" + rname + "','" + email + "'," + ppid + ");");
            SqlCommand cmd4 = new SqlCommand(command, con);
            cmd4.ExecuteNonQuery();
            Console.Write("Data Saved");
            con.Close();
            Console.ReadKey();
        }
        public void Select()
        {

            con.Open();

            string query = "select * from ProjectAllocation_Data";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0}   {1}  {2}  {3}  {4}  {5}  {6}", rdr["Employee_Id"], rdr["Role_Id"], rdr["Project_Id"], rdr["Employee_Name"], rdr["Project_Name"], rdr["Role_Name"], rdr["Email"],rdr["PDID"]);
                }
            }

            con.Close();
        }
        public void Delete(int id)
        {

            con.Open();
            string query = string.Format("DELETE from ProjectAllocation_Data where PDID = " + id + ";");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.ReadKey();


            con.Close();
        }
    }
}

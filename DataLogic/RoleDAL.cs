using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Data.SqlClient;

namespace DataLogic
{
    public class RoleDAL

    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EFE3AH;Initial Catalog=PPM;Integrated Security =True");
        public void Insert()
        {
            try { 
            con.Open();
            RoleModel roleModel = new RoleModel();
            Console.Write("Enter the Role-ID: ");
            roleModel.roleId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Name of Role: ");
            roleModel.roleName = Console.ReadLine();

            string command = string.Format("Insert into Role_Data(roleId,roleName) values(" + roleModel.roleId + ",'" + roleModel.roleName + "');");
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.ExecuteNonQuery();
             }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Console.WriteLine("RoleId already Exist");

                }
                else throw;
            }

            con.Close();
        }
        public void Select()
        {

            con.Open();

            string query = "select * from Role_Data";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0}   {1}", rdr["RoleId"], rdr["RoleName"]);
                }
            }

            con.Close();
        }
        public void Delete(int id)
        {
            con.Open();
            string query = string.Format("DELETE from Role_Data where RoleId = " + id + ";");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.ReadKey();
            con.Close();
        }
    }
}

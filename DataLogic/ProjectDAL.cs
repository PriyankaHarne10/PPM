using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLogic;


namespace DataLogic
{
    public class ProjectDAL
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EFE3AH;Initial Catalog=PPM;Integrated Security =True");

        public void Insert()
        {
            con.Open();
            try
            {
                ProjectModel projectModel = new ProjectModel();
                Console.Write("Enter the Project ID: ");
                projectModel.ProjectId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Project Name: ");
                projectModel.ProjectName = Console.ReadLine();
                Console.WriteLine("Enter the start date in project");
                Console.Write("Enter year: ");
                int yy1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter month: ");
                int mm1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter day: ");
                int dd1 = Convert.ToInt32(Console.ReadLine());
                projectModel.StartDate = DateTime.Parse($"{yy1}-{mm1}-{dd1}");
                Console.WriteLine("Enter the end date in project");
                Console.Write("Enter year: ");
                int yy2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter month: ");
                int mm2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter day: ");
                int dd2 = Convert.ToInt32(Console.ReadLine());
                projectModel.EndDate = DateTime.Parse($"{yy2}-{mm2}-{dd2}");
                string command = string.Format("Insert into Project_Data(ProjectId,ProjectName,StartDate,EndDate) values(" + projectModel.ProjectId + ",'" + projectModel.ProjectName + "','" + projectModel.StartDate + "','" + projectModel.EndDate + "');");
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
               
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Console.WriteLine("ProjectId already Exist");
          
                }
                else throw;
            }
         

            con.Close();
        }
       
        public void Select()
        {

            con.Open();

            string query = "select * from Project_Data";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0}   {1}   {2}   {3}", rdr["ProjectId"], rdr["ProjectName"], rdr["StartDate"], rdr["EndDate"]);
                }
            }

            con.Close();
        }
             
        public void Delete(int id)
        {

            con.Open();
            string query = string.Format("DELETE from Project_Data where ProjectId = " + id + ";");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.ReadKey();
            con.Close();
        }
      
       
        

    }
}
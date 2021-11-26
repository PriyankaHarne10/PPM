using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;



namespace ProlificsProjectManagement_2
{
    class ProjectUI
    {
        public ProjectUI()
        {

        }
        public ProjectModel Input()
        {
            ProjectModel projectModel = new ProjectModel();
            try
            {
                
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
            }
            catch (FormatException ex1)
            {
                Console.WriteLine("Please enter the Numeric value only");
                Console.WriteLine(ex1.Message);
            }
            catch (StackOverflowException ex2)
            {
                Console.WriteLine("Enter only the single digit value");
                Console.WriteLine(ex2.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return projectModel;
        }

      
        public void Output(List<ProjectModel> projectModels)
        { 
            Console.WriteLine("====================================================================================================================\n                                                PROJECT INFORMATION          \n====================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t\t\t{3,-10}(column index)", "0", "1", "2", "3");
            Console.WriteLine("______________________________________________________________________________________________________________________");
            Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t\t\t{3,-10}", "ID", "NAME", "Startdate", "Enddate");
            Console.WriteLine("====================================================================================================================");
            for (int i = 0; i < projectModels.Count; i++)
            {
                Console.Write("{0,-5}\t{1,-10}{2,-10}\t{3,-10}", projectModels[i].ProjectId, projectModels[i].ProjectName, projectModels[i].StartDate, projectModels[i].EndDate);
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------\n");

            }
        }

        public void ViewListAfterAddingEmployees(List<ProjectModel> projectModels)
        {
            for (int i = 0; i < projectModels.Count; i++)
            {
                Console.WriteLine("\nProject ID = " + projectModels[i].ProjectId);
                Console.WriteLine("Name Of Project = " + projectModels[i].ProjectName);
                Console.WriteLine("Start date : " + projectModels[i].StartDate);
                Console.WriteLine("End date : " + projectModels[i].EndDate);
                Console.WriteLine("Employees Working under Project: ");
                

                for (int j = 0; j < projectModels[i].ProjectEmployeesList.Count; j++)
                {
                    Console.WriteLine("====================================================================================================================\n                                                PROJECT INFORMATION          \n====================================================================================================================");
                    Console.WriteLine();
                    Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t{3,-10}(column index)", "0", "1", "2", "3");
                    Console.WriteLine("______________________________________________________________________________________________________________________");
                    Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t{3,-10}", "FName", "LNAME", "RoleID", "Rolename");
                    Console.WriteLine("====================================================================================================================");
                    Console.Write("{0,-5}\t{1,-10}{2,-10}\t{3,-10}", projectModels[i].ProjectEmployeesList[j].firstName, projectModels[i].ProjectEmployeesList[j].lastName, projectModels[i].ProjectEmployeesList[j].role.roleId, projectModels[i].ProjectEmployeesList[j].role.roleName);
                    Console.WriteLine();
                }

            }
        }
        
        public void AddEmployee()
        {
            try
            {
                Console.WriteLine("Enter the Project-Name :");
                string pname = Console.ReadLine();

                Console.WriteLine("Enter the Employee-ID :");
                int eid = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException ex1)
            {
                Console.WriteLine("Please enter the Numeric value only");
                Console.WriteLine(ex1.Message);
            }

            catch (StackOverflowException ex2)
            {
                Console.WriteLine("Enter only the single digit value");
                Console.WriteLine(ex2.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        
        public void ViewById(ProjectModel projectModels)
        {
            Console.WriteLine("====================================================================================================================\n                                                PROJECT INFORMATION          \n====================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t\t\t{3,-10}(column index)", "0", "1", "2", "3");
            Console.WriteLine("______________________________________________________________________________________________________________________");
            Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t\t\t{3,-10}", "ID", "NAME", "Startdate", "Enddate");
            Console.WriteLine("====================================================================================================================");         
            Console.Write("{0,-5}\t{1,-10}{2,-10}\t{3,-10}", projectModels.ProjectId, projectModels.ProjectName, projectModels.StartDate, projectModels.EndDate);
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------");

        }
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
namespace ProlificsProjectManagement_2
{
    public class EmployeeUI
    {
        public EmployeeModel Insert()
        {
            ProjectModel projectModel = new ProjectModel();
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                Console.WriteLine("*******Enter the employee details*******");

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
            }
            catch (FormatException ex1)
            {
                Console.WriteLine(" Enter proper value ");
                Console.WriteLine(ex1.Message);
            }

            catch (StackOverflowException ex2)
            {
                Console.WriteLine(ex2.Message);
            }
            catch (Exception ex3)
            {
                Console.Write(ex3.ToString());
            }
            return employeeModel;
        }

        public void Select(List<EmployeeModel> employeeModels)

        {
            Console.WriteLine("====================================================================================================================\n                                                EMPLOYEE INFORMATION          \n====================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}(column index)", "0", "1", "2", "3", "4", "5");
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}", "ID", "FirstName", "LastName", "Email", "Mobile No.", "Address");
            Console.WriteLine("====================================================================================================================");
            for (int i = 0; i < employeeModels.Count; i++)
            {
                Console.Write("{0,-5}\t{1,-10}{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}", employeeModels[i].empolyeeId, employeeModels[i].firstName, employeeModels[i].lastName, employeeModels[i].emailID, employeeModels[i].phoneNo, employeeModels[i].address);
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------\n");
               
            }

        }
        public void Remove(List<EmployeeModel> employeeModels)
        {
            Console.Write("Enter Employee ID: ");
            int eid = int.Parse(Console.ReadLine());
            for (int i = 0; i < employeeModels.Count; i++)
            {
               
                if (employeeModels[i].empolyeeId == eid)
                {
                    employeeModels.RemoveAt(i);
                    Console.WriteLine("Employee Deleted");
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry! Employee not found!");
                }
            }

        }
       

        public void ViewById(EmployeeModel employeeModels)
        {                      
                    Console.WriteLine("====================================================================================================================\n                                                EMPLOYEE INFORMATION          \n====================================================================================================================");
                    Console.WriteLine();
                    Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}(column index)", "0", "1", "2", "3", "4", "5");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("{0,-5}\t{1,-10}{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}", "ID", "FirstName", "LastName", "Email", "Mobile No.", "Address");
                    Console.WriteLine("====================================================================================================================");
                    Console.Write("{0,-5}\t{1,-10}{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}", employeeModels.empolyeeId, employeeModels.firstName, employeeModels.lastName, employeeModels.emailID, employeeModels.phoneNo, employeeModels.address);
                    Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------\n");
        }



    }
}

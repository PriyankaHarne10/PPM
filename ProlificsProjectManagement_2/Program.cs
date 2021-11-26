using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using DataLogic;
using System.Data.SqlClient;

namespace ProlificsProjectManagement_2
{
    class Program
    {   
        static void Main(string[] args)
        {
            ProjectUI projectUI = new ProjectUI();
            ProjectBL projectBL = new ProjectBL();
            EmployeeUI employeeUI = new EmployeeUI();
            EmployeeBL employeeBL = new EmployeeBL();
            RoleUI roleUI = new RoleUI();
            RoleBL roleBL = new RoleBL();
            int i = 0;
            ProjectDAL pdl = new ProjectDAL();
            RoleDAL rdl = new RoleDAL();
            EmployeeDAL edl = new EmployeeDAL();
            ProjectAllocationDAL padl = new ProjectAllocationDAL();


            try
            {
                int subchoice = 0, subchoice1 = 0, subchoice2 = 0, subchoice3 = 0, subchoice4 = 0;
                int ch = 0,ch1=0,ch2=0;
                string confirm;
                do
                {
                Again:
                    DisplayMenu();
                    Console.Write("Enter your choice(A-E):");
                    char choice = Console.ReadLine()[0];                 
                    switch (choice)
                    {
                        case 'A':
                            do
                            {
                                DisplayMenu1();
                                Console.Write("Enter your choice(1-8):");
                                subchoice = int.Parse(Console.ReadLine());

                                switch (subchoice)
                                {
                                    case 1: //Insert Project
                                        Console.Clear();                                     
                                        projectBL.Add(projectUI.Input());
                                        break;
                                    case 2:  //View Projects 
                                        Console.Clear();                                     
                                        projectUI.Output(projectBL.Get());
                                        break;
                                    case 3:
                                        Console.Clear();
                                        pdl.Insert();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        pdl.Select();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.Write("Enter Project id: ");
                                        int pid = int.Parse(Console.ReadLine());
                                        pdl.Delete(pid);
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.Write("Enter Project id: ");
                                        int projectid = int.Parse(Console.ReadLine());
                                        if (projectBL.IsExists(projectid))
                                        {
                                            Boolean flag = projectBL.Remove(projectid);
                                            if (flag == true)
                                            {
                                                Console.WriteLine("Project Deleted");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Project not found");
                                        break;
                                    case 7:
                                        Console.Clear();
                                        Console.Write("Enter Project Id: ");
                                        int Pid = int.Parse(Console.ReadLine());
                                        if (projectBL.IsExists(Pid))
                                        {
                                            ProjectModel project = projectBL.Get(Pid);
                                            projectUI.ViewById(project);
                                        }
                                        else
                                            Console.WriteLine("Project not found");
                                        break;
                                    case 8:
                                        Console.Clear();
                                        goto Again;                                      
                                        break;
                                    default:
                                        break;
                                }
                                Console.Write("Press y or Y to continue:");
                                confirm = Console.ReadLine().ToString();
                                Console.Clear();
                            } while (confirm == "y" || confirm == "Y");
                            break;                        
                        case 'B':
                            do
                            {
                                DisplayMenu2();
                                Console.Write("Enter your choice(1-8):");
                                subchoice1 = int.Parse(Console.ReadLine());
                                switch (subchoice1)
                                {
                                    case 1: //Insert Role
                                        Console.Clear();
                                        roleBL.Add(roleUI.Insert());
                                        break;
                                    case 2:  //View Role 
                                        Console.Clear();
                                        roleUI.Select(roleBL.Get());
                                        break;
                                    case 3:
                                        Console.Clear();
                                        rdl.Insert();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        rdl.Select();
                                        break;
                                    case 5:
                                        Console.Clear();                                   
                                        Console.Write("Enter Role id: ");
                                        int roleid = int.Parse(Console.ReadLine());
                                        rdl.Delete(roleid);
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.Write("Enter Role id: ");
                                        int rid = int.Parse(Console.ReadLine());
                                        if (roleBL.IsExists(rid))
                                        {
                                            Boolean flag = roleBL.Remove(rid);
                                            if (flag == true)
                                            {
                                                Console.WriteLine("Role Deleted");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Role not found");
                                        break;
                                    case 7:  
                                        Console.Clear();
                                        Console.Write("Enter Role Id: ");
                                        int Rid = int.Parse(Console.ReadLine());
                                        if (roleBL.IsExists(Rid))
                                        {
                                            RoleModel role = roleBL.Get(Rid);
                                            roleUI.ViewById(role);
                                        }
                                        else
                                            Console.WriteLine("Role not found");
                                        break;
                                    case 8:
                                        Console.Clear();
                                        goto Again;
                                        break;
                                    default:
                                        break;
                                }
                                Console.Write("Press y or Y to continue:");
                                confirm = Console.ReadLine().ToString();
                                Console.Clear();
                            } while (confirm == "y" || confirm == "Y");
                            break;
                        case 'C':
                            do
                            {
                                DisplayMenu3();
                                Console.Write("Enter your choice(1-8):");
                                subchoice2 = int.Parse(Console.ReadLine());

                                switch (subchoice2)
                                {
                                    case 1: //Insert Employee
                                        Console.Clear();
                                        employeeBL.Add(employeeUI.Insert());
                                        break;
                                    case 2:  //View Employee
                                        Console.Clear();
                                        employeeUI.Select(employeeBL.Get());
                                        break;
                                    case 3:
                                        Console.Clear();
                                        edl.Insert();                                      
                                        break;
                                    case 4:
                                        Console.Clear();
                                        edl.Select();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.Write("Enter Employee id: ");
                                        int empid = int.Parse(Console.ReadLine());                                     
                                        edl.Delete(empid);
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.Write("Enter Employee id: ");
                                        int eid = int.Parse(Console.ReadLine());
                                        if (employeeBL.IsExists(eid))
                                        {
                                            Boolean flag = employeeBL.Remove(eid);
                                            if (flag == true)
                                            {
                                                Console.WriteLine("Employee Deleted");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Employee not found");
                                        break;
                                    case 7:
                                        Console.Clear();
                                        Console.Write("Enter Employee Id: ");
                                        int Eid = int.Parse(Console.ReadLine());
                                        if (employeeBL.IsExists(Eid))
                                        {
                                            EmployeeModel employee = employeeBL.Get(Eid);
                                            employeeUI.ViewById(employee);
                                        }
                                        else
                                            Console.WriteLine("Employee not found");
                                        break;
                                    case 8:
                                        Console.Clear();
                                        goto Again;
                                        break;                                        
                                    default:
                                        break;
                                }
                                Console.Write("Press y or Y to continue:");
                                confirm = Console.ReadLine().ToString();
                                Console.Clear();
                            } while (confirm == "y" || confirm == "Y");
                            break;
                        case 'D':
                            do
                            {
                                DisplayMenu4();
                                Console.Write("Enter your choice(1-5):");
                                subchoice3 = int.Parse(Console.ReadLine());

                                switch (subchoice3)
                                {
                                    case 1: //Add employee to project
                                        Console.Clear();
                                        Console.WriteLine("Enter the Project-ID :");
                                        int pid = Convert.ToInt32(Console.ReadLine());
                                        if (projectBL.IsExists(pid))
                                        {
                                            Console.WriteLine("Enter the Employee-ID :");
                                            int eid = Convert.ToInt32(Console.ReadLine());
                                            if (employeeBL.IsExists(eid))
                                            {
                                                EmployeeModel emp = employeeBL.GetById(eid);
                                                projectBL.AddEmployee(pid, emp);
                                                Console.WriteLine("Employee Added Successfully!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("EmployeeID not Found");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("ProjectID not Found");
                                            break;
                                        }
                                        break;
                                    case 2: 
                                        Console.Clear();
                                        Console.WriteLine("Enter the employee ID: ");
                                        int eid2 = Convert.ToInt32(Console.ReadLine());

                                        if (employeeBL.IsExists(eid2))
                                        {
                                            Console.WriteLine("Enter the Role-ID: ");
                                            int rid = Convert.ToInt32(Console.ReadLine());

                                            if (roleBL.IsExists(rid))
                                            {
                                                RoleModel role;
                                                role = roleBL.GetById(rid);
                                                employeeBL.AssignRole(eid2, role);
                                            }
                                            else
                                                Console.WriteLine("RoleId is not found");
                                        }
                                        else
                                            Console.WriteLine("EmployeeId is not found");
                                        break;
                                    case 3: 
                                        Console.Clear();
                                        projectUI.ViewListAfterAddingEmployees(projectBL.Get());                                                                        
                                        break;
                                    case 4:
                                        Console.Clear();
                                        padl.Insert();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        padl.Select();
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine("Enter the Project-ID :");
                                        int pid1 = Convert.ToInt32(Console.ReadLine());
                                        if (projectBL.IsExists(pid1))
                                        {
                                            Console.WriteLine("Enter the Employee-ID :");
                                            int eid1 = Convert.ToInt32(Console.ReadLine());
                                            if (employeeBL.IsExists(eid1))
                                            {
                                                EmployeeModel emp = employeeBL.GetById(eid1);
                                                projectBL.DeleteEmployee(pid1, emp);
                                                Console.WriteLine("Employee Deleted Successfully!");
                                            }
                                            else
                                            {
                                                Console.WriteLine(" Oops! EmployeeID is not Found");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(" Oops! Project is not Found");
                                            break;
                                        }
                                        break;
                                    case 7:
                                        Console.Clear();
                                        Console.Write("Enter Project Allocation id: ");
                                        int paid = int.Parse(Console.ReadLine());
                                        padl.Delete(paid);
                                        break;
                                    case 8:
                                        Console.Clear();
                                        goto Again;
                                        break;
                                    default:
                                        break;
                                }
                                Console.Write("Press y or Y to continue:");
                                confirm = Console.ReadLine().ToString();
                                Console.Clear();
                            } while (confirm == "y" || confirm == "Y");
                            break;
                        case 'E':
                            do
                            {
                                DisplayMenu5();
                                Console.Write("Enter your choice(1-3):");
                                subchoice4 = int.Parse(Console.ReadLine());
                                switch (subchoice4)
                                {
                                case 1:
                                        FileMenu();
                                        Console.Write("Enter your choice(1-3):");
                                        ch = int.Parse(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case 1:
                                               projectBL.ProjectXmlSerialize(projectBL.ProjectList);
                                                break;
                                            case 2:
                                                roleBL.RoleXmlSerialize(roleBL.RoleList);
                                                break;
                                            case 3:
                                                employeeBL.EmployeeXmlSerialize(employeeBL.EmployeeList);
                                                break;
                                            case 4:
                                                DisplayMenu5();
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 3:
                                        break;
                                    case 4:
                                        goto Again;
                                        break;
                                    default:
                                        break;

                                }
                              
                                Console.Write("Press y or Y to continue:");
                                confirm = Console.ReadLine().ToString();
                                Console.Clear();
                            } while (confirm == "y" || confirm == "Y");
                            break;
                        default:
                            break;
                    }
                }

                while (i <= 10);
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        static void DisplayMenu()
        {
           
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("A. Project Module");
            Console.WriteLine("B. Role Module");
            Console.WriteLine("C. Employee Module");
            Console.WriteLine("D. Project Allocation");
            Console.WriteLine("E. Save ");
            Console.WriteLine("F. Quit ");



        }
        static void DisplayMenu1()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. Insert Project to List ");
            Console.WriteLine("2. View Project from List");
            Console.WriteLine("3. Insert Project to DB ");          
            Console.WriteLine("4. View Project from DB");
            Console.WriteLine("5. Delete Project from DB");
            Console.WriteLine("6. Delete Project from List");
            Console.WriteLine("7. View Project By ID");
            Console.WriteLine("8. Back");
        }
        static void DisplayMenu2()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. Insert Role to List ");
            Console.WriteLine("2. View  Role from List");
            Console.WriteLine("3. Insert  Role to DB ");
            Console.WriteLine("4. View  Role from DB");
            Console.WriteLine("5. Delete  Role from DB");
            Console.WriteLine("6. Delete  Role from List");
            Console.WriteLine("7. View  Role By ID");
            Console.WriteLine("8. Back");
        }
        static void DisplayMenu3()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. Insert Employee to List ");
            Console.WriteLine("2. View Employee from List");
            Console.WriteLine("3. Insert Employeeto DB ");
            Console.WriteLine("4. View Employee from DB");
            Console.WriteLine("5. Delete Employee from DB");
            Console.WriteLine("6. Delete Employee from List");
            Console.WriteLine("7. View Employee By ID");
            Console.WriteLine("8. Back");



        }
        static void DisplayMenu4()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. Add employee to project");
            Console.WriteLine("2. Assign Role");
            Console.WriteLine("3. View Project Allocation Deails from list ");
            Console.WriteLine("4. Project Allocation");
            Console.WriteLine("5. View Project Allocation Deails");
            Console.WriteLine("6. Delete Employee from project");
            Console.WriteLine("7. Back");
        }
        static void DisplayMenu5()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. File");
            Console.WriteLine("2. DB-ADO");
            Console.WriteLine("3. DB-EF");
            Console.WriteLine("4. Back");
        }
        static void FileMenu()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. Save Project");
            Console.WriteLine("2. Save Role");
            Console.WriteLine("3. Save Employee");
            Console.WriteLine("4. Back");
        }
        static void DBADOMenu()
        {
            Console.Clear();
            Console.WriteLine("****************Welcome To Prolifics Project Management***************");
            Console.WriteLine("\n - Enter your choice: ");
            Console.WriteLine("1. Save Project");
            Console.WriteLine("2. Save Role");
            Console.WriteLine("3. Save Employee");
            Console.WriteLine("4. Save ProjectDetails");
            Console.WriteLine("5. Back");
        }
        
       
        
        

    }
}

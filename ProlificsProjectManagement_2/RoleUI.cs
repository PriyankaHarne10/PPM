using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace ProlificsProjectManagement_2
{
    public class RoleUI
    {
        public RoleModel Insert()
        {
            RoleModel roleModel = new RoleModel();
            try
            {
                Console.Write("Enter the Role-ID: ");
                roleModel.roleId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the Name of Role: ");
                roleModel.roleName = Console.ReadLine();
                

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


            return roleModel;
        }

        public void Select(List<RoleModel> roleModels)
        {
            try
            {
                for (int i = 0; i < roleModels.Count; i++)
                {
                    Console.Write("{0,-5}\t{1,-10}", roleModels[i].roleId, roleModels[i].roleName);
                    Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------\n");
                }
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
            catch (Exception ex3)
            {
                Console.Write(ex3.ToString());
            }



        }
        //public void Remove(List<RoleModel> roleModels)
        //{
        //    Console.Write("Enter Role id: ");
        //    int rid = int.Parse(Console.ReadLine());
        //    for (int i = 0; i < roleModels.Count; i++)
        //    {

        //        if (roleModels[i].roleId == rid)
        //        {
        //            roleModels.RemoveAt(i);
        //            Console.WriteLine("Role Deleted");
        //            break;

        //        }
        //        else
        //        {
        //            Console.WriteLine("Sorry! Role not found!");
        //        }
        //    }

        //}
        
        public void ViewById(RoleModel roleModels)
        {
            Console.Write("{0,-5}\t{1,-10}", roleModels.roleId, roleModels.roleName);
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------");
        }

    }
}

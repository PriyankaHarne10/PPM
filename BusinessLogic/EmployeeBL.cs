using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace BusinessLogic
{
    public class EmployeeBL: IEmployeeOperation
    {
        public List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        public void Add(EmployeeModel employee)
        {
            EmployeeList.Add(employee);
        }

        public List<EmployeeModel> Get()
        {
            return EmployeeList;
        }
       
        public bool Remove(int eid)
        {
           
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (eid == EmployeeList[i].empolyeeId)
                {
                    EmployeeList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public EmployeeModel Get(int eid)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            for(int i =0;i<EmployeeList.Count;i++)
            {
                if(eid == EmployeeList[i].empolyeeId)
                {
                    employeeModel = EmployeeList[i];
                    return employeeModel;
                }
            }
            return employeeModel;
        }

        public void AssignRole(int eid, RoleModel role)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].empolyeeId == eid)
                {
                    EmployeeList[i].SetRole(role);
                }

            }

        }

        public bool IsExists(int eid)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (eid == EmployeeList[i].empolyeeId)
                {
                    return true;
                }
            }
            return false;
        }

        public EmployeeModel GetById(int eid)
        {
            EmployeeModel emp = new EmployeeModel();
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (eid == EmployeeList[i].empolyeeId)
                {
                    emp = EmployeeList[i];
                    return emp;
                }
            }
            return emp;
        }
        public void EmployeeXmlSerialize(List<EmployeeModel> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<EmployeeModel>));
            using (TextWriter writer = new StreamWriter("C:\\Users\\W10\\source\\repos\\ProlificsProjectManagement_2\\Employee_XML.xml"))
            {

                xmlSerializer.Serialize(writer, list);
                Console.WriteLine("Data Saved ");
            }

        }

    }
}

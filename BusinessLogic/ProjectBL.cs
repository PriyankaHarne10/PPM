using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace BusinessLogic
{
    public class ProjectBL: IProjectOperation
    {
        public List<ProjectModel> ProjectList = new List<ProjectModel>();
        public ProjectBL()
        {

        }
        public void Add(ProjectModel projectModel)
        {
            ProjectList.Add(projectModel);
        }

        public List<ProjectModel> Get()
        {
            return ProjectList;
        }
        public bool Remove(int pid)
        {
            
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    ProjectList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
          
        public ProjectModel Get(int pid)
        {
            ProjectModel projectModel = new ProjectModel();
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    projectModel = ProjectList[i];
                    return projectModel;
                }
            }
            return projectModel;
        }
       
        
        public void AddEmployee(int pid, EmployeeModel emp)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    ProjectList[i].ProjectEmployeesList.Add(emp);
                    break;
                }
            }
        }

        public void DeleteEmployee(int pid, EmployeeModel emp)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    ProjectList[i].ProjectEmployeesList.Remove(emp);
                    break;
                }
            }
        }
        public bool IsExists(int pid)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    return true;
                }
            }
            return false;
        }
        public void ProjectXmlSerialize(List<ProjectModel> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProjectModel>));
            using (TextWriter writer = new StreamWriter("C:\\Users\\W10\\source\\repos\\ProlificsProjectManagement_2\\Project_XML.xml"))
            {
                xmlSerializer.Serialize(writer, list);
                Console.WriteLine("Data Saved ");
            }

        }
    }
}

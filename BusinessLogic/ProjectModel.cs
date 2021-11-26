using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLogic
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<EmployeeModel> ProjectEmployeesList = new List<EmployeeModel>();
        public ProjectModel()
        {
        }
        public ProjectModel(int ProjectId, string projectName, DateTime startDate, DateTime endDate)
        {
            this.ProjectId = ProjectId;
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.EndDate = endDate;
           
        }
        
    }
}

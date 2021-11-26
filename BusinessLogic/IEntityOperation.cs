using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IProjectOperation
    {
        void Add(ProjectModel projectModel);
        List<ProjectModel> Get();
        bool Remove(int pid);
        ProjectModel Get(int pid);
        bool IsExists(int pid);
        void AddEmployee(int pid, EmployeeModel emp);
        void DeleteEmployee(int pid, EmployeeModel emp);
    }
    interface IRoleOperation
    {
        void Add(RoleModel role);
        List<RoleModel> Get();
        bool Remove(int rid);
        RoleModel Get(int rid);
        bool IsExists(int rid);
        RoleModel GetById(int rid);
    }
    interface IEmployeeOperation
    {
        void Add(EmployeeModel employee);
        List<EmployeeModel> Get();
        bool Remove(int eid);
        EmployeeModel Get(int eid);
        void AssignRole(int eid, RoleModel role);
        bool IsExists(int eid);
        EmployeeModel GetById(int eid);
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using ProlificsProjectManagement_2;
using System.Collections;
using System.Collections.Generic;

namespace NUnit_PPM
{
    [TestClass]
    public class UnitTest1
    {
        ProjectBL projectBLTest = new ProjectBL();
        EmployeeBL employeeBLTest = new EmployeeBL();
        RoleBL roleBLTest = new RoleBL();
        List<ProjectModel> projects;
        List<EmployeeModel> employees;
        List<RoleModel> roles;
        [TestMethod]
        public void AddProject_Test()
        {
            //Arrange
            DateTime sd = new DateTime(2016, 12, 20);
            DateTime ed = new DateTime(2019, 12, 20);
            ProjectModel project = new ProjectModel(11, "PPM", sd, ed);

            //Act
            projectBLTest.Add(project);
            projects = projectBLTest.Get();

            //Assert
            Assert.AreEqual(true, projectBLTest.IsExists(project.ProjectId));       
        }
        [TestMethod]
        public void DeleteProject()
        {
            DateTime sd = new DateTime(2016, 12, 20);
            DateTime ed = new DateTime(2019, 12, 20);
            ProjectModel project = new ProjectModel(11, "PPM", sd, ed);

            //Act
            projectBLTest.Add(project);
            Boolean flag = projectBLTest.Remove(11);
            Assert.AreEqual(false, projectBLTest.IsExists(11));
        }
        [TestMethod]
        public void ViewProjectById()
        {
            //Arrange

            DateTime sd = new DateTime(2016, 12, 20);
            DateTime ed = new DateTime(2019, 12, 20);
            ProjectModel project = new ProjectModel(11, "PPM", sd, ed);

            //Act
            projectBLTest.Add(project);
            ProjectModel projectModel= projectBLTest.Get(11);
            Assert.AreEqual(11, projectModel.ProjectId);
        }

        [TestMethod]
        public void AddRole_Test()
        {
            //Arrange 
            RoleModel role1 = new RoleModel(101, "Tester");
            RoleModel role2 = new RoleModel(102, "Developer");

            //Act
            roleBLTest.Add(role1);
            roleBLTest.Add(role2);
            roles = roleBLTest.Get();

            //Assert
            Assert.AreEqual(101, role1.roleId);
            Assert.AreEqual("Tester", role1.roleName);

            Assert.AreEqual(102, role2.roleId);
            Assert.AreEqual("Developer", role2.roleName);

            Assert.AreEqual(true, roleBLTest.IsExists(role1.roleId));
            Assert.AreEqual(true, roleBLTest.IsExists(role2.roleId));
        }
        [TestMethod]
        public void DeleteRole_Test()
        {
            RoleModel role= new RoleModel(101, "Tester");

            //Act
            roleBLTest.Add(role);
            Boolean flag = roleBLTest.Remove(101);
            Assert.AreEqual(false, roleBLTest.IsExists(101));
        }
        [TestMethod]
        public void ViewRoleById()
        {
            //Arrange
            RoleModel role = new RoleModel(101, "Tester");
            //Act
            roleBLTest.Add(role);
            RoleModel roleModel = roleBLTest.Get(101);
            Assert.AreEqual(101, roleModel.roleId);
        }
        [TestMethod]
        public void AddEmployee_Test()
        {

            //Arrange
            EmployeeModel employee1 = new EmployeeModel(1, "Priya", "Harne", "PH@test.com", "9881087404", "Hyderabad");
            //Act
            employeeBLTest.Add(employee1);
            employees = employeeBLTest.Get();
            //Assert
            Assert.AreEqual(1, employee1.empolyeeId);
            Assert.AreEqual("Priya", employee1.firstName);
            Assert.AreEqual("Harne", employee1.lastName);
            Assert.AreEqual("PH@test.com", employee1.emailID);
            Assert.AreEqual("9881087404", employee1.phoneNo);
            Assert.AreEqual("Hyderabad", employee1.address);
            Assert.AreEqual(true, employeeBLTest.IsExists(employee1.empolyeeId));        
        }
        [TestMethod]
        public void DeleteEmployee_Test()
        {
            EmployeeModel employee = new EmployeeModel(1, "Priya", "Harne", "PH@test.com", "9881087404", "Hyderabad");

            //Act
            employeeBLTest.Add(employee);
            Boolean flag = employeeBLTest.Remove(1);
            Assert.AreEqual(false, employeeBLTest.IsExists(1));
        }
        [TestMethod]
        public void ViewEmployeeById()
        {
            //Arrange
            EmployeeModel employee = new EmployeeModel(1, "Priya", "Harne", "PH@test.com", "9881087404", "Hyderabad");
            //Act
            employeeBLTest.Add(employee);
            EmployeeModel employeeModel = employeeBLTest.Get(1);
            Assert.AreEqual(1, employeeModel.empolyeeId);
        }

        [TestMethod]
        public void AssignedRole()
        {
            //Arrange
            EmployeeModel employee = new EmployeeModel(101, "Priyanka", "Harne", "PH@test.com", "9881087404", "Hyderabad");
            RoleModel role1 = new RoleModel(1, "Trainee");
            //Act
            employeeBLTest.Add(employee);
           
            employees = employeeBLTest.Get();
            employeeBLTest.AssignRole(101, role1); 
            //Assert
            int roleID = employees[0].GetRoleId();
            Assert.AreEqual(roleID, role1.roleId);
            
        }
        

    }
}

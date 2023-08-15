using Data.Model;
using Data;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService
    {
        private readonly MyDbContext _dbContext;
        private readonly GenericRepository<Employee> _employeeRepository;

        public EmployeeService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Employee employee)
        {
            _dbContext.employees.Add(employee);
            _dbContext.SaveChanges();
        }
        public void Update(Employee employee)
        {
            _dbContext.employees.Update(employee);
            _dbContext.SaveChanges();

        }
        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
        public List<Employee> GetAll()
        {
            return _dbContext.employees.ToList();
        }

        public Employee GetById(int EmployeeID)
        {
            return _employeeRepository.Get(c => c.EmployeeID == EmployeeID);
        }
        public object GetEmployeeWithDepartmentName(int employeeId)
        {
            var result = _dbContext.employees
                .Where(employee => employee.EmployeeID == employeeId)
                .Join(
                    _dbContext.departments,
                    employee => employee.DepartmentID,
                    department => department.DepartmentID,
                    (employee, department) => new
                    {
                        EmployeeID = employee.EmployeeID,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DepartmentName = department.DepartmentName
                    })
                .FirstOrDefault();

            return result;
        }

    }
}

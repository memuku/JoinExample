using Data;
using Data.Model;
using DataAccess.Repository;

namespace Business.Services
{
    public class DepartmentService
    {
        private readonly MyDbContext _dbContext;
        private readonly GenericRepository<Department> _departmentRepository;

        public DepartmentService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Department department)
        {
            _dbContext.departments.Add(department);
            _dbContext.SaveChanges();
        }
        public void Update(Department department)
        {
            _dbContext.departments.Update(department);
            _dbContext.SaveChanges();

        }
        public void Delete(Department department)
        {
            _departmentRepository.Delete(department);
        }
        public List<Department> GetAll()
        {
            return _dbContext.departments.ToList();
        }

    }
}

using Data;
using Data.Model;
using DataAccess.Repository;

namespace Business.Services
{
    public class CustomerService
    {
        private readonly MyDbContext _dbContext;
        private readonly GenericRepository<Customer> _customerRepository;

        public CustomerService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _customerRepository = new GenericRepository<Customer>(_dbContext);
        }

        public void Add(Customer customer)
        {
            _dbContext.customers.Add(customer);
            _dbContext.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _dbContext.customers.Update(customer);
            _dbContext.SaveChanges();

        }
        public void Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
        }
        public List<Customer> GetAll()
        {
            return _dbContext.customers.ToList();
        }

        public Customer GetById(int CostumerID)
        {
            return _customerRepository.Get(c => c.CustomerId == CostumerID);
        }
        
    }
}


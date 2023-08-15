using Data;
using Data.Model;
using DataAccess.Repository;

namespace Business.Services
{
    public class OrderService
    {
        private readonly MyDbContext _dbContext;
        private readonly GenericRepository<Order> _orderRepository;

        public OrderService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Order order)
        {
            _dbContext.orders.Add(order);
            _dbContext.SaveChanges();
        }
        public void Update(Order order)
        {
            _dbContext.orders.Update(order);
            _dbContext.SaveChanges();

        }
        public void Delete(Order order)
        {
            _orderRepository.Delete(order);
        }
        public List<Order> GetAll()
        {
            return _dbContext.orders.ToList();
        }

        public Order GetById(int id)
        {
            return _orderRepository.Get(order => order.OrderID == id);
        }
        public object GetOrderWithCustomerName(int orderId)
        {
            var result = _dbContext.orders
                .Where(order => order.OrderID == orderId)
                .Join(
                    _dbContext.customers,
                    order => order.CustomerID,
                    customer => customer.CustomerId,
                    (order, customer) => new
                    {
                        OrderID = order.OrderID,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        
                    })
                .FirstOrDefault();

            return result;
        }
    }
}

using BurgerAppRefactored.DataAccess.Abstraction;
using BurgerAppRefactored.Domain;
using Microsoft.EntityFrameworkCore;

namespace BurgerAppRefactored.DataAccess.Repositories
{
    public class OrderRepository : IRepository<Order>
    {

        private readonly BurgerAppRefactoredDbContext _dbContext;

        public OrderRepository(BurgerAppRefactoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.Include(x => x.Burgers).ThenInclude(y => y.Burger).Include(x => x.Extras).ThenInclude(y => y.Extra).ToList();
        }
        public Order GetById(int id)
        {
            return _dbContext.Orders.Include(x => x.Burgers).ThenInclude(y => y.Burger).Include(x => x.Extras).ThenInclude(y => y.Extra).FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Order entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _dbContext.Orders.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}

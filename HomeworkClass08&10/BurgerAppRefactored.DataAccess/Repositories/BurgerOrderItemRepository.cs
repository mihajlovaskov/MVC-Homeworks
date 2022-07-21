using BurgerAppRefactored.DataAccess.Abstraction;
using BurgerAppRefactored.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.DataAccess.Repositories
{
    public class BurgerOrderItemRepository : IRepository<BurgerOrderItem>
    {
        private readonly BurgerAppRefactoredDbContext _dbContext;

        public BurgerOrderItemRepository(BurgerAppRefactoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BurgerOrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public BurgerOrderItem GetById(int id)
        {
            return _dbContext.BurgerOrderItems.Include(x => x.Burger).Include(x => x.Order).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(BurgerOrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BurgerOrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}

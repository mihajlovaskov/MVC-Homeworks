﻿using BurgerAppRefactored.DataAccess.Abstraction;
using BurgerAppRefactored.Domain;

namespace BurgerAppRefactored.DataAccess.Repositories
{
    public class BurgerRepository : IRepository<Burger>
    {

        private readonly BurgerAppRefactoredDbContext _dbContext;

        public BurgerRepository(BurgerAppRefactoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Burger> GetAll()
        {
            return _dbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _dbContext.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Burger entity)
        {

            _dbContext.Burgers.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Burger entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                _dbContext.Burgers.Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _dbContext.Burgers.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}

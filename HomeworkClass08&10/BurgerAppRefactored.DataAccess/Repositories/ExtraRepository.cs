using BurgerAppRefactored.DataAccess.Abstraction;
using BurgerAppRefactored.Domain;

namespace BurgerAppRefactored.DataAccess.Repositories
{
    public class ExtraRepository : IRepository<Extra>
    {
        private readonly BurgerAppRefactoredDbContext _dbContext;

        public ExtraRepository(BurgerAppRefactoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Extra> GetAll()
        {
            return _dbContext.Extras.ToList();
        }
        public Extra GetById(int id)
        {
            return _dbContext.Extras.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Extra entity)
        {
            _dbContext.Extras.Add(entity);
            _dbContext.SaveChanges();

        }
        public void Update(Extra entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                _dbContext.Extras.Update(entity);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _dbContext.Extras.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}

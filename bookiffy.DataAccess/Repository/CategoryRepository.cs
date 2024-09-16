using bookiffy.DataAccess.Data;
using bookiffy.DataAccess.Repository.IRepository;
using bookiffy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bookiffy.DataAccess.Repository
{
    //both Repository<T> and ICategoryRepository inherit from IRepository thats why it does not cause an error
    //But if you try to remove the Repository<Category>, it will show the error that other method should be implemented.
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) //pass the implementation to the base classes.
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}

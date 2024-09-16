using bookiffy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookiffy.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category> //inherit all based method from IRepository
    {
        void Update(Category obj);
        void Save();
    }
}

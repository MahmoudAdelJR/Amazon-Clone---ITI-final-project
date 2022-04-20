using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IModelRepo<T>
    {
        void Create(T entity);
        IQueryable<T> Read();
        void Update(T entity);
        void Delete(int id);
        T GetByID(int id);
    }
}

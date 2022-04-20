using Admin.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class AdminRepo<T> : IModelRepo<T> where T : BaseClass
    {
        DbContext context;
        DbSet<T> table;
        public AdminRepo(DbContext _context)
        {
            context = _context;
            table = _context.Set<T>();
        }

        public void Create(T entity)
        {
            table.Add(entity);
        }

        public void Delete(int Id)
        {
            table.Remove(GetByID(Id));
        }

        public T GetByID(int id)
        {
            return table.FirstOrDefault(item => item.Id==id);
        }

        public IQueryable<T> Read()
        {
            return table;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

    }
}

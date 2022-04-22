using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    
        public class GenericUnitOfWork : IDisposable
    {
        // Initialization code
        DbContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public GenericUnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public IModelRepo<T> Repository<T>() where T : BaseClass
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(IModelRepo<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (IModelRepo<T>)repositories[type];
        }
        // other methods
    }
}

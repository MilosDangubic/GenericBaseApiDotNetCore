using BaseApi.Core;
using BaseApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;
        public IUserRepository Users { get; private set; }

        public ApplicationContext Context 
        {
            get { return context; }
        }

        public UnitOfWork(ApplicationContext context) 
        {
            this.context = context;
            Users = new UserRepository(this.context);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (typeof(TEntity) == typeof(User)) 
            {
                return Users as IRepository<TEntity>;
            }

            return null;
        }
    }
}

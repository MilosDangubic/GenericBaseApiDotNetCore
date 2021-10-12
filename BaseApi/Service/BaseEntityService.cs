using BaseApi.Configuration;
using BaseApi.Core.Service;
using BaseApi.Model;
using BaseApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Service
{
    public class BaseEntityService<TEntity> : BaseService, IBaseEntityService<TEntity> where TEntity : class
    {
        public BaseEntityService(ProjectConfiguration projectConfiguration) : base(projectConfiguration) { }

        public virtual TEntity Get(int id)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(new ApplicationContext());
            return unitOfWork.GetRepository<TEntity>().Get(id);
        }
        public virtual bool Delete(int id)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(new ApplicationContext());
            Entity entity = unitOfWork.GetRepository<TEntity>().Get(id) as Entity;

            if (entity == null)
            {
                return false;
            }

            unitOfWork.GetRepository<TEntity>().Update(entity as TEntity);
            entity.Deleted = true;
            unitOfWork.Complete();

            return true;
        }
    }
}

using BaseApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Core.Service
{
    public interface IBaseEntityService<TEntity> where TEntity : class
    {
        public  TEntity Get(int id);
        public  bool Delete(int id);
    }
}

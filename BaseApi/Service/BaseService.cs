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
    public class BaseService
    {
        protected ProjectConfiguration configuration;
        public BaseService() { }
        public BaseService(ProjectConfiguration configuration) 
        {
            this.configuration = configuration;
        }
    }
}

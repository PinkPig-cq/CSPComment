using Core.Extension;
using Domain.ServiceProviders;
using Microsoft.Extensions.Caching.Memory;
using Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ServiceProviderService
{
    public class ServiceProviderService: GenericService<ServiceProvider>,IServiceProviderService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly static string MODEL_KEY = "ServiceProvider";
        private readonly IRepository<ServiceProvider> __serviceProviderRepository;

        public ServiceProviderService(IRepository<ServiceProvider> serviceProviderRepository, IMemoryCache memoryCache):base(serviceProviderRepository)
        {
            this.__serviceProviderRepository = serviceProviderRepository;
            this._memoryCache = memoryCache;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        public new IList<ServiceProvider> FindAll()
        {
            return __serviceProviderRepository.Table.ToList();
        }

        /// <summary>
        /// 计算平均星级
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceProvider GetStarScore(ServiceProvider entity)
        {
            foreach (var EvaluationOrder in entity.EvaluationOrderList)
            {
                entity.Star = entity.Star + EvaluationOrder.Star;
            }
            entity.Star = (entity.Star / entity.EvaluationOrderList.Count()).IntFloor();

            return entity;
        }
    }
}

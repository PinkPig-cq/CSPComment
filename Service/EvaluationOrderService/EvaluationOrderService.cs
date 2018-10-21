using Domain.EvaluationOrders;
using Microsoft.Extensions.Caching.Memory;
using Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.EvaluationOrderService
{
    public class EvaluationOrderService: GenericService<EvaluationOrder>,IEvaluationOrderService
    {

        private readonly IMemoryCache _memoryCache;
        private readonly static string MODEL_KEY = "EvaluationOrder";
        private readonly IRepository<EvaluationOrder> __evaluationOrderRepository;

        public EvaluationOrderService(IRepository<EvaluationOrder> evaluationOrderRepository, IMemoryCache memoryCache):base(evaluationOrderRepository)
        {
            this.__evaluationOrderRepository = evaluationOrderRepository;
            this._memoryCache = memoryCache;
        }

        public new IList<EvaluationOrder> FindAll()
        {
            return __evaluationOrderRepository.Table.ToList();
        }
    }
}

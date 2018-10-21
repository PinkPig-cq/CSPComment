using Domain.EvaluationOrders;
using Domain.Replies;
using Domain.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
    /// <summary>
    /// 数据库表-实体映射静态扩展类
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region Reply
        public static RepliesModel ToModel(this Reply entity)
        {
            return entity.MapTo<Reply, RepliesModel>();
        }

        public static Reply ToEntity(this RepliesModel entity)
        {
            return entity.MapTo<RepliesModel, Reply>();
        }
        #endregion

        #region EvaluationOrder
        public static EvaluationOrderModel ToModel(this EvaluationOrder entity)
        {
            return entity.MapTo<EvaluationOrder, EvaluationOrderModel>();
        }

        public static EvaluationOrder ToEntity(this EvaluationOrderModel entity)
        {
            return entity.MapTo<EvaluationOrderModel, EvaluationOrder>();
        }
        #endregion

        #region EvaluationOrder
        public static ServiceProviderModel ToModel(this ServiceProvider entity)
        {
            return entity.MapTo<ServiceProvider, ServiceProviderModel>();
        }

        public static ServiceProvider ToEntity(this ServiceProviderModel entity)
        {
            return entity.MapTo<ServiceProviderModel, ServiceProvider>();
        }
        #endregion
    }
}

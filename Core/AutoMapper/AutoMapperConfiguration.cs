using AutoMapper;
using Domain.EvaluationOrders;
using Domain.Replies;
using Domain.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
    /// <summary>
    /// AutoMapper的全局实体映射配置静态类
    /// </summary>
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(configure =>
            {
                //将领域实体映射到视图实体

                configure.CreateMap<EvaluationOrder, EvaluationOrderModel>().ForMember(d => d.Creator, d => d.MapFrom(s => s.SysUser.Name));
                configure.CreateMap<Reply, RepliesModel>().ForMember(d => d.Writer, d => d.MapFrom(s => s.SysUser.Name));

                configure.CreateMap<EvaluationOrderModel, EvaluationOrder>();
                configure.CreateMap<Reply, RepliesModel>();

                configure.CreateMap<ServiceProvider, ServiceProviderModel>().ForMember(d => d.EvaluationCount, d => d.MapFrom(s => s.EvaluationOrderList.Count));
                configure.CreateMap<ServiceProviderModel, ServiceProvider>();
            });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.AutoMapper;
using Domain.ServiceProviders;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using Services.EvaluationOrderService;
using Services.ServiceProviderService;
using Services.SysUserService;

namespace UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISysUserService _sysUserService;
        private readonly IServiceProviderService _serviceProviderService;
        public readonly IEvaluationOrderService _evaluationOrderService;
        public HomeController(ISysUserService sysUserService,
            IServiceProviderService serviceProviderService,
            IEvaluationOrderService evaluationOrderService)
        {
            this._sysUserService = sysUserService;
            this._serviceProviderService = serviceProviderService;
            this._evaluationOrderService = evaluationOrderService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            page = page ?? 1;

            //获取服务商信息 
            var serviceProviderList = _serviceProviderService.FindAll()
                .Select(s => new ServiceProvider
                 {
                     ID = s.ID,
                     Name = s.Name,
                     Description = s.Description,
                     Image = s.Image,
                     Star = s.Star,
                     EvaluationOrderList = _evaluationOrderService.FindAll().Where(o => o.ServiceProviderID == s.ID).ToList()
                 }).OrderByDescending(o => o.EvaluationOrderList.Count).AsQueryable().ToPagedList((int)page,3);

            //计算供应商的星级
            foreach (var serviceProvider in serviceProviderList)
            {
                _serviceProviderService.GetStarScore(serviceProvider);
            }

            //将领域对象转换成UI对象
            var list = serviceProviderList.Select(s => s.ToModel()).ToList();

            //分页
            ViewBag.Pagination = new StaticPagedList<ServiceProviderModel>(list, serviceProviderList.PageNumber,
                                                                            serviceProviderList.PageSize, 4);

            return View(list);
        }
      
        
    }
}

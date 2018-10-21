using Domain.EvaluationOrders;
using Domain.Replies;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using Services.EvaluationOrderService;
using Services.RepliesService;
using Services.ServiceProviderService;
using Services.SysUserService;
using System.Linq;
using UI.Models;

namespace UI.Controllers
{
    public class ServiceProviderController : BaseController
    {
        private readonly IServiceProviderService _serviceProvider;
        private readonly IServiceProviderService _serviceProviderService;
        public readonly IEvaluationOrderService _evaluationOrderService;
        public readonly IReplyService _replyService;
        public readonly ISysUserService _sysUserService;
        public ServiceProviderController(IServiceProviderService serviceProvider,
            IServiceProviderService serviceProviderService,
            IEvaluationOrderService evaluationOrderService,
            IReplyService replyService,
            ISysUserService sysUserService)
        {
            this._serviceProvider = serviceProvider;
            this._serviceProviderService = serviceProviderService;
            this._evaluationOrderService = evaluationOrderService;
            this._replyService = replyService;
            this._sysUserService = sysUserService;
        }


        /// <summary>
        ///提供商详情 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IActionResult ServiceProviderDetails(int ID, int? page)
        {
            page = page ?? 1;

            var serviceProvider = _serviceProvider.FindById(ID);

            var evaluationOrdersPage = _evaluationOrderService.FindAll()
                                                   .Where(o => o.ServiceProviderID == serviceProvider.ID)
                                                   .Select(s => new EvaluationOrder
                                                   {
                                                       Content = s.Content,
                                                       Star = s.Star,
                                                       EvaluationStart = s.EvaluationStart,
                                                       ID = s.ID,
                                                       SysUser = _sysUserService.FindById(s.CreatorID),
                                                       ReplyList = _replyService.FindAll().Where(r => r.EvaluationOrderID == s.ID)
                                                                   .Select(r => new Reply
                                                                   {
                                                                       Content = r.Content,
                                                                       ReplyStart = r.ReplyStart,
                                                                       Writer = _sysUserService.FindById(r.ReplierID).Name
                                                                   }).OrderByDescending(o => o.ReplyStart)
                                                                   .ToList()
                                                   }).OrderByDescending(s => s.EvaluationStart)
                                                   .AsQueryable().ToPagedList((int)page, 10);

            serviceProvider.EvaluationOrderList = evaluationOrdersPage.ToList();
            //计算供应商的星级
            _serviceProviderService.GetStarScore(serviceProvider);

            //统计每个星级个数
            ViewBag.Star = new StarType
            {
                One = serviceProvider.EvaluationOrderList.Where(s => s.Star == 1).Count(),
                Two = serviceProvider.EvaluationOrderList.Where(s => s.Star == 2).Count(),
                Three = serviceProvider.EvaluationOrderList.Where(s => s.Star == 3).Count(),
                Four = serviceProvider.EvaluationOrderList.Where(s => s.Star == 4).Count(),
                Five = serviceProvider.EvaluationOrderList.Where(s => s.Star == 5).Count()
            };

            //分页
            ViewBag.Pagination = new StaticPagedList<EvaluationOrder>(serviceProvider.EvaluationOrderList, evaluationOrdersPage.PageNumber,
                                                                      evaluationOrdersPage.PageSize, evaluationOrdersPage.TotalItemCount);

            return View(serviceProvider);
        }
    }
}
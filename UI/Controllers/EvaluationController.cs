using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AutoMapper;
using Domain.EvaluationOrders;
using Domain.Replies;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using Services.EvaluationOrderService;
using Services.RepliesService;
using Services.ServiceProviderService;
using Services.SysUserService;

namespace UI.Controllers
{
    public class EvaluationController : BaseController
    {
        private readonly IServiceProviderService _serviceProviderService;
        public readonly IEvaluationOrderService _evaluationOrderService;
        public readonly IReplyService _replyService;
        public readonly ISysUserService _sysUserService;
        public EvaluationController(IServiceProviderService serviceProvider,
            IServiceProviderService serviceProviderService,
            IEvaluationOrderService evaluationOrderService,
            IReplyService replyService,
            ISysUserService sysUserService)
        {
            this._serviceProviderService = serviceProviderService;
            this._evaluationOrderService = evaluationOrderService;
            this._replyService = replyService;
            this._sysUserService = sysUserService;
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IActionResult PostEvaluatuin(int? ID)
        {
            var entity = _serviceProviderService.FindById(ID).ToModel();

            return View(entity);
        }

        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostEvaluatuin(int providerID,int starScore,string content)
        {
            var entity = new EvaluationOrder()
            {
                ServiceProvider = _serviceProviderService.FindById(providerID),
                SysUser = _sysUserService.FindById(WebHelper.WebHelper.UserSession.ID),
                Content = content.Trim(),
                Star = starScore,
                EvaluationStart= DateTime.Now
            };
            _evaluationOrderService.Insert(entity);

            return Redirect("/ServiceProvider/ServiceProviderDetails?id="+ providerID);
        }

        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="ProviderID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult Index(int ProviderID, int EvaluationID, int? page)
        {
            page = page ?? 1;

            var serviceProvider = _serviceProviderService.FindById(ProviderID);
            var EvaluationOrderPage = _evaluationOrderService.FindAll()
                                                   .Where(o => o.ServiceProviderID == serviceProvider.ID).Select(s => new EvaluationOrder
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
                                                   })
                                                   .OrderByDescending(s => s.EvaluationStart)
                                                   .AsQueryable().ToPagedList((int)page, 10);

            serviceProvider.EvaluationOrderList = EvaluationOrderPage.ToList();

            //计算供应商的星级
            _serviceProviderService.GetStarScore(serviceProvider);

            //当前回复评论的ID
            ViewBag.EvaluationID = EvaluationID;

            //分页
            ViewBag.Pagination = new StaticPagedList<EvaluationOrder>(serviceProvider.EvaluationOrderList, EvaluationOrderPage.PageNumber, 
                                                                      EvaluationOrderPage.PageSize, EvaluationOrderPage.TotalItemCount);

            return View(serviceProvider);
        }

        /// <summary>
        /// 提交回复
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostReply(int providerID,int evaluationID, string content)
        {
            Reply entity = new Reply()
            {
                Content = content.Trim(),
                Writer = WebHelper.WebHelper.UserSession.Name,
                EvaluationOrder = _evaluationOrderService.FindById(evaluationID),
                ReplyStart = DateTime.Now,
                SysUser = _sysUserService.FindById(WebHelper.WebHelper.UserSession.ID)
            };
            _replyService.Insert(entity);

            return Redirect("/ServiceProvider/ServiceProviderDetails?ID=" + providerID);
        }
    }
}
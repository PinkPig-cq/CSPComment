using Core.Encrypt;
using Domain.EvaluationOrders;
using Domain.Replies;
using Domain.ServiceProviders;
using Domain.SysUsers;
using Services.EvaluationOrderService;
using Services.RepliesService;
using Services.ServiceProviderService;
using Services.SysUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.InitData
{
    public class InitData
    {
        private readonly ISysUserService _sysUserService;
        private readonly IServiceProviderService _serviceProviderService;
        private readonly IEvaluationOrderService _evaluationOrderService;
        private readonly IReplyService _replyService;
        public InitData(ISysUserService sysUserService,
            IServiceProviderService serviceProviderService,
            IEvaluationOrderService evaluationOrderService,
            IReplyService replyService)
        {
            this._sysUserService = sysUserService;
            this._serviceProviderService = serviceProviderService;
            this._evaluationOrderService = evaluationOrderService;
            this._replyService = replyService;
        }
        public void InitDataBase()
        {
            Init_serviceProvider();
            Init_SysUser();
            Init_EvaluationOrder();
            Init_Reply();     
        }

        /// <summary>
        /// 初始化用户表
        /// </summary>
        public void Init_SysUser()
        {
            try
            {
                _sysUserService.Insert(new SysUser()
                {
                    Account = "Admin",
                    Password = EncryptorHelper.GetMD5("Admin"),
                    Name = "张三",
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 初始化云服务商家
        /// </summary>
        public void Init_serviceProvider()
        {
            try
            {
                _serviceProviderService.Insert(new ServiceProvider()
                {
                    Name = "阿里云",
                    Description = "这是阿里云的介绍",
                    Star = 5,
                    Image = ""
                });
                _serviceProviderService.Insert(new ServiceProvider()
                {
                    Name = "腾讯云",
                    Description = "这是腾讯云的介绍",
                    Star = 5,
                    Image = ""
                });
                _serviceProviderService.Insert(new ServiceProvider()
                {
                    Name = "华为云",
                    Description = "这是华为云的介绍",
                    Star = 5,
                    Image = ""
                });
                _serviceProviderService.Insert(new ServiceProvider()
                {
                    Name = "小米云",
                    Description = "这是小米云的介绍",
                    Star = 5,
                    Image = ""
                });
                _serviceProviderService.Insert(new ServiceProvider()
                {
                    Name = "小鸟云",
                    Description = "这是小鸟云的介绍",
                    Star = 5,
                    Image = ""
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 初始化评论
        /// </summary>
        public void Init_EvaluationOrder()
        {
            try
            {
                _evaluationOrderService.Insert(new EvaluationOrder()
                {
                    Star = 5,
                    EvaluationStart = DateTime.Now,
                    ServiceProvider = _serviceProviderService.FindById(1),
                    Content = "超级快  性价比超高 稳定1111111",
                    SysUser =_sysUserService.FindById(1)
                });
                _evaluationOrderService.Insert(new EvaluationOrder()
                {
                    Star = 5,
                    EvaluationStart = DateTime.Now,
                    ServiceProvider = _serviceProviderService.FindById(1),
                    Content = "超级快  性价比超高 稳定222222",
                    SysUser = _sysUserService.FindById(1)
                });
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 初始化回复
        /// </summary>
        public void Init_Reply()
        {
            try
            {
                _replyService.Insert(new Reply()
                {
                    Writer = "张三",
                    Content = "一楼主说的对呀",
                    ReplyStart = DateTime.Now.AddHours(1),
                    SysUser = _sysUserService.FindById(1),
                    EvaluationOrder = _evaluationOrderService.FindById(1)
                   
                });
                _replyService.Insert(new Reply()
                {
                    Writer = "张三",
                    Content = "二楼主说的对呀",
                    ReplyStart = DateTime.Now.AddHours(1),
                    SysUser = _sysUserService.FindById(1),
                    EvaluationOrder = _evaluationOrderService.FindById(2)
                });
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}

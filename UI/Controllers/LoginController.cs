using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Encrypt;
using Domain.SysUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.SysUserService;

namespace UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ISysUserService _sysUserService;
        public LoginController(ISysUserService sysUserService)
        {
            this._sysUserService = sysUserService;
        }

        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public string CheckLogin(string Account,string Pwd)
        {
          
            Pwd = EncryptorHelper.GetMD5(Pwd);
            SysUser user = _sysUserService.CheckUser(Account, Pwd);
            if (user != null)
            {
                WebHelper.WebHelper.UserSession = user;
                if (HttpContext.Session.GetString("Url") != null)
                {
                    string url =  HttpContext.Session.GetString("Url").ToString();
                    HttpContext.Session.Remove("Url");          
                    return  url;
                }
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
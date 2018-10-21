using Domain.SysUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebHelper
{
    public static class WebHelper
    {
        public static SysUser user;
        /// <summary>
        /// 存储用户
        /// </summary>
        public static SysUser UserSession
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void Logout()
        {
            user = null;
        }
    }
}

using Core;
using Domain.SysUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SysUserService
{
    public interface ISysUserService:IService<SysUser>
    {
        SysUser CheckUser(string account, string pwd);
    }
}

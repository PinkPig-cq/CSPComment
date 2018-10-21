using Domain.SysUsers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Reflection.Metadata;
using System.Data.SqlClient;
using Repositroy;

namespace Services.SysUserService
{
    public class SysUserService: GenericService<SysUser>, ISysUserService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly static string MODEL_KEY = "SysUser";
        private readonly IRepository<SysUser> __sysUserRepository;

        public SysUserService(IRepository<SysUser> sysUserRepository, IMemoryCache memoryCache):base(sysUserRepository)
        {
            this.__sysUserRepository = sysUserRepository;
            this._memoryCache = memoryCache;
        }

        /// <summary>
        /// 获取所以用户 + 缓存
        /// </summary>
        /// <returns></returns>
        public new IList<SysUser> FindAll()
        {
            List<SysUser> list = null;
            _memoryCache.TryGetValue<List<SysUser>>(MODEL_KEY, out list);
            if (list != null) return list;
            list = __sysUserRepository.Table.ToList();
            _memoryCache.Set(MODEL_KEY, list, DateTimeOffset.Now.AddMinutes(5));
            return list;
        }

        /// <summary>
        /// 验证用户  (由于数据少直接查全表了)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public SysUser CheckUser(string account, string pwd)
        {
           return __sysUserRepository.Table.Where(a=>a.Account == account && a.Password == pwd).FirstOrDefault();
        }
    }
}

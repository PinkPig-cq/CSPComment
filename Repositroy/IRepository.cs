using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositroy
{
    /// <summary>
    /// 提供统一仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        DbContext DbContext { get; }

        /// <summary>
        /// 
        /// </summary>
        DbSet<TEntity> Entities { get; }

        /// <summary>
        /// 获取所有对象
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// 通过主键ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        void Insert(TEntity entity, bool isSave = true);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        void Update(TEntity entity, bool isSave = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        void Delete(TEntity entity, bool isSave = true);

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        IPagedList<TEntity> FindPagedList( Expression<Func<TEntity, object>> keySelector, string orderBy = "", int pageIndex = 1, int pageSize = 20);
    }
}

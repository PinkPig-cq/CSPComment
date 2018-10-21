using Domain;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositroy
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private GeneralDbContext _dbContext;

        public EfRepository(GeneralDbContext generalDbContext)
        {
            this._dbContext = generalDbContext;
        }

        public DbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<TEntity> Entities
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }


        public void Delete(TEntity entity, bool isSave = true)
        {
            Entities.Remove(entity);
            if (isSave)
                _dbContext.SaveChanges();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsExist(TEntity entity)
        {
            return Entities.Contains(entity) ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity, bool isSave = true)
        {
            if (!IsExist(entity))
                Entities.Add(entity);
            if (isSave)
                _dbContext.SaveChanges();
        }

        public void Update(TEntity entity, bool isSave = true)
        {
            if (isSave)
                _dbContext.SaveChanges();
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<TEntity> FindPagedList(Expression<Func<TEntity,object>> keySelector,  string orderBy = "",int pageIndex = 1, int pageSize = 10)
        {
                var page = Entities.OrderBy(keySelector).ToPagedList(pageIndex, pageSize);                
                return page;
        }
    }
}

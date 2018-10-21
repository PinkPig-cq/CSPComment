using PagedList.Core;
using Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Services
{
    public class GenericService<TEntity> : IService<TEntity> where TEntity : class, new()
    {
        private readonly IRepository<TEntity> _repository;
        public GenericService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }
        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteById(object id)
        {
            _repository.GetById(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _repository.Table.ToList();
        }

        public TEntity FindById(object pkValue)
        {
            return _repository.GetById(pkValue);
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<TEntity> FindPagedList( Expression<Func<TEntity, object>> keySelector, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            return _repository.FindPagedList(keySelector,orderBy,pageIndex,pageSize);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

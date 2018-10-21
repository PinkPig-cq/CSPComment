using Domain.Replies;
using Microsoft.Extensions.Caching.Memory;
using Repositroy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.RepliesService
{
    public class ReplyService:GenericService<Reply>,IReplyService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly static string MODEL_KEY = "SysUser";
        private readonly IRepository<Reply> __replyRepository;

        public ReplyService(IRepository<Reply> _replyRepository, IMemoryCache memoryCache) : base(_replyRepository)
        {
            this.__replyRepository = _replyRepository;
            this._memoryCache = memoryCache;
        }
    }
}

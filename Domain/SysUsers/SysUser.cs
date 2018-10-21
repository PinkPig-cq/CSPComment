using Domain.EvaluationOrders;
using Domain.Replies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.SysUsers
{
    [Table("SysUser")]
    public class SysUser:DomainBase
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string  Password { get; set; }

        /// <summary>
        ///发表的评论 
        /// </summary>
        public virtual ICollection<EvaluationOrder> EvaluationOrderList { get; set; }

        /// <summary>
        /// 发表的回复
        /// </summary>
        public ICollection<Reply> ReplyList { get; set; }
    }
}

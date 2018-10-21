using Domain.Replies;
using Domain.ServiceProviders;
using Domain.SysUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.EvaluationOrders
{
    [Table("EvaluationOrder")]
    public class EvaluationOrder : DomainBase
    {
        public float Star { get; set; } = 5;

        public string Content { get; set; }

        public DateTime? EvaluationStart { get; set; }

        [NotMapped]
        public int CreatorID { get; set; }
        [NotMapped]
        public int ServiceProviderID { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [ForeignKey("CreatorID")]
        public virtual SysUser SysUser { get; set; }

        /// <summary>
        /// 评论对象
        /// </summary>
        [ForeignKey("ServiceProviderID")]
        public virtual ServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 评论下面的回复
        /// </summary>
        public virtual ICollection<Reply> ReplyList { get; set; }
    }
}

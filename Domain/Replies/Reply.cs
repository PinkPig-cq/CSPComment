using Domain.EvaluationOrders;
using Domain.SysUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Replies
{
    [Table("Reply")]
    public class Reply:DomainBase
    {
        public DateTime? ReplyStart { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }

        [NotMapped]
        public int ReplierID { get; set; }
      
        public int ParentReplyID { get; set; }
        [NotMapped]
        public int EvaluationOrderID { get; set; }

        /// <summary>
        /// 多级回复 -> 子集
        /// </summary>
        [NotMapped]
        public virtual ICollection<Reply> ChildReplyList { get; set; }

        /// <summary>
        /// 回复者
        /// </summary>
        [ForeignKey("ReplierID")]
        public virtual SysUser SysUser { get; set; }

        /// <summary>
        /// 回复的评论
        /// </summary>
        [ForeignKey("EvaluationOrderID")]
        public virtual EvaluationOrder EvaluationOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Replies
{
    public class RepliesModel
    {
        public DateTime? ReplyStart { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }

    }
}

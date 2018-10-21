using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EvaluationOrders
{
    public class EvaluationOrderModel
    {
        public float Star { get; set; } = 5;


        public string Content { get; set; }

        public DateTime? EvaluationStart { get; set; }

        public string Creator { get; set; }
    }
}

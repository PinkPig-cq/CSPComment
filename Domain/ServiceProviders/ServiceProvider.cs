using Domain.EvaluationOrders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.ServiceProviders
{
    [Table("ServiceProvider")]
    public class ServiceProvider:DomainBase
    { 
        public float Star { get; set; } = 0;

        [Required(ErrorMessage = "不能为空！")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string Image { get; set; }

        public virtual ICollection<EvaluationOrder> EvaluationOrderList { get; set; }
    }
}

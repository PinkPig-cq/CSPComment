using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ServiceProviders
{
    public class ServiceProviderModel
    {
        public int ID { get; set; }
        public float Star { get; set; } = 0;

        public string Name { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }
        public int EvaluationCount { get; set; } = 0;
    }
}

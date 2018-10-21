using Domain.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ServiceProviderService
{
    public interface IServiceProviderService:IService<ServiceProvider>
    {
        ServiceProvider GetStarScore(ServiceProvider entity);
    }
}

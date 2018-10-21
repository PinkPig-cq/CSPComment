using Domain.EvaluationOrders;
using Domain.Replies;
using Domain.ServiceProviders;
using Domain.SysUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<ServiceProvider> ServiceProvider { get; set; }
        public DbSet<EvaluationOrder> EvaluationOrder { get; set; }
        public DbSet<Reply> Reply { get; set; }
    }
}

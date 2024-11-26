using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public sealed class OrderHistoryEntityConfiguration : IEntityTypeConfiguration<OrdersHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<OrdersHistoryEntity> builder)
        {
            builder.ToTable("OrderHistory");

            //=====================Свойства====================
            builder
                .HasKey(o => o.Id);


            //===================Связи========================
            
        }
    }
}

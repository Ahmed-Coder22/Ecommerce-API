using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Entities.Order;

namespace Ecom.infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.OwnsOne(x => x.shippingAddress,
                n => { n.WithOwner(); });

            builder.HasMany(x => x.orderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Status).HasConversion(o => o.ToString(),
                o => (Status)Enum.Parse(typeof(Status), o));

            builder.Property(m => m.SubTotal).HasColumnType("decimal(18,2)");
        }
    }
}

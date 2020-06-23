using eccomerce_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eccomerce_webapi.ModelConfigs
{
    public class CustomerConfig : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.HasKey(b => b.Id).HasName("CustomerId");
            builder.Property(b => b.Name).HasMaxLength(500).IsRequired();
            builder.Property(b => b.email).HasMaxLength(500);
            builder.Property(b => b.password).HasMaxLength(500);
            builder.Property(b => b.gender).HasMaxLength(500);
            builder.Property(b => b.is_married).HasMaxLength(500);
            builder.Property(b => b.gender).HasMaxLength(500);
            builder.Property(b => b.address).HasMaxLength(500);
        }
    }
}

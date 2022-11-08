﻿using JewelryWorkshopOrders.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.EntityConfigurations
{
    internal class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .Property(x => x.CategoryName)
                .IsRequired();
        }
    }
}

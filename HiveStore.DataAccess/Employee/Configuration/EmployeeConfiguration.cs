using HiveStore.Entity.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DataAccess.Employee.Configuration
{
    public class EmployeeConfiguration<TEntity> : BasicEntityConfiguration, IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("Employee", "hive");
            builder.Property(p => p.Id).HasColumnName("EMPLOYEE_ID");
            builder.Property(p => p.FirstName).HasColumnName("FIRST_NAME").HasMaxLength(200).IsRequired();
            builder.Property(p => p.LastName).HasColumnName("LAST_NAME").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Address).HasColumnName("ADDRESS").HasMaxLength(200);
            builder.Property(p => p.City).HasColumnName("CITY").HasMaxLength(200);
            builder.Property(p => p.Country).HasColumnName("COUNTRY").HasMaxLength(200);
            ConfigureBase(builder);
        }
    }
}

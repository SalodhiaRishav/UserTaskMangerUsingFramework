using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;

namespace DAL.DatabaseConfigurations.EntityConfigurations
{
    class TaskCategoryEntityConfiguration : EntityTypeConfiguration<TaskCategory>
    {
        public TaskCategoryEntityConfiguration()
        {
            this.HasKey<int>(taskCategory => taskCategory.ID);

            this.HasIndex(taskCategory => taskCategory.CategoryName)
            .IsUnique();

            this.Property(taskCategory => taskCategory.CategoryName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

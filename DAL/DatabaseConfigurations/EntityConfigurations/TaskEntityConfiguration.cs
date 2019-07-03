using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Shared.DomainModels;

namespace DAL.DatabaseConfigurations.EntityConfigurations
{
    public class TaskEntityConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskEntityConfiguration()
        {
            this.HasKey<int>(task => task.ID);

            this.Property(task => task.TimeSpent)             
                .IsRequired();

            this.Property(task => task.ExpectedTime)
               .IsRequired();

            this.Property(task => task.UserStory)
                .HasMaxLength(200)
               .IsRequired();

            this.Property(task => task.TaskDate)
               .IsRequired()
               .HasColumnType("datetime2");

            this.HasRequired(task => task.TaskCategory)
                .WithMany()
                .HasForeignKey(task => task.TaskCategoryID);

        }
    }
}

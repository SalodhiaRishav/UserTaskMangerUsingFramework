using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using DAL.DatabaseConfigurations.EntityConfigurations;
using Shared.DomainModels;

namespace DAL.DatabaseConfigurations
{
    public class TaskManagerDBContext : DbContext
    {
        public TaskManagerDBContext() : base("TaskManagerDBConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new TaskEntityConfiguration());
            modelBuilder.Configurations.Add(new TaskCategoryEntityConfiguration());


        }
    }
}

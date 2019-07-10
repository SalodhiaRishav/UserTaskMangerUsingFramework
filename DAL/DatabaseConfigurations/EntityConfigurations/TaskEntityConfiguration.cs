namespace DAL.DatabaseConfigurations.EntityConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Shared.DomainModels;

    public class TaskEntityConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskEntityConfiguration()
        {
            this.HasKey<int>(task => task.Id);

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

            this.HasRequired<TaskCategory>(task => task.TaskCategory)
                .WithMany()
                .HasForeignKey(task => task.TaskCategoryId);
        }
    }
}

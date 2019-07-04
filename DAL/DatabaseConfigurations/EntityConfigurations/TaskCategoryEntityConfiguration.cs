namespace DAL.DatabaseConfigurations.EntityConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Shared.DomainModels;

    class TaskCategoryEntityConfiguration : EntityTypeConfiguration<TaskCategory>
    {
        public TaskCategoryEntityConfiguration()
        {
            this.HasKey<int>(taskCategory => taskCategory.Id);

            this.HasIndex(taskCategory => taskCategory.CategoryName)
            .IsUnique();

            this.Property(taskCategory => taskCategory.CategoryName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

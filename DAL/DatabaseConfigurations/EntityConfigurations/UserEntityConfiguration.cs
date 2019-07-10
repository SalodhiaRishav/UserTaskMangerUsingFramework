namespace DAL.DatabaseConfigurations.EntityConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Shared.DomainModels;

    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasKey<int>(user => user.Id);

            this.Property(user => user.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            this.Property(user => user.LastName)
               .HasMaxLength(20)
               .IsRequired();

            this.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.HasIndex(user => user.Email)
            .IsUnique();
            
            this.Property(user => user.Password)
              .HasMaxLength(20)
              .IsRequired();
        }
    }
}

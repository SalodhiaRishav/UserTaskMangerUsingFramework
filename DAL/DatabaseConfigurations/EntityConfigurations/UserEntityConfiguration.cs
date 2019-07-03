using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;

namespace DAL.DatabaseConfigurations.EntityConfigurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasKey<int>(user => user.ID);

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
        
            this.HasMany<Shared.DomainModels.Task>(user => user.Tasks)           
            .WithOptional()
            .HasForeignKey<int>(task => task.UserID);
        }
    }
}

using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
            (
             new Role
             {
                Id = 1,
                 Name = "Administrator",
                 NormalizedName = "ADMINISTRATOR"
             },
             new Role
             {
                 Id = 2,
                 Name = "Manager",
                 NormalizedName = "MANAGER"
             },
             new Role
             {
                 Id = 3,
                 Name = "Client",
                 NormalizedName = "CLIENT"
             });
        }
    }
}


 /* public class BankAccountsConfiguration : IEntityTypeConfiguration<BankAccounts>
{
    public void Configure(EntityTypeBuilder<BankAccounts> builder)
    {
        builder.Property(b => b.Balance).HasPrecision(18, 2);
    }
}
*/

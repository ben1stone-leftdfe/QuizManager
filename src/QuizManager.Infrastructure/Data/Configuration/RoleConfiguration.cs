using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = UserRole.Editor,
                    NormalizedName = UserRole.Editor.ToUpper()
                },
                new IdentityRole
                {
                    Name = UserRole.Viewer,
                    NormalizedName = UserRole.Viewer.ToUpper()
                },
                new IdentityRole
                {
                    Name = UserRole.Restricted,
                    NormalizedName = UserRole.Restricted.ToUpper()
                }
            ); 
        }
    }
}

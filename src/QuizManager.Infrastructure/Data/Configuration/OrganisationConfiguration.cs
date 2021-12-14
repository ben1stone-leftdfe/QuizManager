using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizManager.Core.Enitites;
using QuizManager.Shared.DevelopmentData;

namespace QuizManager.Infrastructure.Data.Configuration
{
    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasData(
                new Organisation
                {
                    Id = DevData.OrganisationId,
                    Name = DevData.OrganisationName
                });
        }
    }
}

using Letter.Business.Dtos.Get.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Letter.DataAccess.Configurations
{
    public class HomeConfiguration : IEntityTypeConfiguration<Home>
    {
        public void Configure(EntityTypeBuilder<Home> builder)
        {

            builder.HasOne(x => x.Status)
                .WithMany(x => x.Homes)
                .HasForeignKey(x => x.StatusId);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class DormitoryConfig : IEntityTypeConfiguration<Dormitory>
{
    public void Configure(EntityTypeBuilder<Dormitory> builder)
    {
        builder.ToTable("dormitory", opt => opt.HasComment("寝室管理")); // 配置表的名称
        // 配置表字段的属性
        builder.Property(dormitory => dormitory.Id).HasColumnName("id").HasComment("寝室Id，唯一");
        builder.Property(dormitory => dormitory.Name).HasColumnName("name").HasMaxLength(10).IsFixedLength()
            .HasComment("寝室名称").IsRequired();
        builder.Property(dormitory => dormitory.DormBuildId).HasColumnName("dormBuildId").HasComment("所属宿舍楼Id")
            .IsRequired();
    }
}